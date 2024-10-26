using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Domain.Entities
{
    public class Module : Entity
    {
        public Module(Guid courseId, string name, string description, Course course, List<Lesson> lessons)
        {
            CourseId = courseId;
            Name = name;
            Description = description;
            Course = course;
            Lessons = lessons;
        }

        public Guid CourseId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Course Course { get; private set; }
        public List<Lesson> Lessons { get; private set; }
    }
}
