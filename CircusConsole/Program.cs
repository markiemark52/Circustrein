using System;

namespace CircusConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Train currentTrain = new Train();
            currentTrain = StartTrain();
            ShowHelp();

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("Help", StringComparison.CurrentCultureIgnoreCase))
                {
                    ShowHelp();
                }
                else if (input.Contains("AddAnimal"))
                {
                    currentTrain.AllAnimals.Add(AddAnimal(input));
                }
                else if (input.Equals("ShowAnimals", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.Clear();
                    Console.WriteLine("All animals:");
                    foreach (Animal a in currentTrain.AllAnimals)
                    {
                        Console.WriteLine(a.Name + " - " + a.Food + " - " + a.Size);
                    }
                }
                else if (input.Equals("ShowTrain", StringComparison.CurrentCultureIgnoreCase))
                {
                    currentTrain.PlaceAnimals();
                    ShowTrain(currentTrain);
                    currentTrain.ClearWagons();
                }
            }
        }

        private static void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine("Commands:");
            Console.WriteLine("Help");
            Console.WriteLine("AddAnimal#[name]#[carnivore/herbivore]#[1/3/5 (size;1=small,3=average,5=large)]");
            Console.WriteLine("ShowAnimals");
            Console.WriteLine("ShowTrain");
        }

        private static Animal AddAnimal(string input)
        {
            Console.Clear();
            int sepName = input.IndexOf("#");
            int sepFood = sepName + input.Substring(sepName + 1).IndexOf("#") + 1;
            int sepSize = sepFood + input.Substring(sepFood + 1).IndexOf("#") + 1;
            int sizeName = sepFood - sepName - 1;
            int sizeFood = sepSize - sepFood - 1;
            string name = input.Substring(sepName + 1, sizeName);
            string food = input.Substring(sepFood + 1, sizeFood);
            int size = Convert.ToInt32(input.Substring(sepSize + 1));
            Console.WriteLine("Animal added:");
            Console.WriteLine(name + " - " + food + " - " + size);
            return new Animal(name, food, size);
        }

        private static void ShowTrain(Train t)
        {
            Console.Clear();
            Console.WriteLine("Current train:");
            int wagonNumber = 1;
            foreach (Wagon w in t.Wagons)
            {
                Console.WriteLine("Wagon " + wagonNumber);
                foreach (Animal a in w.Animals)
                {
                    Console.WriteLine(a.Name + " - " + a.Food + " - " + a.Size);
                }
                Console.WriteLine();
                wagonNumber++;
            }
        }

        private static Train StartTrain()
        {
            Train startTrain = new Train();
            startTrain.AllAnimals.Add(new Animal("dog", "carnivore", 3));
            startTrain.AllAnimals.Add(new Animal("cat", "carnivore", 3));
            startTrain.AllAnimals.Add(new Animal("giraffe", "herbivore", 5));
            startTrain.AllAnimals.Add(new Animal("lion", "carnivore", 5));
            startTrain.AllAnimals.Add(new Animal("rabbit", "herbivore", 3));
            startTrain.AllAnimals.Add(new Animal("rat", "carnivore", 1));
            startTrain.AllAnimals.Add(new Animal("goldfish", "herbivore", 1));
            startTrain.AllAnimals.Add(new Animal("bird", "herbivore", 1));
            startTrain.AllAnimals.Add(new Animal("horse", "herbivore", 5));
            startTrain.AllAnimals.Add(new Animal("cow", "herbivore", 5));
            startTrain.AllAnimals.Add(new Animal("goat", "herbivore", 5));

            return startTrain;
        }
    }
}
