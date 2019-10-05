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
            QueryNetwork();            

            Console.ReadKey();
        }


        private static async void QueryNetwork()
        {
            int delay = 0;
            //Network network = new Network();

            PopulateNetwork(network);

            network.GetPage("Exiting News").AddVideo("https://www.youtube.com/watch?v=laPFq3Fhs8k&t=1766s", "Tim Corey is teaching WPF for us noobs");
            network.GetPage("SpacePage").AddEntry("Elon Musk announces BigFuckingRocket");                        
            await Task.Delay(delay);

            Person jakob = network.GetPerson("Jakob");
            Person jens = network.GetPerson("Jens");
            Person jonas = network.GetPerson("Jonas");
            Person stranger = network.GetPerson("Fremmed");

            jakob.AddFriend(jens);
            await Task.Delay(delay);

            jakob.AddLikedPage(network.GetPage("Exiting News"));
            await Task.Delay(delay);

            jakob.AddLikedPage(network.GetPage("SpacePage"));
            await Task.Delay(delay);

            jakob.AddVideo("https://www.youtube.com/watch?v=r1tdMPFK9MA", "Curious Marc er på spil igen");
            await Task.Delay(delay);

            jakob.AddEntry("Jeg spekulerer på om jeg kan sætte owner udfra kalder af metoden istedet for som parameter?");
            await Task.Delay(delay);

            jens.AddFriend(jonas);
            jens.AddLikedPage(network.GetPage("SpacePage")); 

            jonas.AddLikedPage(network.GetPage("Exiting News"));
            jonas.AddFriend(jakob);
            jonas.AddVideo("https://www.youtube.com/watch?v=sOpMrVnjYeY", "Starship Update");
            await Task.Delay(delay);


            network.GetPerson("Fremmed").AddEntry("I'm lost and confused");
            network.GetPerson("Jonas").AddFriend(network.GetPerson("Fremmed"));

            //network.PrintAllFriends();
            //network.PrintAllEntities();
            //network.PrintAllActivities();
            //jakob.PrintNewsFeed(); // PrintTimeline

            network.PrintPageFollowers("SpacePage");
        }

        public static void PopulateNetwork(Network network)
        {
            network.AddPage("Exiting News", new DateTime(2010, 4, 1));
            network.AddPage("FirstPage", new DateTime(2017, 1, 18));
            network.AddPage("SpacePage", new DateTime(2012, 8, 1));

            network.AddPerson("John Smith", new DateTime(1970, 1, 1));
            network.AddPerson("Will Smith", new DateTime(1972, 1, 30));
            network.AddPerson("Jakob", new DateTime(1970, 1, 8));
            network.AddPerson("Jens", new DateTime(1967, 1, 8));
            network.AddPerson("Jonas", new DateTime(2001, 1, 1));
            network.AddPerson("Fremmed", new DateTime(1970, 1, 1));
        }
    }
}
