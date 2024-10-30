using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Entities;

public class Module : Entity
{
    public Module(string title, string description, Guid courseId, Course course, IEnumerable<Lesson> lessons)
    {
        Title = title;
        Description = description;
        CourseId = courseId;
        Course = course;
        Lessons = lessons;
    }

    protected Module() { }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Guid CourseId { get; private set; }
    public Course Course { get; private set; } = null!;
    public IEnumerable<Lesson> Lessons { get; private set; } = [];

}
