using System;
using System.Threading.Tasks;
using BBShopNg.Business.Intefaces;
using BBShopNg.Business.Models;
using BBShopNg.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BBShopNg.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}