using System.Collections.Generic;
 
namespace CadastroClientes.Domain.Entities

{

    public class Cliente

    {

        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required string CPF { get; set; } // Adicionando CPF

        public ICollection<Endereco> Enderecos { get; set; }
 
        public Cliente()

        {

            Enderecos = new List<Endereco>();

        }

    }

}

 