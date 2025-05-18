 using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("funcionario")]
    public class ControladorFuncionario : Controller 
    {
        [HttpGet("visualizar")]
         public IActionResult VisualizarFuncionarios()
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            ViewBag.Funcionarios = repositorioFuncionario.SelecionarRegistros();
            return View("Visualizar");
         }

        [HttpGet("cadastrar")]
        public IActionResult ExibirFormularioCadastroFuncionario()
        {
            return View("Cadastrar");
        }   

        [HttpPost("cadastrar")]
        public IActionResult CadastrarFuncionario([FromForm] string nome, [FromForm] string telefone, [FromForm] string cpf)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);
            repositorioFuncionario.CadastrarRegistro(funcionario);

            ViewBag.Mensagem = $"O funcionário {funcionario.Nome} foi cadastrado com sucesso!";   
            return View("Notificacao");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult ExibirFormularioEdicaoFuncionario([FromRoute] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarRegistroPorId(id);

            ViewBag.Funcionario = funcionarioSelecionado;
            return View("Editar");
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult EditarFuncionario([FromRoute] int id, [FromForm] string nome, [FromForm] string telefone, [FromForm] string cpf)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            Funcionario funcionarioEditado = new Funcionario(nome, telefone, cpf);

            repositorioFuncionario.EditarRegistro(id, funcionarioEditado);

            ViewBag.Mensagem = $"O funcionário {funcionarioEditado.Nome} foi editado com sucesso!";
            return View("Notificacao");
        }

        [HttpGet("excluir/{id:int}")]
         public IActionResult ExibirFormularioExclusaoFuncionario([FromForm] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);


            ViewBag.Funcionario = repositorioFuncionario.SelecionarRegistroPorId(id);
            return View("Excluir");
        }

        [HttpPost("excluir/{id:int}")]
        public IActionResult ExcluirFuncionario([FromForm] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            repositorioFuncionario.ExcluirRegistro(id);

            string conteudo = System.IO.File.ReadAllText("Compartilhado/Html/Notificador.html");
            StringBuilder sb = new StringBuilder(conteudo);
            sb.Replace("#mensagem#", "Funcionário excluído com sucesso!");

            conteudo = sb.ToString();
            return Content(conteudo, "text/html");
        }

    }
}
