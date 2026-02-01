using BAUERGROUP.Shared.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BAUERGROUP.Shared.Core.Files
{
    public class FileProcessing
    {
        public String JobDirectory { get; private set; }
        public String JobDirectory_Processed { get; private set; }
        public String JobDirectory_Unprocessed { get; private set; }

        public String JobFileFilter { get; private set; }

        public FileProcessing(String jobDirectory, String jobFileFilter)
        {
            if (jobDirectory == null)
                throw new FileProcessingException("FileProcessing() -> Argument jobDirectory cannot be NULL.", new ArgumentNullException("jobDirectory cannot be NULL."));

            if (jobFileFilter == null)
                throw new FileProcessingException("FileProcessing() -> Argument jobFileFilter cannot be NULL.", new ArgumentNullException("jobFileFilter cannot be NULL."));

            JobDirectory = jobDirectory;
            JobFileFilter = jobFileFilter;

            JobDirectory_Processed = Path.Combine(JobDirectory, @"Verarbeitet");
            JobDirectory_Unprocessed = Path.Combine(JobDirectory, @"Unverarbeitet");

            if (!Directory.Exists(JobDirectory))
                throw new FileProcessingException($"Folder '{JobDirectory}' does not exists.", new ArgumentException($"Folder '{JobDirectory}' does not exists."));

            if (!Directory.Exists(JobDirectory_Processed))
                Directory.CreateDirectory(JobDirectory_Processed);

            if (!Directory.Exists(JobDirectory_Unprocessed))
                Directory.CreateDirectory(JobDirectory_Unprocessed);
        }

        public String[] GetFiles()
        {
            if (!Directory.Exists(JobDirectory))
                throw new FileProcessingException($"Folder '{JobDirectory}' does not exists.");

            return Directory.GetFiles(JobDirectory, JobFileFilter, SearchOption.TopDirectoryOnly).OrderBy(p => new FileInfo(p).Name).ToArray();
        }

        public Int32 GetFilesCount()
        {
            return GetFiles().Length;
        }

        public void MoveFile(String file, FileProcessingStatus status = FileProcessingStatus.Processed, Boolean moveConnectedFiles = true)
        {
            var targetFolder = status == FileProcessingStatus.Processed ? JobDirectory_Processed : JobDirectory_Unprocessed;

            //Move primary File
            if (File.Exists(file))
                File.Move(file, Path.Combine(targetFolder, Path.GetFileName(GetTargetFilename(file))));

            //Move connected Files
            if (moveConnectedFiles)
            {
                var connectedFiles = Directory.GetFiles(JobDirectory, $"{Path.GetFileNameWithoutExtension(file)}.*", SearchOption.TopDirectoryOnly);
                foreach (var connectedFile in connectedFiles)
                    File.Move(connectedFile, Path.Combine(targetFolder, Path.GetFileName(GetTargetFilename(connectedFile))));
            }
        }

        private string GetTargetFilename(string sourceFilename)
        {
            var directory = Path.GetDirectoryName(sourceFilename) ?? string.Empty;
            return Path.Combine(directory, String.Format("[{0:yyyy-MM-dd HHmmss}] {1}", DateTime.Now, Path.GetFileName(sourceFilename)));
        }
    }
}
