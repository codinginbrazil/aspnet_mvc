namespace Application.ViewModel;

public class ErrorViewModel
{
	public string? RequestId;

	public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
