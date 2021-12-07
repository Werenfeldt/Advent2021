public class Fish
{

    int age = 0;


    public Fish(int year)
    {
        this.age = year;
    }

    public Fish()
    {
        this.age = 8;
    }

    public int getAge()
    {
        return age;
    }

    public void DayPasses()
    {

        age--;
        if (age == -1)
        {
            age = 6;
        }


    }


}