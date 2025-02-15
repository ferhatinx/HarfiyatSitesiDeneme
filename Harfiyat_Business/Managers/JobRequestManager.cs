using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Results;
using Harfiyat_Business.Extensions;
using Harfiyat_Business.Services;
using Harfiyat_Common.ResponseObjects;
using Harfiyat_DataAccess.Contracts;
using Harfiyat_Entities.Entities;

namespace Harfiyat_Business.Interfaces;

public class JobRequestManager : IJobRequestService
{
    private readonly IValidator<JobRequest> _validator;
    private readonly IRepositoryManager _manager;

    public JobRequestManager(IValidator<JobRequest> validator, IRepositoryManager manager)
    {
        _validator = validator;
        _manager = manager;

    }

    public IResponse AcceptJobRequest(int id)
    {
        var entity = _manager.JobRequestRepository.GetByIdJobRequest(id);
        if(entity is not null)
        {
            entity.IsApproved = true;
            UpdateJobRequest(entity);
            return new Response(ResponseType.Success);
        }
        return new Response(ResponseType.NotFound,"iş İsteği Bulunamadi");
    }


    public IResponse AddJobRequest(JobRequest entity)
    {
        var validator = _validator.Validate(entity);
        if (validator.IsValid)
        {
            _manager.JobRequestRepository.Add(entity);
            _manager.SaveChanges();
            return new Response(ResponseType.Success);
        }

        return new Response<JobRequest>(entity, ResponseType.ValidationError, ConverToFluenValidationResult.ConvertToFluentValidatonResultErrors(validator));
    }

    public IResponse DeleteJobRequest(int id)
    {
        var deleteEntity = _manager.JobRequestRepository.GetByIdJobRequest(id);
        if (deleteEntity is not null)
        {
            _manager.JobRequestRepository.Delete(deleteEntity);
            _manager.SaveChanges();
            return new Response(ResponseType.Success);
        }
        return new Response(ResponseType.NotFound,"Ürün Olmadığı için silinemedi.");
      
    }

    public IResponse<IEnumerable<JobRequest>> GetAllJobRequest(bool trackChanges = false)
    {
        var entityList = _manager.JobRequestRepository.GetAllJobRequest(trackChanges);
        if(!entityList.Any())
        {
            return new Response<IEnumerable<JobRequest>>(ResponseType.NoData);
        }
        return new Response<IEnumerable<JobRequest>>(entityList,ResponseType.Success);
    }

    public IResponse<IEnumerable<JobRequest>> GetAllJobRequestWithJobs(bool trackChanges = false)
    {
        var list =  _manager.JobRequestRepository.GetAllJobRequestWithJobs(false);
        if(list is not null)
        {
            return new Response<IEnumerable<JobRequest>>(list,ResponseType.Success);
        }
        return new Response<IEnumerable<JobRequest>>(ResponseType.NoData);
    }

    public IResponse<IEnumerable<JobRequest>> GetAllWithConditionJobRequest(Expression<Func<JobRequest, bool>> expression, bool trackChanges = false)
    {
        var list =  _manager.JobRequestRepository.GetAllWithConditionJobRequest(expression,trackChanges);
        if(list is not null)
        {
            return new Response<IEnumerable<JobRequest>>(list,ResponseType.Success);
        }
        return new Response<IEnumerable<JobRequest>>(ResponseType.NoData);
    }

    public IResponse<JobRequest?> GetByIdJobRequest(int id, bool trackChanges = false)
    {
        var entitiy = _manager.JobRequestRepository.GetByIdJobRequest(id,trackChanges);
        if(entitiy is not null)
        {
            return new Response<JobRequest?>(entitiy,ResponseType.Success);
        }
        return new Response<JobRequest?>(ResponseType.NoData);
    }

    public IResponse UpdateJobRequest(JobRequest entity)
    {
        var validator = _validator.Validate(entity);
        if(validator.IsValid)
        {
            _manager.JobRequestRepository.UpdateJobRequest(entity);
            _manager.SaveChanges();
            return new Response(ResponseType.Success);
        }
        return new Response<JobRequest>(entity,ResponseType.ValidationError);
    }

}
