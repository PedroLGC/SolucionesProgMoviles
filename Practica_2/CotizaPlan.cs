
using System;

namespace Practica2
{
    /*
    * Autor: Pedro Luis González Cernuda
    *
    * Programa que hace una cotización de un plan mensual de telefonía movil. 
    * El programa pide al cliente su nombre y la gama de celular que contrató 
    * y devuelve los megabytes y minutos consumidos y el pago a realizar.
    */
    public class CotizaPlan
    {
        public static void Main(string[] args)
        {
            string usuario = " ";
            int gama = 0;
            bool ciclo = true;
            PlanRenta plan;
            Console.WriteLine("COTIZACIÓN DE PLAN DE RENTA");
            do
            {
                ciclo = true;
                Console.Write("Introduzca su nombre: ");
                usuario = Console.ReadLine();
                if (usuario.Length > 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("El campo no puede ir vacio, vuelva a introducir el dato");
                    ciclo = false;
                }
            } while (!ciclo);

            do
            {
                ciclo = true;
                Console.Write("Introduzca la gama de su dispositivo 1.Gama baja 2.Gama media 3.Gama alta: ");
                try
                {
                    gama = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Dato inválido, vuelva a introducir el dato: {e.Message}");
                    ciclo = false;
                }
                if (gama < 1 || gama > 3)
                {
                    Console.WriteLine($"Solo puede elegir la opcion 1, 2 o 3");
                    ciclo=false;
                }
            } while (ciclo == false);

            plan = new PlanRenta(usuario, gama);
            plan.ConsumeMB(1000);
            plan.ConsumeMinutos(900);
            Console.Write(plan.ToString());
            Console.ReadKey();
        }
    }
}