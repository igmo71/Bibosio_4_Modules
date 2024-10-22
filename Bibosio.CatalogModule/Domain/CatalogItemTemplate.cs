namespace Bibosio.CatalogModule.Domain
{
    internal class CatalogItemTemplate
    {
        private readonly string _template;

        public CatalogItemTemplate(string template)
        {
            _template = template;
        }

        public string Generate(CatalogItem catalogItem)
        {
            string result = _template;

            // TODO: Implement Generate

            return result;
        }
    }
}