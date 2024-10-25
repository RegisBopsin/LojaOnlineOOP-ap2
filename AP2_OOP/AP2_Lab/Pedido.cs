public class Pedido : ICarreavel //Pedido herdando da interface ICarriavel
{
    public Cliente Cliente { get; private set; }
    public DateTime DataPedido { get; private set; }
    public StPedido Status { get; private set; }
    public List<Produto> Produtos { get; set; }

    public Pedido(Cliente cliente)
    {
        cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        DataPedido = DateTime.Now;
        Status = StPedido.Pendente;
        Produtos = new List<Produto>();
    }

    public void adicionarProduto(Produto produto) //a sequencia (Produto produto) indica que podem ser quaisquer produtos que podem utilizar o mesmo metodo
    {
        if (produto == null)
        {
            throw new ArgumentException("Dado inválido!");
        }
        Produtos.Add(produto);
        Console.WriteLine($"{produto.Nome} adicionado com sucesso!");
    }

    public void removerProduto(Produto produto)
    {
        if (produto == null)
        {
            throw new ArgumentException("Dado inválido!");
        }
        if (Produtos.Contains(produto))
        {
            Produtos.Remove(produto);
            Console.WriteLine($"{produto.Nome} removido com sucesso!");
        }
        else
        {
            Console.WriteLine($"Produto não encontrado...");
        }
    }

    public decimal calcularTotal()
    {
        decimal Total = 0;
        foreach (var produto in Produtos)
        {
            Total += produto.CalculoFinal();
        }
        return  Total;

    }

    public void finalizarPedido()
    {
        if (Status == StPedido.Finalizado)
        {
            Console.WriteLine("Pedido finalizado!");
            return;
        }

        Status = StPedido.Finalizado;
    }
}

public enum StPedido{
    Pendente,
    Finalizado,
    Cancelado
}