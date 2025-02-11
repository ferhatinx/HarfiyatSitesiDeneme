namespace Harfiyat_Common.ResponseObjects;

public class CustomValidationError
{
    public CustomValidationError(string propertyName, string errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
    public string? PropertyName { get; set; }
    public string? ErrorMessage { get; set; }
}
