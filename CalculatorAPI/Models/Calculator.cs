using CalculatorAPI.Interfaces;
using static CalculatorAPI.Models.Helpers;

namespace CalculatorAPI.Models
{
    public class Calculator : ICalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public double? Calculate(Numbers numbers, Operation operation)
        {
            double? retVal = 0;

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

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public List<Operation> Options(Numbers numbers)
        {
            // generate a collection of our operations
            var values = Enum.GetValues(typeof(Operation)).Cast<Operation>();

            // exclude "divide" if the right value is 0 (cannot divide by 0)
            if (numbers.RightNumber == 0)
            {
                values = values.Where(x => x != Operation.Divide);
            }

            return values.ToList();
        }
    }
}
