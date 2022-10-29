using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineService.BLL.Interface.Services;

namespace SerialsOnlineCenter.Controllers
{
    public class GenericController<TService, TModel, TViewModel> : ControllerBase where TService : IGenericService<TModel>
    {
        protected readonly TService _service;
        protected readonly IMapper _mapper;

        public GenericController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IReadOnlyList<TViewModel>> GetAll(CancellationToken cancellationToken)
        {
            var models = await _service.GetAll(cancellationToken);
            var result = _mapper.Map<IReadOnlyList<TViewModel>>(models);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<TViewModel> GetById(int id, CancellationToken cancellationToken)
        {
            var model = await _service.GetById(id, cancellationToken);
            var result = _mapper.Map<TViewModel>(model);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<TViewModel> DeleteById(int id, CancellationToken cancellationToken)
        {
            var model = await _service.Delete(id, cancellationToken);
            var result = _mapper.Map<TViewModel>(model);

            return result;
        }
    }
}
