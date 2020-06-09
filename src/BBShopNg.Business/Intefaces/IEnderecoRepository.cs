using System;
using System.Threading.Tasks;
using BBShopNg.Business.Models;

namespace BBShopNg.Business.Intefaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}