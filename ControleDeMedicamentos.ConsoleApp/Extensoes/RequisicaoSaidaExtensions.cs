using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricoesMedicas;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesEntrada;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesSaida;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static class RequisicaoSaidaExtensions
    {
        public static DetalheRequisicaoSaidaViewModel ParaDetalheVM(this RequisicaoSaida requisicaoSaida)
        {

            return new DetalheRequisicaoSaidaViewModel
                (
                    requisicaoSaida.Id,
                    requisicaoSaida.dataRequisicaoSaida,
                    requisicaoSaida.paciente.Nome,
                    requisicaoSaida.medicamento.Nome,
                    requisicaoSaida.prescricaoMedica.Id
                );
        }

        public static RequisicaoSaida ParaEntidade(this CadastrarRequisicaoSaidaViewModel formularioVM, List<Paciente> pacientes, List<Medicamento> medicamentos, List<PrescricaoMedica> prescricaoMedicas)
        {
            Paciente pacienteSelecionado = null;
            Medicamento medicamentoSelecionado = null;
            PrescricaoMedica prescricaoMedicaSelecionada = null;

            foreach (var f in pacientes)
            {
                if (f.Id == formularioVM.PacienteId)
                {
                    pacienteSelecionado = f;
                }
            }

            foreach (var f in medicamentos)
            {
                if (f.Id == formularioVM.MedicamentoId)
                {
                    medicamentoSelecionado = f;
                }
            }  
            
            foreach (var f in prescricaoMedicas)
            {
                if (f.Id == formularioVM.PrescricaoMedicaId)
                {
                    prescricaoMedicaSelecionada = f;
                }
            }

            return new RequisicaoSaida
                (
                    formularioVM.DataRequisicaoSaida,
                    pacienteSelecionado,
                    medicamentoSelecionado,
                    prescricaoMedicaSelecionada
                );
        }
    }
}
