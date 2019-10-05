using SocialNetWork.Interfaces;
using SocialNetWork.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Types
{
    public abstract class Activity
    {
        private DateTime eventTime;
        private ActivityTypes eventType;

        public DateTime EventTime { get { return eventTime; } }

        public ActivityTypes Event { get { return eventType; } }

        public Activity(ActivityTypes activity)
        {
            SetActivity(activity);
        }

        public void SetActivity(ActivityTypes activity)
        {
            eventType = activity;
            eventTime = DateTime.Now;
        }
    }

    public class SocialEvent : Activity
    {
        public SocialEvent(ActivityTypes activity)  : base(activity)
        {
            SetActivity(activity);
        }
    }


    public class Activities
    {
        private List<Activity> activities;

        public Activities(List<Activity> activities)
        {
            this.activities = activities;
        }

        public void AddEvent(Activity activity)
        {
            //var newActivity = new Activity();
            activities.Add(activity);
        }
    }




    //public class FriendShip : Activity
    //{
    //    // track new friendships between 2 persons
    //    public FriendShip(Person listOwner, Person newFriend, ActivityTypes activity) : base(activity)
    //    {
    //        // add both persons to eachothers list of relations
    //    }
    //}

    //public class Following : Activity
    //{
    //    // track when person follows page
    //    public Following(Person listOwner, Page likedPage)
    //    {
    //        // add page to listOwners list of relations
    //    }
    //}



}
