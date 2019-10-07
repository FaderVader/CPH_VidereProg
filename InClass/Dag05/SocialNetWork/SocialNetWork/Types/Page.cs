using System;

namespace SocialNetWork.Types
{
    public class Page : Entity
    {
        public Page(string name, DateTime birthday) : base(name, birthday) { }

        virtual public void AddVideo(string url, string txt)
        {
            base.AddVideo(new Video(this, url, txt));
        }

        virtual public void AddEntry(string txt)
        {
            base.AddEntry(new Entry(this, txt));
        }
    }
}
