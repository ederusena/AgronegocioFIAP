using Agronegocio.Models;
using Agronegocio.Repository.Context;
using Agronegocio.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agronegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoloController : Controller
    {
        private readonly SoloRepository soloRepository;

        public SoloController(DataBaseContext context)
        {
            soloRepository = new SoloRepository(context);
        }

        [HttpGet]
        public ActionResult<IList<SoloModel>> Get()
        {
            try
            {
                var lista = soloRepository.Listar();

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
        public ActionResult<SoloModel> Get([FromRoute] int id)
        {
            try
            {
                var soloModel = soloRepository.Consultar(id);

                if (soloModel != null)
                {
                    return Ok(soloModel);
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
        public ActionResult<SoloModel> Post([FromBody] SoloModel soloModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                soloRepository.Inserir(soloModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + soloModel.SoloId);
                return Created(location, soloModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o solo. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<SoloModel> Delete([FromRoute] int id)
        {
            try
            {
                var soloModel = soloRepository.Consultar(id);

                if (soloModel != null)
                {
                    soloRepository.Excluir(id);
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
        public ActionResult<SoloModel> Put([FromRoute] int id, [FromBody] SoloModel soloModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (soloModel.SoloId != id)
            {
                return NotFound();
            }


            try
            {
                soloRepository.Alterar(soloModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o solo. Detalhes: {error.Message}" });
            }
        }
    }
}
