using System;
using System.Collections;
using System.Collections.Generic;

namespace BitArray
{
    class BitArray64 : IEnumerable<int>
    {
        private readonly ulong number;

        //constructor
        public BitArray64(ulong number = 0)
        {
            this.number = number;
        }

        //ienumerable interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = this.ConvertToBits();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        //property to return array of all bits
        public int[] Bits
        {
            get { return this.ConvertToBits(); }
        }

        //method for converting
        private int[] ConvertToBits()
        {
            ulong value = this.number;

            int[] bits = new int[64];
            int counter = 63;

            while (value != 0)
            {
                bits[counter] = (int)value % 2;
                value /= 2;
                counter--;
            }

            do
            {
                bits[counter] = 0;
                counter--;
            }
            while (counter != 0);

            return bits;
        }

        //equals
        public bool Equals(BitArray64 value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return this.number == value.number;
        }

        public override bool Equals(object obj)
        {
            BitArray64 temp = obj as BitArray64;
            if (temp == null)
                return false;
            return this.Equals(temp);
        }

        //hash code (generated with JustCode)
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.number.GetHashCode();
                return result;
            }
        }

        //indexator
        private bool IndexChecker(int index)
        {
            if (index < 0 || index > 63)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //index to check the bit at position
        public int this[int index]
        {
            get
            {
                if (IndexChecker(index))
                {
                    throw new System.IndexOutOfRangeException();
                }

                int[] bits = this.ConvertToBits();
                return bits[index];
            }
        }

        //== operator
        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        //!= operator
        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
    }
}
