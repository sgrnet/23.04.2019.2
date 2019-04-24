using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PseudoEnumerable;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lstr = new List<string>();
            lstr.Add("123456789");
            lstr.Add("12345678");
            lstr.Add("1234");
            lstr.Add("12345");
            lstr.Add("123");
            lstr.Add("12");
            lstr.Add("12345678");

            
            
            
            foreach (var item in Enumerable.SortBy<string, int>(lstr, (s) => s.Length))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("*********************************************************");












            B source = new A("ссылка B, объект A");
            A result = new A("ссылка A, объект A");
            object ob = new object();
            //ob = (B)ac;

            Console.WriteLine(result is B);

            if ( result is B)
            {
               result = (A)source;
            }


            Console.WriteLine($"type result {result.GetType()}");
            Console.WriteLine(result);
            Console.WriteLine($"type source {source.GetType()}");
            Console.WriteLine(source);
            Console.WriteLine($"type ob {ob.GetType()}");
            Console.WriteLine(ob);





            B[] Bbarr = new B[] { new B("B1"), new B("B2"), new B("B3") };
            A[] Aarr = new A[] { new A("A1"), new A("A2"), new A("A3") };
            foreach (var item in Aarr)
            {
                Console.WriteLine(item);
            }

            List<B> Barr = new List<B>();
            foreach (var item in Enumerable.CastTo<B>(Aarr))
            {
                Barr.Add(item);
            }
            List<object> Oarr = new List<object>();
            foreach (var item in Enumerable.CastTo<object>(Bbarr))
            {
                Oarr.Add(item);
            }

            foreach (var item in Oarr)
            {
                Console.WriteLine(item + item.GetType().ToString());
                
            }

            List<B> OAarr = new List<B>();
            foreach (var item in Enumerable.CastTo<B>(Oarr))
            {
                OAarr.Add(item);
                item.DisplayB();
            }

            foreach (var item in OAarr)
            {
                Console.WriteLine(item + item.GetType().ToString());
               

            }



            //foreach (var item in Barr)
            //{
            //    Console.WriteLine($"{item} typeof {item.GetType()}");
            //    item.DisplayB();
            //}

            //Console.WriteLine( ac is B);







            Console.ReadKey();
        }
    }
    class B
    {
        public string heredity;

        public string title;

        public B(string name)
        {
            title = name;
            heredity = "Base";
        }

        public override string ToString()
        {
            return $"{title} {heredity}";
        }
        public void DisplayB()
        {
            Console.WriteLine($"DisplayB {ToString()}");
        }
    }
    class A:B
    {
        public A(string name) : base(name)
        {
            heredity = "Child";
        }

        public override string ToString()
        {
            return $"{base.title} {heredity}";
        }
        public void DisplayA()
        {
            Console.WriteLine($"DisplayA {ToString()}");
        }
    }

}
