using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesEntrada;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static class RequisicaoEntradaExtensions
    {
        public static DetalheRequisicaoEntradaViewModel ParaDetalheVM(this RequisicaoEntrada requisaoEntrada)
        {

            return new DetalheRequisicaoEntradaViewModel
                (
                    requisaoEntrada.Id, 
                    requisaoEntrada.Data,
                    requisaoEntrada.Medicamento.Nome,
                    requisaoEntrada.Funcionario.Nome,
                    requisaoEntrada.Quantidade
                );
        }


        public static RequisicaoEntrada ParaEntidade(this CadastrarRequisicaoEntradaViewModel formularioVM, List<Funcionario> funcionarios, List<Medicamento>  medicamentos)
        {
            Funcionario funcionarioSelecionado = null;
            Medicamento medicamentoSelecionado = null;

            foreach (var f in funcionarios)
            {
                if (f.Id == formularioVM.FuncionarioId)
                {
                    funcionarioSelecionado = f;
                }
            }   
            
            foreach (var f in medicamentos)
            {
                if (f.Id == formularioVM.MedicamentoId)
                {
                    medicamentoSelecionado = f;
                }
            }
            return new RequisicaoEntrada 
                (
                    formularioVM.Data,
                    medicamentoSelecionado,
                    funcionarioSelecionado,
                    formularioVM.QuantidadeEmEstoque
                );
        }
    }
}
