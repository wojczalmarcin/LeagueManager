using LeagueManager.Shared.Abstractions.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeagueManager.Shared.Infrastructure.Persistence;
public sealed class DomainIdToBytesConverter<T> : ValueConverter<DomainId<Ulid>, byte[]> where T : DomainId<Ulid>
{
    public DomainIdToBytesConverter()
    : base(id => id.Value.ToByteArray(), value
        => new DomainId<Ulid>(new Ulid(value)))
    { }
}
