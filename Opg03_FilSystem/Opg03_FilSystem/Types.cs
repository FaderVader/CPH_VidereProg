using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg03_FilSystem
{
    public class MyFile
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
}
