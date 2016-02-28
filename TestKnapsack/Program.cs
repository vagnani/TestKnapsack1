using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Collections;

namespace TestKnapsack
{
    class Program
    {
        static void Main()
        {
            List<Element> elements = new List<Element>()
            {
                new Element("n1",50,40),
                new Element("n2",55,50),
                new Element("n3",10,35),
                new Element("n4",40,10),
                new Element("n5",50,40),
            };

            Knapsack bag = new Knapsack(elements);

            Console.WriteLine(bag.TheHighest(2, 80));
            Console.ReadKey();
        }
    }
}
