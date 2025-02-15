namespace Harfiyat_Common.ResponseObjects;

public interface IResponse<T> : IResponse
{
    T? Data { get; set; }

   
}
