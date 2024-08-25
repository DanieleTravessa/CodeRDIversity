using APIgeladeira.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiGeladeira.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeladeiraController : ControllerBase

    {
        private readonly Geladeira geladeira;

        public GeladeiraController()
        {
            geladeira = new Geladeira();
        }

        // GET: api/geladeira
        [HttpGet("listar-itens")]
        public ActionResult<IEnumerable<Prateleiras>> GetAllItens()
        {
            return geladeira.Prateleiras;
        }

        // GET: api/geladeira/5/1/2
        [HttpGet("pegar-item")] //{prateleiraId}/{containerId}/{posicaoId}
        public ActionResult<string> GetItemById(int prateleiraId, int containerId, int posicaoId)
//        public IActionResult GetById(int prateleira, int container, int posicao)
        {
            try
            {
                return geladeira.Prateleiras[prateleiraId].Containers[containerId].Posicoes[posicaoId];
            }
            catch (IndexOutOfRangeException)
            {
                return NotFound("Item não encontrado.");
            }
        }
        
        // POST: api/geladeira/5/1/2
        [HttpPost("inserir-item")]//{prateleiraId}/{containerId}/{posicaoId}
        public IActionResult AddItem(int prateleiraId, int containerId, int posicaoId, string item)
        {
            try
            {
                geladeira.Prateleiras[prateleiraId].Containers[containerId].Posicoes[posicaoId] = item;
            //var posicaoVazia = geladeira.Prateleiras[prateleira].Containers[container].Posicoes.ToList().IndexOf(null);
                return Ok("Item adicionado com sucesso");
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest("Posição inválida");
            }
            //
            //if (posicaoVazia == -1)
            //geladeira.Prateleiras[prateleira].Containers[container].Posicoes[posicaoVazia] = item;
            //return CreatedAtAction(nameof(GetById), new { prateleira, container, posicao = posicaoVazia }, item);
                return BadRequest("Nenhuma posição vazia disponível.");         
            //
        }

        // PUT: api/geladeira/5/1/2
        [HttpPut("atualizar-itens-vencidos")]//{prateleiraId}/{containerId}/{posicaoId}
        public IActionResult UpdateItem(int prateleiraId, int containerId, int posicaoId, string item)
        {
            {
            if (geladeira.Prateleiras[prateleiraId].Containers[containerId].Posicoes[posicaoId] == null)
                return NotFound("Posição vazia.");

            geladeira.Prateleiras[prateleiraId].Containers[containerId].Posicoes[posicaoId] = item;
            return NoContent();
            }
            // ...
            return Ok();
        }

        // DELETE: api/geladeira/5/1/2
        [HttpDelete("remover-itens")]//{prateleiraId}/{containerId}/{posicaoId}
        public IActionResult DeleteItem(int prateleiraId, int containerId, int posicaoId)
        {
            if (geladeira.Prateleiras[prateleiraId].Containers[containerId].Posicoes[posicaoId] == null)
                return NotFound("Posição já está vazia.");

            geladeira.Prateleiras[prateleiraId].Containers[containerId].Posicoes[posicaoId] = null;
            return NoContent();
        
            return Ok();
        }
    }
}