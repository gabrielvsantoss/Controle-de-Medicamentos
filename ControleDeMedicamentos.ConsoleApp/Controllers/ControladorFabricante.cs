using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.ConsoleApp.Controllers
{
    [Route("funcionario")]
    public class ControladorFabricante : Controller
    {
        [HttpGet("visualizar")]
         public IActionResult VisualizarFabricantes()
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            string conteudo = System.IO.File.ReadAllText("ModuloFuncionarios/Html/Visualizar.html");
            StringBuilder sb = new StringBuilder(conteudo);
            foreach (Funcionario funcionario in repositorioFuncionario.SelecionarRegistros())
            {
                string item = $"<li>{funcionario.ToString()} <a href='/funcionario/editar/{funcionario.Id}'> Editar </a> | <a href='/funcionario/excluir/{funcionario.Id}'> Excluir </a> #funcionario# </l1>";
                sb.Replace("#funcionario#", item);
            }

            sb.Replace("#funcionario#", "");
            conteudo = sb.ToString();
            
            return Content(conteudo, "text/html");
         }
    }
}
