using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    public class MyFile : IMyFile
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
    }

    public class Video : MyFile, IDuration, IResolution
    {
        public TimeSpan Duration { get; set; }
        public Resolution Resolution { get; set; }
    }


    public class Image : MyFile, IResolution
    {
        public Resolution Resolution { get; set; }
    }

    public class Audio : MyFile, IDuration
    {
        public TimeSpan Duration { get; set; }
    }

    public class Resolution
    {
        public int sizeX;
        public int sizeY;
    }

    public class Folder
    {
        public string FolderName { get; set; }
        public List<Folder> Folders { get; set; }
        public List<MyFile> Files { get; set; }

        public int GetFolderSize()
        {
            int folderSize = 0;

            foreach (var folder in Folders)
            {
                foreach (var file in folder.Files)
                {
                    folderSize += file.FileSize;
                }
            }
            return folderSize;
        }
    }
}
