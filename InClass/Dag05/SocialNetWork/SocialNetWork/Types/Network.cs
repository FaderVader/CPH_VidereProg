﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetWork.Types
{
    public class Network
    {
        private List<Entity> entities;

        public List<Entity> Entities
        {
            get { return entities; }
        }

        public Network()
        {
            entities = new List<Entity>();
        }

        public void AddPerson(string name, DateTime dateTime)
        {
            Person person = new Person(name, dateTime);
            entities.Add(person);
        }

        public void AddPage(string name, DateTime dateTime)
        {
            Page page = new Page(name, dateTime);
            entities.Add(page);
        }

        public Entity GetEntity(string searchName)
        {
            return entities.Where(entity => entity.Name == searchName).FirstOrDefault();
        }

        public Person GetPerson(string searchName)
        {
            return entities.Where(entity => entity.Name == searchName).FirstOrDefault() as Person;
        }

        public Page GetPage(string searchName)
        {
            return entities.Where(entity => entity.Name == searchName).FirstOrDefault() as Page;
        }

        /// <summary>
        /// Iterate over all entities - if person, check if Page is listed in Relations, if yes, then add person to output-list
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        public List<Person> GetPageFollowers(string searchName)
        {
            Page page = GetPage(searchName);
            List<Person> hitList = new List<Person>();

            // brick-by-brick
            var result1 = entities.Where(entity => entity is Person).ToList();
            var result2 = result1.Where(person => person.Relations.Count > 0).ToList(); ;
            List<Person> result3 = result2.Where(person => person.Relations.Contains(page)).Cast<Person>().ToList();
            
            // one-liner
            hitList = entities
                //.Where(entity => entity is Person)
                .Where(person => person.Relations.Contains(page))
                .Cast<Person>()
                .ToList();

            //foreach (var entity in entities)
            //{
            //    if (entity is Person)
            //    {
            //        List<Entity> list = entity.Relations;
            //        foreach (var relation in entity.Relations)
            //        {
            //            if ((relation is Page) && (relation.Name == page.Name))
            //            {
            //                {
            //                    hitList.Add(entity as Person);
            //                }
            //            }
            //        }
            //    }
            //}

            return hitList;
        }

        public void PrintPageFollowers(string searchName)
        {
            List<Person> hitList = GetPageFollowers(searchName);

            hitList.ForEach(hit =>
            {
                Console.WriteLine(hit.Name);
            });
        }

        public void PrintAllEntities()
        {
            foreach (var entity in entities)
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
            foreach (var entity in entities)
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
            foreach (var entity in entities)
            {
                entity.PrintActivities();
            }
        }
    }
}
