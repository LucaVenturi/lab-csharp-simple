using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        // TODO fill this class
        private char? _operation;
        private Complex _intermediateResult;

        public Complex Value { get; set; }
        public char? Operation
        {
            get => _operation;
            set
            {
                if (Operation.HasValue)
                {
                    ComputeResult();
                }
                _operation = value;
                _intermediateResult = Value;
                Value = null;
            }
        }
        public void Reset()
        {
            Value = null;
            Operation = null;
        }

        public void ComputeResult()
        {
            switch (_operation)
            {
                case OperationPlus:
                    Value = _intermediateResult.Plus(Value);
                    break;
                case OperationMinus:
                    Value = _intermediateResult.Minus(Value);
                    break;
                default:
                    break;
            }
            _operation = null;
            _intermediateResult = null;
        }

        public override string ToString()
        {
            return $"Calculator shows Value {Value}, is storing operation {_operation} and an intermidiate result {_intermediateResult}";
        }
    }
}