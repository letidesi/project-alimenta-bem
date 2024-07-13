public interface ISoftDelete
{
    DateTimeOffset? deletedAt { get; set; }
}
