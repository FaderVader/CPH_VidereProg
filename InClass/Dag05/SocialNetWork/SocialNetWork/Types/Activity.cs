using SocialNetWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Types
{
    public abstract class Activity //: IActivity
    {
        public DateTime EventTime { get; set; }

        public Activity()
        {
            EventTime = DateTime.Now;
        }

        public List<Activity> Events { get; set; } // private list ?

        // method for adding events
    }

    public class FriendShip : Activity
    {
        // track new friendships between 2 persons
    }

    public class Following : Activity
    {
        // track when person follows page
    }
}
