using System.Runtime.InteropServices;

namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string keyWord = Console.ReadLine();
            string text = Console.ReadLine();   

            while (text.Contains(keyWord))
            {
                //int indexOfKeyWord = text.IndexOf(keyWord);
                //text = text.Remove(indexOfKeyWord, keyWord.Length);

                text = text.Replace(keyWord, "");
            }

            Console.WriteLine(text);
        }
    } 
}