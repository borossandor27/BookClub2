using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub_desktop_cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Statisztika stat = new Statisztika();
            stat.feladat01();
            stat.feladat02();
            stat.feladat03();
            stat.feladat04();
            stat.feladat05();
            Console.WriteLine("\nProgram vége!");
            Console.ReadLine();
        }
    }
}
