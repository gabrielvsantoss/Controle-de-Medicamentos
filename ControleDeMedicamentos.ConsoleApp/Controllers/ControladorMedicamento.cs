using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("medicamentos")]
    public class ControladorMedicamento : Controller
    {
        public IActionResult visualizar() 
        {
            var contextoDados = new ContextoDados(true);
            IRepositorioMedicamento repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);

            List<Medicamento> medicamentos = repositorioMedicamento.SelecionarRegistros();

            VisualizarMedicamentosViewModel visualizarVM = new VisualizarMedicamentosViewModel(medicamentos);
            return View("visualizar", visualizarVM);
        }
    }
}
