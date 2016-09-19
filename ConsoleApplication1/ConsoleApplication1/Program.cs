using BND.Services.IbanStore.Proxy.NET4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test");
            IbanResource a = new IbanResource("","");
            Console.ReadKey();
            Console.WriteLine(a.GetType());
        }
    }
}
