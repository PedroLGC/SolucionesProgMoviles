//Autor: Pedro Luis González Cernuda
//Progam for calculating the travel expenses for a car trip based on the given data.
//The program requires the user to input the car brand, the travel distance, car efficiency and gas type.
using System;

namespace CostoViaje
{
    public class Program
    {
        //CONSTANT VALUES FOR GAS TYPE.
        static double REGULAR_PRICE = 19.19;
        static double PREMIUM_PRICE = 21.49;

        public static void Main(string[] args)
        {
            //VARIABLE DECLARATIONS.
            string brand = " ";
            string gasType = " ";
            string scanner = " ";
            double price = 0.0;
            double distance = 0.0;
            double efficiency = 0.0;
            //BOOLEAN FOR WHILE CONDITION.
            bool ciclo = true;
            //In this section of the code, I use do while to check if the user inputs what the program needs, and it repeats until the given value is a valid value.
            //I use try catch to help me identify whether or not the given value is valid.
            do {
                try {
                    ciclo = true;
                    Console.WriteLine("Input the car brand: ");
                    brand = Console.ReadLine();
                }
                catch(Exception e){
                    ciclo = false;
                    Console.WriteLine($"Invalid value, please rewrite your answer: {e}");
                }
            } while (!ciclo);
            //I convert the string variables to double using the convert class.
            do {
                try {
                    ciclo = true;
                    Console.WriteLine("Input the travel distance (km): ");
                    scanner = Console.ReadLine();
                    distance = Convert.ToDouble(scanner);
                }
                catch(Exception e){
                    ciclo = false;
                    Console.WriteLine($"Invalid value, please rewrite your answer: {e}");
                }
            } while(!ciclo);
            
            do {
                try {
                    ciclo = true;
                    Console.WriteLine("Input the efficiency of the car: ");
                    scanner = Console.ReadLine();
                    efficiency = Convert.ToDouble(scanner);
                } 
                catch(Exception e){
                    ciclo = false;
                    Console.WriteLine($"Invalid value, please rewrite your answer {e}");
                }
            } while(!ciclo);
            /*I tried a different approach in this section of the activity. I made use of an
            exception that I created. The exception is thrown when the user inputs an invalid
            gasoline type. I made a switch statement on the ValidateGas function and I wrote some
            of the possible answers from the user as the cases.
            */
            do {
                try{
                    ciclo = true;
                    Console.WriteLine("Input the gas type (regular or premium): ");
                    gasType = Console.ReadLine();
                    ValidateGas(gasType);
                }
                catch(Exception e){
                    ciclo = false;
                    Console.WriteLine($"Invalid value, please rewrite your answer {e}");
                }
            } while (!ciclo);
            //If the gas type is regular, this part of the code is printed on the console.
            //I researched a different syntax of string interpolation and i found out that i can use N2 to round up to 2 decimals.
            if (gasType == "Regular" || gasType == "regular" || gasType == "REGULAR"){
                price = REGULAR_PRICE * distance / efficiency ;
                Console.Clear();
                Console.WriteLine("_______________________________________");
                Console.WriteLine("CAR TRIP COST\n");
                Console.WriteLine($"Car brand: {brand}");
                Console.WriteLine($"Distance (km): {distance}");
                Console.WriteLine($"Efficiency (km x liter): {efficiency}");
                Console.WriteLine($"Gast type: {gasType}");
                Console.WriteLine($"The cost of this trip for the {brand} car is: ${price:N2}");
            }
            //If the gas type is premium, this part of the code is printed on the console.
            else {
                price = PREMIUM_PRICE * distance / efficiency;
                Console.Clear();
                Console.WriteLine("_______________________________________");
                Console.WriteLine("CAR TRIP COST\n");
                Console.WriteLine($"Car brand: {brand}");
                Console.WriteLine($"Distance (km): {distance}");
                Console.WriteLine($"Efficiency (km x liter): {efficiency}");
                Console.WriteLine($"Gast type: {gasType}");
                Console.WriteLine($"The cost of this trip for the {brand} car is: ${price:N2}");
            }
        }
        //Class used to validate the gas type string.
        private static void ValidateGas(string name)
        {
            switch(name) {
                case "regular":
                break;
                case "Regular":
                break;
                case "REGULAR":
                break;
                case "premium":
                break;
                case "Premium":
                break;
                case "PREMIUM":
                break;
                default:
                throw new InvalidGasNameException(name);
            }
        }
    }
    //This is the exception that is thrown when the user inputs an invalid gas type, the ValidateGas function. It prints out the invalid gas type message.
    public class InvalidGasNameException : Exception
    {
        public InvalidGasNameException(string name) 
            :base(String.Format($"Invalid gas Type: {name}")) 
        { 

        }
    }
}