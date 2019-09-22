using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg03_FilSystem
{
    /// <summary>
    /// TO DO: Must fix the classes so they have a common method for returning their properties
    /// Tim Corey: https://youtu.be/A7qwuFnyIpM?t=1192
    /// </summary>
    /// 
    /// experiments
    /// var myType = file.GetType().FullName;
    /// if (myType == "Opg03_FilSystem.Video")
    /// dynamic changedObj = Convert.ChangeType(file, myType);
    /// combinedDuration = combinedDuration.Add(changedObj.Duration);

    class Program
    {
        static void Main(string[] args)
        {
            List<IMyFile> fileList = PopulateList();

            CombinedDuration(fileList);
            CombinedSize(fileList);
            Console.ReadKey();
        }


        public static TimeSpan CombinedDuration(List<IMyFile> fileList)
        {
            TimeSpan combinedDuration = new TimeSpan();
            foreach (var file in fileList)
            {
                if (file.GetType().GetProperty("Duration") != null)
                {
                    combinedDuration += ((IDuration)file).Duration;
                }
            }
            Console.WriteLine($"Combined duration: {combinedDuration}");
            return combinedDuration;
        }

        public static int CombinedSize(List<IMyFile> fileList)
        {
            int combinedSize = 0;
            foreach (var file in fileList)
            {
                Console.WriteLine($"FileName: {file.FileName}, size: {file.FileSize}");
                combinedSize += file.FileSize;
            }
            Console.WriteLine($"Combined size: {combinedSize}");
            return combinedSize;
        }

        public static List<IMyFile> PopulateList()
        {
            List<IMyFile> fileList = new List<IMyFile>
            {
                new Video() { FileName = "Video1", FileSize=200, Duration= new TimeSpan(0, 10, 0)},
                new Image() { FileName = "Image1", FileSize=10, Resolution = new Resolution() { sizeX = 100, sizeY = 100} },
                new Audio() { FileName = "Audio1", FileSize=50, Duration = new TimeSpan(0, 5, 0)}
            };
            return fileList;
        }
    }
}
