﻿using Bibosio.Abstractions;
using Bibosio.CatalogModule.Domain.ValueObjects;

namespace Bibosio.CatalogModule.Domain
{
    internal class CatalogItem : AppEntity
    {
        public string? Name { get; set; }
        public bool IsUseInProductName { get; set; } // TODO: ?

        public bool IsCategory { get; set; }
        public bool IsProduct => !IsCategory;

        public Sku? Sku { get; set; }

        public Guid? ParentItemId { get; set; }
        public CatalogItem? ParentItem { get; set; }

        public List<CatalogItem>? ChildItems { get; set; }

        public List<CatalogItemOption> CatalogItemOptions { get; set; } = new();

        public string GetFullName(CatalogItemTemplate template)
        {
            return template.Generate(this);
        }
    }
}
