using Bibosio.Interfaces;

namespace Bibosio.Common
{
    public abstract class AppEntity : IEntity<Guid>
    {
        public AppEntity()
        {
            Id = Guid.CreateVersion7();
        }

        public AppEntity(Guid id) => Id = id;

        public Guid Id { get; private set; }
    }
}
