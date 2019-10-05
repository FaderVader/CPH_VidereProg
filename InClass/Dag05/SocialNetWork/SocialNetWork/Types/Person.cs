using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Types
{
    public class Person : Entity
    {
        public Person(string name, DateTime birthday) : base(name, birthday) { }        

        public void AddFriend(Person friend)
        {
            // add relation to both parties
            AddRelation(friend);
            friend.AddRelation(this);

            // add activity to both
            AddActivity(new FriendShip(this, friend));
            friend.AddActivity(new FriendShip(friend, this));
        }

        public void AddLikedPage(Page page)
        {
            AddRelation(page);
            AddActivity(new LikedPage(this, page));
        }
    }
}
