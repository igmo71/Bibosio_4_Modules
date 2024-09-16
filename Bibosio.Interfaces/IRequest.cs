namespace Bibosio.Interfaces
{
    public interface IAppRequest { }

    public interface IRequest : IAppRequest { }

    public interface IRequest<out TResponse> : IAppRequest { }
}
