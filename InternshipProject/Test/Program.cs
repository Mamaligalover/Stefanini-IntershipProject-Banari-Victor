using InternshipProject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var cooks = new List<Cook>()
            {
                new Cook()  { Name = "first", Numberdishes = 1,  Time=4 },
                new Cook()  { Name = "second", Numberdishes = 0, Time=0 },
                new Cook()  { Name = "third", Numberdishes = 2,  Time=2 },
                new Cook()  { Name = "fourth", Numberdishes = 0, Time=1 }

            };
            
            var cooks2 = new List<Cook>();
            Cook sortCook = new Cook();
            for (int i = 0; i < cooks.Count; i++)
            {
                cooks2.Add(cooks[i]);
            }

            cooks2.Sort(delegate (Cook x, Cook y) { return x.Time.CompareTo(y.Time);  });
           List<Cook> sorted = cooks.OrderBy(x => x.Time).ToList();
            foreach (var item in sorted)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Numberdishes);
                Console.WriteLine(item.Time);
            }


            
        }
    }
}
