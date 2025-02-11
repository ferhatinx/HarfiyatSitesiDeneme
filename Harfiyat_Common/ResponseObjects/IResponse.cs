namespace Harfiyat_Common.ResponseObjects;

public interface IResponse
{
    public string? Message { get; set; }

    ResponseType ResponseType{ get; set; }
}
