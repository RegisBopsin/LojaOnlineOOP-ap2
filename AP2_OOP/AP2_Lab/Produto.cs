public abstract class Produto // classe abstrasta
{
    public string Nome { get; set; } //armazenando o nome do produto
    public string CodigoProduto { get; set; } //Codigo unico para cada produto
    public decimal Preco { get; set; } //armazenando o preço inicial  do produto
    public Produto(string nome, decimal preco) //Construtor
    {
        Nome = nome;
        Preco = preco;
        CodigoProduto = Guid.NewGuid().ToString(); //gerando codigo unico para a classe CódigoProduto
    }
    public abstract decimal CalculoFinal(); //metodo abstrato, classes herdeiras de Produto vão usar auma logica especifica  para calcular o preco final do produto
}
