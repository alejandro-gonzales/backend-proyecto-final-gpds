using backend_proyecto_final_gpds.Connection;
using backend_proyecto_final_gpds.Dominio;
using backend_proyecto_final_gpds.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend_proyecto_final_gpds.Controllers
{
    [EnableCors("DevelopmentCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors
        public LibroController(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString =
            _configuration["SqlConnectionString:DefaultConnection"];
            DBManager.Instance.ConnectionString = connectionString;
        }
        #endregion Constructors

        #region Methods
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = LibroServicios.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetLibroById(int id)
        {
            try
            {
                var result = LibroServicios.GetById<Libro>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddLibro")]
        public IActionResult Insert(Libro libro)
        {
            try
            {
                var result = LibroServicios.Insert(libro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateLibro")]
        public IActionResult Update(Libro libro)
        {
            try
            {
                var result = LibroServicios.Update(libro);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("DeleteLibro")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = LibroServicios.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("RecoverLibro")]
        public IActionResult Recover(int id)
        {
            try
            {
                var result = LibroServicios.Recover(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion Methods
    }
}
