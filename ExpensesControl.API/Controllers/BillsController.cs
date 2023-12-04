using AutoMapper;
using ExpensesControl.API.Models;
using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;
        private readonly IMapper _mapper;
        public BillsController(IBillService billService, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<BillModel> Get()
        {
            return _billService.Get();
        }

        [HttpPost]
        public bool Create(BillDto bill)
        {
            var billModel = _mapper.Map<BillDto, BillModel>(bill);
            _billService.Create(billModel);
            return true;
        }
    }
}
