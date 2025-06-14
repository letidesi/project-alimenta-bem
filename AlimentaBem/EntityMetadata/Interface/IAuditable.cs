public interface IAuditable
{
    DateTimeOffset createdAt { get; set; }
    DateTimeOffset? updatedAt { get; set; }
}
