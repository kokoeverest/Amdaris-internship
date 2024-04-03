using StructuralDesignPatterns.Decorators;

namespace StructuralDesignPatterns
{
    public class BaseFormatDecorator
    {
        private string _currentText;
        private readonly List<Decorator> _decorators;
        public BaseFormatDecorator(string text)
        {
            _currentText = text;
            _decorators = [];
        }

        public int DecoratorsCount => _decorators.Count;
        public void AddFormat(Decorator decorator)
        {
            _decorators.Add(decorator);

        }

        public bool Print()
        {
            foreach (Decorator decorator in _decorators)
            {
                _currentText = decorator.Decorate(_currentText);
            }
            Console.WriteLine(_currentText);
            return true;
        }
    }
}
