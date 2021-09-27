using System;

namespace Project1.Models.Abstract
{
    public interface ISymbolsChecker
    {
        bool AllSymbols(string input);
        bool ContainsSymbol(string input);
    }
}
