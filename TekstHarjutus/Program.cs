using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TekstHarjutus
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText(@"../../tekst.txt");

            var SõnuKokku = (from täht in data.Split()
                         select täht).Count();

            Console.WriteLine("Kokku on : {0} sõnu ", SõnuKokku);
            Console.WriteLine("");

            

            int EriTähed = (from täht in data.Distinct()
                     where täht != ' '
                     select täht).Count();

            Console.WriteLine("Tekstis on {0} erinevat tähte", EriTähed);
            Console.WriteLine("");


            var EriTähtedeKordus = File.ReadAllText(@"../../tekst.txt")
                .Where(c => Char.IsLetter(c))
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (KeyValuePair<char, int> Tähekordus in EriTähtedeKordus)
            {
                Console.WriteLine("{1} korda esineb tekstis täht : {0}", Tähekordus.Key, Tähekordus.Value);
            }
   
            
            Console.ReadLine();
        }
    }
}
