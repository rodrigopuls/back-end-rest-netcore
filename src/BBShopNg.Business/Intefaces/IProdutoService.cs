using System;
using System.Threading.Tasks;
using BBShopNg.Business.Models;

namespace BBShopNg.Business.Intefaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}