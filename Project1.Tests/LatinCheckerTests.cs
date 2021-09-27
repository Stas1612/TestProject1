using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1.Models.Cocrete.Validators;

namespace Project1.Tests
{
    [TestClass]
    public class LatinCheckerTests
    {
        [TestMethod]
        public void Validate_returns_false_if_input_contains_one_symbol_and_latin()
        {
            var input = "я";
            var validator = new LatinChecker();
            var contains = validator.ContainsSymbol(input);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Validate_returns_false_if_input_contains_sevaral_latin_symbols()
        {
            var input = "айё";
            var validator = new LatinChecker();
            var contains = validator.ContainsSymbol(input);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Validate_returns_false_if_input_contains_digits_only()
        {
            var input = "123";
            var validator = new LatinChecker();
            var contains = validator.ContainsSymbol(input);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Validate_returns_false_if_input_contains_plus_minus_vasya()
        {
            var input = ".+-,";
            var validator = new LatinChecker();
            var contains = validator.ContainsSymbol(input);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Validate_returns_true_if_input_contains_latin()
        {
            var input = "123яsil";
            var validator = new LatinChecker();
            var contains = validator.ContainsSymbol(input);
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void Validate_returns_false_if_input_contains_all_latin()
        {
            var input = "123яsi";
            var validator = new LatinChecker();
            var contains = validator.AllSymbols(input);
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Validate_returns_true_if_input_contains_all_latin()
        {
            var input = "abcdpiywqz";
            var validator = new LatinChecker();
            var contains = validator.AllSymbols(input);
            Assert.IsTrue(contains);
        }
    }
}
