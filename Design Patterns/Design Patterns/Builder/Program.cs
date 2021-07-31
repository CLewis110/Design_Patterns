using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Builder
{
    public interface IBuilder
    {
        void StartOperations();
        void BuildBody();
        void InsertWheels();
        void AddHeadlights();
        void EndOperations();
        Product GetVehicle();
    }

    public class Product
    {
        private LinkedList<string> parts;

        public Product()
        {
            parts = new LinkedList<string>();
        }
        public void Add(string part)
        {
            parts.AddLast(part);
        }
        public void Show()
        {
            foreach(string part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    class Car : IBuilder
    {
        private string brandName;
        private Product product;

        public Car(string name)
        {
            product = new Product();
            brandName = name;
        }

        public void StartOperations()
        {
            product.Add(string.Format("Car Model name: {0}", this.brandName));
        }
        public void BuildBody()
        {
            product.Add("This is the body of the car.");
        }
        public void AddHeadlights()
        {
            product.Add("2 headlights added.");
        }
        public void InsertWheels()
        {
            product.Add("4 wheels added.");
        }
        public void EndOperations()
        {
            //Does nothing
        }
        public Product GetVehicle()
        {
            return product;
        }
    }

    public class Director
    {
        IBuilder builder;

        public void Construct(IBuilder builder)
        {
            this.builder = builder;

            //Call builder construction methods
            builder.StartOperations();
            builder.BuildBody();
            builder.InsertWheels();
            builder.AddHeadlights();
            builder.EndOperations();
        }
    }

    class Program
    {
        static void Main()
        {
            //Create director
            Director director = new Director();

            //Create builder interface with car name
            IBuilder car = new Car("Subaru");

            //Call director construct method
            director.Construct(car);

            //Product to store vehicle
            Product p = car.GetVehicle();

            //Show vehicle parts
            p.Show();
        }
    }
}
