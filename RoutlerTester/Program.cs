using Routler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutlerTester
{
    [RoutlerClass("a/324", "Test")]
    [RoutlerClass("b/23", "Test2")]
    class RTest
    {
        //public const t = ""

        [RoutlerField("Test")]
        public string s = "943085kjdsf";

        [RoutlerField("Test")]
        [RoutlerField("Test2")]
        public string s2 = "lksajflkdsfsdf";

        [RoutlerField("Test2")]
        private string s3 = "23i4";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var o = new RTest();
            var s = RoutlerStatic.GenerateURL(o, "Test");
            var s2 = o.GenerateURL("Test2");

            Routler.RoutlerTest t = new RoutlerTest();
            t.MemberTest = "askjhfsdaf";

            var s3 = t.GenerateURL("kdsfj");
            
            Console.WriteLine("Test 1 : " + s);
            Console.WriteLine("Test 2 : " + s2);
            Console.WriteLine("Routler Test : " + s3);
            Console.ReadLine();
        }
    }
}
