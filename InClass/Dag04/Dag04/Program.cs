using System;
using System.Collections.Generic;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            Folder folder = new Folder();
            folder.Files = PopulateList();

            //List<IMyFile> fileList = PopulateList();

            Console.WriteLine($"Combined size: {CombinedSize(folder.Files)}");
            Console.WriteLine($"Combined duration: {CombinedDuration(folder.Files)}");

            Console.ReadKey();
        }


        public static TimeSpan CombinedDuration(List<MyFile> fileList)
        {
            TimeSpan combinedDuration = new TimeSpan();
            foreach (var file in fileList)
            {
                IDuration duration = file as IDuration;
                
                if (duration != null) 
                {                   
                    combinedDuration += duration.Duration;                            
                }
            }
            return combinedDuration;
        }

        public static int CombinedSize(List<MyFile> fileList)
        {
            int combinedSize = 0;
            foreach (var file in fileList)
            {
                Console.WriteLine($"FileName: {file.FileName}, size: {file.FileSize}");
                combinedSize += file.FileSize;
            }            
            return combinedSize;
        }

        public static List<MyFile> PopulateList()
        {
            List<MyFile> fileList = new List<MyFile>
            {
                new Video() { FileName = "Video1", FileSize=200, Duration= new TimeSpan(0, 10, 0)},
                new Image() { FileName = "Image1", FileSize=10, Resolution = new Resolution() { sizeX = 100, sizeY = 100} },
                new Audio() { FileName = "Audio1", FileSize=50, Duration = new TimeSpan(0, 5, 0)}
            };
            return fileList;
        }
    }
}
