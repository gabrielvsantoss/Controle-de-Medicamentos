using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricoesMedicas;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesSaida;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("RequisicaoSaida")]
    public class ControladorRequisicaoSaida: Controller
    {
        [HttpGet("Visualizar")]
        public IActionResult Visualizar()
        {
            var contexto = new ContextoDados(true);

            var repositorioRequisicaoSaida = new RepositorioRequisicaoSaidaEmArquivo(contexto);
            var requisicoesSaida = repositorioRequisicaoSaida.SelecionarRegistros();

            var visualizarVM = new VisualizarRequisicoesSaidaViewModel(requisicoesSaida);
            return View("Visualizar", visualizarVM);
        }

        [HttpGet("Cadastrar")]
        public IActionResult ExibirFormularioDeCadastroRequisicaoSaida()
        {
            var contextoDados = new ContextoDados(true);
            var repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
            var repositorioPrescricaoMedica = new RepositorioPrescricaoMedicaEmArquivo(contextoDados);

            var pacientes = repositorioPaciente.SelecionarRegistros();
            var medicamentos = repositorioMedicamento.SelecionarRegistros();
            var prescricoesMedicas = repositorioPrescricaoMedica.SelecionarRegistros();

            var cadastrarVM = new CadastrarRequisicaoSaidaViewModel(pacientes, medicamentos, prescricoesMedicas);
            return View("Cadastrar", cadastrarVM);
        }

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarRequisicaoSaida(CadastrarRequisicaoSaidaViewModel cadastrarVM)
        {
            var contextoDados = new ContextoDados(true);
            var repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
            var repositorioPrescricaoMedica = new RepositorioPrescricaoMedicaEmArquivo(contextoDados);
            var repositorio = new RepositorioRequisicaoSaidaEmArquivo(contextoDados);

            var pacientes = repositorioPaciente.SelecionarRegistros();
            var medicamentos = repositorioMedicamento.SelecionarRegistros();
            var prescricoesMedicas = repositorioPrescricaoMedica.SelecionarRegistros();

            RequisicaoSaida requisicaoSaida = cadastrarVM.ParaEntidade(pacientes, medicamentos, prescricoesMedicas);

            repositorio.CadastrarRegistro(requisicaoSaida);
            ViewBag.Mensagem = $"A Requisição de Saida foi cadastrada com sucesso!";
            return View("Notificador");
        }
    }
}
