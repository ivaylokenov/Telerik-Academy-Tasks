public class HumanOperations
{
    public void CreateHuman(int identificationalNumber)
    {
        Person newPerson = new Person();
        newPerson.Age = identificationalNumber;

        if (identificationalNumber % 2 == 0)
        {
            newPerson.Name = "The older guy";
            newPerson.PersonSex = Sex.Male;
        }
        else
        {
            newPerson.Name = "The hot chick";
            newPerson.PersonSex = Sex.Female;
        }
    }
}
