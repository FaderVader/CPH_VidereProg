using SocialNetWork.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork
{
    class Program
    {
        private static Network network = new Network();
        static void Main(string[] args)
        {
            PopulateNetWork();
            //network.PrintAllEntities();

            network.PrintAllFriends();

            Console.ReadKey();
        }

        private static void PopulateNetWork()
        {
            network.AddPage(new Page("FirstPage", new DateTime(2017, 1, 18)));
            network.AddPerson(new Person("John Smith", new DateTime(1970, 1, 1)));
            network.AddPerson(new Person("Will Smith", new DateTime(1972, 1, 30)));

            Person jakob = new Person("Jakob", new DateTime(1970, 1, 8));
            Person jens = new Person("Jens", new DateTime(1967, 1, 8));
            network.AddPerson(jakob);
            network.AddPerson(jens);
            jakob.AddFriend(jens);

            Page exiting = new Page("Exiting News", new DateTime(2010, 4, 1));
            network.AddPage(exiting);

            jakob.AddLikedPage(exiting);
        }
    }
}
