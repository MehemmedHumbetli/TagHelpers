using System.Collections.Generic;
using System.Threading.Tasks;
using TagHelpers.Entities;

namespace TagHelpers.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        void Add(Student student);
    }
}
