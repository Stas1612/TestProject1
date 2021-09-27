using Project1.Models.Abstract;

namespace Project1.Models.Cocrete.Validators
{
    public class LatinChecker : ISymbolsChecker
    {
        public bool AllSymbols(string input)
        {
            foreach (var c in input)
            {
                if (IsCharCyrellic(c) == false)
                    return false;
            }

            return true;
        }

        public bool ContainsSymbol(string input)
        {
            foreach (var c in input)
            {
                if (IsCharCyrellic(c))
                    return true;
            }

            return false;
        }

        private bool IsCharCyrellic(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
    }
}
