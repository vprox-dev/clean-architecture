namespace CleanArchitecture.Application.Interfaces;

public interface IBaseManager<T, T1> where T : class where T1 : class
{
    Task<IReadOnlyList<T>> Get();

    Task<T> Add(T employee);

    Task Update(int id, T employeeModel);

    Task<T> GetbyId(int id);

    Task Delete(int id);
}