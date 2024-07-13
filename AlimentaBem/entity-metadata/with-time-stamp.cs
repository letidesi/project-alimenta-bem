public abstract class WithTimeStamp : IAuditable, ISoftDelete
{
    public DateTimeOffset createdAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? updatedAt { get; set; }
    public DateTimeOffset? deletedAt { get; set; }
}