using TechTalk.SpecFlow;
using Example;
using NUnit.Framework;
using System;

namespace GettingStarted.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private Calculator calculator = new Calculator();
        private int Result;
        
        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {

            calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {

            Result = calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            Assert.AreEqual(expectedResult, Result);
        }


        [Given(@"the numerator is (.*)")]
        public void GivenTheNumeratorIs(int p)
        {
            calculator.Numerator = p;
        }

        [Given(@"the denominator is (.*)")]
        public void GivenTheDenominatorIs(int p)
        {
            calculator.Denominator = p;
        }
        [When(@"the numbers are divided")]
        public void WhenTheNumbersAreDivided()
        {
            Result = calculator.Divide();
        }

        [When(@"the denominator is (.*)")]
        public void WhenTheDenominatorIs(int p)
        {
            calculator.Denominator = p;
        }

        [Then(@"divide by zero exception")]
        public void ThenDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide());

        }


    }
}