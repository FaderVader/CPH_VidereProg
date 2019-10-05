using SocialNetWork.Interfaces;
using SocialNetWork.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Types
{
    public abstract class Activity : IComparable<Activity>
    {
        private DateTime eventTime;
        private Entity owner;
        public DateTime EventTime { get { return eventTime; } }
        public Entity Owner { get { return owner; } }

     public Activity(Entity owner)
        {
            eventTime = DateTime.Now;
            this.owner = owner;
        }

        public abstract string GetText();

        public int CompareTo(Activity other)
        {
            if (this.EventTime > other.EventTime) {
                return -1;
            };
            return 0;
        }
    }

    public class FriendShip : Activity
    {        
        private Person friend;

        public FriendShip(Person owner, Person friend) : base(owner)
        {            
            this.friend = friend;
        }

        public override string GetText()
        {
            string description = $"{Owner.Name} - {EventTime}: {Owner.Name} is now friends with {friend.Name}";
            return description;
        }      
    }

    public class LikedPage : Activity
    {
        private Page page;        
        public LikedPage(Person owner, Page likedPage) : base(owner)
        {
            this.page = likedPage;
        }
        public override string GetText()
        {
            string description = $"{Owner.Name} - {EventTime}: {Owner.Name} started following {page.Name}";
            return description;
        }
    }

    public class Entry : Activity
    {
        private string entryText;

        public Entry(Entity owner, string entry) : base(owner)
        {
            this.entryText = entry;
        }
        public override string GetText()
        {
            string description = $"{Owner.Name} - {EventTime} Entry: {entryText}";
            return description;
        }
    }

    public class Video : Activity
    {
        private string address;

        private string text;        

        public Video(Entity owner, string address, string text) : base(owner)
        {
            this.address = address;
            this.text = text;
        }
        public override string GetText()
        {
            string description = $"{Owner.Name} - {EventTime} Video: {text} {address}";
            return description;
        }
    }


}
