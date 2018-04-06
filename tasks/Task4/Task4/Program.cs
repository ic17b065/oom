using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task4
{
    public interface IActuator
    {
       void Print();
    }

    public class LinearDrive : IActuator
    {
        public void Print()
        {
            Console.WriteLine($"LinearDrive: { Name } Hub: {Hub}mm  Strom: { Current }A  Spannung: { Voltage }V  Leistung: { Power }W");
        }

        // private field
        private double P_Power;

        //Constructor
        [JsonConstructor]
        public LinearDrive(string name, double hub, double current, double voltage)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must not be empty.", nameof(name));
            if (hub < 0) throw new ArgumentException("Hub must be higher than 0.", nameof(hub));
            if (current < 0) throw new ArgumentException("Current must be higher than 0.", nameof(current));
            if ((voltage < 18) || (voltage > 30)) throw new ArgumentException("Voltage must be between 18 and 30.", nameof(voltage));

            Name = name;
            Hub = hub;
            Current = current;
            Voltage = voltage;
            P_Power = current * voltage;
        }

        //public properties
        public string Name { get; }
        public double Hub { get; }
        public double Current { get; }
        public double Voltage { get; }

        public double Power => P_Power;
        
        //1 public method
        /*public double GetPower(double current, double voltage)
        {
            if (current < 0) throw new ArgumentException("Current must be higher than 0.", nameof(current));
            if ((voltage < 18) || (voltage > 30)) throw new ArgumentException("Voltage must be between 18 and 30.", nameof(voltage));

            return current * voltage;    
        }*/
        
    }

    public class ChainDrive : IActuator
    {
        public void Print()
        {
            Console.WriteLine($"ChainDrive: { Name } Preis: {Price}Euro");
        }

        //Constructor
        [JsonConstructor]
        public ChainDrive(string name, double price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must not be empty.", nameof(name));
            if (price < 0) throw new ArgumentException("Price must be higher than 0.", nameof(price));

            Name = name;
            Price = price;

        }

        //public properties
        public string Name { get; }
        public double Price { get; set; }

        //1 public method
        public void SetPrice(double new_Price)
        {
            if (new_Price < 0)
                throw new Exception("negativer Preis");
            Price = new_Price;
        }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //creates instances (objects)
                LinearDrive PLA = new LinearDrive("PLA", 500, 2.5, 24.0);
                LinearDrive FTA = new LinearDrive("FTA", 200, 1.4, 24.0);
                ChainDrive KSA = new ChainDrive("KSA", 433.20);

                //calls method
                KSA.SetPrice(477.42);

                /*double iCurrent, iVoltage;
                Console.WriteLine("\nCalculate new power for PLA:");
                Console.WriteLine("Current: ");
                string inCurrent = Console.ReadLine();
                iCurrent = Convert.ToInt32(inCurrent);
                Console.WriteLine("Voltage: ");
                string inVoltage = Console.ReadLine();
                iVoltage = Convert.ToInt32(inVoltage);
                PLA.GetPower(iCurrent, iVoltage);*/

                //create Array
                IActuator[] ActuatorArray = { PLA, FTA, new ChainDrive("KS2", 125.70), KSA };

                //print Array
                foreach (IActuator Actuator in ActuatorArray)
                {
                    Actuator.Print();
                }

                //serialize ActuatorArray with all items, formatting and type included 
                var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
                /*var json = JsonConvert.SerializeObject(ActuatorArray, settings);
                Console.WriteLine(json);
                //deserialize json and print
                var itemsfromjson = JsonConvert.DeserializeObject<IActuator[]>(json, settings);
                foreach (var Actuator in itemsfromjson)
                    Actuator.Print();*/
                Console.WriteLine(JsonConvert.SerializeObject(ActuatorArray, settings));

                //store json string to file "items.json" on your desktop
                var text = JsonConvert.SerializeObject(ActuatorArray, settings);
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filename = Path.Combine(desktop, "Actuators.json");
                File.WriteAllText(filename, text);

                //deserialize items from "items.json"
                var TextFromFile = File.ReadAllText(filename);
                var ItemsFromFile = JsonConvert.DeserializeObject<IActuator[]>(TextFromFile, settings);

                foreach (var Actuator in ItemsFromFile)
                {
                    Actuator.Print();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine($"Something happens {e.Message}");
            }
        }
    }
}
