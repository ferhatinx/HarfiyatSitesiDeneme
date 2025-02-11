
namespace Harfiyat_Common.ResponseObjects;

public class Response<T> : Response, IResponse<T>
{
    
    public T? Data { get;set;}
    public List<CustomValidationError>? Errors { get;set;}

    public Response(T data, ResponseType responseType) : base(responseType) 
    {
        Data = data;
    }
    public Response( T data,ResponseType responseType, List<CustomValidationError> customValidationErrors) : this(data,responseType)
    {
        Errors = customValidationErrors;
    }
    public Response(ResponseType responseType, string message) : base(responseType,message)
    {
        
    }
    public Response(ResponseType responseType) : base(responseType)
    {
        
    }
}
