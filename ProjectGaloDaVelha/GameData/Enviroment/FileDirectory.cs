using System;
using System.IO;


namespace ProjectGaloDaVelha.GameData.Enviroment
{

    public class FileDirectory
    {
        // Folder path to project directory
        private DirectoryInfo info = Directory.CreateDirectory
        (Environment.CurrentDirectory);


        // Automatic property
        public DirectoryInfo Info
        {
            get => info;
            set => info = value;
        }
    }
}