using System.Security.Cryptography.Xml;
using System.Text;
using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesSaida;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            WebApplication app = builder.Build();

            app.MapGet("/", PaginaInicial);
            app.MapGet("/funcionario/cadastrar", ExibirFormularioCadastroFuncionario);
            app.MapPost("/funcionario/cadastrar", CadastrarFuncionario);

            app.MapGet("/funcionario/editar/{id:int}", ExibirFormularioEdicaoFuncionario);
            app.MapPost("/funcionario/editar/{id:int}", EditarFuncionario);  

            app.MapGet("/funcionario/excluir/{id:int}", ExibirFormularioExclusaoFuncionario);
            app.MapPost("/funcionario/excluir/{id:int}", ExcluirFuncionario);

            app.MapGet("/funcionario/visualizar", VisualizarFabricantes);
            app.Run();
        }
        static Task ExibirFormularioExclusaoFuncionario(HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarRegistroPorId(id);
            string conteudo = File.ReadAllText("ModuloFuncionarios/Html/Excluir.html");
            StringBuilder sb = new StringBuilder(conteudo);

            sb.Replace("#id#", id.ToString());
            sb.Replace("#funcionario#", funcionarioSelecionado.Nome);

            conteudo = sb.ToString();

            return context.Response.WriteAsync(conteudo);
        }
        static Task ExcluirFuncionario(HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
            int id = Convert.ToInt32(context.GetRouteValue("id"));

            repositorioFuncionario.ExcluirRegistro(id);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificador.html");
            StringBuilder sb = new StringBuilder(conteudo);
            sb.Replace("#mensagem#", "Funcionário excluído com sucesso!");

            conteudo = sb.ToString();
            return context.Response.WriteAsync(conteudo);
        }
        static Task ExibirFormularioEdicaoFuncionario (HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
            int id = Convert.ToInt32(context.GetRouteValue("id"));

            Funcionario funcionarioSelecionado = repositorioFuncionario.SelecionarRegistroPorId(id);
            string conteudo = File.ReadAllText("ModuloFuncionarios/Html/Editar.html");
            StringBuilder sb = new StringBuilder(conteudo);

            sb.Replace("#id#", id.ToString());
            sb.Replace("#nome#", funcionarioSelecionado.Nome);
            sb.Replace("#telefone#", funcionarioSelecionado.Telefone);
            sb.Replace("#cpf#", funcionarioSelecionado.CPF);

            conteudo = sb.ToString();

            return context.Response.WriteAsync(conteudo);
        } 
        static Task EditarFuncionario (HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);
            int id = Convert.ToInt32(context.GetRouteValue("id"));

            string nome = context.Request.Form["nome"].ToString();
            string telefone = context.Request.Form["telefone"].ToString();
            string cpf = context.Request.Form["cpf"].ToString();

            Funcionario funcionarioEditado = new Funcionario(nome, telefone, cpf);

            repositorioFuncionario.EditarRegistro(id, funcionarioEditado);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificador.html");

            StringBuilder sb = new StringBuilder(conteudo);

            sb.Replace("#mensagem#", "Funcionario editado com sucesso!");

            conteudo = sb.ToString();

            return context.Response.WriteAsync(conteudo);
        }
        static Task VisualizarFabricantes(HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            string conteudo = File.ReadAllText("ModuloFuncionarios/Html/Visualizar.html");
            StringBuilder sb = new StringBuilder(conteudo);
            foreach (Funcionario funcionario in repositorioFuncionario.SelecionarRegistros())
            {
                string item = $"<li>{funcionario.ToString()} <a href='/funcionario/editar/{funcionario.Id}'> Editar </a> | <a href='/funcionario/excluir/{funcionario.Id}'> Excluir </a> #funcionario# </l1>";
                sb.Replace("#funcionario#", item);
            }
            sb.Replace("#funcionario#", "");
            conteudo = sb.ToString();
            return context.Response.WriteAsync(conteudo);
        }
        static Task CadastrarFuncionario(HttpContext context)
        {
            ContextoDados contextoDados = new ContextoDados(true);
            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioEmArquivo(contextoDados);

            string nome = context.Request.Form["nome"].ToString();
            string telefone = context.Request.Form["telefone"].ToString();
            string cpf = context.Request.Form["cpf"].ToString();

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);
            repositorioFuncionario.CadastrarRegistro(funcionario);

            string conteudo = File.ReadAllText("Compartilhado/Html/Notificador.html");

            StringBuilder sb = new StringBuilder(conteudo);
            sb.Replace("#mensagem#", $"Funcionário {nome} cadastrado com sucesso!");

            conteudo = sb.ToString();
            return context.Response.WriteAsync(conteudo);
        }
        static Task PaginaInicial(HttpContext context)
        {
            string conteudo = File.ReadAllText("Compartilhado/Html/PaginaInicial.html");
            return context.Response.WriteAsync(conteudo);
        } 
        static Task ExibirFormularioCadastroFuncionario(HttpContext context)
        {
            string conteudo = File.ReadAllText("ModuloFuncionarios/Html/Cadastrar.html");
            return context.Response.WriteAsync(conteudo);
        }
    }
}
    