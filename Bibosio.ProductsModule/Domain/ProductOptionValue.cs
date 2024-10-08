namespace Bibosio.ProductsModule.Domain
{
    internal class ProductOptionValue
    {
        internal Guid ProductId { get; set; }
        internal Product? Product { get; set; }  

        internal Guid OptionId { get; set; }
        internal Option? Option { get; set; }

        internal Guid OptionValueId { get; set; }
        internal OptionValue? OptionValue { get; set; }
    }
}
