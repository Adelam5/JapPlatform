using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Dtos.Lecture;

namespace JapPlatformBackend.Core.Interfaces
{
    public interface ILectureService
    {
        Task<ServiceResponse<GetLectureDto>> GetById(int id);
        Task<PagedResponse<List<GetLectureDto>>> List(ItemSearchDto search);
        Task<ServiceResponse<GetLectureDto>> Create(CreateLectureDto newLecture);
        Task<ServiceResponse<GetLectureDto>> Update(int id, UpdateLectureDto updatedLecture);
        Task<ServiceResponse<List<GetLectureDto>>> Delete(int id);
    }
}
