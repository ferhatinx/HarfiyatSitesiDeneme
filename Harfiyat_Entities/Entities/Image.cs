using Harfiyat_Common.Enums;

namespace Harfiyat_Entities.Entities;

public class Image : BaseEntitiy
{
    public string? FileName { get; set; } = string.Empty;
    public string? FilePath { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; }
    public ImageType ImageType { get; set; }

    public int? JobRequestId { get; set; }
    public JobRequest? JobRequest { get; set; }
}
