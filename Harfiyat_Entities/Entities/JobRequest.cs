namespace Harfiyat_Entities.Entities;

public class JobRequest : BaseEntitiy
{
    //! Property Tanumlamaları Yanlış yerede
    public string JobTitle { get; set; } = string.Empty;
    public string RequestedBy { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public bool IsApproved { get; set; }
    public IEnumerable<Job>? Jobs { get; set; }
}
