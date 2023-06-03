using Agronegocio.Models;
using Agronegocio.Repository.Context;
using Agronegocio.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agronegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : Controller
    {
        private readonly PlanoRepository planoRepository;

        public PlanoController(DataBaseContext context)
        {
            planoRepository = new PlanoRepository(context);
        }

        [HttpGet]
        public ActionResult<IList<PlanoModel>> Get()
        {
            try
            {
                var lista = planoRepository.Listar();

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
        public ActionResult<PlanoModel> Get([FromRoute] int id)
        {
            try
            {
                var planoModel = planoRepository.Consultar(id);

                if (planoModel != null)
                {
                    return Ok(planoModel);
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
        public ActionResult<PlanoModel> Post([FromBody] PlanoModel planoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                planoRepository.Inserir(planoModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + planoModel.PlanoId);
                return Created(location, planoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o plano. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<PlanoModel> Delete([FromRoute] int id)
        {
            try
            {
                var planoModel = planoRepository.Consultar(id);

                if (planoModel != null)
                {
                    planoRepository.Excluir(id);
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
        public ActionResult<PlanoModel> Put([FromRoute] int id, [FromBody] PlanoModel planoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (planoModel.PlanoId != id)
            {
                return NotFound();
            }


            try
            {
                planoRepository.Alterar(planoModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o plano. Detalhes: {error.Message}" });
            }
        }
    }
}
