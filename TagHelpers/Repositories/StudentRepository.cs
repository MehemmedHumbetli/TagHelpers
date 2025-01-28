using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using TagHelpers.Context;
using TagHelpers.Entities;

namespace TagHelpers.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext schoolDbContext;

        public StudentRepository(SchoolDbContext schoolDbContext)
        {
            this.schoolDbContext = schoolDbContext;
        }

        public void Add(Student student)
        {
            schoolDbContext.Students.Add(student);
            schoolDbContext.SaveChanges();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await schoolDbContext.Students.ToListAsync();
        }
    }
}
