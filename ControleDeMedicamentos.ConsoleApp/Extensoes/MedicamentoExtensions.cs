using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static class MedicamentoExtensions
    {
        public static Medicamento ParaEntidade(
        this FormularioMedicamentoViewModel formularioVM, List<Fornecedor> fornecedores)
        {
            Fornecedor fornecedorSelecionado = null;

            foreach(var f in fornecedores)
            {
                if(f.Id ==  formularioVM.FornecedorId)
                {
                    fornecedorSelecionado = f;
                }
            }
            return new Medicamento
                (
                    formularioVM.Nome,
                    formularioVM.Descricao,
                    formularioVM.QuantidadeEmEstoque,
                    fornecedorSelecionado
                );
        }
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

        public static EditarMedicamentoViewModel ParaEditarVM(this Medicamento medicamento)
        {
            return new EditarMedicamentoViewModel
                (
                    medicamento.Id,
                    medicamento.Nome,
                    medicamento.Descricao,
                    medicamento.Fornecedor.Id
                );
        }
         
        public static List<SelecionarFornecedorViewModel> ParaSelecionarFornecedorViewModel(this List <Fornecedor> fornecedores)
        {
            List<SelecionarFornecedorViewModel> fornecedoresVM = new List<SelecionarFornecedorViewModel>();
            foreach (Fornecedor fornecedor in fornecedores)
            {
                var fornecedorVM = new SelecionarFornecedorViewModel(fornecedor.Id, fornecedor.Nome);
                fornecedoresVM.Add(fornecedorVM);
            }
            return fornecedoresVM;
        }

        public static ExcluirMedicamentoViewModel ParaExcluirVM(this Medicamento medicamento)
        {
            return new ExcluirMedicamentoViewModel
                (
                     medicamento.Id,
                    medicamento.Nome
                );
        }

    }
}
