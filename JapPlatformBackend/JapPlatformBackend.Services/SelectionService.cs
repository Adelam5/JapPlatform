using AutoMapper;
using JapPlatformBackend.Common;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Core.Interfaces.Repositories;

namespace JapPlatformBackend.Services
{
    public class SelectionService : ISelectionService
    {
        private readonly IMapper mapper;
        private readonly ISelectionRepository selectionRepository;

        public SelectionService(IMapper mapper, ISelectionRepository selectionRepository)
        {
            this.mapper = mapper;
            this.selectionRepository = selectionRepository;
        }

        public async Task<ServiceResponse<GetSelectionDto>> GetById(int id)
        {
            var includes = "Program, Students";
            var response = new ServiceResponse<GetSelectionDto>
            {
                Data = await selectionRepository.GetById(id, includes)
            };
            return response;
        }

        public async Task<PagedResponse<List<GetSelectionDto>>> List(SelectionSearchDto search)
        {
            var newSearch = mapper.Map<BaseSearch>(search);
            newSearch.Includes = "Program";

            return await selectionRepository.List(newSearch);
        }

        public async Task<ServiceResponse<GetSelectionDto>> Create(CreateSelectionDto newSelection)
        {
            var response = new ServiceResponse<GetSelectionDto>
            {
                Data = await selectionRepository.Create(newSelection)
            };
            return response;
        }

        public async Task<ServiceResponse<GetSelectionDto>> Update(int id, UpdateSelectionDto updatedSelection)
        {
            var response = new ServiceResponse<GetSelectionDto>
            {
                Data = await selectionRepository.Update(id, updatedSelection)
            };
            return response;
        }

        public async Task<ServiceResponse<List<GetSelectionDto>>> Delete(int id)
        {
            var includes = "Students";

            var response = new ServiceResponse<List<GetSelectionDto>>
            {
                Data = await selectionRepository.Delete(id, includes)
            };
            return response;
        }

        public async Task<ServiceResponse<GetSelectionDto>> AddStudent(int studentId, int slectionId)
        {
            var response = new ServiceResponse<GetSelectionDto>
            {
                Data = await selectionRepository.AddStudent(studentId, slectionId)
            };
            return response;
        }

        public async Task<ServiceResponse<GetSelectionDto>> RemoveStudent(int studentId, int slectionId)
        {
            var response = new ServiceResponse<GetSelectionDto>
            {
                Data = await selectionRepository.RemoveStudent(studentId, slectionId)
            };
            return response;
        }

    }
}
