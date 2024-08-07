using NFluent;
using NUnit.Framework;
namespace StringCalculatorTest;

public class StringCalculatorTest
{
    [Test]
    public void ShouldReturn0WhenInputIsEmpty()
    {
        var stringCalculator = new StringCalculator();
        Check.That(stringCalculator.Add("")).IsEqualTo(0);
    }

    [Test]
    public void ShouldReturn1WhenInputContains1()
    {
        var stringCalculator = new StringCalculator();
        Check.That(stringCalculator.Add("1")).IsEqualTo(1);
    }

    [Test]
    public void ShouldReturn3WhenInputContains1And2SeparatedByComma()
    {
        var stringCalculator = new StringCalculator();
        Check.That(stringCalculator.Add("1,2")).IsEqualTo(3);
    }
    
    [Test]
    public void ShouldReturn10WhenInputContains1And2And3And4SeparatedByComma()
    {
        var stringCalculator = new StringCalculator();
        Check.That(stringCalculator.Add("1,2,3,4")).IsEqualTo(10);
    }

    [Test]
    public void ShouldReturn6WhenInputContains1And2And3SeparatedByNewlineAndComma()
    {
        var stringCalculator = new StringCalculator();
        Check.That(stringCalculator.Add("1\n2,3")).IsEqualTo(6);
    }

    [Test]
    public void ShouldReturn3WhenInputcontainsDifferentDelimiterAndNumbers()
    {
        var stringCalculator = new StringCalculator();
        Check.That(stringCalculator.Add("//,\\n1,2")).IsEqualTo(3);
    }

    [Test]
    public void ShouldThrowAnErrorWhenInputContainsOneNeagativeNumber()
    {
        var stringCalculator = new StringCalculator();
        Check.ThatCode(() => stringCalculator.Add("-1,2")).Throws<Exception>().WithMessage("Negatives are not allowed: -1");
    }
    
    [Test]
    public void ShouldThrowAnErrorWhenInputContainsNeagativeNumbers()
    {
        var stringCalculator = new StringCalculator();
        Check.ThatCode(() => stringCalculator.Add("-1,-2,-3")).Throws<Exception>().WithMessage("Negatives are not allowed: -1,-2,-3");
    }

    [Test]
    public void ShouldIgnoredWhenNumberAreBiggerThan1000()
    {
        var stringCalculator = new StringCalculator();
        Check.That(stringCalculator.Add("1000,2")).IsEqualTo(2);
    }
}