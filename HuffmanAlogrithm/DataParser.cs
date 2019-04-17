using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HuffmanAlogrithm
{
    class DataParser
    {
        public string RawData { get; set; }

        public DataParser(string filename)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filename))
                {
                    // Read the stream to a string, and write the string to the console.
                    RawData = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void GenerateRandomData()
        {
            Random r = new Random();
            StringBuilder s = new StringBuilder();
            int amountOfData = r.Next(500, 1000);
            for (int i = 0; i < amountOfData; i++)
            {
                s.Append(r.Next(0, 8).ToString());
            }
            RawData = s.ToString();
        }
        public static IEnumerable<string> Split(string str, int chunkSize, char fillUpChar = '0')
        {

            if (str.Length % chunkSize != 0)
            {
                Console.WriteLine($"Warning, input is not divisible into equal chunks {str.Length}%{chunkSize}={str.Length % chunkSize}, Adding extra {str.Length % chunkSize} character.");
                str += new string(fillUpChar, str.Length % chunkSize);
            }
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}
