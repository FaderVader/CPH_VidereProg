using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemObject
{
    public abstract class FSObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public abstract int GetSize();
    }

    public class Folder : FSObject
    {
        public List<Folder> SubFolders { get; set; }
        public List<File> Files { get; set; }

        public void AddItem(Folder folder)
        {
            SubFolders.Add(folder);
        }

        public void AddItem(File file)
        {
            Files.Add(file);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)SubFolders).GetEnumerator();
        }

        public Folder(string folderName)
        {
            this.Name = folderName;
            SubFolders = new List<Folder>();
            Files = new List<File>();
        }

        public override int GetSize()
        {
            int totalSize = 0;

            foreach (var file in Files)
            {
                totalSize += file.GetSize();
            }
            return totalSize;
        }
    }

    public class File : FSObject
    {
        public int FileSize { get; set; }

        public File(string fileName, int fileSize)
        {
            this.Name = fileName;
            this.FileSize = fileSize;
        }

        public override int GetSize()
        {
            return FileSize;
        }
    }

    public class Video : File, IDuration, IResolution
    {
        public TimeSpan Duration { get; set; }
        public Resolution Resolution { get; set; }

        public Video(string fileName, int fileSize, TimeSpan duration, Resolution resolution) : base(fileName, fileSize)
        {
            this.Name = fileName;
            this.FileSize = fileSize;
            this.Duration = duration;
            this.Resolution = resolution;
        }
    }

    public class Image : File, IResolution
    {
        public Resolution Resolution { get; set; }
        public Image(string fileName, int fileSize, Resolution resolution) : base(fileName, fileSize)
        {
            this.Name = fileName;
            this.FileSize = fileSize;
            this.Resolution = resolution;
        }
    }

    public class Audio : File, IDuration
    {
        public Audio(string fileName, int fileSize, TimeSpan duration) : base(fileName, fileSize)
        {
            this.Name = fileName;
            this.FileSize = fileSize;
            this.Duration = duration;
        }

        public TimeSpan Duration { get; set; }
    }

    public class Resolution
    {
        public int sizeX;
        public int sizeY;

        public Resolution(int x, int y)
        {
            this.sizeX = x;
            this.sizeY = y;
        }
    }

}
