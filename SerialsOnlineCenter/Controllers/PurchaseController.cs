using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SerialsOnlineCenter.ViewModels;
using SerialsOnlineService.BLL.Interface.Services;
using SerialsOnlineService.BLL.Models;

namespace SerialsOnlineCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : GenericController<IPurchaseService, Purchase, PurchaseViewModel>
    {
        private readonly IPurchaseService _service;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }
    }
}
