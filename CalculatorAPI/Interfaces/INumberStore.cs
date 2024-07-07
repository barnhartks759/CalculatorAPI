using static CalculatorAPI.Models.Helpers;

namespace CalculatorAPI.Interfaces
{
    public interface INumberStore
    {
        void Clear(Guid guid);

        void Store(double number, Guid guid, Position position);

        Numbers Retrieve(Guid guid);
    }
}
