using System;
using BBShopNg.Data.Context;


namespace BBShopNg.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MeuDbContext context, IServiceProvider serviceProvider)
        {
            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //context.Database.EnsureCreated();

            //// Look for any Organization.
            //if (context.Clientes.Any())
            //{
            //    return;   // DB has been seeded
            //}


            //#region Titular
            //var titular = userManager.FindByEmailAsync("titular@bbshop.com.br").Result;
            //var cliente = new Cliente
            //{
            //    ApplicationUserId = titular.Id,
            //    Celular = "14999999999",
            //    Email = titular.Email,
            //    Nome = "Rodrigo",
            //    Sobrenome = "de Freitas Puls",
            //};

            //context.Clientes.Add(cliente);
            //context.SaveChanges();
            //#endregion


            //var empresa = new Empresa
            //{
            //    TipoEmpresa = TipoEmpresa.PessoaJuridica,
            //    CpfCnpj = "04256561000107",
            //    Detalhes = "Sem Detalhes",
            //    EmailCobranca = "cobranca@bbshop.com.br",
            //    EmailNf = "nf@bbshop.com.br",
            //    Ie = "209354864114",
            //    NomeFantasia = "BBShop Websites",
            //    RazaoSocial = "BBShop Tecnologias Ltda. ME",
            //    Telefone = "1832130322"
            //};
            //context.Empresas.Add(empresa);
            //context.SaveChanges();


            //var endereco = new Endereco
            //{
            //    EmpresaId = empresa.Id,
            //    Logradouro = "Rua Belmonte",
            //    Complemento = "",
            //    Bairro = "Centro",
            //    Numero = "1315",
            //    Cep = "16200280",
            //    Cidade = "Birigui",
            //    Estado = "SP"
            //};
            //context.Enderecos.Add(endereco);
            //context.SaveChanges();

            //#region Membro
            //var membro = userManager.FindByEmailAsync("membro@bbshop.com.br").Result;
            //var cliente2 = new Cliente
            //{
            //    ApplicationUserId = membro.Id,
            //    TitularId = titular.Id,
            //    Celular = "14999999999",
            //    Email = membro.Email,
            //    Nome = "Rodrigo",
            //    Sobrenome = "de Freitas Puls",
            //    EmpresaId = cliente.EmpresaId
            //};

            //context.Clientes.Add(cliente2);
            //context.SaveChanges();
            //#endregion
        }
    }
}