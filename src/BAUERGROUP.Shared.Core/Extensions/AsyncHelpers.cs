using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAUERGROUP.Shared.Core.Extensions
{
    public static class AsyncHelpers
    {
        /// <summary>
        /// Execute's an async Task method which has a void return value synchronously.
        /// </summary>
        /// <param name="task">Task method to execute.</param>
        public static void RunSync(Func<Task> task)
        {
            var existingContext = SynchronizationContext.Current;
            var exclusiveSynchronisation = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(exclusiveSynchronisation);

            exclusiveSynchronisation.Post(async _ =>
            {
                try
                {
                    await task();
                }
                catch (Exception e)
                {
                    exclusiveSynchronisation.InnerException = e;
                    throw;
                }
                finally
                {
                    exclusiveSynchronisation.EndMessageLoop();
                }
            }, null);

            exclusiveSynchronisation.BeginMessageLoop();

            SynchronizationContext.SetSynchronizationContext(existingContext);
        }

        /// <summary>
        /// Execute's an async Task method which has a T return type synchronously.
        /// </summary>
        /// <typeparam name="T">Return Type.</typeparam>
        /// <param name="task">Task method to execute.</param>
        /// <returns>The result of the task.</returns>
        public static T? RunSync<T>(Func<Task<T>> task)
        {
            var existingContext = SynchronizationContext.Current;
            var exclusiveSynchronisation = new ExclusiveSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(exclusiveSynchronisation);

            T? returnValue = default;
            exclusiveSynchronisation.Post(async _ =>
            {
                try
                {
                    returnValue = await task();
                }
                catch (Exception e)
                {
                    exclusiveSynchronisation.InnerException = e;
                    throw;
                }
                finally
                {
                    exclusiveSynchronisation.EndMessageLoop();
                }
            }, null);

            exclusiveSynchronisation.BeginMessageLoop();

            SynchronizationContext.SetSynchronizationContext(existingContext);

            return returnValue;
        }

        private class ExclusiveSynchronizationContext : SynchronizationContext
        {
            private Boolean completed;
            public Exception? InnerException { get; set; }
            readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);
            readonly Queue<Tuple<SendOrPostCallback, object?>> items = new Queue<Tuple<SendOrPostCallback, object?>>();

            public override void Send(SendOrPostCallback postCallback, Object? state)
            {
                throw new NotSupportedException("Unable to send on same Thread.");
            }

            public override void Post(SendOrPostCallback postCallback, Object? state)
            {
                lock (items)
                {
                    items.Enqueue(Tuple.Create(postCallback, state));
                }

                workItemsWaiting.Set();
            }

            public void EndMessageLoop()
            {
                Post(_ => completed = true, null);
            }

            public void BeginMessageLoop()
            {
                while (!completed)
                {
                    Tuple<SendOrPostCallback, object?>? currentTask = null;

                    lock (items)
                    {
                        if (items.Count > 0)
                        {
                            currentTask = items.Dequeue();
                        }
                    }

                    if (currentTask != null)
                    {
                        currentTask.Item1(currentTask.Item2);

                        if (InnerException != null)
                        {
                            throw new AggregateException("AsyncHelpers.Run Method Exception.", InnerException);
                        }
                    }
                    else
                    {
                        workItemsWaiting.WaitOne();
                    }
                }
            }

            public override SynchronizationContext CreateCopy()
            {
                return this;
            }
        }
    }
}
