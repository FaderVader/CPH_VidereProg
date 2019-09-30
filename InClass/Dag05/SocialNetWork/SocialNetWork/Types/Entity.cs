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
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public List<Entity> Relations { get; set; }

        public Entity(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;

            Relations = new List<Entity>();
        }
    }
}
