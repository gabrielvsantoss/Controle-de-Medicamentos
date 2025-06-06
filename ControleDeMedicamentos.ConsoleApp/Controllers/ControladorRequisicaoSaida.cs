using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesEntrada;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("RequisicaoSaida")]
    public class ControladorRequisicaoSaida: Controller
    {
        [HttpGet("Visualizar")]
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
    }
}
