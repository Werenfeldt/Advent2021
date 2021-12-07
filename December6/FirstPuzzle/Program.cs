public class Program
{

    static List<Fish> Fishes = new List<Fish>();

    static int babyfishes = 0;


    

    public static void Main()
    {
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            string[] line = item.Split(",");

            foreach (var node in line)
            {
                Fishes.Add(new Fish(Convert.ToInt32(node)));


            }
           
        }

        for (int i = 0; i < 257; i++)
        {
            if(i%50 == 0){
                Console.WriteLine(i);
            }

            if (babyfishes > 0)
            {
                for (int j = 0; j < babyfishes; j++)
                {
                    Fishes.Add(new Fish());
                    
                }
            }
            babyfishes = 0;
            //Console.Write("After {0} days: ", i);
            foreach (var item in Fishes)
            {

                //Console.Write(item.getAge());
                if (item.getAge() == 0)
                {

                    babyfishes++;
                }
                item.DayPasses();
            }
            //Console.WriteLine();


            //Console.WriteLine("Number og baby fishes: " + babyfishes);

            //Console.WriteLine(" ");
        }

        Console.WriteLine(Fishes.Count);

        // foreach (var item in Fishes)
        // {
        //     Console.WriteLine(item.getAge());
        // }
    }
}