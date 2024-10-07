using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clasesdeApi.Models;

    public class Vehiculo
    {
        public int Id {get;set;}

        public required string Marca{get;set;}

        public required string Modelo {get;set;}
        public required int Ano {get;set;}
        public required string  Color {get;set;}
        public required string TipoVehiculo {get;set;}
    }
