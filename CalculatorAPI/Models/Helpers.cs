namespace CalculatorAPI.Models
{
    public class Helpers
    {
        public enum Position
        {
            Left, Right
        }

        public struct Numbers
        {
            public double? LeftNumber;
            public double? RightNumber;
        }

        public enum Operation
        {
            Add, Subtract, Multiply, Divide, Clear
        }
    }
}
