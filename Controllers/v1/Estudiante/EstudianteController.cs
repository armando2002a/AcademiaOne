using Microsoft.AspNetCore.Mvc;
using Servicio.Estudiante;

namespace Academia.Controllers.v1.Estudiante
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteServicio _estudianteServicio;

        public EstudianteController(IEstudianteServicio estudianteServicio)
        {
            _estudianteServicio = estudianteServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Datos.Models.Estudiante> lista = new List<Datos.Models.Estudiante>();
            
            var result = _estudianteServicio.ListaEstudiantes();

            return Ok(result);

        }


    }
}
