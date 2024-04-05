using System;
using System.IO;


namespace ProjectGaloDaVelha.GameData.Enviroment
{
    /// <summary>
    ///  Represents the directory of the solution
    /// </summary>
    public class FileDirectory
    {
        // Folder path to project directory
        private DirectoryInfo dir = Directory.CreateDirectory
        (Environment.CurrentDirectory);

 
        public DirectoryInfo GetDir()
        {
            return dir;
        }
    }
}