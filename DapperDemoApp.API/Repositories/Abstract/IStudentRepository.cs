using DapperDemoApp.API.Dtos.StudentDtos;

namespace DapperDemoApp.API.Repositories.Abstract
{
    public interface IStudentRepository
    {
        Task<bool> AddAsync(StudentAddDto studentAddDto);
        Task<bool> DeleteAsync(Guid studentId);
        Task<bool> UpdateAsync(StudentUpdateDto studentUpdateDto);
        Task<StudentDto> GetByAsync(Guid studentId);
        Task<IEnumerable<StudentDto>> GetAllAsync();
    }
}