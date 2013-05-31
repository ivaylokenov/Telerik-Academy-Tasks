using System;
using System.Text;

namespace GenericList
{
    public class GenericList<T> where T: IComparable
    {
        private T[] list;
        private int currentElement = 0;

        //constructor with capacity
        public GenericList(int capacity)
        {
            list = new T[capacity];
        }

        //constructor with default capacity
        public GenericList() : this(4)
        {
        }

        //adding element
        public void AddElement(T value)
        {
            if (currentElement == list.Length)
            {
                DoubleCapacity();
            }

            list[currentElement] = value;
            currentElement++;
        }

        //removing element
        public void RemoveElement(int index)
        {
            if (index < 0 || index >= currentElement)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T[] newArray = new T[list.Length];

                for (int i = 0; i < index; i++)
                {
                    newArray[i] = list[i];
                }

                for (int i = index + 1; i < currentElement; i++)
                {
                    newArray[i - 1] = list[i];
                }

                list = newArray;
                currentElement--;
            }
        }

        //insert element at position
        public void InsertElement(int index, T value)
        {
            if (index == list.Length)
            {
                DoubleCapacity();
            }

            if (index < 0 || index > currentElement)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T[] newArray = new T[list.Length];

                for (int i = 0; i < index; i++)
                {
                    newArray[i] = list[i];
                }

                newArray[index] = value;

                for (int i = index; i < currentElement; i++)
                {
                    newArray[i + 1] = list[i];
                }

                list = newArray;
                currentElement++;
            }
        }

        //showing list's lenght
        public int Count
        {
            get { return currentElement; }
        }

        //clearing the list
        public void Clear()
        {
            list = new T[4];
            currentElement = 0;
        }

        //find element by value - returns -1 if nothing found
        public int FindElement<T>(T value)
        {
            int index = -1;

            for (int i = 0; i < currentElement; i++)
            {
                if (value.Equals(list[i]))
                {
                    return i;
                }
            }

            return index;
        }

        //indexator
        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= currentElement)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return list[index];
                }
            }
            set 
            {
                if (index < 0 || index >= currentElement)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    list[index] = value;
                }
            }
        }

        //ToString()
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < currentElement; i++)
            {
                output.Append(list[i] + " ");
            }

            output.AppendLine();

            return output.ToString();
        }

        //double the capacity method
        private void DoubleCapacity()
        {
            T[] newArray = new T[list.Length * 2];

            for (int i = 0; i < list.Length; i++)
            {
                newArray[i] = list[i];
            }

            list = newArray;
        }

        //minimum element
        public T MinElement()
        {
            T minValue = list[0];

            for (int i = 0; i < currentElement; i++)
            {
                if ((dynamic)minValue > (dynamic)list[i])
                {
                    minValue = list[i];
                }
            }

            return minValue;
        }

        //maximum element
        public T MaxElement()
        {
            T maxValue = list[0];

            for (int i = 0; i < currentElement; i++)
            {
                if ((dynamic)maxValue < (dynamic)list[i])
                {
                    maxValue = list[i];
                }
            }

            return maxValue;
        }
    }
}
