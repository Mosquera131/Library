using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clasesdeApi.Models;

    public class Propietario
    {
        public int Id {get;set;}

        public required string Nombre {get;set;}

        public required string Apellido {get;set;}
        public required string NumerodeIdentificacion {get;set;}
        public required string Direccion {get;set;}
        public required string Telefono {get;set;}
        public required string Correo{get;set;}
    }
