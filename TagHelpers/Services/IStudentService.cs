using System.Collections.Generic;
using System.Threading.Tasks;
using TagHelpers.Entities;

namespace TagHelpers.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllByKeyAsync(string key="");
    }
}
