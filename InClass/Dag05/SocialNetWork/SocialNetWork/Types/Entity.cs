using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Types
{
    public abstract class Entity
    {
        // navn og fødselsdag
        private string name;
        private DateTime birthday;

        public string Name { get { return name; } } 
        public DateTime Birthday { get { return birthday; } } 

        public List<Entity> Relations { get; } // set
        public List<Activity> Activities { get; }

        public Entity(string name, DateTime birthday)
        {
            this.name = name;
            this.birthday = birthday;

            Relations = new List<Entity>();
            Activities = new List<Activity>();
        }

        public void AddRelation(Entity entity)
        {
            Relations.Add(entity);
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void PrintActivities()
        {
            Activities.ForEach(activity =>
            {
                Console.WriteLine(activity.GetText());
            });
        }
    }
}
