using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesControl.API.Models;
using ExpensesControl.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditBucketsController : ControllerBase
    {
        private readonly ICreditBucketService _creditBucketService;
        public CreditBucketsController(ICreditBucketService creditBucketService)
        {
            _creditBucketService = creditBucketService;
        }

        [HttpGet]
        public IEnumerable<CreditBucketModel> Get()
        {
            return _creditBucketService.Get();
        }

        [HttpGet("{id}")]
        public CreditBucketModel? GetBy(int id)
        {
            return _creditBucketService.Get(id);
        }

        [HttpPost]
        public CreditBucketModel? Create(CreditBucketModel creditBucket)
        {
            return _creditBucketService.CreateBucket(creditBucket);
        }

        [HttpPut]
        public void Update(CreditBucketModel creditBucket)
        {
            _creditBucketService.UpdateBucket(creditBucket);
        }

        [HttpDelete]
        public void Delete(CreditBucketModel creditBucket)
        {
            _creditBucketService.DeleteBucket(creditBucket);
        }
    }
}
