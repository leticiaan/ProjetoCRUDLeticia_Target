using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoCRUDLeticia_Target.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncController : ControllerBase
    {
        private static List<Funcionario> funcionarios = new List<Funcionario>
        {
                new Funcionario {
                    FuncId = 1,
                    FuncUsuario = "Leticia",
                    FuncNomeCompleto = "Letícia Antunes",                  
                    FuncNacionalidade = "Brasil",
                    FuncCargo = "Programadora"
                },
                new Funcionario {
                    FuncId = 2,
                    FuncUsuario = "Mariana",
                    FuncNomeCompleto = "Mariana Antunes",
                    FuncNacionalidade = "Brasil",
                    FuncCargo = "Suporte"
                }
        };



        [HttpGet]
        public async Task<ActionResult<List<Funcionario>>> Get()
        {
            return Ok(funcionarios);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Funcionario>> Get(int codigo)
        {
            var funcionario = funcionarios.Find(h => h.FuncId == codigo);
            if (funcionario == null)
                return BadRequest("Colaborador não encontrado!");
            return Ok(funcionario);
        }

        [HttpPost]

        public async Task<ActionResult<List<Funcionario>>> AdicionarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            return Ok(funcionarios);
        }

        [HttpPut]

        public async Task<ActionResult<List<Funcionario>>> EditarFuncionario(Funcionario chamada)
        {
            var funcionario = funcionarios.Find(h => h.FuncId == chamada.FuncId);
            if (funcionario == null)
                return BadRequest("Colaborador não encontrado!");

            funcionario.FuncId = chamada.FuncId;
            funcionario.FuncUsuario = chamada.FuncUsuario;
            funcionario.FuncNomeCompleto = chamada.FuncNomeCompleto;
            funcionario.FuncNacionalidade = chamada.FuncNacionalidade;
            funcionario.FuncCargo = chamada.FuncCargo;
            
            return Ok(funcionario);

        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult<List<Funcionario>>> ExcluirFuncionario(int codigo)
        {
            var funcionario = funcionarios.Find(h => h.FuncId == codigo);
            if (funcionario == null)
                return BadRequest("Colaborador não encontrado!");

            funcionarios.Remove(funcionario);
            return Ok(funcionario);
        }

    }
}
