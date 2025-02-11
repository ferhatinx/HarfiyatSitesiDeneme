using Harfiyat_Business.Services;

namespace Harfiyat_Business.Interfaces;

public interface IBaseService
{
    IJobRequestService JobRequestService {get;}
    IJobService JobService {get;}
}
