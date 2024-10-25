public class Cliente
{
    private String nome;
    private String endereco;
    private string identifica;
    public Contato contatoConta { get; set; }

    public string Nome { get{return nome;} 
    set
    {
        if(string.IsNullOrEmpty(value))
        throw new ArgumentException("Dado inválido!");
        nome = value;
        }
    }

    public string Endereco { get{return endereco;} 
    set
    {
        if(string.IsNullOrEmpty(value))
        throw new ArgumentException("Dado inválido!");
        endereco = value;
        }
    }

    public string Identifica { get{return identifica;} 
    set
    {
        if(string.IsNullOrEmpty(value))
        throw new ArgumentException("Dado inválido!");  
        identifica = value;
       }
    }

    public struct Contato
    {
        public string telefone { get; set; }
        public string email { get; set; }
            public Contato(string telefone, string email)
            {
                if (string.IsNullOrEmpty(telefone))
                throw new ArgumentException("Dado inválido!");
                if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Dado inválido!");

                this.telefone = telefone;
                this.email = email; //verificar o this. caso algo anormal aconteça
            }
    }

    public Cliente(string nome, string endereco, string identifica, Contato contato)
    {
        Nome = nome;
        Endereco = endereco;
        Identifica = identifica;
        contatoConta = contato;
    }


    public void ExibirInformacoes()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Endereço: {Endereco}");
        Console.WriteLine($"Id: {Identifica}");
        Console.WriteLine($"Telefone: {contatoConta.telefone}");
        Console.WriteLine($"Email: {contatoConta.email}");
    }
}


