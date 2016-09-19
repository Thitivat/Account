using BND.Services.IbanStore.Proxy.NET4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDependencieLek
{
    public class Class1
    {
        public static void Test()
        {
            NextAvailable asgsg = new NextAvailable()
            {
                Uid = "fasfsag",
                UidPrefix = "fsagds"
            };

            List<NextAvailable> test = new List<NextAvailable>();
            for (int i = 0; i < 9; i++)
            {
                test.Add(asgsg);
            }

            string a = JsonConvert.SerializeObject(test);

        }
    }
}
