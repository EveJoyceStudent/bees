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
            Beehive hive1 = new Beehive(4);
            hive1.AddBee(new Bee("John", 3.2F));
            hive1.AddBee(new Bee("Paul", 2.7F));
            hive1.AddBee(new Bee("George", 1.1F));
            hive1.AddBee(new Bee("Ringo", 2.0F));
            hive1.AddBee(new Bee("Unwanted Larry", 2.5F));

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

            // try to have hive two's queen make a bee
            hive2.QueenMakeBee("Baby Bee");
            // add a queen
            hive2.AddQueenBee(new QueenBee("Queeny"));
            Console.WriteLine($"Hive 2 has {hive2.Bees.Count} bees");
            // try to add a second queen
            hive2.AddQueenBee(new QueenBee("Beeonce"));
            Console.WriteLine($"Hive 2 has {hive2.Bees.Count} bees");
            // have hive two's queen make a bee
            hive2.QueenMakeBee("Baby Bee");
            Console.WriteLine($"Hive 2 has {hive2.Bees.Count} bees");
            // see how much extra honey the hive collected with its new bees
            Console.WriteLine($"Collected {hive2.CollectHoney(2)} honey from hive 2 over 2 days");


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
    class QueenBee : Bee
    {
        public QueenBee(string name) : base(name, 0F)
        {
        }
        public Bee MakeBee(string name){
            return new Bee(name, 0.1F);
        }
    }
    class Beehive
    {
        public int MaxBees { get; set; }
        public List<Bee> Bees { get; set; }
        public List<QueenBee> Queen { get; set; }

        public Beehive(int maxBees)
        {
            MaxBees = maxBees;
            Bees = new List<Bee>();
            Queen = new List<QueenBee>();
        }

        public void AddBee(Bee newbee){
            if(this.Bees.Count<this.MaxBees){
                this.Bees.Add(newbee);
            } else {
                Console.WriteLine("Beehive is full");
            }
        }

        public void AddQueenBee(QueenBee newQueen){
            if(this.Bees.Count<this.MaxBees){
                if(this.Queen.Count == 0){
                    this.Bees.Add(newQueen);
                    this.Queen.Add(newQueen);
                    Console.WriteLine($"Queen {newQueen.Name} added to Beehive");
                } else {
                    Console.WriteLine("Beehive already has Queen");
                }
            } else {
                Console.WriteLine("Beehive is full");
            }
        }

        public void QueenMakeBee(string name){
            if(this.Queen.Count>0){
                this.AddBee(this.Queen[0].MakeBee(name));
                Console.WriteLine($"Queen had new child {name}, they were added to Beehive");
            } else {
                Console.WriteLine("Hive has no queen.");
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
