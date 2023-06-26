using backend_proyecto_final_gpds.Connection;
using backend_proyecto_final_gpds.Dominio;
using backend_proyecto_final_gpds.Servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend_proyecto_final_gpds.Controllers
{
    [EnableCors("DevelopmentCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        #endregion Fields

        #region Constructors
        public UsuarioController(IConfiguration configuration)
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
                var result = UsuarioServicios.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetUsuarioById(int id)
        {
            try
            {
                var result = UsuarioServicios.GetById<Usuario>(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUsuario")]
        public IActionResult Insert(Usuario usuario)
        {
            try
            {
                var result = UsuarioServicios.Insert(usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateUsuario")]
        public IActionResult Update(Usuario usuario)
        {
            try
            {
                var result = UsuarioServicios.Update(usuario);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("DeleteUsuario")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = UsuarioServicios.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("RecoverUsuario")]
        public IActionResult Recover(int id)
        {
            try
            {
                var result = UsuarioServicios.Recover(id);
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