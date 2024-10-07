using System;
using System.Collections.Generic;
using System.Linq;

public class ControleDeEstoque
{
    private List<Produto> produtos;

    public ControleDeEstoque()
    {
        produtos = new List<Produto>();
    }

    // Adiciona um produto, verificando duplicação de ID
    public void AdicionarProduto(Produto produto)
    {
        if (produtos.Any(p => p.Id == produto.Id))
        {
            Console.WriteLine($"Erro: Já existe um produto com o ID {produto.Id}.");
            return;
        }

        produtos.Add(produto);
        Console.WriteLine($"Produto '{produto.Nome}' adicionado com sucesso!");
    }

    // Lista todos os produtos
    public void ListarProdutos()
    {
        if (produtos.Any())
        {
            Console.WriteLine("\n--- Lista de Produtos ---");
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto.ToString());
            }
        }
        else
        {
            Console.WriteLine("Nenhum produto no estoque.");
        }
    }

    // Atualiza um produto chamando o método Atualizar da classe Produto
    public void AtualizarProduto(int id, string novoNome, int novaQuantidade, decimal novoPreco, string? tarjado = null)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            try
            {
                produto.Atualizar(novoNome, novaQuantidade, novoPreco, tarjado);
                Console.WriteLine($"Produto ID {id} atualizado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    // Deleta um produto
    public void DeletarProduto(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            produtos.Remove(produto);
            Console.WriteLine($"Produto ID {id} removido do estoque.");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    // Busca um produto pelo ID
    public Produto? BuscarProduto(int id)
    {
        return produtos.FirstOrDefault(p => p.Id == id);
    }

    internal void AtualizarProduto(int idAtualizar, string? novoNome, double novaQuantidade, double novoPreco)
    {
        throw new NotImplementedException();
    }
}