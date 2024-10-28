using Bibosio.Abstractions;

namespace Bibosio.StorageModule.Domain
{
    /// <summary>
    /// For example: Контейнер, Паллет, Полка; Подвесной, Пол (например, для крупногабаритных товаров)
    /// </summary>
    internal class StorageLocationType : AppEntity
    {
        public string? Name { get; set; }
    }
}
