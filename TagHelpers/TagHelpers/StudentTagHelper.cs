using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TagHelpers.Context;

namespace TagHelpers.TagHelpers
{
    [HtmlTargetElement("student-list")]
    public class StudentTagHelper : TagHelper
    {
        private readonly SchoolDbContext _context;

        public StudentTagHelper(SchoolDbContext context)
        {
            _context = context;
        }

        public string SortOrder { get; set; } = "asc";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var studentsQuery = _context.Students.AsQueryable();

            if (SortOrder == "desc")
            {
                studentsQuery = studentsQuery.OrderByDescending(s => s.Name);
            }
            else
            {
                studentsQuery = studentsQuery.OrderBy(s => s.Name);
            }
             
            var students = await studentsQuery.ToListAsync();
            StringBuilder sb = new();
            foreach (var item in students)
            {
                sb.AppendFormat("<h2><a href ='Student/{0}'>{1}</a></h2>", item.Id, item.Name);
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
