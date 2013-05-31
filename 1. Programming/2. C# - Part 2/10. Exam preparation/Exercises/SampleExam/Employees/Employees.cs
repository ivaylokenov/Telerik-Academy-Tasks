using System;
using System.Collections.Generic;
using System.Text;

class Employees
{
    //BGCoder: 5/100

    class People
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        //Dictionary<string, int> positions = new Dictionary<string, int>();

        string[] positionName = new string[N];
        string[] positionRank = new string[N];

        for (int i = 0; i < N; i++)
        {
            string currentPosition = Console.ReadLine();
            int lastDash = currentPosition.LastIndexOf('-');

            //if (positions.ContainsKey(currentPosition.Substring(0, lastDash).Trim()))
            //{
            //    continue;
            //}
            //positions.Add(currentPosition.Substring(0, lastDash).Trim(), int.Parse(currentPosition.Substring(lastDash + 1, currentPosition.Length - lastDash - 1).Trim()));

            int index = Array.IndexOf(positionName, currentPosition.Substring(0, lastDash).Trim());
            if (index < 0)
            {
                positionName[i] = currentPosition.Substring(0, lastDash).Trim();
                positionRank[i] = currentPosition.Substring(lastDash + 1, currentPosition.Length - lastDash - 1).Trim();
            }
        }

        int M = int.Parse(Console.ReadLine());

        //Dictionary<string, string> people = new Dictionary<string, string>();

        string[] peopleName = new string[M];
        string[] peoplePosition = new string[M];

        for (int i = 0; i < M; i++)
        {
            string currentPerson = Console.ReadLine();
            int lastDash = currentPerson.LastIndexOf('-');

            //if (people.ContainsKey(currentPerson.Substring(0, lastDash).Trim()))
            //{
            //continue;
            //}

            //people.Add(currentPerson.Substring(0, lastDash).Trim(), currentPerson.Substring(lastDash + 1, currentPerson.Length - lastDash - 1).Trim());

            int index = Array.IndexOf(peopleName, currentPerson.Substring(0, lastDash).Trim());
            if (index < 0)
            {
                peopleName[i] = currentPerson.Substring(0, lastDash).Trim();
                peoplePosition[i] = currentPerson.Substring(lastDash + 1, currentPerson.Length - lastDash - 1).Trim();
            }
        }

        //Dictionary<string, int> orderedPositions = new Dictionary<string, int>();

        List<string> orderedPositionName = new List<string>();

        for (int i = 10000; i >= 0; i--)
        {
            int index = Array.IndexOf(positionRank, i.ToString());
            while (index >= 0)
            {
                orderedPositionName.Add(positionName[index]);

                index = Array.IndexOf(positionRank, i.ToString(), index + 1);
            }
        }

        string[] firstName = new string[M];
        string[] lastName = new string[M];

        List<People> allPeople = new List<People>();

        for (int i = 0; i < orderedPositionName.Count; i++)
        {
            for (int j = 0; j < peoplePosition.Length; j++)
            {
                if (peoplePosition[j] == null)
                {
                    continue;
                }
                else if (peoplePosition[j] == orderedPositionName[i])
                {
                    string name = peopleName[j];

                    int index = name.IndexOf(' ');

                    if (index < 0)
                    {
                        People newPerson = new People();
                        newPerson.firstName = "0";
                        newPerson.lastName = name;
                        allPeople.Add(newPerson);
                    }
                    else
                    {
                        string[] names = name.Split(' ');

                        People newPerson = new People();
                        newPerson.firstName = names[0];
                        newPerson.lastName = names[1];
                        allPeople.Add(newPerson);
                    }
                }
            }
        }

        foreach (var person in allPeople)
        {
            Console.WriteLine(person.firstName + " " + person.lastName);
        }
    }
}
