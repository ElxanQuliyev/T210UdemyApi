using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseManager
    {
        public Task<IEnumerable<Course>> PopularCourses();
        public Task<Course> CourseId(int id);
        public Task CourseAdded(Course course);
    }
}
