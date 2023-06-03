using Agronegocio.Models;
using Agronegocio.Repository.Context;
using Agronegocio.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Agronegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentoController : Controller
    {
        private readonly AlimentoRepository alimentoRepository;

        public AlimentoController(DataBaseContext context)
        {
            alimentoRepository = new AlimentoRepository(context);
        }

        [HttpGet]
        public ActionResult<IList<AlimentoModel>> Get()
        {
            try
            {
                var lista = alimentoRepository.Listar();

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
        public ActionResult<AlimentoModel> Get([FromRoute] int id)
        {
            try
            {
                var alimentoModel = alimentoRepository.Consultar(id);

                if (alimentoModel != null)
                {
                    return Ok(alimentoModel);
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
        public ActionResult<AlimentoModel> Post([FromBody] AlimentoModel alimentoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                alimentoRepository.Inserir(alimentoModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + alimentoModel.AlimentoId);
                return Created(location, alimentoModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o alimento. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<AlimentoModel> Delete([FromRoute] int id)
        {
            try
            {
                var alimentoModel = alimentoRepository.Consultar(id);

                if (alimentoModel != null)
                {
                    alimentoRepository.Excluir(id);
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
        public ActionResult<AlimentoModel> Put([FromRoute] int id, [FromBody] AlimentoModel alimentoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (alimentoModel.AlimentoId != id)
            {
                return NotFound();
            }


            try
            {
                alimentoRepository.Alterar(alimentoModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o alimento. Detalhes: {error.Message}" });
            }
        }
    }
}
