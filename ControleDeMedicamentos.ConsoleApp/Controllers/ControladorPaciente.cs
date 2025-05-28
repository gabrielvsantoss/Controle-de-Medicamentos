using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using Microsoft.AspNetCore.Mvc;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("paciente")]
    public class ControladorPaciente : Controller
    {
        [HttpGet("visualizar")]
        public IActionResult VisualizarPacientes()
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);

            List<Paciente> pacientes = repositorioPaciente.SelecionarRegistros();
            ViewBag.Pacientes = pacientes;
            return View("Visualizar", pacientes);
        }

        [HttpGet("cadastrar")]
        public IActionResult ExibirFormularioCadastroPaciente()
        {
            return View("Cadastrar");
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarPaciente(Paciente novoPaciente)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);


            repositorioPaciente.CadastrarRegistro(novoPaciente);

            ViewBag.Mensagem = $"O paciente {novoPaciente.Nome} foi cadastrado com sucesso!";
            return View("Notificador");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult ExibirFormularioEdicaoFuncionario([FromRoute] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);

            Paciente pacienteSelecionado = repositorioPaciente.SelecionarRegistroPorId(id);
            EditarPacienteViewModel editarVM = new EditarPacienteViewModel(
           pacienteSelecionado.Id, pacienteSelecionado.Nome, pacienteSelecionado.Telefone, pacienteSelecionado.CartaoSus);

            return View("Editar", editarVM);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult EditarPaciente([FromRoute] int id, Paciente pacienteEditado)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);

            repositorioPaciente.EditarRegistro(id, pacienteEditado);

            ViewBag.Mensagem = $"O paciente {pacienteEditado.Nome} foi editado com sucesso!";
            return View("Notificador");
        }

        [HttpGet("excluir/{id:int}")]
        public IActionResult ExibirFormularioExclusaoPaciente([FromRoute] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);

            Paciente pacienteExcluido = repositorioPaciente.SelecionarRegistroPorId(id);

            ExcluirPacienteViewModel excluirVM =
            new ExcluirPacienteViewModel(pacienteExcluido.Id, pacienteExcluido.Nome);

            return View("Excluir", excluirVM);
        }

        [HttpPost("excluir/{id:int}")]
        public IActionResult ExcluirPaciente([FromRoute] int id)
        {
            ContextoDados contextoDados = new ContextoDados(true);
             IRepositorioPaciente repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);

            repositorioPaciente.ExcluirRegistro(id);

            ViewBag.Mensagem = $"O paciente foi excluido com sucesso!";

            return View("Notificador");
        }
    }
}
