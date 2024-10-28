using Bibosio.Abstractions;

namespace Bibosio.CatalogModule.Domain
{
    internal class Option : AppEntity
    {
        public string? Name { get; set; }

        /// <summary>
        /// Is use OptionValue in CatalogItem Name
        /// If 0 do not use in CatalogItem Name
        /// </summary>
        public int PriorityInProductName { get; set; }

        public List<OptionValue> OptionValues { get; set; } = new();
    }
}
