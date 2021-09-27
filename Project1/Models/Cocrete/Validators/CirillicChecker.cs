using Project1.Models.Abstract;

namespace Project1.Models.Cocrete.Validators
{
    public class CirillicChecker : ISymbolsChecker
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
            foreach(var c in input)
            {
                if (IsCharCyrellic(c))
                    return true;
            }

            return false;
        }

        private bool IsCharCyrellic(char c)
        {
            return (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я');
        }
    }
}
