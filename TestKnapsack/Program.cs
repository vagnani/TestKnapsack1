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
            Console.WriteLine("Risoluzione problema knapsack");
            Console.WriteLine("Inserire elementi con il seguente formalismo");
            Console.WriteLine("(nome,valore,peso) <==le parentesi obbligatorie");            
            Knapsack bag = new Knapsack(Console.ReadLine());            
            
            do
            {
                Console.WriteLine();
                Console.Write("Numero di elementi della lista finale: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.Write("Peso massimo: ");
                int maxWeight = Convert.ToInt32(Console.ReadLine());                
                Console.WriteLine(bag.TheHighest(number: number, maxWeight: maxWeight));                
                Console.WriteLine();

                Console.WriteLine("Vuoi ripetere, si o no?");
                if (Console.ReadLine() == "no")
                    break;             
            } while (true);
        }
    }
}
