using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_Escuela.Models;
using System.Linq;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Examen_Escuela.Classes;
using Examen_Escuela.Models.ViewModels;

namespace Examen_Escuela.Controllers
{
    public class EscuelaController : Controller
    {

        SQL sql = new SQL();

        // GET: Escuela
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GET_Students() {


            DataTable dtAlumnos = sql.spGetData(new string[] { "@Accion:" + "GET_Students" });

            List<Alumno> AlumnosReturned = dtAlumnos.AsEnumerable().Select(a => new Alumno { 
                Nombre = Convert.IsDBNull(a["Nombre"]) ? "" : (string)a["Nombre"],
                Apellido_Paterno = Convert.IsDBNull(a["Apellido_Paterno"]) ? "" : (string)a["Apellido_Paterno"],
                Apellido_Materno = Convert.IsDBNull(a["Apellido_Materno"]) ? "" : (string)a["Apellido_Materno"],
                CURP = Convert.IsDBNull(a["CURP"]) ? "" : (string)a["CURP"],
                Telefono = Convert.IsDBNull(a["Telefono"]) ? "" : (string)a["Telefono"],
                Correo = Convert.IsDBNull(a["Correo"]) ? "" : (string)a["Correo"],
                Edad = Convert.IsDBNull(a["Edad"]) ? 0 : (int)a["Edad"],
                Domicilio = Convert.IsDBNull(a["Domicilio"]) ? "" : (string)a["Domicilio"],
                Municipio = Convert.IsDBNull(a["Municipio"]) ? "" : (string)a["Municipio"],
                Genero = Convert.IsDBNull(a["Genero"]) ? "" : (string)a["Genero"],
                Genero_Id = Convert.IsDBNull(a["Genero_Id"]) ? 0 : (int)a["Genero_Id"],

            }).ToList();

            var data = Json(AlumnosReturned, JsonRequestBehavior.AllowGet);

            data.MaxJsonLength = int.MaxValue;

            return data;
        }

        public JsonResult Get_Generos() {
            try {

                DataTable DTGeneros = sql.spGetData(new string[] { "@Accion:" + "GET_Generos" });
                List<Genero> LGeneros = DTGeneros.AsEnumerable().Select(a => new Genero { 
                    Id = Convert.IsDBNull(a["Id"]) ? 0 : (int)a["Id"],
                    Nombre = Convert.IsDBNull(a["Nombre"]) ? "" : (string)a["Nombre"]
                }).ToList();


                var data = Json(LGeneros, JsonRequestBehavior.AllowGet);

                data.MaxJsonLength = int.MaxValue;

                return data;

            }
            catch (Exception Ex) {
                return null;
            }
        }


    }
}