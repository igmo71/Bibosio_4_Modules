namespace Bibosio.CatalogModule.Domain
{
    internal class CatalogItemOption
    {
        public CatalogItemOption(CatalogItem catalogItem, Option option, OptionValue optionValue)
        {
            CatalogItem = catalogItem;
            Option = option;
            OptionValue = optionValue;
        }

        public CatalogItemOption(Guid catalogItemId, Guid optionId, Guid optionValueId)
        {
            CatalogItemId = catalogItemId;
            OptionId = optionId;
            OptionValueId = optionValueId;
        }

        public Guid CatalogItemId { get; private set; }
        public CatalogItem? CatalogItem { get; private set; }

        public Guid OptionId { get; private set; }
        public Option? Option { get; private set; }

        public Guid OptionValueId { get; private set; }
        public OptionValue? OptionValue { get; private set; }

        public string Template { get; set; } = "{Option}: {OptionValue}; "; // TODO: Кастыль

        public string GetNamePart()
        {
            string namePart = Template.Replace("{OptionValue}", Option?.Name).Replace("OptionValue", OptionValue?.Value);
            return namePart;
        }
    }
}
