using System;
using System.Collections.Generic;
using System.Text;

namespace CircusConsole
{
    public class Wagon
    {
        private int points;
        private List<Animal> animals;

        public List<Animal> Animals
        {
            get { return animals; }
            private set { animals = value; }
        }

        public Wagon()
        {
            points = 0;
            Animals = new List<Animal>();
        }

        private bool HasSpace(int size)
        {
            if (points + size <= 10)
            {
                return true;
            }
            return false;
        }

        private bool AnimalsEatEachother(Animal newAnimal)
        {
            foreach (Animal a in Animals)
            {
                if (a.Food == "carnivore")
                {
                    if (newAnimal.Size <= a.Size)
                    {
                        return true;
                    }
                }
                if (newAnimal.Food == "carnivore")
                {
                    if (newAnimal.Size >= a.Size)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AnimalCanBePlaced(Animal newAnimal)
        {
            if (HasSpace(newAnimal.Size) && !AnimalsEatEachother(newAnimal))
            {
                return true;
            }
            return false;
        }

        public void AddAnimal(Animal newAnimal)
        {
            if (AnimalCanBePlaced(newAnimal))
            {
                animals.Add(newAnimal);
                points += newAnimal.Size;
            }
            else
            {
                Console.WriteLine("Animal can't be added!");
            }
        }
    }
}
