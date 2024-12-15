using _18_EntityFrameworkExample.Models;

namespace _18_EntityFrameworkExample.Extensions
{
    public static class StudentExtensions
    {
        public static IDictionary<string,List<Student>> GroupByAgeRange(this IEnumerable<Student> students)
        {
            return students
                   .GroupBy(s =>
                   {
                       if (s.Age < 18) return "17 ve altı";
                       if (s.Age < 25) return "18 ve  24 arası";
                       if (s.Age < 35) return "25 ve  34 arası";
                       return "35 üstü";
                   })
                   .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
