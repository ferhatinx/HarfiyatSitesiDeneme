using System.Linq.Expressions;
using FluentValidation;
using Harfiyat_Business.Extensions;
using Harfiyat_Business.Interfaces;
using Harfiyat_Common.ResponseObjects;
using Harfiyat_DataAccess.Contracts;
using Harfiyat_Entities.Entities;

namespace Harfiyat_Business.Managers;

public class JobManager : IJobService
{
    private readonly IValidator<Job> _validator;
    private readonly IRepositoryManager _repoManager;

    public JobManager(IValidator<Job> validator, IRepositoryManager repoManager)
    {
        _validator = validator;
        _repoManager = repoManager;

    }


    public IResponse AddJob(Job entity)
    {
        var validate = _validator.Validate(entity);
        if (validate.IsValid)
        {
            _repoManager.JobRepository.AddJob(entity);
            _repoManager.SaveChanges();
            return new Response(ResponseType.Success);
        }
        return new Response<Job>(entity, ResponseType.ValidationError, ConverToFluenValidationResult.ConvertToFluentValidatonResultErrors(validate));
    }

    public IResponse CompletedJob(int id)
    {
        var entity = _repoManager.JobRepository.GetByIdJob(id, false);
        if (entity is not null)
        {
            entity.isCompleted = true;
            return UpdateJob(entity);
        }
        return new Response(ResponseType.NoData);

    }


    public IResponse DeleteJob(int id)
    {
        var job = _repoManager.JobRepository.GetByIdJob(id, false);
        if (job is not null)
        {
            _repoManager.JobRepository.DeleteJob(job);
            _repoManager.SaveChanges();
            return new Response(ResponseType.Success);
        }
        return new Response(ResponseType.NotFound);
    }

    public IResponse<IEnumerable<Job>> GetAllJob(bool trackChanges = false)
    {
        var entityList = _repoManager.JobRepository.GetAllJob(trackChanges);
        if (!entityList.Any())
        {
            return new Response<IEnumerable<Job>>(ResponseType.NoData);
        }
        return new Response<IEnumerable<Job>>(entityList, ResponseType.Success);
    }

    public IResponse<IEnumerable<Job>> GetAllWithJobRequest(int jobRequestId, bool trackChanges = false)
    {
        var list = _repoManager.JobRepository.GetAllWithConditionJob(x => x.JobRequestId == jobRequestId, trackChanges);
        if (list is not null)
        {
            return new Response<IEnumerable<Job>>(list, ResponseType.Success);
        }
        return new Response<IEnumerable<Job>>(ResponseType.NoData);
    }


    public IResponse<Job?> GetByIdJob(int id, bool trackChanges = false)
    {
        var entitiy = _repoManager.JobRepository.GetByIdJob(id, trackChanges);
        if (entitiy is not null)
        {
            return new Response<Job?>(entitiy, ResponseType.Success);
        }
        return new Response<Job?>(ResponseType.NoData);
    }

    public IResponse UpdateJob(Job entity)
    {
        var validator = _validator.Validate(entity);
        if (validator.IsValid)
        {
            _repoManager.JobRepository.UpdateJob(entity);
            _repoManager.SaveChanges();
            return new Response(ResponseType.Success);
        }
        return new Response<Job>(entity, ResponseType.ValidationError);
    }

}
