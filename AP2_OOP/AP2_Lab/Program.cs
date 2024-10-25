Loja lojinha = new Loja();
var produtoFisico = new ProdutoFisico(80, 5, 7, "Periféricos", "Teclado", new ProdutoFisico.Dimensoes (5, 10, 2));
lojinha.CadastrarProduto(produtoFisico);
Console.WriteLine($"Há {produtoFisico.Estoque} unidades do produto {produtoFisico.Nome} disponíveis em estoque!");
var ProdutoDigital = new ProdutoDigital(".Zip", "Emulador PS2", 45, 15.5);
                                // Formato do arquivo, Nome do produto digital, preço dele e tamanho do arquivo
var clienteExemploContato = new Cliente.Contato("3628-1241", "exemplo@hotmail.com");
var clienteExemplo = new Cliente("Porca Véia", "Rua flavio dalpiaz 2005", "123", clienteExemploContato);
                            // nome do cliente, endereço e o ID identificador
lojinha.CadastrarClientes(clienteExemplo);

var pedido = lojinha.CriarPedido(clienteExemplo);
pedido.adicionarProduto(produtoFisico);
pedido.adicionarProduto(ProdutoDigital);
var Total = pedido.calcularTotal();
Console.WriteLine($"Valor total: {Total}");
lojinha.FinalizarPedido(pedido);
Console.WriteLine("");
Console.WriteLine("___________________________________________________________");
Console.WriteLine("Lista de produtos:");
lojinha.ListarProdutos();
Console.WriteLine("");
Console.WriteLine("___________________________________________________________");
Console.WriteLine("Lista de clientes:");
lojinha.ListarClientes();