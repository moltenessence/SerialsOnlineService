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

        [HttpGet]
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

        [HttpPost]
        public async Task<TViewModel> Add(TViewModel model, CancellationToken cancellationToken)
        {
            var modelToInsert = _mapper.Map<TModel>(model);

            var result = await _service.Insert(modelToInsert, cancellationToken);

            return _mapper.Map<TViewModel>(result);
        }

        [HttpPut]
        public async Task<TViewModel> Update(TViewModel model, CancellationToken cancellationToken)
        {
            var modelToInsert = _mapper.Map<TModel>(model);

            var result = await _service.Update(modelToInsert, cancellationToken);

            return _mapper.Map<TViewModel>(result);
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
