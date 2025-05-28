using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static class MedicamentoExtensions
    {
        public static DetalheMedicamentoViewModel ParaDetalheVM(this Medicamento medicamento)
        {
            return new DetalheMedicamentoViewModel
                (
                    medicamento.Id,
                    medicamento.Nome, 
                    medicamento.Descricao,
                    medicamento.QuantidadeEmEstoque, 
                    medicamento.Fornecedor.Nome
                );
        }
    }
}
