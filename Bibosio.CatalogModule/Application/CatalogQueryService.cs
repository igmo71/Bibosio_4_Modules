using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibosio.CatalogModule.Application
{
    internal class CatalogQueryService : ICatalogQueryService
    {
        public List<CatalogItem> GetParents(CatalogItem catalogItem)
        {
            throw new NotImplementedException();
        }
    }
}
