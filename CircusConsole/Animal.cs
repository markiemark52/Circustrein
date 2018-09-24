using System;
using System.Collections.Generic;
using System.Text;

namespace CircusConsole
{
    public class Animal
    {
        private string name;
        private string food;
        private int size;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Food
        {
            get { return food; }
            set { food = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public Animal(string name, string food, int size)
        {
            this.name = name;
            this.food = food;
            this.size = size;
        }
    }
}
