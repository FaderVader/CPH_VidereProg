using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Interfaces
{
    public interface IActivity
    {
        DateTime EventTime { get; }

        ActivityTypes Activity { get; }
    }

    public enum ActivityTypes
    {
        Following,
        Friendship
    }
}
