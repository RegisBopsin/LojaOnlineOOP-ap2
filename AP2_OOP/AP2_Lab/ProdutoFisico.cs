using System;

public class ProdutoFisico : Produto //ProdutoFisico herda da classe produto
{
    private double peso;
    private Dimensoes dimensoes;
    private int estoque;

    public double Peso
    {
        get { return peso; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("O peso deve ser maior que zero."); //ArgumentException é necessário para interromper o programa quando valores inválidos forem inseridos
            peso = value;
        }
    }

    public Dimensoes Tamanho
    {
        get { return dimensoes; }
        set { dimensoes = value; }
    }

    public string Categoria { get; set; }

    public ProdutoFisico(decimal preco, double peso, int estoqueUm, string categoria, string nome, Dimensoes tamanho) : base(nome, preco)
    {
        Estoque = estoqueUm; // Usar a propriedade Estoque
        Tamanho = tamanho; // Corrigir a atribuição
        Categoria = categoria;
        Peso = peso; // Inicializar peso
    }

    public override decimal CalculoFinal() // O método CalculoFinal é sobrescrito
    //O método CalculoFinal está sobrescrevendo o método da classe base, pode ser classificado no pilar POLIMORFISMO

    {
        decimal taxaDeImposto = 0.2m;
        decimal imposto = Preco * taxaDeImposto;
        decimal frete = 30;
        decimal desconto = 0.1m;
        decimal semDesconto = Preco + imposto + frete;
        decimal comDesconto = semDesconto - (semDesconto * desconto);
        return comDesconto;
    }

    public int Estoque
    {
        get { return estoque; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Estoque não pode ser menor ou igual a zero");
            estoque = value;
        }
    }

    public void TiraEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");
        if (quantidade > estoque)
            throw new ArgumentException("Erro... Estoque insuficiente!");

        estoque -= quantidade;
        Console.WriteLine($"A quantia de {quantidade} do produto {Nome} foi removida... Restante disponível: {Estoque}");
    }

    public struct Dimensoes
    {
        private double profundidade;
        private double largura;
        private double altura;

        public double Profundidade
        {
            get { return profundidade; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dado inválido!");
                profundidade = value;
            }
        }

        public double Largura
        {
            get { return largura; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dado inválido!");
                largura = value;
            }
        }

        public double Altura
        {
            get { return altura; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dado inválido!");
                altura = value;
            }
        }

        public Dimensoes(double profundidade, double largura, double altura)
        {
            if (profundidade <= 0 || largura <= 0 || altura <= 0)
                throw new ArgumentException("As dimensões devem ser maiores que zero.");
            this.profundidade = profundidade;
            this.largura = largura;
            this.altura = altura;
        }
    }
}

