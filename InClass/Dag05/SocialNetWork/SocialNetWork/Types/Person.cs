using System;
using System.Collections.Generic;

namespace SocialNetWork.Types
{
    public class Person : Entity
    {
        public Person(string name, DateTime birthday) : base(name, birthday) { }

        public void AddFriend(Person friend)
        {
            AddRelation(friend);
            friend.AddRelation(this);

            AddActivity(new FriendShip(this, friend));
            friend.AddActivity(new FriendShip(friend, this));
        }

        public void AddLikedPage(Page page)
        {
            AddRelation(page);
            AddActivity(new LikedPage(this, page));
        }

        virtual public void AddVideo(string url, string txt)
        {
            base.AddVideo(new Video(this, url, txt));
        }

        virtual public void AddEntry(string txt)
        {
            base.AddEntry(new Entry(this, txt));
        }

        public void PrintTimeline()
        {
            this.PrintActivities();
        }

        public void PrintNewsFeed()
        {
            List<Activity> localList = new List<Activity>(Activities);

            foreach (var relation in Relations)
            {
                foreach (var activity in relation.Activities)
                {
                    localList.Add(activity);
                }
            }

            localList.Sort();

            localList.ForEach(item => {
                Console.WriteLine(item.GetText());
            });

        }       
    }
}
