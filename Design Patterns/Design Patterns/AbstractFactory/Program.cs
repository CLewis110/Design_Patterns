using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.AbstractFactory
{
    public interface IDog
    {
        //Interface actions
        void Speak();
        void Sit();
    }
    public interface IAnimalFactory
    {
        IDog GetDog();
    }

    class PetDog : IDog
    {
        public void Sit()
        {
            Console.WriteLine("Pet dog sits.");
        }

        public void Speak()
        {
            Console.WriteLine("Ruff.");
        }
    }

    class WildDog : IDog
    {
        public void Sit()
        {
            Console.WriteLine("Wild dog doesn't listen and walks away.");
        }

        public void Speak()
        {
            Console.WriteLine("Grrr.");
        }
    }

    public class PetAnimalFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new PetDog();
        }
    }

    public class WildAnimalFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new WildDog();
        }
    }

    class Program
    {
        static void Main()
        {
            //Create abstract animal factory
            IAnimalFactory wildAnimalFactory = new WildAnimalFactory();
            //Get dog
            IDog wildDog = wildAnimalFactory.GetDog();
            //Do dog actions
            wildDog.Sit();
            wildDog.Speak();
        }
    }
}
