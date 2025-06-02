using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Models
{
    public abstract class FormularioMedicamentoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int FornecedorId { get; set; }

        public List<SelecionarFornecedorViewModel> FornecedoresDisponiveis { get; set; }

        protected FormularioMedicamentoViewModel()
        {
            FornecedoresDisponiveis = new List<SelecionarFornecedorViewModel>();
        }
    }

    public class SelecionarFornecedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public SelecionarFornecedorViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    } 
    public class CadastrarMedicamentoViewModel : FormularioMedicamentoViewModel
    {
        public CadastrarMedicamentoViewModel()
        {

        }
        public CadastrarMedicamentoViewModel (List<Fornecedor> fornecedores)
        {
            foreach (Fornecedor fornecedor in fornecedores)
            {
                var fornecedorVM = new SelecionarFornecedorViewModel(fornecedor.Id, fornecedor.Nome);
                FornecedoresDisponiveis.Add(fornecedorVM);
            }
        }
    }

    public class EditarMedicamentoViewModel : FormularioMedicamentoViewModel
    {
        public int Id { get; set; }
        public EditarMedicamentoViewModel()
        {
            
        }
        public EditarMedicamentoViewModel(int id, string nome, string descricao, int fornecedorId)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            FornecedorId = fornecedorId;
        }
    }
    public class VisualizarMedicamentosViewModel
    {
        public List<DetalheMedicamentoViewModel> Registros { get; set; }

        public VisualizarMedicamentosViewModel(List<Medicamento> medicamentos)
        {
            Registros = new List<DetalheMedicamentoViewModel>();

            foreach (Medicamento m in medicamentos)
            {
                DetalheMedicamentoViewModel detalheVM = m.ParaDetalheVM();

                Registros.Add(detalheVM);
            }
        }
    }

    public class DetalheMedicamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string NomeFornecedor { get; set;}

        public DetalheMedicamentoViewModel(int id, string nome, string descricao, 
            int quantidadeEmEstoque, string nomeFornecedor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            NomeFornecedor = nomeFornecedor;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome} | Descrição: {Descricao}               | Quantidade em Estoque: {QuantidadeEmEstoque} | Fabricante: {NomeFornecedor}";
        }
    }
}
