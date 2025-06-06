using ControleDeMedicamentos.ConsoleApp.Models;
using ControleDeMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricoesMedicas;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesEntrada;

namespace ControleDeMedicamentos.ConsoleApp.Extensoes
{
    public static class PrescricaoMedicaExtensions
    {
        public static DetalhePrescricaoMedicaViewModel ParaDetalheVM(this PrescricaoMedica prescricaoMedica)
        {

            return new DetalhePrescricaoMedicaViewModel
                (
                    prescricaoMedica.Id,
                    prescricaoMedica.CRM,
                    prescricaoMedica.DataPrescricao,
                    prescricaoMedica.Medicamentos
                );
        }

        public static PrescricaoMedica ParaEntidade
            (
                this CadastrarPrescricaoMedicaViewModel cadastrarVM,
                List<Paciente> pacientes, List<Medicamento> medicamentos
            )
        {
            Paciente pacienteSelecionado = null;
            Medicamento medicamentoSelecionado = null;

            foreach (var f in pacientes)
            {
                if (f.Id == cadastrarVM.PacienteId)
                {
                    pacienteSelecionado = f;
                }
            }

            foreach (var f in medicamentos)
            {
                if (f.Id == cadastrarVM.MedicamentoId)
                {
                    medicamentoSelecionado = f;
                }
            }


             return new PrescricaoMedica
                (
                    cadastrarVM.CRM,
                    cadastrarVM.DataPrescricao,
                    cadastrarVM.medicamentosPrescricao
                );
        }
    }
}

