
namespace ControleDeMedicamentos.ConsoleApp.Models
{
    public class ExcluirFornecedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ExcluirFornecedorViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
    public class EditarFornecedorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }

        public EditarFornecedorViewModel(int id, string nome, string telefone, string cnpj)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            CNPJ = cnpj;
        }
    }
}
