using System.Collections.Generic;

namespace suraj
{
    class Student
    {
        //properties
        public int age;
        public int name;
        public int gender;
        public int std;
        public List<string> Hobbies;

        //behaviours
        public void study()
        {
            //TODO : student kasa abhyas karto
        }
        public bool come()
        {
            return true;
        }
        public bool IsPresent()
        {
            return false;
        }
    }
    public class Cheif
    {
        public static void main()
        {
            //Mixture mixter = Kicthen.GetMixture(1);
            Mixture mixer = Kicthen.PickUpAnyRandomWorkingMixture(true, 90);
            mixer.TurnOn(true, 90);
        }
    }


    static class Kicthen
    {
        static List<Mixture> _mixture = new List<Mixture> { new Mixture(1, "White"), new Mixture(2, "Black") };
        public static Mixture GetMixture(int id)
        {
            foreach (var mixer in _mixture)
            {
                if (mixer.MixtureNo == id)
                {
                    return mixer;
                }
            }
            return null;
        }
        public static Mixture PickUpAnyRandomWorkingMixture(bool powerSupply, decimal voltage)
        {
            foreach (var mixer in _mixture)
            {
                if (mixer.motor.TurnOn(powerSupply, voltage))
                {
                    return mixer;
                }
            }
            return null;
        }
    }

    class Education
    {
    }

    class Mixture
    {
        public Mixture(int id, string color)
        {
            this.MixtureNo = id;
            this.Color = color;
            this.button = new Button();
            this.motor = new Motor();
        }
        public int MixtureNo;
        public string Color;
        public Button button;
        public Motor motor;
        public string OnOffLight;
        public bool TurnOn(bool supplyReceived, decimal voltage)
        {
            if (button.isOn = true && motor.TurnOn(supplyReceived, voltage))
            {
                return true;
            }
            return false;
        }
    }
    class Motor
    {
        public bool isSupplyRecieved { get; set; }
        public bool isRunning { get; set; }
        public decimal VoltageRangeMin = 100;
        public decimal VoltageRangeMax = 250;
        public bool TurnOn(bool isSupplyRecieved, decimal voltage)
        {
            if (isSupplyRecieved && voltage >= VoltageRangeMin && voltage <= VoltageRangeMax)
            {
                isRunning = true;
            }
            return isRunning;
        }
        public bool TurnOff(bool isSupplyStopped)
        {
            if (isSupplyStopped)
            {
                isRunning = false;
            }
            return isRunning;
        }
    }
    class Button
    {
        public bool isOn { get; set; }
    }
}

namespace suraj1 { }

namespace suraj2 { }

namespace suraj3 { }
