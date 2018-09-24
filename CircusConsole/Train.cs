using System;
using System.Collections.Generic;
using System.Text;

namespace CircusConsole
{
    public class Train
    {
        private List<Wagon> wagons;
        private List<Animal> allAnimals;

        public List<Wagon> Wagons
        {
            get { return wagons; }
            set { wagons = value; }
        }
        public List<Animal> AllAnimals
        {
            get { return allAnimals; }
            set { allAnimals = value; }
        }

        public Train()
        {
            Wagons = new List<Wagon>();
            AllAnimals = new List<Animal>();
        }

        public void PlaceAnimals()
        {
            foreach (Animal a in AllAnimals)
            {
                Wagon wagon = GetAvailableWagon(a);
                wagon.AddAnimal(a);
            }
        }

        private Wagon GetAvailableWagon(Animal a)
        {
            foreach (Wagon w in wagons)
            {
                if (w.AnimalCanBePlaced(a))
                {
                    return w;
                }
            }
            Wagon newWagon = new Wagon();
            wagons.Add(newWagon);
            return newWagon;
        }

        public void ClearWagons()
        {
            wagons.Clear();
        }
    }
}
