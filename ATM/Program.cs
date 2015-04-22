using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            CassetteLoader loader = new CassetteLoader();
            
            loader.LoadCassettes("money.txt");

            //for (int i = 0; i < loader.Cassettes.Banknotes.Count(); i++)
            //{
            //    Console.WriteLine(loader.Cassettes.Banknotes.ElementAt(i));
            //}
            Console.WriteLine("Input sum that you want to get: ");
            int sum = int.Parse(Console.ReadLine());
            WithdrawMoneyAlgorithm algorithm = new WithdrawMoneyAlgorithm();
            Atm bankomat = new Atm(algorithm);
            Money result = algorithm.Algorithm(sum, loader.Cassettes);
            if(result != null)
            foreach (KeyValuePair<Banknote, int> a in result.Banknotes)
            {
                if(a.Value != 0)
                Console.WriteLine(a.Key.Nominal + " " + a.Value);
            }
            Console.WriteLine(algorithm.state.ToString());
            bankomat.UpdateMoney(loader.Cassettes);
            foreach (KeyValuePair<Banknote, int> a in loader.Cassettes.Banknotes)
            {
                Console.WriteLine(a.Key.Nominal + " " + a.Value);
            }

            Console.ReadKey();
        }
    }
}
