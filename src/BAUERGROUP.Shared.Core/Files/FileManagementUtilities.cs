using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BAUERGROUP.Shared.Core.Files
{
    public static class FileManagementUtilities
    {
        public static void MoveDirectoryContents(String sourceDirectory, String destinationDirectory)
        {
            Directory.Move(sourceDirectory, destinationDirectory);
        }

        public static void CopyDirectoryContents(String sourceDirectory, String destinationDirectory)
        {
            if (sourceDirectory == destinationDirectory)
                throw new ArgumentException("Source and destination cannot be the same directory.");

            foreach (var path in Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(path.Replace(sourceDirectory, destinationDirectory));

            foreach (var path in Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories))
                File.Copy(path, path.Replace(sourceDirectory, destinationDirectory), true);
        }
    }
}
