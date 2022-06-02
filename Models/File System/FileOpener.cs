using System.Diagnostics;
using System.IO;

namespace RedRatShortcuts.Models.FileSystem
{
    /// <summary>
    /// Opens programs/files under specific paths.
    /// </summary>
    public static class FileOpener
    {
        public static event Action<string>? OnErrorPathNotExist;

        /// <summary>
        /// Open a file or a directory under a specific path.
        /// </summary>
        /// <param name="path">The of the file/Directory.</param>
        public static void Open(string path)
        {
            if (IsDirectory(path)) 
                TryOpenDirectory(path);
            else TryOpenFile(path);
        }

        /// <summary>
        /// Checks if a given path is a directory or a file.
        /// </summary>
        /// <param name="path">The path to check.</param>
        /// <returns>TRUE if path is directory, otherwise is a file.</returns>
        private static bool IsDirectory(string path)
        {
            FileAttributes attributes = File.GetAttributes(path);
            return attributes.HasFlag(FileAttributes.Directory);
        }

        /// <summary>
        /// Tries to open a directory under specific path.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        private static void TryOpenDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                OnErrorPathNotExist?.Invoke($"The directory '{path}' does not exist.");
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Arguments = path;
            startInfo.FileName = "explorer.exe";
            Process.Start(startInfo);
        }
        
        /// <summary>
        /// Tries to open a file under specific path.
        /// </summary>
        /// <param name="path">The path of the directory.</param>
        private static void TryOpenFile(string path)
        {
            if (!File.Exists(path))
            {
                OnErrorPathNotExist?.Invoke($"The file '{path}' does not exist.");
                return;
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Arguments = path;
            startInfo.FileName = "explorer";
            Process.Start(startInfo);
        }
    }
}