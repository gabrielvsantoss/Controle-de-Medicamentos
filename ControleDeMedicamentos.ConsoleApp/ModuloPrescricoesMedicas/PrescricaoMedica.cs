using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ControleDeMedicamentos.ConsoleApp.ModuloPrescricoesMedicas
{
    public class PrescricaoMedica : EntidadeBase<PrescricaoMedica>
    {

        public List<Medicamento> Medicamentos2 { get; set; } = new List<Medicamento>();
        public string CRM { get; set; }
        public DateTime DataPrescricao { get; set; }
        public List<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();

        public PrescricaoMedica(string crm, DateTime dataPrescricao, List<Medicamento> medicamentos)
        {
            CRM = crm;
            DataPrescricao = dataPrescricao;
            Medicamentos = medicamentos;
        }

        public override void AtualizarRegistro(PrescricaoMedica registroEditado)
        {
            CRM = registroEditado.CRM;
            DataPrescricao = registroEditado.DataPrescricao;
            Medicamentos = registroEditado.Medicamentos;
        }

        public override string Validar()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(CRM))
                erros += "O campo CRM é obrigatório.\n";
            else if (!Regex.IsMatch(CRM, @"^\d{6}$"))
                erros += "O campo CRM deve conter exatamente 6 digitos numericos.\n";


            if (DataPrescricao == default)
                erros += "A data de prescricao é invalida.\n";
            else if (DataPrescricao > DateTime.Today)
                erros += "A data de prescricao não pode ser futura.\n";

                return erros;
        }
    }
}
