
using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;

namespace ControleDeMedicamentos.ConsoleApp.Models
{
    public abstract class FormularioFabricanteViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
    }
    public class ExcluirFuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ExcluirFuncionarioViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
    public class EditarFuncionarioViewModel : FormularioFabricanteViewModel
    {
        public int Id { get; set; }
        public EditarFuncionarioViewModel(int id, string nome, string telefone, string cpf)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
        }
    }
    public class CadastrarFuncionarioViewModel : FormularioFabricanteViewModel
    {
        public CadastrarFuncionarioViewModel()
            {

            }
        public CadastrarFuncionarioViewModel(string nome, string telefone, string cpf) : this()
            {
                Nome = nome;
                Telefone = telefone;
                CPF = cpf;
            }
    }
    public class VisualizarFuncionariosViewModel
    {
        public List<DetalheFuncionarioViewModel> registros { get; } = new List<DetalheFuncionarioViewModel>();
        public VisualizarFuncionariosViewModel(List<Funcionario> fabricantes)
        {
           foreach(Funcionario f in fabricantes)
            {
                DetalheFuncionarioViewModel detalhesVM =  f.ParaDetalheViewModel();
                registros.Add(detalhesVM);
            } 
        }
    }
    public class DetalheFuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public DetalheFuncionarioViewModel(int id, string nome, string telefone, string cpf)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Nome: {Nome} | Telefone: {Telefone} | CPF: {CPF} |";
        }
    }
}



