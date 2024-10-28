using Bibosio.Abstractions;

namespace Bibosio.ProductsModule.Domain
{
    internal class Option : AppEntity
    {
        internal required string Name { get; set; }

        /// <summary>
        /// Is use OptionValue in Product Name
        /// If 0 do not use in Product Name
        /// </summary>
        internal int PriorityInProductName { get; set; }

        internal Guid CategoryId { get; set; }
        internal Category? Category { get; set; }

        internal List<OptionValue>? OptionValues { get; set; }
    }
}
