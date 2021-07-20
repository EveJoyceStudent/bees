using System;
using System.Collections.Generic;

namespace Bees
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create beehives (with bees)
            // To start off create 2 beehives
            // 4 bees (John, Paul, George, Ringo) -> Sizes (3.2, 2.7, 1.1,  2.0)
            Beehive hive1 = new Beehive(10);
            hive1.AddBee(new Bee("John", 3.2F));
            hive1.AddBee(new Bee("Paul", 2.7F));
            hive1.AddBee(new Bee("George", 1.1F));
            hive1.AddBee(new Bee("Ringo", 2.0F));
            // 3 bees (Kurt, Dave, Krist) -> Sizes (2.3, 7.4, 1.5)
            Beehive hive2 = new Beehive(10);
            hive2.AddBee(new Bee("Kurt", 2.3F));
            hive2.AddBee(new Bee("Dave", 7.4F));
            hive2.AddBee(new Bee("Krist", 1.5F));

            // From each beehive run the CollectHoney method for a specified number of days
            Console.WriteLine($"Collected {hive1.CollectHoney(1)} honey from hive 1 over 1 day");
            Console.WriteLine($"Collected {hive2.CollectHoney(2)} honey from hive 2 over 2 days");
            // Report on the number of bees in each beehive
            Console.WriteLine($"Hive 1 has {hive1.Bees.Count} bees");
            Console.WriteLine($"Hive 2 has {hive2.Bees.Count} bees");
        }
    }
    class Bee
    {
        public string Name { get; set; }
        public float Size { get; set; }

        public Bee(string name, float size)
        {
            Name = name;
            Size = size;
        }
    }
    class Beehive
    {
        public int MaxBees { get; set; }
        public List<Bee> Bees { get; set; }

        public Beehive(int maxBees)
        {
            MaxBees = maxBees;
            Bees = new List<Bee>();
        }

        public void AddBee(Bee newbee){
            if(this.Bees.Count<this.MaxBees){
                this.Bees.Add(newbee);
            }
        }

        public float CollectHoney(int days){
            float honeysum = 0F;
            // each day each bee in the hive collects 0.2 of their size
            foreach (Bee collector in this.Bees)
            {
                honeysum+=collector.Size*0.2F;
            }
            // the daily amount is then collected each day
            honeysum*=days;
            return honeysum;
        }
    }
}
