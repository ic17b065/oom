using System;

namespace Task3
{

    interface IActuator
    {
        void Print();
    }
    
    class LinearDrive : IActuator
    {
        public void Print()
        {
            Console.WriteLine($"LinearDrive: { A_Name } Hub: {A_Hub}mm  Strom: { A_Current }A  Spannung: { A_Voltage }V  Leistung: { A_Power }W");
        }

        // private fields
        private string Name;
        private double Hub;
        private double Current;
        private double Voltage;

        //Constructor
        public LinearDrive(string newName, double newHub, double newCurrent, double newVoltage)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name must not be empty.", nameof(newName));
            if (newHub < 0) throw new ArgumentException("Hub must be higher than 0.", nameof(newHub));
            if (newCurrent < 0) throw new ArgumentException("Current must be higher than 0.", nameof(newCurrent));
            if ((newVoltage < 18) || (newVoltage > 30)) throw new ArgumentException("Voltage must be between 18 and 30.", nameof(newVoltage));
            
            Name = newName;
            Hub = newHub;
            Current = newCurrent;
            Voltage = newVoltage;
        }

        //public properties
        public string A_Name => Name;
        public double A_Hub => Hub;
        public double A_Current => Current;
        public double A_Voltage => Voltage;
        
        public double A_Power => Current * Voltage;

        //1 public method
        /*public double GetPower(double current, double voltage)
        {
            if (current < 0) throw new ArgumentException("Current must be higher than 0.", nameof(current));
            if ((voltage < 18) || (voltage > 30)) throw new ArgumentException("Voltage must be between 18 and 30.", nameof(voltage));

            return current * voltage;    
        }*/
    }

    class ChainDrive : IActuator
    {
        public void Print()
        {
            Console.WriteLine($"ChainDrive: { A_Name } Preis: {A_Prize}Euro");
        }

        // private fields
        private string Name;
        private double Prize;

        //Constructor
        public ChainDrive(string newName, double newPrize)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name must not be empty.", nameof(newName));
            if (newPrize < 0) throw new ArgumentException("Prize must be higher than 0.", nameof(newPrize));

            Name = newName;
            Prize = newPrize;

        }

        //public properties
        public string A_Name => Name;
        public double A_Prize => Prize;

        //1 public method
        public void SetPrize(double new_Prize)
        {
            if (new_Prize < 0)
                throw new Exception("negativer Preis");
            Prize = new_Prize;
        }     
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //creates instances (objects)
                LinearDrive PLA = new LinearDrive("PLA", 500, 2.5, 24.0);
                LinearDrive FTA = new LinearDrive("FTA", 200, 1.4, 24.0);
                ChainDrive KSA = new ChainDrive("KSA", 433.20);
                
                //calls method
                KSA.SetPrize(477.42);

                /*double iCurrent, iVoltage;
                Console.WriteLine("\nCalculate new power for PLA:");
                Console.WriteLine("Current: ");
                string inCurrent = Console.ReadLine();
                iCurrent = Convert.ToInt32(inCurrent);
                Console.WriteLine("Voltage: ");
                string inVoltage = Console.ReadLine();
                iVoltage = Convert.ToInt32(inVoltage);
                PLA.GetPower(iCurrent, iVoltage);*/
                
                IActuator[] ActuatorArray = { PLA, FTA, new ChainDrive("KS2", 125.70), KSA };

                foreach (IActuator Actuator in ActuatorArray)
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
