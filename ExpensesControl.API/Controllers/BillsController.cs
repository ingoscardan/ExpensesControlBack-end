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

        [HttpGet("from/{startDate:datetime}/to/{endDate:datetime}")]
        public IEnumerable<BillModel> GetBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _billService.GetBetweenDates(startDate, endDate);
        }

        [HttpPost]
        public bool Create(BillDto bill)
        {
            var billModel = _mapper.Map<BillDto, BillModel>(bill);
            _billService.Create(billModel);
            return true;
        }
        
        [HttpPut]
        public bool Update(BillDto bill)
        {
            var billModel = _mapper.Map<BillDto, BillModel>(bill);
            _billService.Update(billModel);
            return true;
        }
        
        [HttpPatch("/{billId}/")]
        public bool UpdateName(int billId, [FromBody]string newName)
        {
            _billService.ChangeName(billId, newName);
            return true;
        }
    }
}
