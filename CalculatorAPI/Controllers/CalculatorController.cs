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
        public List<Operation> StoreLeft(Guid guid, double number)
        {
            numberStore.Store(number, guid, Position.Left);
            return calculator.Options(numberStore.Retrieve(guid));
        }

        // POST api/<CalculatorController>/5
        [HttpPost("{guid}")]
        public List<Operation> StoreRight(Guid guid, double number)
        {
            numberStore.Store(number, guid, Position.Right);
            return calculator.Options(numberStore.Retrieve(guid));
        }

        // PUT api/<CalculatorController>/5
        [HttpPut("{guid}")]
        public double? Calculate(Guid guid, Operation operation)
        {
            double? result = null;

            // only call calculate if the operation is not Clear
            if (operation != Operation.Clear)
            {
                result = calculator.Calculate(numberStore.Retrieve(guid), operation);
            }

            // clean up numberStore after performing the operation
            numberStore.Clear(guid);

            return result;
        }
    }
}
