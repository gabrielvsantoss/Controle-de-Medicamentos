using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesEntrada;

namespace ControleDeMedicamentos.ConsoleApp.Models
{
    public abstract class FormularioRequisicaoEntradaViewModel
    {
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int FuncionarioId { get; set; }
        public int MedicamentoId { get; set; }
        public DateTime Data { get; set; } 

        public List<SelecionarFuncionarioViewModel> FuncionariosDisponiveis { get; set; }
        public List<SelecionarMedicamentoViewModel> MedicamentosDisponiveis { get; set; }

        protected FormularioRequisicaoEntradaViewModel()
        {
            FuncionariosDisponiveis = new List<SelecionarFuncionarioViewModel>();
            MedicamentosDisponiveis = new List<SelecionarMedicamentoViewModel>();
        }
    }

    public class SelecionarFuncionarioViewModel
    {
       public  int Id { get; set; }
       public string Nome { get; set; }

        public SelecionarFuncionarioViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
    public class SelecionarMedicamentoViewModel
    {
       public int Id { get; set; }
       public string Nome { get; set; }

        public SelecionarMedicamentoViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class VisualizarRequisicaoesEntradaViewModel
    {
        public List<DetalheRequisicaoEntradaViewModel> Registros { get; set; }

        public VisualizarRequisicaoesEntradaViewModel(List<RequisicaoEntrada> requisicoesEntrada)
        {
            Registros = new List<DetalheRequisicaoEntradaViewModel>();

            foreach (RequisicaoEntrada m in requisicoesEntrada)
            {
                DetalheRequisicaoEntradaViewModel detalheVM = m.ParaDetalheVM();

                Registros.Add(detalheVM);
            }
        }
    }

    public class CadastrarRequisicaoEntradaViewModel : FormularioRequisicaoEntradaViewModel
    {
        public CadastrarRequisicaoEntradaViewModel()
        {

        }
        public CadastrarRequisicaoEntradaViewModel(List<Funcionario> funcionarios, List<Medicamento> medicamentos)
        {
            foreach (Funcionario funcionario in funcionarios)
            {
                var funcionarioVM = new SelecionarFuncionarioViewModel(funcionario.Id, funcionario.Nome);
                FuncionariosDisponiveis.Add(funcionarioVM);
            }   

            foreach (Medicamento medicamento in medicamentos)
            {
                var medicamentoVM = new SelecionarMedicamentoViewModel(medicamento.Id, medicamento.Nome);
                MedicamentosDisponiveis.Add(medicamentoVM);
            }
        }
    }

    public class DetalheRequisicaoEntradaViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string NomeMedicamento { get; set; }
        public string NomeFuncionario { get; set; }
        public int Quantidade { get; set; }

        public DetalheRequisicaoEntradaViewModel(int id, DateTime data, string nomeMedicamento,
            string nomeFuncionario, int quantidade)
        {
            Id = id;
            Data = data;
            NomeMedicamento = nomeMedicamento;
            NomeFuncionario = nomeFuncionario;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Data: {Data.ToShortDateString()} | Medicamento: {NomeMedicamento} | Funcionario: {NomeFuncionario} | Quantidade: {Quantidade}";
        }
    }
}
    

