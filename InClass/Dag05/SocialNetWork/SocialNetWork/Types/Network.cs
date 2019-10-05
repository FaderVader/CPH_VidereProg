using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetWork.Types
{
    public class Network 
    { 
        private List<Entity> entities; 

        public List<Entity> Entities
        {
            get { return entities;  }
            //set { entities = value; }
        }

        public Network()
        {
            entities = new List<Entity>();
        }


        public void AddPerson(Person person)
        {
            Entities.Add(person);
        }

        public void AddPage(Page page)
        {
            Entities.Add(page);
        }

        public void PrintAllEntities()
        {
            foreach(var entity in Entities)
            {
                string prefix = "";
                if (entity is Person)
                {
                    prefix = "Person";
                }

                if (entity is Page)
                {
                    prefix = "Page";
                }
                
                Console.WriteLine($"{prefix}:\t{entity.Name}:\t{entity.Birthday.ToString("MM/dd/yyyy")}");
            }
        }

        public void PrintAllFriends()
        {
            foreach (var entity in Entities)
            {
                if (entity is Person)
                {
                    Console.WriteLine($"{entity.Name}");

                    foreach (var relation in entity.Relations)
                    {
                            Console.WriteLine($"- {relation.Name}");
                    }
                }
            }
        }

        public void PrintAllActivities()
        {
            //Entities.ForEach(entity =>
            //{
            //    entity.PrintActivities();
            //});

            foreach(var entity in Entities)
            {
                entity.PrintActivities();
            }
        }
    }
}
