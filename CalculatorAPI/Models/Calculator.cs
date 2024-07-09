using CalculatorAPI.Interfaces;
using Newtonsoft.Json.Linq;
using static CalculatorAPI.Models.Helpers;

namespace CalculatorAPI.Models
{
    public class Calculator : ICalculator
    {
        /// <summary>
        /// performs mathematical calculation of numbers based on the operation provided
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operation"></param>
        /// <returns>result of operation</returns>
        public double? Calculate(Numbers numbers, Operation operation)
        {
            double? retVal = null;

            // only perform operation if neither number is null
            if (numbers.RightNumber.HasValue && numbers.LeftNumber.HasValue)
            {
                switch (operation)
                {
                    case Operation.Add:
                        retVal = numbers.LeftNumber + numbers.RightNumber;
                        break;
                    case Operation.Subtract:
                        retVal = numbers.LeftNumber - numbers.RightNumber;
                        break;
                    case Operation.Multiply:
                        retVal = numbers.LeftNumber * numbers.RightNumber;
                        break;
                    case Operation.Divide:
                        retVal = numbers.LeftNumber / numbers.RightNumber;
                        break;
                }
            }

            return retVal;
        }

        /// <summary>
        /// creates a list of valid operations based on the numbers
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>list of valid operations</returns>
        public List<Operation> Options(Numbers numbers)
        {
            // generate a collection of our operations
            var values = Enum.GetValues(typeof(Operation)).Cast<Operation>();

            // only return math operations if both numbers are not null
            if (numbers.LeftNumber.HasValue && numbers.RightNumber.HasValue)
            {
                // exclude "divide" if the right value is 0 (cannot divide by 0)
                if (numbers.RightNumber == 0)
                {
                    values = values.Where(x => x != Operation.Divide);
                }
            } 
            else
            {
                // only return clear operation
                values = values.Where(x => x == Operation.Clear);
            }

            

            return values.ToList();
        }
    }
}
