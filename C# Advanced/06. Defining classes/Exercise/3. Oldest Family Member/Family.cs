using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            Peoples=new List<Person>();
        }
        private List<Person> peoples;

        public List<Person> Peoples
        {
            get { return peoples; }
            set { peoples = value; }
        }

        public void AddMember(Person member)
        {
            Peoples.Add(member);
        }
        public Person GetOldestMember() => Peoples.OrderByDescending(x => x.Age).FirstOrDefault();
    }
}
