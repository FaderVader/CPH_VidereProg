using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Types
{
    public class Person : Entity
    {
        public Person(string name, DateTime birthday) : base(name, birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public void AddFriend(Person friend)
        {
            Relations.Add(friend);
            friend.Relations.Add(this);
        }

        public void AddLikedPage(Page page)
        {
            Relations.Add(page);
        }
    }
}
