using DapperDemoApp.API.Dtos.StudentDtos;
using DapperDemoApp.API.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet("Students")]
        public async Task<IActionResult> Students() =>
            await studentRepository.GetAllAsync() is null ? NotFound("Students was not found !") : Ok(await studentRepository.GetAllAsync());

        [HttpGet("GetBy/{studentId}")]
        public async Task<IActionResult> GetBy(Guid studentId) =>
            await studentRepository.GetByAsync(studentId) is null ? NotFound("Searching student was not found !") : Ok(await studentRepository.GetByAsync(studentId));

        [HttpPost("Add")]
        public async Task<IActionResult> Add(StudentAddDto studentAddDto) =>
            await studentRepository.AddAsync(studentAddDto) is false ? BadRequest("Student was not added !") : Ok("Student was added successfully !");

        [HttpDelete("Delete/{studentId}")]
        public async Task<IActionResult> Delete(Guid studentId) =>
            await studentRepository.DeleteAsync(studentId) is true ? Ok("Student was deleted successfully !") : BadRequest("Student deleting process was unsuccess !");

        [HttpPut("Update")]
        public async Task<IActionResult> Update(StudentUpdateDto studentUpdateDto) =>
            await studentRepository.UpdateAsync(studentUpdateDto) is true ? Ok($"{studentUpdateDto.Name} {studentUpdateDto.Surname}'s informations was updated successfully !")
            : BadRequest($"{studentUpdateDto.Name} {studentUpdateDto.Surname}'s informations was not updated !");
    }
}