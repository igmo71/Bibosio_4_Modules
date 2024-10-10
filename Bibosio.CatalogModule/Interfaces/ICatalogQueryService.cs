using Bibosio.CatalogModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibosio.CatalogModule.Interfaces
{
    internal interface ICatalogQueryService
    {
        List<CatalogItem> GetParents(CatalogItem catalogItem);
    }
}
