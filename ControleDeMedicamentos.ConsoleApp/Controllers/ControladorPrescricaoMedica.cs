using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricoesMedicas;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("PrescricaoMedica")]
    public class ControladorPrescricaoMedica : Controller
    {
        [HttpGet("Visualizar")]
        public IActionResult Visualizar()
        {
            var contextoDados = new ContextoDados(true);
            var repositorio = new RepositorioPrescricaoMedicaEmArquivo(contextoDados);
        

            var prescricaoMedicas = repositorio.SelecionarRegistros();
            var visualizarVM = new VisualizarPrescricoesMedicasViewModel(prescricaoMedicas);
            return View("Visualizar", visualizarVM);
        }

        [HttpGet("Cadastrar")]
        public IActionResult ExibirFormularioDeCadastroPrescricaoMedica()
        {
            var contextoDados = new ContextoDados(true);
            var repositorio = new RepositorioPrescricaoMedicaEmArquivo(contextoDados);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
            var repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);

            var medicamentos = repositorioMedicamento.SelecionarRegistros();
            var pacientes = repositorioPaciente.SelecionarRegistros();

            CadastrarPrescricaoMedicaViewModel cadastrarVM = new CadastrarPrescricaoMedicaViewModel(medicamentos, pacientes);

            return View("Cadastrar", cadastrarVM);
        } 
        
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarPrescricaoMedica(CadastrarPrescricaoMedicaViewModel cadastrarVM)
        {
            var contextoDados = new ContextoDados(true);
            var repositorio = new RepositorioPrescricaoMedicaEmArquivo(contextoDados);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);
            var repositorioPaciente = new RepositorioPacienteEmArquivo(contextoDados);

            var medicamentos = repositorioMedicamento.SelecionarRegistros();
            var pacientes  = repositorioPaciente.SelecionarRegistros();

            PrescricaoMedica prescricaoMedica = cadastrarVM.ParaEntidade(pacientes, medicamentos);

            repositorio.CadastrarRegistro(prescricaoMedica);
            ViewBag.Mensagem = $"A prescrição foi cadastrada com sucesso!";
            return View("Notificador");
        }

    }
 }


