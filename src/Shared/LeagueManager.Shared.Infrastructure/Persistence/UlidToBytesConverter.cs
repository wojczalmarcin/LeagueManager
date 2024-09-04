using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeagueManager.Shared.Infrastructure.Persistence;
public sealed class UlidToBytesConverter : ValueConverter<Ulid, byte[]>
{
    public UlidToBytesConverter()
        : base(id => id.ToByteArray(), value
            => new Ulid(value))
    { }
}