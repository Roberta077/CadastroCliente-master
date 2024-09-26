namespace CadastroClientes.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public required string Logradouro { get; set; }
        public required string Numero { get; set; }
        public required string Cidade { get; set; }
        public required TipoEndereco TipoEndereco { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
 
 