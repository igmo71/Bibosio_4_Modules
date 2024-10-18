namespace Bibosio.CatalogModule.Domain
{
    internal class CatalogItemTemplate
    {
        private readonly string _template;

        internal CatalogItemTemplate(string template)
        {
            _template = template;
        }

        internal string Generate(CatalogItem catalogItem)
        {
            string result = _template;

            // TODO: Implement Generate

            return result;
        }
    }
}