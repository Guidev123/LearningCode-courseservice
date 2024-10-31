using Courses.Core.Entities;
using Courses.Core.Entities.Validations;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;
using Courses.Core.Responses.Messages;

namespace Courses.Core.Services
{
    public class CourseService(ICourseRepository courseRepository) : ICourseService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;
        public async Task<Response<Course?>> CreateAsync(Course course)
        {
            var validationResult = new CourseValidation().Validate(course);
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
                return new Response<Course?>(null, 400, ResponseMessages.VALID_OPERATION.GetDescription(), errorMessages);

            await _courseRepository.CreateAsync(course);

            return new Response<Course?>(null, 201, ResponseMessages.VALID_OPERATION.GetDescription());
        }

        public async Task<Response<Course?>> DeleteAsync(Guid id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course is null)
                return new Response<Course?>(null, 404, ResponseMessages.COURSE_NOT_FOUND.GetDescription());

            if (course.Modules.Any())
                return new Response<Course?>(null, 400, ResponseMessages.COURSE_CANNOT_BE_DELETED.GetDescription());

            course.SetEntityAsDeleted();
            _courseRepository.UpdateAsync(course);

            return new Response<Course?>(null, 204, ResponseMessages.VALID_OPERATION.GetDescription());
        }

        public async Task<Response<Course?>> UpdateAsync(Course course, Guid id)
        {
            var validationResult = new CourseValidation().Validate(course);
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
                return new Response<Course?>(null, 400, ResponseMessages.INVALID_OPERATION.GetDescription(), errorMessages);

            var oldCourse = await _courseRepository.GetByIdAsync(id);
            if(oldCourse is null)
                return new Response<Course?>(null, 404, ResponseMessages.COURSE_NOT_FOUND.GetDescription());

            oldCourse.UpdateCourse(course.Name, course.Description, course.JustForPremium);
            _courseRepository.UpdateAsync(oldCourse);

            return new Response<Course?>(null, 204, ResponseMessages.VALID_OPERATION.GetDescription());
        }
    }
}
