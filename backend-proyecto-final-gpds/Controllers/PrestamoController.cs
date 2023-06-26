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
    public class PrestamoController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors
        public PrestamoController(IConfiguration configuration)
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
                var result = PrestamoServicios.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetPrestamoById(int id)
        {
            try
            {
                var result = PrestamoServicios.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddPrestamo")]
        public IActionResult Insert(Prestamo prestamo)
        {
            try
            {
                var result = PrestamoServicios.Insert(prestamo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdatePrestamo")]
        public IActionResult Update(Prestamo prestamo)
        {
            try
            {
                var result = PrestamoServicios.Update(prestamo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("DeletePrestamo")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = PrestamoServicios.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("RecoverPrestamo")]
        public IActionResult Recover(int id)
        {
            try
            {
                var result = PrestamoServicios.Recover(id);
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
