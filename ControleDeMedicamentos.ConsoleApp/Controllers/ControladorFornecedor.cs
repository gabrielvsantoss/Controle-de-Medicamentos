using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
   
    
        [Route("fornecedor")]
        public class ControladorFornecedor : Controller
        {
            [HttpGet("visualizar")]
            public IActionResult VisualizarFornecedores()
            {
                ContextoDados contextoDados = new ContextoDados(true);
                IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

                List<Fornecedor> fornecedores = repositorioFornecedor.SelecionarRegistros();
                ViewBag.Fornecedor = fornecedores;
                return View("Visualizar", fornecedores);
            }

            [HttpGet("cadastrar")]
            public IActionResult ExibirFormularioCadastroFornecedor()
            {
                return View("Cadastrar");
            }

            [HttpPost("cadastrar")]
            public IActionResult CadastrarFornecedor(Fornecedor novoFornecedor)
            {
                ContextoDados contextoDados = new ContextoDados(true);
                IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);


                repositorioFornecedor.CadastrarRegistro(novoFornecedor);

                ViewBag.Mensagem = $"O fornecedor {novoFornecedor.Nome} foi cadastrado com sucesso!";
                return View("Notificador");
            }

            [HttpGet("editar/{id:int}")]
            public IActionResult ExibirFormularioEdicaoFornecedor([FromRoute] int id)
            {
                ContextoDados contextoDados = new ContextoDados(true);
                IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

                Fornecedor fornecedorSelecionado = repositorioFornecedor.SelecionarRegistroPorId(id);
                EditarFornecedorViewModel editarVM = new EditarFornecedorViewModel(
               fornecedorSelecionado.Id, fornecedorSelecionado.Nome, fornecedorSelecionado.Telefone, fornecedorSelecionado.CNPJ);

                return View("Editar", editarVM);
            }

            [HttpPost("editar/{id:int}")]
            public IActionResult EditarFornecedor([FromRoute] int id, Fornecedor fornecedorEditado)
            {
                ContextoDados contextoDados = new ContextoDados(true);
                IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

                repositorioFornecedor.EditarRegistro(id, fornecedorEditado);

                ViewBag.Mensagem = $"O fornecedor {fornecedorEditado.Nome} foi editado com sucesso!";
                return View("Notificador");
            }

            [HttpGet("excluir/{id:int}")]
            public IActionResult ExibirFormularioExclusaoFornecedor([FromRoute] int id)
            {
                ContextoDados contextoDados = new ContextoDados(true);
                IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

                Fornecedor fornecedorExcluido = repositorioFornecedor.SelecionarRegistroPorId(id);

                ExcluirFornecedorViewModel excluirVM =
                new ExcluirFornecedorViewModel(fornecedorExcluido.Id, fornecedorExcluido.Nome);

                return View("Excluir", excluirVM);
            }

            [HttpPost("excluir/{id:int}")]
            public IActionResult ExcluirFornecedor([FromRoute] int id)
            {
                ContextoDados contextoDados = new ContextoDados(true);
                IRepositorioFornecedor repositorioFornecedor = new RepositorioFornecedorEmArquivo(contextoDados);

                repositorioFornecedor.ExcluirRegistro(id);

                ViewBag.Mensagem = $"O fornecedor foi excluido com sucesso!";

                return View("Notificador");
            }
        }
    }



