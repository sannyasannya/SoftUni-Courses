using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string firstWord = "Hey, ";
            // string secondWord = "girl!";

            //Console.WriteLine(firstWord + secondWord);

            //firstWord += secondWord;
            //Console.WriteLine(firstWord);

            //Console.WriteLine(string.Concat(firstWord, secondWord));
            //


            //string A = "Sanya";
            //string B = "Boyanova";
            //string C = "Panova";

            //Console.WriteLine(string.Join(" ", A, B, C));



            //string s = "abc";
            //string[] arr = new string[3];

            //for (int i = 0; i < arr.Length; i++)
            //{
            //  arr[i] = s;
            //}

            //string repeated = string.Join("", arr);
            //Console.WriteLine(repeated);





            //string alphabet = "abcdefg";
            //Console.WriteLine(alphabet.Substring(5));
            // взима всичко след индекса и го печата от 4 индекс

            //string alphabet = "abcdefg";
            //Console.WriteLine(alphabet.Substring(3, 3));
            // започвам от индекс 3 и взимам 3 символа, т е def

            //string text = "Hello, john@softuni.org, you have been using john@softuni.org in your registration";
            //string[] words = text.Split(", ") { }, 
            //StringSplitOptions.RemoveEmptyEntries();
            //Console.WriteLine(text);



            //char[] separators = new char[] { ' ', ',', '.' };
            // string text = "Hello, I am John.";
            //string[] words = text.Split(separators);
            // Console.WriteLine();





            //StringBuilder output = new StringBuilder();

            //output.Append("Hi,");
            //output.Append('\n');
            // output.Append("Sanny!");

            //Console.WriteLine(output.ToString());   



            //Stopwatch sw = new Stopwatch();
            // sw.Start();
            // string text = "";
            // for (int i = 0; i < 200; i++)
            //    text += i;
            // sw.Stop();
            // Console.WriteLine(sw.ElapsedMilliseconds);




            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //StringBuilder text = new StringBuilder();
            //for (int i = 0; i < 200000; i++)
            //    text.Append(i);
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);


            StringBuilder sb = new StringBuilder();

            sb.Append("Hello,");
            sb.Append("Sannya!");
            //sb.Clear();
            sb.Insert(6, ":)");

            //Console.WriteLine(sb.Length);
            Console.WriteLine(sb);







        }
    }
}



