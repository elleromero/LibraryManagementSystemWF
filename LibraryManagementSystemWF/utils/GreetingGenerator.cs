using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class GreetingGenerator
    {
        public static string GenerateGreeting(string firstName, string timeString)
        {
            // should use time based greeting
            bool useTimeBasedGreeting = new Random().Next(2) == 0;

            // Get the current time
            DateTime currentTime = DateTime.Parse(timeString);
            int currentHour = currentTime.Hour;

            // Define the greetings based on the time of the day
            string morningGreeting = "Good morning";
            string afternoonGreeting = "Good afternoon";
            string eveningGreeting = "Good evening";
            string nightGreeting = "Good night";

            // Define additional creative greetings
            string[] additionalGreetings =
            {
            "Hello",
            "Hi there",
            "Hey",
            "Greetings",
            "Salutations",
            "Howdy",
            "Yo",
            "Welcome",
            "Nice to see you",
            "Hey, what's up"
            };

            // Generate the greeting
            string greeting;
            if (useTimeBasedGreeting)
            {
                if (currentHour >= 5 && currentHour < 12)
                {
                    greeting = morningGreeting;
                }
                else if (currentHour >= 12 && currentHour < 17)
                {
                    greeting = afternoonGreeting;
                }
                else if (currentHour >= 17 && currentHour < 21)
                {
                    greeting = eveningGreeting;
                }
                else
                {
                    greeting = nightGreeting;
                }
            }
            else
            {
                Random random = new Random();
                greeting = additionalGreetings[random.Next(additionalGreetings.Length)];
            }

            // Generate the greeting with the first name
            string fullGreeting = $"{greeting}, {firstName}!";

            return fullGreeting;
        }
    }
}
