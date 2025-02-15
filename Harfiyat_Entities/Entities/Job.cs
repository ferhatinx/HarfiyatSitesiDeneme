

namespace Harfiyat_Entities.Entities;

public class Job : BaseEntitiy
{

    public string? ProjectName { get; set; } = string.Empty;

    public string? Localiton { get; set; } = string.Empty;

    public DateTime? StartDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public decimal? Price { get; set; }

    public bool isCompleted { get; set; } = false;
    public string? Summary { get; set; }
    public int JobRequestId { get; set; }
    public JobRequest? JobRequest { get; set; }
    

}
