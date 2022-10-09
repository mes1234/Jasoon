namespace Jasoon.DTO.Poco;

public record Item
{
    public Guid Id { get; init; }
}

public record ItemWithPreviewDetails
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

public record ItemWithFullDetails
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string FullName { get; init; } = string.Empty;


}

