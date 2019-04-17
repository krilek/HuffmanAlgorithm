using System;
using System.Collections.Generic;
using System.Linq;

namespace HuffmanAlogrithm
{
    class Huffman
    {
        private readonly List<string> _c;
        public List<Data<string>> Queues { get; }
        public Data<string> Root { get; }
        public readonly Dictionary<string, string> Codes = new Dictionary<string, string>();

        public Huffman(List<string> allValues)
        {
            Queues = BuildQueue(allValues);
            _c = Queues.Select(q => q.Val).ToList();
            Root = GenerateHuffmanTree();
            ReadCodesFromTree(Root, "");
        }

        private void ReadCodesFromTree(Data<string> node, string str)
        {
            if(node == null) return;
            if (node.IsLeaf())
            {
                Codes.Add(node.Val, str);
                return;
            }
            ReadCodesFromTree(node.Left, str+"0");
            ReadCodesFromTree(node.Right, str + "1");
        }

        public override string ToString()
        {
            return Codes.Select(x => x.Key + ": " + x.Value).Aggregate((s1, s2) => s1 + "\n" + s2);
        }

        private Data<string> GenerateHuffmanTree()
        {
            List<Data<string>> q = Queues.Clone().ToList();
            for (int i = 1; i < _c.Count; i++)
            {
                var x = ExtractMin(q);
                var y = ExtractMin(q);
                var z = new Data<string>("#", x.F + y.F)
                {
                    Left = x,
                    Right = y
                };
                q.Add(z);
            }
            return ExtractMin(q);
        }

        private static Data<string> ExtractMin(ICollection<Data<string>> queues)
        {
            Data<string> x = queues.Min();
            queues.Remove(x);
            return x;
        }

        private List<Data<string>> BuildQueue(List<string> allValues)
        {
            List<Data<string>> ret = new List<Data<string>>();
            foreach (string allValue in allValues)
            {
                if (ret.All(d => d.Val != allValue))
                {
                    ret.Add(new Data<string>(allValue, 1));
                }
                else
                {
                    ret.Find(d => d.Val == allValue).F++;
                }
                
            }
            return ret;
        }

        public int GetEncodedLenght()
        {
            //For each code, look for it in queues, check its frequency and multiple that by amount of bits of code
            return Codes.Sum(valuePair => (int) Queues.Find(d => d.Val == valuePair.Key).F * valuePair.Value.Length);
        }
    }

    internal static class Extensions
    {
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
