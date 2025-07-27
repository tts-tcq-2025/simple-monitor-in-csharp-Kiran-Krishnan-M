using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
    class Checker
    {
        static bool IsTemperatureOk(float t) => t >= 0 && t <= 45;
        static bool IsSocOk(float soc) => soc >= 20 && soc <= 80;
        static bool IsChargeRateOk(float cr) => cr <= 0.8;

        static bool batteryIsOk(float temperature, float soc, float chargeRate)
        {
            bool isTempOk = IsTemperatureOk(temperature);
            bool isSocOk = IsSocOk(soc);
            bool isChargeOk = IsChargeRateOk(chargeRate);

            if (!(isTempOk && isSocOk && isChargeOk))
            {
                Console.WriteLine(
                    !isTempOk ? "Temperature is out of range!" :
                    !isSocOk ? "State of Charge is out of range!" :
                    "Charge Rate is out of range!");
                return false;
            }
            return true;
        }


    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main() {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
    
}
}
