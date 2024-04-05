using System;
using System.IO;    // File Reading


namespace ProjectGaloDaVelha.GameData.Enviroment
{
    /// <summary>
    /// Represents the directory of the solution or project depending on how 
    /// is run (VS or VSCode|Terminal from project directory or soluntion 
    /// directory).
    /// </summary>
    public class FileDirectory
    {
        // Folder path to project directory
        private DirectoryInfo dir = Directory.CreateDirectory
        (Environment.CurrentDirectory);

        /// <summary>
        /// Getter for Directory Path
        /// Function returns solution directory path
        /// </summary>
        /// <returns>returns directory path</returns>
        public DirectoryInfo GetDir()
        {
            // directory path
            return dir;
        }
    }
}