using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Models
{
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
            return $"ID: {Id}, Nome: {Nome} | Descrição: {Descricao} | Quantidade em Estoque: {QuantidadeEmEstoque} | Fabricante: {NomeFornecedor}";
        }
    }
}
