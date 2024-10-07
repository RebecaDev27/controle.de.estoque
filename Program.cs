using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        ControleDeEstoque estoque = new ControleDeEstoque();
        CultureInfo cultura = new CultureInfo("pt-BR");

        while (true)
        {
            ExibirMenu();
            string opcao = VerificarEsc();
            Console.WriteLine("\nMenu de Controle de Estoque - FARMACIA REBECA - Manipulações");
            Console.WriteLine("1. Adicionar Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Atualizar Produto");
            Console.WriteLine("4. Deletar Produto");
            Console.WriteLine("5. Buscar Produto");
            Console.WriteLine("6. Sair");
            Console.WriteLine("Esc para retornar ao Menu!");
            Console.Write("Escolha uma opção: ");

            switch (opcao)
            {
                case "1":
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    Console.Write("Preço: ");
                    string precoInputString = Console.ReadLine();

                    if (double.TryParse(precoInputString, NumberStyles.Currency, cultura, out double precoInput))
                    {
                        // Formatar a saída usando a mesma cultura
                        Console.WriteLine($"Preço convertido: {precoInput.ToString("C", cultura)}");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, insira o preço no formato correto, por exemplo, R$ 10,00.");
                    }

                    Produto produto = new Produto(id, nome, quantidade, precoInput);
                    estoque.AdicionarProduto(produto);
                    break;

                case "2":
                    estoque.ListarProdutos();
                    break;

                case "3":
                    Console.Write("ID do Produto a ser atualizado: ");
                    int idAtualizar = int.Parse(Console.ReadLine());

                    Console.Write("Novo Nome: ");
                    string novoNome = Console.ReadLine();

                    Console.Write("Nova Quantidade: ");
                    int novaQuantidade = int.Parse(Console.ReadLine());

                    Console.Write("Novo Preço: ");
                    string novoPrecoString = Console.ReadLine(); // Lê a string do novo preço em Reais R$ USANDO CURRENCY
                    double novoPreco = double.Parse(novoPrecoString, NumberStyles.Currency, new CultureInfo("pt-BR"));

                    estoque.AtualizarProduto(idAtualizar, novoNome, novaQuantidade, novoPreco);
                    break;

                case "4":
                    Console.Write("ID do Produto a ser deletado: ");
                    int idDeletar = int.Parse(Console.ReadLine());
                    estoque.DeletarProduto(idDeletar);
                    break;

                case "5":
                    Console.Write("ID do Produto a ser buscado: ");
                    int idBuscar = int.Parse(Console.ReadLine());
                    var produtoBuscado = estoque.BuscarProduto(idBuscar);
                    if (produtoBuscado != null)
                    {
                        Console.WriteLine(produtoBuscado.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Produto não encontrado.");
                    }
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("\n---Menu de Controle de Estoque ---");
        Console.WriteLine("1 - Adicionar Produto");
        Console.WriteLine("2 - Listar Produto");
        Console.WriteLine("3 - Atualizar Produto");
        Console.WriteLine("4 - Deletar Produto");
        Console.WriteLine("5 - Buscar Produto");
        Console.WriteLine("6 - Sair do Sistema.");
        Console.Write("Escolha uma opcao: ");
    }

    static string VerificarEsc()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

        if (keyInfo.Key == ConsoleKey.Escape)
        {
            return "Esc";
        }

        return keyInfo.KeyChar.ToString();
    }
}