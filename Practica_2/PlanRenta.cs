using System;

namespace Practica2
{
    /*
    * Autor: Pedro Luis González Cernuda
    *
    * Clase que contiene los métodos para calcular
    * el costo del plan telefónico y el método de impresión.
    */
    public class PlanRenta
    {
        public string NombreUsuario { get; set; }
        public int MinutosConsumidos { get; set; }
        public int MbConsumidos { get; set; }
        public int TipoCelular { get; set; }

        public PlanRenta(string NombreUsuario, int TipoCelular)
        {
            this.NombreUsuario = NombreUsuario;
            this.MinutosConsumidos = 0;
            this.MbConsumidos = 0;
            this.TipoCelular = TipoCelular;
        }

        public void ConsumeMinutos(int min)
        {
            this.MinutosConsumidos += min;
        }
        public void ConsumeMB(int mb)
        {
            this.MbConsumidos += mb;
        }
        public double CalculaPagoMensual()
        {
            double resultado;

            if (MinutosConsumidos >= 800 && MbConsumidos >= 1000)
            {
                resultado = 199 + (MinutosConsumidos - 800) * 0.25 + (MbConsumidos - 1000) * 0.35;
            }
            else if (MinutosConsumidos >= 800)
            {
                resultado = 199 + (MinutosConsumidos - 800) * 0.25;
            }
            else
            {
                resultado = 199 + (MbConsumidos - 1000) * 0.35;
            }
            if (resultado > 0)
                return resultado;
            return 0;
        }
        public double DiferenciaEquipo(int selector)
        {
            if (selector == 1)
            {
                return 0;
            }
            else if (selector == 2)
            {
                return 1999;
            }
            else
            {
                return 5999;
            }
        }
        public override string ToString()
        {
            return "\nRESULTADOS \n" +
            $"\nUsuario: {NombreUsuario} \nMinutos consumidos: {MinutosConsumidos} \nMB consumidos: {MbConsumidos} \n" +
             $"Renta mensual: {CalculaPagoMensual()} \nPago diferencial de su equipo: ${DiferenciaEquipo(TipoCelular)}";
        }
    }
}