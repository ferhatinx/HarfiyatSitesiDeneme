

namespace Harfiyat_Entities.Entities;

public class Job : BaseEntitiy
{

    public string? ProjectName { get; set; } = string.Empty;

    public string? Localiton { get; set; } = string.Empty;

    public DateTime? StartDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public decimal? Budget { get; set; }
    
    public decimal Amount { get; set; }

    public int JobRequestId { get; set; }
    public JobRequest? JobRequest { get; set; }
    public IEnumerable<Image>? Images { get; set; }
    public int JobSummaryId { get; set; }
    public JobSummary? JobSummary { get; set; }

}
