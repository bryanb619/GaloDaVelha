using System;
using System.IO;


namespace ProjectGaloDaVelha.GameData.Enviroment
{

    public class FileDirectory
    {
        // Folder path to project directory
        private DirectoryInfo dir = Directory.CreateDirectory
        (Environment.CurrentDirectory);


        // Automatic property
        public DirectoryInfo GetDir
        {
            get => dir;
            set => dir = value;
        }
    }
}