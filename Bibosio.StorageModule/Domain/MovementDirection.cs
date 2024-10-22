namespace Bibosio.StorageModule.Domain
{
    internal record MovementDirection(int Id, string Name, string NameRu)
    {
        // Receive Goods (Приемка товаров), Inbound Process (Входящий процесс)
        public static MovementDirection In { get; } = new(1, "Receipt", "Поступление");

        //Issue Goods (Выдача товаров), Outbound Process (Исходящий процесс)
        public static MovementDirection Out { get; } = new(2, "Issue", "Выдача");
    }
}
