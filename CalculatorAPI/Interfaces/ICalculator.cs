using System.Security.Cryptography;
using static CalculatorAPI.Models.Helpers;

namespace CalculatorAPI.Interfaces
{
    public interface ICalculator
    {
        List<Operation> Options(Numbers numbers);

        double? Calculate(Numbers numbers, Operation operation);
    }
}
