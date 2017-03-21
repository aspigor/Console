using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Program1
{
    class Program1
    {
        static void Main(string[] args)
        {
            ResourceManager rm = new ResourceManager("items", Assembly.GetExecutingAssembly());

            ResourceSet resourceSet = InputAnimals.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            Farm farm = new Farm();
            foreach (DictionaryEntry entry in resourceSet)
            {
                Animal animal = new ConsoleApplication1.Program1.Animal();
                animal.type = entry.Key.ToString();
                animal.voice = entry.Value.ToString();
                farm.animals.Add(animal);
            }


            //farm.animals.Add(cat);
            //farm.animals.Add(dog);
            //farm.animals.Add(cow);
            //Console.Out.WriteLine("Welcome to the Farm");
            //Console.Out.WriteLine("Insert info for the new animal in the farm in the format 'animalType animalSound' or press Enter for printing");

            //Console.Out.WriteLine("Example: cat meow");
            //string input;
            //while (true)
            //{
            //    input = Console.ReadLine();
            //    if (input == "") break;
            //    else
            //    {
            //        string[] words = input.Split(' ');
            //        if (words.Length > 1)
            //        {
            //            Animal newAnimal = new Animal(words[0], words[1]);
            //            farm.animals.Add(newAnimal);
            //        }
            //        else Console.Out.WriteLine("Invalid format!!! Try again!");
            //    }

            //}

            Console.Out.Write(farm.printAnimals());
            Console.Out.WriteLine();
            Console.Out.WriteLine("The End");
            Console.In.ReadLine();

        }
    }

    class Animal
    {
        public string type { get; set; }
        public string voice { get; set; }

        public Animal() { }

        public Animal(string _type, string _voice)
        {
            type = _type;
            voice = _voice;
        }

    }

    class Farm
    {
        public List<Animal> animals = new List<Animal>();

        public string printAnimals()
        {
            string song = "The @animalType makes @animalVoice";
            StringBuilder sb = new StringBuilder();
            foreach (Animal animal in animals)
            {
                sb.AppendLine(song.Replace("@animalType", animal.type).Replace("@animalVoice", animal.voice));
            }

            return sb.ToString();
        }
    }




}
