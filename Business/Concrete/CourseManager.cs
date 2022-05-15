using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseDal _dal;

        public CourseManager(ICourseDal dal)
        {
            _dal = dal;
        }

        public async Task CourseAdded(Course course)
        {
            course.PublishDate = DateTime.Now;
           await _dal.AddCourse(course);
        }

        public async Task<Course> CourseId(int id)
        {
            return await _dal.GetCourseById(id);
        }

        public async Task<IEnumerable<Course>> PopularCourses()
        {
            return  await _dal.GetPopularCourses();
        }
    }
}
