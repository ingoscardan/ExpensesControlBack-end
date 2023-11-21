using ExpensesControl.DataModelManager.Models;
using Microsoft.AspNetCore.Mvc;
using BucketModel = ExpensesControl.API.Models.BucketModel;

namespace ExpensesControl.API.Controllers.Buckets
{
    [Route("api/bucket/debits/")]
    [ApiController]
    public class DebitBucketController : ControllerBase, IBucketController<BucketModel>
    {
        [HttpGet]
        public IList<BucketModel> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public BucketModel Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}/movements")]
        public IList<MovementModel> GetMovements(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}/bills")]
        public IList<BillModel> GetBills(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public BucketModel Create(BucketModel bucket)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public BucketModel ChangeBucketDetails(BucketModel bucket)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public BucketModel Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
