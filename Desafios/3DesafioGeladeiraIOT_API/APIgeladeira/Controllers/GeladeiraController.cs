using APIgeladeira.Models;
using Microsoft.AspNetCore.Mvc;

/*
using Geladeiraiot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
*/

namespace ApiGeladeira.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeladeiraController : ControllerBase
/*namespace Geladeiraiot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeladeiraController : ControllerBase    */
    {
        private readonly Geladeira geladeira;

        public GeladeiraController()
        {
            geladeira = new Geladeira();
        }


/*  {
        private static readonly Geladeira geladeira = new Geladeira();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(geladeira.Prateleiras);
        }
        */

        // GET: api/geladeira
        [HttpGet]
        public ActionResult<IEnumerable<Prateleira>> GetAllItens()
        {
            return geladeira.Prateleiras;
        }

        // GET: api/geladeira/5/1/2
        [HttpGet("{prateleiraId}/{containerId}/{posicaoId}")]
        public ActionResult<string> GetItemById(int prateleiraId, int containerId, int posicaoId)
        {
            try
            {
                return geladeira.Prateleiras[prateleiraId].Containers[containerId].Posicoes[posicaoId];
            }
            catch (IndexOutOfRangeException)
            {
                return NotFound();
            }
        }

        // POST: api/geladeira/5/1/2
        [HttpPost("{prateleiraId}/{containerId}/{posicaoId}")]
        public IActionResult AddItem(int prateleiraId, int containerId, int posicaoId, string item)
        {
            try
            {
                geladeira.Prateleiras[prateleiraId].Containers[containerId].Posicoes[posicaoId] = item;
                return Ok("Item adicionado com sucesso");
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest("Posição inválida");
            }
        }

        // PUT: api/geladeira/5/1/2
        [HttpPut("{prateleiraId}/{containerId}/{posicaoId}")]
        public IActionResult UpdateItem(int prateleiraId, int containerId, int posicaoId, string item)
        {
            // Implemente a lógica para atualizar um item
            // ...
            return Ok();
        }

        // DELETE: api/geladeira/5/1/2
        [HttpDelete("{prateleiraId}/{containerId}/{posicaoId}")]
        public IActionResult DeleteItem(int prateleiraId, int containerId, int posicaoId)
        {
            // Implemente a lógica para excluir um item
            // ...
            return Ok();
        }
    }
}

/*



  

        [HttpGet("{prateleira}/{container}/{posicao}")]
        public IActionResult GetById(int prateleira, int container, int posicao)
        {
            var item = geladeira.Prateleiras[prateleira].Containers[container].Posicoes[posicao];
            if (item == null)
                return NotFound("Item não encontrado.");
            
            return Ok(new { item, prateleira, container, posicao });
        }

        [HttpPost("{prateleira}/{container}")]
        public IActionResult Post(int prateleira, int container, [FromBody] string item)
        {
            var posicaoVazia = geladeira.Prateleiras[prateleira].Containers[container].Posicoes.ToList().IndexOf(null);
            if (posicaoVazia == -1)
                return BadRequest("Nenhuma posição vazia disponível.");

            geladeira.Prateleiras[prateleira].Containers[container].Posicoes[posicaoVazia] = item;
            return CreatedAtAction(nameof(GetById), new { prateleira, container, posicao = posicaoVazia }, item);
        }

        [HttpPut("{prateleira}/{container}/{posicao}")]
        public IActionResult Put(int prateleira, int container, int posicao, [FromBody] string item)
        {
            if (geladeira.Prateleiras[prateleira].Containers[container].Posicoes[posicao] == null)
                return NotFound("Posição vazia.");

            geladeira.Prateleiras[prateleira].Containers[container].Posicoes[posicao] = item;
            return NoContent();
        }

        [HttpDelete("{prateleira}/{container}/{posicao}")]
        public IActionResult Delete(int prateleira, int container, int posicao)
        {
            if (geladeira.Prateleiras[prateleira].Containers[container].Posicoes[posicao] == null)
                return NotFound("Posição já está vazia.");

            geladeira.Prateleiras[prateleira].Containers[container].Posicoes[posicao] = null;
            return NoContent();
        }
    }
}
*/