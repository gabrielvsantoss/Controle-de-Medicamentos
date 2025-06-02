using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("medicamentos")]
    public class ControladorMedicamento : Controller
    {
        [HttpGet("visualizar")]
        public IActionResult Visualizar() 
        {
            var contextoDados = new ContextoDados(true);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);

            var medicamentos = repositorioMedicamento.SelecionarRegistros();
            var visualizarVM = new VisualizarMedicamentosViewModel(medicamentos);

            return View("Visualizar", visualizarVM);
        }

        [HttpGet("cadastrar")]
        public IActionResult ExibirFormularioDeCadastroMedicamento()
        {
            var contextoDados = new ContextoDados(true);
            var repositorio = new RepositorioFornecedorEmArquivo(contextoDados);

            var fornecedores = repositorio.SelecionarRegistros();
            var cadastrarVM = new CadastrarMedicamentoViewModel(fornecedores);
            return View("Cadastrar", cadastrarVM);
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarMedicamento(CadastrarMedicamentoViewModel cadastrarVM)
        {
            var contextoDados = new ContextoDados(true);
            var repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);
            var repositorio = new RepositorioMedicamentoEmArquivo(contextoDados);

            Medicamento medicamento = cadastrarVM.ParaEntidade(repositorioFornecedor.SelecionarRegistros());
                
            repositorio.CadastrarRegistro(medicamento);
            return View("Cadastrar", cadastrarVM);
        }

        [HttpGet("editar/{Id:int}")]
        public IActionResult ExibirFormularioDeEdicaoMedicamento([FromRoute] int id)
        {

            
            var contextoDados = new ContextoDados(true);
            var repositorio = new RepositorioMedicamentoEmArquivo(contextoDados);
            var repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

            var medicamento = repositorio.SelecionarRegistroPorId(id);
            EditarMedicamentoViewModel editarVM = medicamento.ParaEditarVM();
            var fornecedores = repositorioFornecedor.SelecionarRegistros();
            editarVM.FornecedoresDisponiveis = fornecedores.ParaSelecionarFornecedorViewModel();
            return View("editar", editarVM);
        }

        [HttpPost("editar/{Id:int}")]
        public IActionResult EditarMedicamento([FromRoute] int id, EditarMedicamentoViewModel editarVM)
        {

            var contextoDados = new ContextoDados(true);
            var repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);

            var fornecedores = repositorioFornecedor.SelecionarRegistros();
            Medicamento medicamento = editarVM.ParaEntidade(repositorioFornecedor.SelecionarRegistros());

            repositorioMedicamento.EditarRegistro(id, medicamento);


            ViewBag.Mensagem = $"O medicamento {medicamento.Nome} foi editado com sucesso!";
            return View("Notificador");
        }

        [HttpGet("excluir/{Id:int}")]

        public IActionResult ExibirFormularioExclusaoMedicamento([FromRoute] int id)
        {


            var contextoDados = new ContextoDados(true);
            var repositorio = new RepositorioMedicamentoEmArquivo(contextoDados);

            var medicamento = repositorio.SelecionarRegistroPorId(id);

            ExcluirMedicamentoViewModel excluirVM = medicamento.ParaExcluirVM();
            return View("Excluir", excluirVM);
        }

        [HttpPost("excluir/{Id:int}")]
        public IActionResult ExcluirMedicamento([FromRoute] int id, ExcluirMedicamentoViewModel excluirVM)
        {

            var contextoDados = new ContextoDados(true);
            var repositorioMedicamento = new RepositorioMedicamentoEmArquivo(contextoDados);


            repositorioMedicamento.ExcluirRegistro(id);


            ViewBag.Mensagem = $"O medicamento foi excluido com sucesso!";
            return View("Notificador");
        }
    }
}
