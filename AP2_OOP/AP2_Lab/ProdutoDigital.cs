public class ProdutoDigital : Produto //ProdutoDigital está herdando a classe Produto
{
    public string formato { get; set; }  //criando um novo atributo formato 

    private double tamanhoDoArquivo;
    public double tamanhoArquivo { get {return tamanhoDoArquivo;}
    set
    {if (value <= 0) //caso o valor seja menor ou igual a zero, não permite a atribuição

        throw new ArgumentException("Dado inválido!");
        tamanhoDoArquivo = value;
        }
    }
    // tal codigo é classificado pelo ENCAPSULAMENTO, já que o mesmo controla seu proprio acesso e proteje seus dados via Private


    //Construtor que inicializa propriedades
    public ProdutoDigital(string Formato, string nome, decimal preco, double TamanhoArquivo) : base(nome, preco)
    {
        tamanhoArquivo = TamanhoArquivo;
        formato = Formato;
    }

    // Calculando o preço final com desconto para produtos digitais, pode ser classificado no POLIMORFISMO pois permite  que a classe filha tenha seu próprio comportamento
    public override decimal CalculoFinal()
    {
        decimal precoDesconto = Preco * 0.1m;
        decimal precoLiquido = Preco -  precoDesconto;
        return precoLiquido;
    }
}

