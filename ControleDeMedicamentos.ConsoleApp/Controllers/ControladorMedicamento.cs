using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("medicamentos")]
    public class ControladorMedicamento : Controller
    {
        [HttpGet("visualizar")]
        public IActionResult visualizar() 
        {
            var contextoDados = new ContextoDados(true);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);

            var medicamentos = repositorioMedicamento.SelecionarRegistros();
            var visualizarVM = new VisualizarMedicamentosViewModel(medicamentos);

            return View("Visualizar", visualizarVM);
        }
    }
}
