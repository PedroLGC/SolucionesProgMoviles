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
            double price = 0.0;
            double distance = 0.0;
            double efficiency = 0.0;
            //BOOLEAN FOR WHILE CONDITION.
            bool ciclo = true;
            //In this section of the code, I use do while to check if the user inputs what the program needs, and it repeats until the given value is a valid value.
            //I use try catch to help me identify whether or not the given value is valid.
            do {
                try {
                    Console.WriteLine("Input the car brand: ");
                    brand = Console.ReadLine();
                }
                catch(Exception e){
                    ciclo = false;
                    Console.WriteLine($"Invalid value, please rewrite your answer: {e}");
                }
            } while (!ciclo);

            do {
                try {
                    Console.WriteLine("Input the travel distance (km): ");
                    distance = Double.Parse(Console.ReadLine());
                }
                catch(Exception e){
                    ciclo = false;
                    Console.WriteLine($"Invalid value, please rewrite your answer: {e}");
                }
            } while(!ciclo);
            
            do {
                try {
                    Console.WriteLine("Input the efficiency of the car: ");
                    efficiency = Double.Parse(Console.ReadLine());
                } 
                catch(Exception e){
                    ciclo = false;
                    Console.WriteLine($"Invalid value, please rewrite your answer {e}");
                }
            } while(!ciclo);

            do {
                try{
                    Console.WriteLine("Input the gas type (regular or premium): ");
                    gasType = Console.ReadLine();
                }catch(Exception e){
                    ciclo = false;
                    Console.WriteLine($"Invalid value, please rewrite your answer {e}");
                }
            } while (ciclo==false && ((gasType == "Regular" || gasType == "regular" || gasType == "REGULAR") || (gasType == "Premium" || gasType == "premium" || gasType == "PREMIUM")));

            if (gasType == "Regular" || gasType == "regular" || gasType == "REGULAR"){
                price = REGULAR_PRICE * distance / efficiency ;
                Console.Clear();
                Console.WriteLine("_______________________________________");
                Console.WriteLine("CAR TRIP COST\n");
                Console.WriteLine($"Car brand: {brand}");
                Console.WriteLine($"Distance (km): {distance}");
                Console.WriteLine($"Efficiency (km x liter): {efficiency}");
                Console.WriteLine($"Gast type: {gasType}");
                Console.WriteLine($"The cost of this trip for the {brand} car is: ${price}");
            }
            else {
                price = PREMIUM_PRICE * distance / efficiency;
                price = Math.Truncate(price);
                Console.Clear();
                Console.WriteLine("_______________________________________");
                Console.WriteLine("CAR TRIP COST\n");
                Console.WriteLine($"Car brand: {brand}");
                Console.WriteLine($"Distance (km): {distance}");
                Console.WriteLine($"Efficiency (km x liter): ");
                Console.WriteLine($"Gast type: {gasType}");
                Console.WriteLine($"The cost of this trip for the {brand} car is: ${price:N2}");
            }
        }
    }
}