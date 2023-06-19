using JapPlatformBackend.Core.Dtos.Lecture;
using JapPlatformBackend.Core.Entities;

namespace JapPlatformBackend.Core.Interfaces.Repositories
{
    public interface ILectureRepository : IBaseRepository<Lecture, CreateLectureDto, UpdateLectureDto, GetLectureDto>
    {
    }
}
