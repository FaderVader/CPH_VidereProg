using System;
using System.Collections.Generic;

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

        protected void AddRelation(Entity entity)
        {
            Relations.Add(entity);
        }

        protected void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void AddEntry(Entry entry)
        {
            AddActivity(entry);
        }

        public void AddVideo(Video video)
        {
            AddActivity(video);
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
