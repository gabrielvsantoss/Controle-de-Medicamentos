using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricoesMedicas;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicoesSaida;

namespace ControleDeMedicamentos.ConsoleApp.Models
{
    public abstract class FormularioRequisicaoSaidaViewModel
    {
        public DateTime DataRequisicaoSaida { get; set; }
        public int PacienteId { get; set; }
        public int MedicamentoId { get; set; }
        public int PrescricaoMedicaId { get; set; }
        public List<SelecionarPacienteViewModel> PacientesDisponiveis { get; set; }
        public List<SelecionarMedicamentoViewModel> MedicamentosDisponiveis { get; set; }
        public List<SelecionarPrescricaoMedicaViewModel> PrescricoesMedicasDisponiveis { get; set; }
        protected FormularioRequisicaoSaidaViewModel()
        {
            PacientesDisponiveis = new List<SelecionarPacienteViewModel>();
            MedicamentosDisponiveis = new List<SelecionarMedicamentoViewModel>();
            PrescricoesMedicasDisponiveis = new List<SelecionarPrescricaoMedicaViewModel>();
    }
}
    public class VisualizarRequisicoesSaidaViewModel
    {
        public List<DetalheRequisicaoSaidaViewModel> Registros { get; set; }

        public VisualizarRequisicoesSaidaViewModel(List<RequisicaoSaida> requisicoesSaida)
        {
            Registros = new List<DetalheRequisicaoSaidaViewModel>();

            foreach (RequisicaoSaida m in requisicoesSaida)
            {
                DetalheRequisicaoSaidaViewModel detalheVM = m.ParaDetalheVM();

                Registros.Add(detalheVM);
            }
        }

    }

    public class DetalheRequisicaoSaidaViewModel
    {
        public int Id { get; set; }
        public DateTime DataRequisicaoSaida { get; set; }
        public string NomePaciente { get; set; }
        public string NomeMedicamento { get; set; }
        public int IdPrescricaoMedica{ get; set; }

        public DetalheRequisicaoSaidaViewModel(int id, DateTime dataRequisicaoSaida, string nomePaciente,
            string nomeMedicamento, int idPrescricaoMedica)
        {
            Id = id;
            DataRequisicaoSaida = dataRequisicaoSaida;
            NomePaciente = nomePaciente;
            NomeMedicamento = NomeMedicamento;
            IdPrescricaoMedica = idPrescricaoMedica;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Data: {DataRequisicaoSaida.ToShortDateString()} | Paciente: {NomePaciente} | Medicamento: {NomeMedicamento} | ID Prescrição: {IdPrescricaoMedica}";
        }
    }

    public class SelecionarPrescricaoMedicaViewModel
    {
        public int Id { get; set; }
        public SelecionarPrescricaoMedicaViewModel(int id)
        {
            Id = id;
        }
    }

    public class CadastrarRequisicaoSaidaViewModel : FormularioRequisicaoSaidaViewModel
    {
        public CadastrarRequisicaoSaidaViewModel()
        {

        }
        public CadastrarRequisicaoSaidaViewModel(List<Paciente> pacientes, List<Medicamento> medicamentos, List<PrescricaoMedica> prescricaoMedicas)
        {
            foreach (Paciente paciente in pacientes)
            {
                var pacienteVM = new SelecionarPacienteViewModel(paciente.Id, paciente.Nome);
                PacientesDisponiveis.Add(pacienteVM);
            }

            foreach (Medicamento medicamento in medicamentos)
            {
                var medicamentoVM = new SelecionarMedicamentoViewModel(medicamento.Id, medicamento.Nome);
                MedicamentosDisponiveis.Add(medicamentoVM);
            }   
        

            foreach (PrescricaoMedica prescricaoMedica in prescricaoMedicas)
            {
                var prescricaoMedica2 = new SelecionarPrescricaoMedicaViewModel(prescricaoMedica.Id);
                PrescricoesMedicasDisponiveis.Add(prescricaoMedica2);
            }
        }
    }

}
