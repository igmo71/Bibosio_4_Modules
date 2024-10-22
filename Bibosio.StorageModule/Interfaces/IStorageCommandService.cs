using Bibosio.StorageModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibosio.StorageModule.Interfaces
{
    internal interface IStorageCommandService
    {
        Task TransferItems(Transfer transfer);
    }
}
