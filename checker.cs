using System;
using System.Diagnostics;
namespace paradigm_shift_csharp
{
    class Checker
    {
        // A struct to represent each validation rule
        private struct Validator
        {
            public Func<bool> Condition { get; }
            public string ErrorMessage { get; }

            public Validator(Func<bool> condition, string message)
            {
                Condition = condition;
                ErrorMessage = message;
            }
        }

        static bool batteryIsOk(float temperature, float soc, float chargeRate)
        {
            // List of validation rules
            var validators = new List<Validator>
            {
                new Validator(
                    () => temperature >= 0f && temperature <= 45f,
                    "Temperature is out of range!"),
                new Validator(
                    () => soc >= 20f && soc <= 80f,
                    "State of Charge is out of range!"),
                new Validator(
                    () => chargeRate <= 0.8f,
                    "Charge rate is out of range!")
            };

            // Check all validators and collect errors
            bool allOk = true;

            foreach (var v in validators)
            {
                if (!v.Condition())
                {
                    Console.WriteLine(v.ErrorMessage);
                    allOk = false;
                }
            }

            return allOk;
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
