using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static  class FuncionarioExtensions
    {
        // Metodo de extensão 
        public static Funcionario ParaEntidade(this FormularioFabricanteViewModel formularioVM)
        {
            return new Funcionario(formularioVM.Nome, formularioVM.Telefone, formularioVM.CPF); 
        }

        public static DetalheFabricanteViewModel ParaDetalheViewModel(this Funcionario funcionario)
        {
            return new DetalheFabricanteViewModel(funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.CPF);
        }
    }
}
