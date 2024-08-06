namespace DapperDemoApp.API.Data.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Number { get; set; }
        public string Class { get; set; }
        public DateTime CreationDate { get; set; }
    }
}