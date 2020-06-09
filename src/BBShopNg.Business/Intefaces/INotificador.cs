using System.Collections.Generic;
using BBShopNg.Business.Notificacoes;

namespace BBShopNg.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}