using Core.Interfaces;
using Core.Repository;
using Domain.Common;
using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOLSoftwareRest.Controllers
{
    /// <summary>
    /// Controlador de Condicion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]   
    public class UsuarioController : ControllerBase
    {



       private readonly ISender _sender;

        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        public UsuarioController(ISender _sender, IUserService userService)
        {
            this._sender = _sender;
            this._userService = userService;
        }




        [HttpGet, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listproducto = await _userService.GetAll();  
                return Ok(listproducto);
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        [HttpGet, Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var producto = await _userService.GetId(id);
                if (producto is not null)
                    return Ok(producto);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        /// <summary>
        /// Metodo de crear el usuario     
        /// </summary>
        [HttpPost, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] UsuarioRequest pruebaSeleccionRequest)
        {
            try
            {
                var result = await _sender.Send(pruebaSeleccionRequest);
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        /// <summary>
        /// Metodo de actualizar el usuario     
        /// </summary>

        [HttpPut, Route("[action]")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest pruebaSeleccionUpdateRequest)
        {
            try
            {
                var result = await _sender.Send(pruebaSeleccionUpdateRequest);
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        /// <summary>
        /// Metodo de eliminar el usuario     
        /// </summary>

        [HttpDelete, Route("[action]/{id}")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _sender.Send(new UserDeleteRequest(){Id_usuario = id });
                if (result is not null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
