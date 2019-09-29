using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemObject
{
    class Program
    {
        static FileSystem fs;
        static void Main(string[] args)
        {
            PopulateFS();
        }

        static void PopulateFS()
        {
            fs = new FileSystem();
            Folder root = fs.GetRoot();

            root.AddItem(new Audio("audio1", 200 ,new TimeSpan(0, 10, 0)));
            root.AddItem(new Audio("audio2", 400, new TimeSpan(0, 20, 0)));

            root.AddItem(new Folder("Video"));
            var video = fs.GetFolderByName("Video");
            video.AddItem(new Video("Video1", 20000, new TimeSpan(0,10,0), new Resolution(160, 90)));
            video.AddItem(new Video("Video2", 40000, new TimeSpan(0, 30, 0), new Resolution(160, 90)));

            root.AddItem(new Folder("Audio"));
            var audio = fs.GetFolderByName("Audio");
            audio.AddItem(new Audio("Audio3", 1000, new TimeSpan(0, 15, 0)));
            audio.AddItem(new Audio("Audio4", 2000, new TimeSpan(0, 30, 0)));

            root.AddItem(new Folder("Image"));
            var image = fs.GetFolderByName("Image");
            image.AddItem(new Image("Image1", 13542, new Resolution(2000, 2000)));
            image.AddItem(new Image("Image2", 43342, new Resolution(3000, 3000)));

            image.AddItem(new Folder("ImageSubfolder"));
            var imageSubfolder = fs.GetFolderByName("ImageSubfolder");
            imageSubfolder.AddItem(new Image("SpecialImage1", 1042, new Resolution(200, 300)));
            imageSubfolder.AddItem(new Image("SpecialImage2", 1642, new Resolution(200, 360)));

            fs.PrintFiles();            
            Console.WriteLine($"Total file-size is {fs.GetTotalSize()}");

            Console.ReadKey();
        }
    }
}
