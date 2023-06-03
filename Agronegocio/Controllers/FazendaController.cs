using Agronegocio.Models;
using Agronegocio.Repository.Context;
using Agronegocio.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agronegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FazendaController : Controller
    {
        private readonly FazendaRepository fazendaRepository;

        public FazendaController(DataBaseContext context)
        {
            fazendaRepository = new FazendaRepository(context);
        }

        [HttpGet]
        public ActionResult<IList<FazendaModel>> Get()
        {
            try
            {
                var lista = fazendaRepository.Listar();

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
        public ActionResult<FazendaModel> Get([FromRoute] int id)
        {
            try
            {
                var fazendaModel = fazendaRepository.Consultar(id);

                if (fazendaModel != null)
                {
                    return Ok(fazendaModel);
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
        public ActionResult<FazendaModel> Post([FromBody] FazendaModel fazendaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                fazendaRepository.Inserir(fazendaModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + fazendaModel.FazendaId);
                return Created(location, fazendaModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a fazenda. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<FazendaModel> Delete([FromRoute] int id)
        {
            try
            {
                var fazendaModel = fazendaRepository.Consultar(id);

                if (fazendaModel != null)
                {
                    fazendaRepository.Excluir(id);
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
        public ActionResult<FazendaModel> Put([FromRoute] int id, [FromBody] FazendaModel fazendaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (fazendaModel.FazendaId != id)
            {
                return NotFound();
            }


            try
            {
                fazendaRepository.Alterar(fazendaModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a fazenda. Detalhes: {error.Message}" });
            }
        }
    }
}
