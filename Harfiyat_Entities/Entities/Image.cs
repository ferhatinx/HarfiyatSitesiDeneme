using Harfiyat_Common.Enums;

namespace Harfiyat_Entities.Entities;

public class Image : BaseEntitiy
{
    public string? FileName { get; set; } = string.Empty;
    public string? FilePath { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; }
    public ImageType ImageType { get; set; }

    public int? JobId { get; set; }
    public Job? Job { get; set; }
}
