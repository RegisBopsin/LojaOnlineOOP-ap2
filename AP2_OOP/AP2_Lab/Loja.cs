using System.Runtime.CompilerServices;

public class Loja
{
    public List<Produto> Produtos { get; private set; }
    public List<Cliente> Clientes { get; private set; }
    public List<Pedido> Pedidos { get; private set; }

    public Loja()
    {
        Produtos = new List<Produto>();
        Clientes = new List<Cliente>();
        Pedidos = new List<Pedido>();
    }

    public void CadastrarProduto(Produto produto)
    {
        if (produto == null)
        {
            Console.WriteLine("Dado inválido!");
            return;
        }

        if (Produtos.Exists(p => p.CodigoProduto == produto.CodigoProduto))
        {
            Console.WriteLine("Produto já cadastrado!");
            return;
        }

        Produtos.Add(produto);
        Console.WriteLine($"{produto.Nome} cadastrado!");
    }

    public Produto ConsultarProdutoPorCodigo(string codigo)
    {
        return Produtos.Find(p => p.CodigoProduto == codigo);
    }

    public void ListarProdutos()
    {
        if (Produtos.Count == 0)
        {
            Console.WriteLine("Lista de produtos vazia...");
            return;
        }

        foreach (var produto in Produtos)
        {
            Console.WriteLine($"Código: {produto.CodigoProduto}");
            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Preço: {produto.Preco}");

            if (produto is ProdutoFisico produtoFisico)
            {
                Console.WriteLine($"Quantidade em estoque: {produtoFisico.Estoque}");
            }
            else
            {
                Console.WriteLine("Quantidade em estoque: Ilimitado");
            }
        }
    }

    public void CadastrarClientes(Cliente cliente)
    {
        if (cliente == null)
        {
            Console.WriteLine("Cliente não pode ser nulo!");
            return;
        }

        if (Clientes.Exists(c => c.Identifica == cliente.Identifica))
        {
            Console.WriteLine("Cadastro já realizado!");
            return;
        }

        Clientes.Add(cliente);
        Console.WriteLine("Cadastro de cliente concluído!");
    }

    public Cliente ConsultarClientePorId(string identifica)
    {
        return Clientes.Find(c => c.Identifica == identifica);
    }

    public void ListarClientes()
    {
        if (Clientes.Count == 0)
        {
            Console.WriteLine("Não há clientes cadastrados!");
            return;
        }

        foreach (var cliente in Clientes)
        {
            Console.WriteLine($"Identificador: {cliente.Identifica}");
            Console.WriteLine($"Nome: {cliente.Nome}");
        }
    }

    public Pedido CriarPedido(Cliente cliente)
    {
        if (cliente == null || !Clientes.Contains(cliente))
        {
            Console.WriteLine("Cliente  não encontrado!");
            return null;
        }
        
        var pedido = new Pedido (cliente);
        Pedidos.Add(pedido);
        return pedido;
    }

    public void FinalizarPedido(Pedido pedido)
    {
        if (pedido == null || !Pedidos.Contains(pedido))
        {
            Console.WriteLine("Pedido não encontrado...");
            return;
        }

        foreach (var produto in pedido.Produtos)
        {
            if (produto is ProdutoFisico fisico)
            {
                if (fisico.Estoque <= 0)
                {
                    Console.WriteLine($"Produto não disponível...");
                    return; 
                }
            }
        }

        foreach (var produto in pedido.Produtos)
        {
            if (produto is ProdutoFisico  fisico)
            {
                fisico.TiraEstoque(1);
            }
        }

        pedido.finalizarPedido();
        Console.WriteLine("Pedido finalizado!");
    }
}

