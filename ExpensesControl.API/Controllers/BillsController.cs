using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesControl.DataModelManager.Models;
using ExpensesControl.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillsController(IBillService billService)
        {
            _billService = billService;
        }
        
        [HttpGet]
        public IEnumerable<BillModel> Get()
        {
            return _billService.Get();
        }
    }
}
