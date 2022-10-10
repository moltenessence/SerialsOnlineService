using AutoMapper;
using SerialsOnlineCenter.DAL.Entities;
using SerialsOnlineCenter.DAL.Interfaces.Repositories;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineService.BLL.Service
{
    public class SerialService : GenericService<Serial, SerialEntity>, ISerialService
    {
        private readonly ISerialRepository _repository;
        private readonly IMapper _mapper;
        public SerialService(ISerialRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
