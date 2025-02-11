namespace Harfiyat_Common.ResponseObjects;

public interface IResponse<T>
{
    T? Data { get; set; }

    List<CustomValidationError>? Errors { get; set; }
}
