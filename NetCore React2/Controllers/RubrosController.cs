using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_React2.Data;
using NetCore_React2.Models;

namespace NetCore_React2.Controllers

{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RubrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RubrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        //[HttpGet("Rubros/BuscarRubros")]

        public JsonResult BuscarRubros()
        {
            var rubros = _context.Rubros.ToList();

            return Json(rubros);
        }
        public JsonResult GuardarRubro(int RubroID, string Descripcion)
        {
            bool resultado = true;

            if (!string.IsNullOrEmpty(Descripcion))
            {

                if (RubroID == 0)
                {
                    //CREA EL REGISTRO DE RUBRO
                    //PARA ESO CREAMOS UN OBJETO DE TIPO RUBRO CON LOS DATOS NECESARIOS
                    var rubro = new Rubro
                    {
                        Descripcion = Descripcion
                    };
                    _context.Add(rubro);
                    _context.SaveChanges();
                }
                else
                {
                    //EDITA EL REGISTRO
                    //BUSCAMOS EL REGISTRO EN LA BASE DE DATOS
                    var rubro = _context.Rubros.Single(m => m.RubroID == RubroID);
                    //CAMBIAMOS LA DESCRIPCIÓN POR LA QUE INGRESÓ EL USUARIO EN LA VISTA
                    rubro.Descripcion = Descripcion;
                    _context.SaveChanges();
                }

            }


            return Json(resultado);
        }
    }
}
