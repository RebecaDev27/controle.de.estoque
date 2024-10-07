public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public string? Tarjado { get; set; } // Tornado opcional (nullable)

    // Construtor completo
    public Produto(int id, string nome, int quantidade, double preco, string? tarjado = null)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
        Tarjado = tarjado;
    }

    // Construtor sem "Tarjado"
    public Produto(int id, string nome, int quantidade, double preco)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
    }

    // Atualiza as propriedades do produto
    public void Atualizar(string novoNome, int novaQuantidade, decimal novoPreco, string? tarjado)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
        {
            throw new ArgumentException("O nome não pode ser vazio ou nulo.");
        }

        Nome = novoNome;
        Quantidade = novaQuantidade;
        Preco = (double)novoPreco;
        Tarjado = tarjado;
    }

    // Método para exibir as informações do produto
    public override string ToString()
    {
        return $"ID: {Id}, Nome: {Nome}, Quantidade: {Quantidade}, Preço: {Preco:C}" +
               (Tarjado != null ? $", Tarjado: {Tarjado}" : string.Empty);
    }
}

public class Fabricante
{
    public string Referencia { get; set; }
    public string Generico { get; set; }
    public string Similar { get; set; }

    // Construtor correto
    public Fabricante(string referencia, string generico, string similar)
    {
        Referencia = referencia;
        Generico = generico;
        Similar = similar;
    }

    // Método para exibir as informações do fabricante
    public override string ToString()
    {
        return $"Referência: {Referencia}, Genérico: {Generico}, Similar: {Similar}";
    }
}