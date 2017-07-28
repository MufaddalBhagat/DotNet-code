using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldComponent;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldData newObject = new HelloWorldData("Hello World");

            //Method use to access property value
            Console.WriteLine(newObject.getName());

            //Direct access to public property
            Console.WriteLine(newObject.Name);






            //"delegate" keyword example
            //create delegate instances for multicast
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            nc = nc1;
            nc += nc2;

            //calling the methods using the delegate objects
            nc1(25);
            Console.WriteLine("Value of Num: {0}", getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}", getNum());

            //calling multicast
            nc(5);
            Console.WriteLine("Value of Num: {0}", getNum());



            //lambda expression
            NumberChanger ncAddWithLambda = (x) => { x += x; return x; };
            Console.WriteLine("Value of ncAddWithLambda: {0}", ncAddWithLambda(10));


            //"using" keyword example
            Console.WriteLine(getContentFromFile(@"C:\Mufaddal\DotNetvsJAVA\Examples\TextDemo.txt"));



            Console.Read();
        }
        

        //delegate declaration
        delegate int NumberChanger(int n);

        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }




        //"using" Keyword
        public static String getContentFromFile(String fileName)
        {
            String line = String.Empty;
            StringBuilder fileBuilder = new StringBuilder();

            using (StreamReader file = new StreamReader(fileName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        fileBuilder.Append(line);
                        fileBuilder.Append(Environment.NewLine);
                    }
                }
            }
            return fileBuilder.ToString();
        }
    }
}
