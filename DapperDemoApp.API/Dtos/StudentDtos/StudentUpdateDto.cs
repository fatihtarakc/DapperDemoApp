namespace DapperDemoApp.API.Dtos.StudentDtos
{
    public class StudentUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Number { get; set; }
        public string Class { get; set; }
    }
}