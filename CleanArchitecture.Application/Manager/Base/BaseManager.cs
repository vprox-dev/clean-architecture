using AutoMapper;

using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Core.Repositories.Base;

namespace CleanArchitecture.Application.Manager;

public class BaseManager<T, T1> : IBaseManager<T, T1> where T : class where T1 : class
{
    private readonly IRepository<T1> _repository;
    private readonly IMapper _mapper;

    public BaseManager(IRepository<T1> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<T>> Get()
    {
        var dbModelList = await _repository.GetAllAsync();
        var result = _mapper.Map<IReadOnlyList<T>>(dbModelList);
        return result;
    }

    public async Task<T> Add(T model)
    {
        var dbModel = _mapper.Map<T1>(model);
        var result = await _repository.AddAsync(dbModel);
        var mappedResult = _mapper.Map<T>(result);
        return mappedResult;
    }

    public async Task Update(int id, T model)
    {
        var dbModel = _mapper.Map<T1>(model);
        await _repository.UpdateAsync(id, dbModel);
    }

    public async Task Delete(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<T> GetbyId(int id)
    {
        var dbModelList = await _repository.GetByIdAsync(id);
        var result = _mapper.Map<T>(dbModelList);
        return result;
    }
}