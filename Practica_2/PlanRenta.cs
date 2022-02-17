using System;

namespace Practica2{
    public class PlanRenta
    {
        public string NombreUsuario {get; set;}
        public int MinutosConsumidos {get; set;}
        public int MbConsumidos {get; set;}
        public int TipoCelular {get; set;}

        public PlanRenta(string NombreUsuario,int MinutosConsumidos,int MbConsumidos,int TipoCelular)
        {
            this.NombreUsuario = NombreUsuario;
            this.MinutosConsumidos = MinutosConsumidos;
            this.MbConsumidos = MbConsumidos;
            this.TipoCelular = TipoCelular;
        }

        
    }
}