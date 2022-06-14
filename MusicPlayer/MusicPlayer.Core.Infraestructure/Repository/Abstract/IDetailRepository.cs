using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Domain.Interfaces;

namespace MusicPlayer.Core.Infraestructure.Repository.Abstract
{
    public interface IDetailRepository<Entity, TransactionId> : ICreate<Entity>, ITransaction
    {
        List<Entity> GetDetailsByTransaction(TransactionId transactionId);

        void Cancel(TransactionId transactionId);
    }
}


