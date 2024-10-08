using Bibosio.Interfaces;

namespace Bibosio.Common
{
    public abstract class AppEntity : IEntity<Guid>
    {
        public AppEntity() { }

        public AppEntity(Guid id) => Id = id;

        public Guid Id { get; private set; }
    }
}
