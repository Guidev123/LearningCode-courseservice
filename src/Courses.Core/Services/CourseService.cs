using Courses.Core.Entities;
using Courses.Core.Entities.Validations;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;

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
                return new Response<Course?>(null, 400, "Error", errorMessages);

            await _courseRepository.CreateAsync(course);

            return new Response<Course?>(null, 201, "");
        }

        public async Task<Response<Course?>> DeleteAsync(Guid id)
        {
            var course = await _courseRepository.GetById(id);
            if (course is null)
                return new Response<Course?>(null, 404, "Este curso nao existe");

            if (course.Modules.Any())
                return new Response<Course?>(null, 400, "O curso tem modulos registrados");

            course.SetEntityAsDeleted();
            _courseRepository.UpdateAsync(course);

            return new Response<Course?>(null, 204, "Curso excluido");
        }

        public Task<Response<Course?>> UpdateAsync(Guid id, Course course)
        {
            throw new NotImplementedException();
        }
    }
}
