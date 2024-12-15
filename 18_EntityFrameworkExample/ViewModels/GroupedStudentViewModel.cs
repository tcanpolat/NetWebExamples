using _18_EntityFrameworkExample.Models;

namespace _18_EntityFrameworkExample.ViewModels
{
    public class GroupedStudentViewModel
    {
        public string Department { get; set; } // Bölüm adı
        public List<Student> Students { get; set; }
    }
}
