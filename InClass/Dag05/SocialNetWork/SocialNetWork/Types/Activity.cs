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
        private Person owner;
        public DateTime EventTime { get { return eventTime; } }
        public Person Owner { get { return owner; } }

     public Activity(Person owner)
        {
            eventTime = DateTime.Now;
            this.owner = owner;
        }

        public abstract string GetText();
    }

    public class FriendShip : Activity
    {        
        private Person friend;

        public FriendShip(Person owner, Person b) : base(owner)
        {            
            this.friend = b;
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


}
