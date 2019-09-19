using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg03_FilSystem
{
    interface IMyFile
    {
        string FileName { get; set; }
        int FileSize { get; set; }

    }
    interface IDuration
    {
        TimeSpan Duration { get; set; }
    }

    interface IResolution
    {
        Resolution Resolution { get; set; }
    }
}
