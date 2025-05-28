using System.Reflection.Metadata.Ecma335;

namespace ControleDeMedicamentos.ConsoleApp.Models
{
    public class ExcluirPacienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ExcluirPacienteViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
    public class EditarPacienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CartaoSus { get; set; }

        public EditarPacienteViewModel(int id, string nome, string telefone, string cartaoSus)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CartaoSus = cartaoSus;
        }
    }
}
