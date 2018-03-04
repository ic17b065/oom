using System;

namespace Task2
{
    public class Actuator
    {
        //Constructor
        public Actuator(string name, string type, double current, double voltage)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must not be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(type)) throw new ArgumentException("Type must not be empty.", nameof(type));

            Name = name;
            Type = type;

            power = GetPower(current, voltage);

            Power = power;
            
        }
        
        //2 public properties
        public string Name { get; }
        public string Type { get; }

        //1 public method
        public double GetPower(double current, double voltage)
        {
            if (current < 0) throw new ArgumentException("Current must be higher than 0.", nameof(current));
            if ((voltage < 18) || (voltage > 30)) throw new ArgumentException("Voltage must be between 18 and 30.", nameof(voltage));
            power = current * voltage;
                        
            return power;
        }

        //1 private field
        private double power;

        public double Power { get; private set; }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //creates instances (objects)
            var PLA = new Actuator("PLA", "linear", 1.4, 24.0);
            var KSA = new Actuator("KSA", "chain", 1.0, 22.0);
            var KS2 = new Actuator("KS2", "chain", 1.2, 28.0);
            var PLS = new Actuator("PLS", "linear", 2.5, 24.0);
            var FTA = new Actuator("FTA", "linear", 4.0, 20.0);
            
            //prints properties
            Console.WriteLine("Actuator {0} {1, -7} {2, 5} W", PLA.Name, PLA.Type, PLA.Power);
            Console.WriteLine("Actuator {0} {1, -7} {2, 5} W", KSA.Name, KSA.Type, KSA.Power);
            Console.WriteLine("Actuator {0} {1, -7} {2, 5} W", KS2.Name, KS2.Type, KS2.Power);
            Console.WriteLine("Actuator {0} {1, -7} {2, 5} W", PLS.Name, PLS.Type, PLS.Power);
            Console.WriteLine("Actuator {0} {1, -7} {2, 5} W", FTA.Name, FTA.Type, FTA.Power);

            double newCurrent, newVoltage;
            Console.WriteLine("\nCalculate new power for KS2:");
            Console.WriteLine("Current: ");
            string inCurrent = Console.ReadLine();
            newCurrent = Convert.ToInt32(inCurrent);
            Console.WriteLine("Voltage: ");
            string inVoltage = Console.ReadLine();
            newVoltage = Convert.ToInt32(inVoltage);
            
            //calls methods on these objects and prints the effects to the console
            Console.WriteLine("\nActuator {0} {1, -7} {2, 5} W\n", KS2.Name, KS2.Type, KS2.GetPower(newCurrent, newVoltage));
                               
        }
    }
}
