using ControleDeMedicamentos.ConsoleApp.Extensoes;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using ControleDeMedicamentos.ConsoleApp.ModuloPrescricoesMedicas;

namespace ControleDeMedicamentos.ConsoleApp.Models
{
    public abstract class FormularioPrescricaoMedicaViewModel
    {
        public string CRM { get; set; }
        public DateTime DataPrescricao { get; set; }
        public List<Medicamento> medicamentosPrescricao { get; set; }
        public int PacienteId { get; set; }
        public int MedicamentoId { get; set; }
        public List<SelecionarMedicamentoViewModel> MedicamentosDisponiveis { get; set; }
        public List<SelecionarPacienteViewModel> PacientesDisponiveis { get; set; }

        protected FormularioPrescricaoMedicaViewModel()
        {
            MedicamentosDisponiveis = new List<SelecionarMedicamentoViewModel>();
            PacientesDisponiveis = new List<SelecionarPacienteViewModel>();
        }
    }
    public class VisualizarPrescricoesMedicasViewModel
    {
        public List<DetalhePrescricaoMedicaViewModel> Registros { get; set; }

        public VisualizarPrescricoesMedicasViewModel(List<PrescricaoMedica> prescricaoMedicas)
        {
            Registros = new List<DetalhePrescricaoMedicaViewModel>();

            foreach (PrescricaoMedica m in prescricaoMedicas)
            {
                DetalhePrescricaoMedicaViewModel detalheVM = m.ParaDetalheVM();

                Registros.Add(detalheVM);
            }
        }
    }
        
    public class DetalhePrescricaoMedicaViewModel
    {
        public int Id { get; set; }
        public string CRM { get; set; }
        public DateTime DataPrescricao { get; set; }
        public List<Medicamento> Medicamentos { get; set; }
        public DetalhePrescricaoMedicaViewModel(int id, string crm, DateTime dataPrescricao, List<Medicamento> medicamentos)
        {
            Id = id;
            CRM = crm;
            DataPrescricao = dataPrescricao;
            Medicamentos = medicamentos;
        }

        public override string ToString()
        {
            return $"ID: {Id}, CRM: {CRM}, Data Prescrição: {DataPrescricao.ToShortDateString()}, Medicamento: {Medicamentos[0].Nome} ";
        }

    }

    public class SelecionarPacienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public SelecionarPacienteViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class CadastrarPrescricaoMedicaViewModel : FormularioPrescricaoMedicaViewModel
    {

        public CadastrarPrescricaoMedicaViewModel() : base()
        { 
        }
        public CadastrarPrescricaoMedicaViewModel(List<Medicamento> medicamentos, List<Paciente> pacientes) : this()
        {
            foreach (var m in medicamentos)
            {
                SelecionarMedicamentoViewModel medicamento = new SelecionarMedicamentoViewModel(m.Id, m.Nome);
                MedicamentosDisponiveis.Add(medicamento);
            }

            foreach (var p in pacientes)
            {
                SelecionarPacienteViewModel paciente = new SelecionarPacienteViewModel(p.Id, p.Nome);
                PacientesDisponiveis.Add(paciente);
            }
        }
    }
}

