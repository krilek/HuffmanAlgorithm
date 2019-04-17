using System;
using System.Linq;

namespace HuffmanAlogrithm
{
    internal class Program
    {
        private static void Main()
        {
            var n = new DataParser("plik.txt");
            //n.GenerateRandomData();
            var x = new Huffman(DataParser.Split(n.RawData, 1).ToList());
            var y = new Huffman(DataParser.Split(n.RawData, 2).ToList());
            Console.WriteLine($"Original text lenght in bits: {n.RawData.Length*8}");
            Console.WriteLine(x);
            Console.WriteLine($"Encoded text lenght in bits when using 1 numbers as key: {x.GetEncodedLenght()}");
            Console.WriteLine(y);
            Console.WriteLine($"Encoded text lenght in bits when using 2 numbers as key: {y.GetEncodedLenght()}");

            Console.ReadKey();
        }
    }
}
