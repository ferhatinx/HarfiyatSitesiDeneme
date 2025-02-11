namespace Harfiyat_Entities.Entities;

public class JobSummary : BaseEntitiy
{
    public decimal TotalReceivedAmount { get; set; } // Alınan toplam para
    public decimal TotalExpense { get; set; }  // Toplam harcama
    public decimal NetProfit => TotalReceivedAmount - TotalExpense; // Net kar (Alınan Para - Harcama)
    
    public List<Job>? Jobs { get; set; }

}
