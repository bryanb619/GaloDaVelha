using System;
using System.IO;


namespace ProjectGaloDaVelha.GameData.Enviroment
{

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