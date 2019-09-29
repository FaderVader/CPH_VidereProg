using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemObject
{
    interface IDuration
    {
        TimeSpan Duration { get; set; }
    }

    interface IResolution
    {
        Resolution Resolution { get; set; }
    }
}
