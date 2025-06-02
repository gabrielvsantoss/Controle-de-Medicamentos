 using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using Microsoft.AspNetCore.Mvc;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.Extensoes;

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

            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarRegistros();

            VisualizarFuncionariosViewModel visualizarVM = new VisualizarFuncionariosViewModel(funcionarios);
            return View("Visualizar", visualizarVM);
         }

        [HttpGet("cadastrar")]
        public IActionResult ExibirFormularioCadastroFuncionario()
        {
            CadastrarFuncionarioViewModel cadastrarVM = new CadastrarFuncionarioViewModel();

            return View("Cadastrar" , cadastrarVM);
        }   

        [HttpPost("cadastrar")]
        public IActionResult CadastrarFuncionario(CadastrarFuncionarioViewModel cadastrarVM)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            Funcionario novoFuncionario =  cadastrarVM.ParaEntidade();
            repositorioFuncionario.CadastrarRegistro(novoFuncionario);

            ViewBag.Mensagem = $"O funcionário {novoFuncionario.Nome} foi cadastrado com sucesso!";   
            return View("Notificador");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult ExibirFormularioEdicaoFuncionario([FromRoute] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarRegistroPorId(id);
            EditarFuncionarioViewModel editarVM = new EditarFuncionarioViewModel(
           funcionarioSelecionado.Id, funcionarioSelecionado.Nome, funcionarioSelecionado.Telefone, funcionarioSelecionado.CPF);

            
            return View("Editar", editarVM);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult EditarFuncionario([FromRoute] int id, Funcionario funcionarioEditado)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            repositorioFuncionario.EditarRegistro(id, funcionarioEditado);

            ViewBag.Mensagem = $"O funcionário {funcionarioEditado.Nome} foi editado com sucesso!";
            return View("Notificador");
        }

        [HttpGet("excluir/{id:int}")]
        public IActionResult ExibirFormularioExclusaoFuncionario([FromRoute] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
            
            Funcionario funcionarioExcluido = repositorioFuncionario.SelecionarRegistroPorId(id);

            ExcluirFuncionarioViewModel excluirVM =
            new ExcluirFuncionarioViewModel(funcionarioExcluido.Id, funcionarioExcluido.Nome);

            return View("Excluir", excluirVM);
        }

        [HttpPost("excluir/{id:int}")]
        public IActionResult ExcluirFuncionario([FromRoute] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            repositorioFuncionario.ExcluirRegistro(id);

            ViewBag.Mensagem = $"O funcionário foi excluido com sucesso!";

            return View("Notificador");
        }
    }
}
