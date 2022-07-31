namespace Presentation.Models;

public record ErrorDto
{
    public string? RequestId;

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}