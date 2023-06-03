using Agronegocio.Models;
using Agronegocio.Repository;
using Agronegocio.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agronegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioController(DataBaseContext context)
        {
            usuarioRepository = new UsuarioRepository(context);
        }

        [HttpGet]
        public ActionResult<IList<UsuarioModel>> Get()
        {
            try
            {
                var lista = usuarioRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<UsuarioModel> Get([FromRoute] int id)
        {
            try
            {
                var usuarioModel = usuarioRepository.Consultar(id);

                if (usuarioModel != null)
                {
                    return Ok(usuarioModel);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                usuarioRepository.Inserir(usuarioModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + usuarioModel.UsuarioId);
                return Created(location, usuarioModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o usuário. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UsuarioModel> Delete([FromRoute] int id)
        {
            try
            {
                var usuarioModel = usuarioRepository.Consultar(id);

                if (usuarioModel != null)
                {
                    usuarioRepository.Excluir(id);
                    // Retorno Sucesso.
                    // Efetuou a exclusão, porém sem necessidade de informar os dados.
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<UsuarioModel> Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (usuarioModel.UsuarioId != id)
            {
                return NotFound();
            }


            try
            {
                usuarioRepository.Alterar(usuarioModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o usuário. Detalhes: {error.Message}" });
            }
        }
    }
}
