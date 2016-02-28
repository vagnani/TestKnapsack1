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
            Console.Write("Risoluzione problema knapsack");
            Console.WriteLine("inserire elementi con il seguente formalismo");
            Console.WriteLine("(nome,valore,peso) <==le parentesi obbligatorie");            
            Knapsack bag = new Knapsack(Console.ReadLine());
            Console.WriteLine();

            bool isStop = false;
            do
            {
                Console.WriteLine("Numero di elementi della lista finale");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Peso massimo");
                int maxWeight = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine(bag.TheHighest(number: number, maxWeight: maxWeight));
                Console.ReadKey();

                Console.WriteLine("Vuoi trovare un'altra lista, si o no?");
                if (Console.ReadLine() == "no")
                    isStop = true;                
            } while (!isStop);
        }
    }
}
