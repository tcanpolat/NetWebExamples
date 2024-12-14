namespace _18_EntityFrameworkExample.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Foreing key property
        public int StudentId { get; set; } //  Öğrenci kimliği
        public Student Student { get; set; } // Navigation property
    }
}
