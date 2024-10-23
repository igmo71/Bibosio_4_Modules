using Bibosio.Interfaces;

namespace Bibosio.Common
{
    public abstract class AppEntity : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
    }
}
