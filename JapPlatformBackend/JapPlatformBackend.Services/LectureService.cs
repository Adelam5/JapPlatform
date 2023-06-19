using AutoMapper;
using JapPlatformBackend.Common;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Dtos.Lecture;
using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Core.Interfaces.Repositories;

namespace JapPlatformBackend.Services
{
    public class LectureService : ILectureService
    {
        private readonly IMapper mapper;
        private readonly ILectureRepository lectureRepository;

        public LectureService(IMapper mapper, ILectureRepository lectureRepository)
        {
            this.mapper = mapper;
            this.lectureRepository = lectureRepository;
        }

        public async Task<ServiceResponse<GetLectureDto>> GetById(int id)
        {
            var response = new ServiceResponse<GetLectureDto>
            {
                Data = await lectureRepository.GetById(id)
            };
            return response;
        }

        public async Task<PagedResponse<List<GetLectureDto>>> List(ItemSearchDto search)
        {
            return await lectureRepository.List(mapper.Map<BaseSearch>(search));
        }

        public async Task<ServiceResponse<GetLectureDto>> Create(CreateLectureDto newLecture)
        {
            var response = new ServiceResponse<GetLectureDto>
            {
                Data = await lectureRepository.Create(newLecture)
            };
            return response;
        }

        public async Task<ServiceResponse<GetLectureDto>> Update(int id, UpdateLectureDto updatedLecture)
        {
            var response = new ServiceResponse<GetLectureDto>
            {
                Data = await lectureRepository.Update(id, updatedLecture)
            };
            return response;
        }
        public async Task<ServiceResponse<List<GetLectureDto>>> Delete(int id)
        {
            var response = new ServiceResponse<List<GetLectureDto>>
            {
                Data = await lectureRepository.Delete(id)
            };
            return response;
        }

    }
}
