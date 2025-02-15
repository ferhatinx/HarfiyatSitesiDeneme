
namespace Harfiyat_Common.ResponseObjects;

public class Response : IResponse
{
    public string? Message { get; set; }

    public ResponseType ResponseType { get; set; }
    public List<CustomValidationError>? Errors { get; set; }


    public Response(ResponseType responseType)
    {
        ResponseType = responseType;
    }
    public Response(ResponseType responseType, string message)
    {
        ResponseType = responseType;
        
        Message = message;
    }
     public Response(ResponseType responseType, List<CustomValidationError>? errors)
    {
        ResponseType = responseType;
        Errors = errors;
    }

}
