using System;

namespace HuffmanAlogrithm
{
    class Data<T> : IComparable<Data<T>>, ICloneable
    {
        public Data<T> Left { get; set; }
        public Data<T> Right { get; set; }
        public double F { get; set; }
        public T Val { get; }

        public Data(T val, double weight)
        {
            Val = val;
            F = weight;
        }
        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }

        public int CompareTo(Data<T> other)
        {
            return F.CompareTo(other.F);
        }

        public override string ToString()
        {
            return $"{Val}: {F}";
        }

        public object Clone()
        {
            return new Data<T>(Val, F) { Left = Left, Right = Right};
        }
    }
}
