using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg03_FilSystem
{
    class Program
    {
        static List<MyFile> fileList;
        static void Main(string[] args)
        {
            PopulateList();
            IterateList();
        }


        static void PopulateList()
        {
            fileList = new List<MyFile>
            {
                new Video() { FileName = "Video1", FileSize=200, Duration= new TimeSpan(0, 10, 0)},
                new Image() { FileName = "Image1", FileSize=10, Resolution = new Resolution() { sizeX = 100, sizeY = 100} },
                new Audio() { FileName = "Audio1", FileSize=50, Duration = new TimeSpan(0, 5, 0)}
            };

            //IMyFile video = new Video { FileName = "Video1", FileSize = 200, Duration = new TimeSpan(0, 10, 0) };
            //IMyFile image = new Image { FileName = "Image1", FileSize = 10, Resolution = new Resolution() { sizeX = 100, sizeY = 100 } };
            //IMyFile audio = new Audio { FileName = "Audio1", FileSize = 50, Duration = new TimeSpan(0, 5, 0) };
            //fileList = new List<IMyFile>() { audio, image, audio };
        }

        static void IterateList()
        {
            TimeSpan combinedDuration = new TimeSpan();
            int combinedSize = 0;

            foreach (var file in fileList)
            {
                Console.WriteLine($"FileName: {file.FileName}, size: {file.FileSize}");
            
                combinedSize += file.FileSize;

                var myType = file.GetType();
                if (file.GetType().GetProperty("Duration") != null)
                {
                    dynamic changedObj = Convert.ChangeType(file, myType);
                    combinedDuration = combinedDuration.Add(changedObj.Duration);
                }
            }

            Console.WriteLine($"Combined file-size: {combinedSize}, combined duration: {combinedDuration}");            
            Console.ReadKey();
        }
    }
}
