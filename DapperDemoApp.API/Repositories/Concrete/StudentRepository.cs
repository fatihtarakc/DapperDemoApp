using Dapper;
using DapperDemoApp.API.Data.Entities;
using DapperDemoApp.API.Dtos.StudentDtos;
using DapperDemoApp.API.Repositories.Abstract;
using Mapster;
using System.Data.SqlClient;

namespace DapperDemoApp.API.Repositories.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private string myConnectionString;
        public StudentRepository(IConfiguration configuration)
        {
            myConnectionString = configuration["ConnectionStrings:conn"];
        }

        public async Task<bool> AddAsync(StudentAddDto studentAddDto)
        {
            var query = "insert into Students (Id, name, surname, number, class, creationdate) values (@studentId, @name, @surname, @number, @class, @creationdate)";

            var parameters = new DynamicParameters();
            parameters.Add("@studentId", Guid.NewGuid());
            parameters.Add("@name", studentAddDto.Name);
            parameters.Add("@surname", studentAddDto.Surname);
            parameters.Add("@number", studentAddDto.Number);
            parameters.Add("@class", studentAddDto.Class);
            parameters.Add("@creationdate", DateTime.Now);

            try
            {
                using (var conn = new SqlConnection(myConnectionString)) 
                {
                    return await conn.ExecuteAsync(query, parameters) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid studentId)
        {
            var query = "delete from students where Id = @studentId";

            var parameters = new DynamicParameters();
            parameters.Add("@studentId", studentId);

            try
            {
                using (var conn = new SqlConnection(connectionString: myConnectionString))
                {
                    return await conn.ExecuteAsync(query, parameters) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(StudentUpdateDto studentUpdateDto)
        {
            var query = "update students set name = @name, surname = @surname, number = @number, class = @class where Id = @studentId";

            var parameters = new DynamicParameters();
            parameters.Add("@studentId", studentUpdateDto.Id);
            parameters.Add("@name", studentUpdateDto.Name);
            parameters.Add("@surname", studentUpdateDto.Surname);
            parameters.Add("@number", studentUpdateDto.Number);
            parameters.Add("@class", studentUpdateDto.Class);

            try
            {
                using (var conn = new SqlConnection(connectionString: myConnectionString))
                {
                    return await conn.ExecuteAsync(query, parameters) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<StudentDto> GetByAsync(Guid studentId)
        {
            var query = "select * from students where Id = @studentId";

            var parameters = new DynamicParameters();
            parameters.Add("@studentId", studentId);

            try
            {
                using (var conn = new SqlConnection(myConnectionString)) 
                {
                    return (await conn.QueryFirstOrDefaultAsync<Student>(query, parameters)).Adapt<StudentDto>();
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var query = "select * from Students";

            try
            {
                using (var conn = new SqlConnection(myConnectionString)) 
                {
                    var students = await conn.QueryAsync<Student>(query);
                    return students.Adapt<IEnumerable<StudentDto>>();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}