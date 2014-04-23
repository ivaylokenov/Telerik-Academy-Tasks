using System;

namespace GenericList
{
    class ListTest
    {
        //5. Write a generic class GenericList<T> that keeps a list of 
        //elements of some parametric type T. Keep the elements of the list 
        //in an array with fixed capacity which is given as parameter in the 
        //class constructor. Implement methods for adding element, accessing 
        //element by index, removing element by index, inserting element at given 
        //position, clearing the list, finding element by its value and ToString(). 
        //Check all input parameters to avoid accessing elements at invalid positions.

        //6. Implement auto-grow functionality: when the internal array 
        //is full, create a new array of double size and move all elements to it.

        //7. Create generic methods Min<T>() and Max<T>() for finding the 
        //minimal and maximal element in the  GenericList<T>. You may need to 
        //add a generic constraints for the type T.

        static void Main()
        {
            //this class is for testing purposes

            GenericList<int> testList = new GenericList<int>(1);

            //adding some elements
            testList.AddElement(15);
            testList.AddElement(10);
            testList.AddElement(49);
            testList.AddElement(18);

            //testing indexator
            Console.WriteLine(testList[1]);
            testList[1] = 56;
            Console.WriteLine(testList[1]);

            //testing remove by index
            testList.RemoveElement(1);
            Console.WriteLine(testList[1]);
            testList.AddElement(1);
            testList.RemoveElement(testList.Count - 1);

            //inserting by index
            testList.InsertElement(0, 100);

            //testing element counter
            Console.WriteLine("Count: " + testList.Count);

            //find element
            Console.WriteLine(testList.FindElement(49));

            //to string
            Console.WriteLine(testList.ToString());

            testList.AddElement(1);
            testList.AddElement(1);
            testList.AddElement(1);
            testList.AddElement(1);
            testList.AddElement(1);
            testList.AddElement(1);

            //min & max element
            Console.WriteLine(testList.MinElement());
            Console.WriteLine(testList.MaxElement());

            //clearing the list
            testList.Clear();
            Console.WriteLine();
        }
    }
}