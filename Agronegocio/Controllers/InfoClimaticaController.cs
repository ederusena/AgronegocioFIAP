using Agronegocio.Models;
using Agronegocio.Repository.Context;
using Agronegocio.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agronegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoClimaticaController : Controller
    {
        private readonly InfoClimaticaRepository infoClimaticaRepository;

        public InfoClimaticaController(DataBaseContext context)
        {
            infoClimaticaRepository = new InfoClimaticaRepository(context);
        }

        [HttpGet]
        public ActionResult<IList<InfoClimaticaModel>> Get()
        {
            try
            {
                var lista = infoClimaticaRepository.Listar();

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
        public ActionResult<InfoClimaticaModel> Get([FromRoute] int id)
        {
            try
            {
                var infoClimaticaModel = infoClimaticaRepository.Consultar(id);

                if (infoClimaticaModel != null)
                {
                    return Ok(infoClimaticaModel);
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
        public ActionResult<InfoClimaticaModel> Post([FromBody] InfoClimaticaModel infoClimaticaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                infoClimaticaRepository.Inserir(infoClimaticaModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + infoClimaticaModel.InfoClimaticaId);
                return Created(location, infoClimaticaModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a informação climática. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<InfoClimaticaModel> Delete([FromRoute] int id)
        {
            try
            {
                var infoClimaticaModel = infoClimaticaRepository.Consultar(id);

                if (infoClimaticaModel != null)
                {
                    infoClimaticaRepository.Excluir(id);
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
        public ActionResult<InfoClimaticaModel> Put([FromRoute] int id, [FromBody] InfoClimaticaModel infoClimaticaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (infoClimaticaModel.InfoClimaticaId != id)
            {
                return NotFound();
            }


            try
            {
                infoClimaticaRepository.Alterar(infoClimaticaModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a informação climática. Detalhes: {error.Message}" });
            }
        }
    }
}
