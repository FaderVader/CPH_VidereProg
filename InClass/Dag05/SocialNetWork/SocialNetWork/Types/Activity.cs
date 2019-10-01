using SocialNetWork.Interfaces;
using SocialNetWork.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Types
{
    public class Event : Activity
    {
        public Event()
        {
            EventTime = DateTime.Now;
        }
    }

    public abstract class Activity
    {
        public DateTime EventTime { get; set; }

        //public List<Activity> Events { get; set; } // private list ?

        public void AddEvent(Activity activity)
        {
            //Events.Add(activity);
        }
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
