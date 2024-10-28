﻿using Bibosio.Common;

namespace Bibosio.StorageModule.Domain
{
    /// <summary>
    /// Reference to CatalogItem
    /// </summary>
    internal class StorageItem : AppEntity
    {
        public string? Name { get; set; }
    }
}