using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesEntrada;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("ControladorRequisicaoEntrada")]

    public class  ControladorR: Controller
    {
        [HttpGet("visualizar")]
        public IActionResult Visualizar()
        {
            var contextoDados = new ContextoDados(true);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
            var repositorioRequisicaoEntrada = new RepositorioRequisicaoEntradaEmArquivo(
                contextoDados, repositorioMedicamento);

            var requisicoesEntrada = repositorioRequisicaoEntrada.SelecionarRegistros();
            var visualizarVM = new VisualizarRequisicaoesEntradaViewModel(requisicoesEntrada);
            return View("Visualizar", visualizarVM);
        }

        [HttpGet("cadastrar")]
        public IActionResult ExibirFormularioDeCadastroRequisicaoEntrada()
        {
            var contextoDados = new ContextoDados(true);
            var repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);

            var funcionarios = repositorioFuncionario.SelecionarRegistros();
            var medicamentos = repositorioMedicamento.SelecionarRegistros();

            var cadastrarVM = new CadastrarRequisicaoEntradaViewModel(funcionarios, medicamentos);
            return View("Cadastrar", cadastrarVM);
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarRequisicaoEntrada(CadastrarRequisicaoEntradaViewModel cadastrarVM)
        {
            var contextoDados = new ContextoDados(true);
            var repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
            var repositorio = new RepositorioRequisicaoEntradaEmArquivo(contextoDados, repositorioMedicamento);

            var funcionarios = repositorioFuncionario.SelecionarRegistros();
            var medicamentos = repositorioMedicamento.SelecionarRegistros();

            RequisicaoEntrada requisicaoEntrada = cadastrarVM.ParaEntidade(funcionarios, medicamentos);

            repositorio.CadastrarRegistro(requisicaoEntrada);
            return View("Cadastrar", cadastrarVM);
        }


    }
}
