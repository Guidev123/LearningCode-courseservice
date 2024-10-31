using Courses.Core.Entities;
using Courses.Core.Entities.Validations;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Interfaces.Services;
using Courses.Core.Responses;
using Courses.Core.Responses.Messages;

namespace Courses.Core.Services
{
    public class LessonService(ILessonRepository lessonRepository) : ILessonService
    {
        private readonly ILessonRepository _lessonRepository = lessonRepository;
        public async Task<Response<Lesson?>> CreateAsync(Lesson lesson)
        {
            var validationResult = new LessonValidation().Validate(lesson);
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
                return new Response<Lesson?>(null, 400, ResponseMessages.VALID_OPERATION.GetDescription(), errorMessages);

            await _lessonRepository.CreateAsync(lesson);

            return new Response<Lesson?>(null, 201, ResponseMessages.VALID_OPERATION.GetDescription());
        }

        public async Task<Response<Lesson?>> DeleteAsync(Guid id)
        {
            var module = await _lessonRepository.GetByIdAsync(id);
            if (module is null)
                return new Response<Lesson?>(null, 404, ResponseMessages.LESSON_NOT_FOUND.GetDescription());

            module.SetEntityAsDeleted();
            _lessonRepository.UpdateAsync(module);

            return new Response<Lesson?>(null, 204, ResponseMessages.VALID_OPERATION.GetDescription());
        }

        public async Task<Response<Lesson?>> UpdateAsync(Lesson lesson, Guid id)
        {
            var validationResult = new LessonValidation().Validate(lesson);
            var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            if (!validationResult.IsValid)
                return new Response<Lesson?>(null, 400, ResponseMessages.VALID_OPERATION.GetDescription(), errorMessages);

            var oldLesson = await _lessonRepository.GetByIdAsync(id);
            if (oldLesson is null)
                return new Response<Lesson?>(null, 404, ResponseMessages.LESSON_NOT_FOUND.GetDescription());

            oldLesson.UpdateLesson(lesson.Title, lesson.LinkVideo);
            _lessonRepository.UpdateAsync(oldLesson);

            return new Response<Lesson?>(null, 204, ResponseMessages.VALID_OPERATION.GetDescription());
        }
    }
}
