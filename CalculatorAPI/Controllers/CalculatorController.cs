using Microsoft.AspNetCore.Mvc;
using CalculatorAPI.Models;
using static CalculatorAPI.Models.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private NumberStore numberStore = new NumberStore();
        private Calculator calculator = new Calculator();

        // GET: api/<CalculatorController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<CalculatorController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CalculatorController>
        [HttpPost]
        public List<Operation> StoreLeft(double number, Guid guid)
        {
            numberStore.Store(number, guid, Position.Left);
            var options = calculator.Options(numberStore.Retrieve(guid));
            return options;
        }

        //[HttpPost]
        //public List<Operation> StoreRight([FromBody] double number, Guid guid)
        //{
        //    numberStore.Store(number, guid, Position.Right);
        //    return calculator.Options(numberStore.Retrieve(guid));
        //}

        //[HttpPost]
        //public double? Calculate([FromBody] Operation operation, Guid guid)
        //{
        //    return calculator.Calculate(numberStore.Retrieve(guid), operation);
        //}

        //// PUT api/<CalculatorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
    }
}
