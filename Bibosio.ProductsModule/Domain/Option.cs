using Bibosio.Common;

namespace Bibosio.ProductsModule.Domain
{
    public class Option : AppEntity
    {
        public required string Name { get; set; }
        public required string ShortName { get; set; }
        public int Priority { get; set; }
        public bool IsUseShortName { get; set; }
        public bool IsUseValue { get; set; }
        public List<string>? Values { get; set; } // TODO: Option Values are string?
    }
}
