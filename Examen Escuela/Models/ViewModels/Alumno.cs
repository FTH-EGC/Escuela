using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Escuela.Models.ViewModels
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string CURP { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public int Maestro_Generos_Id { get; set; }
        public string Domicilio { get; set; }
        public string Genero { get; set; }
        public int Genero_Id { get; set; }
        public int Municipio_Id { get; set; }
        public int Maestro_Materias_Id { get; set; }
    }
    public class Genero { 
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class Municipios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class Maestro_Materias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Response { 
       public string Respuesta { get; set; }
    }
    public class Profesor { 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string NombreCompleto { get; set; }
    }
}