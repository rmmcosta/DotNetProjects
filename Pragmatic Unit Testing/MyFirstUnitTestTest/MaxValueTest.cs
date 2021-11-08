using NUnit.Framework;
using ArrayMaxValue;

namespace MyFirstUnitTestTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PositiveNumbersBegin()
        {
            Assert.AreEqual(9, MaxValue.getMaxValaue(new int[] { 9, 8, 7 }));
        }

        [Test]
        public void PositiveNumbersMiddle()
        {
            Assert.AreEqual(9, MaxValue.getMaxValaue(new int[] { 7, 9, 8 }));

        }

        [Test]
        public void PositiveNumbersEnd()
        {
            Assert.AreEqual(9, MaxValue.getMaxValaue(new int[] { 7, 8, 9 }));

        }

        [Test]
        public void NegativeNumbersBegin()
        {
            Assert.AreEqual(-7, MaxValue.getMaxValaue(new int[] { -7, -8, -9 }));

        }

        [Test]
        public void NegativeNumbersMiddle()
        {
            Assert.AreEqual(-7, MaxValue.getMaxValaue(new int[] { -8, -7, -9 }));

        }

        [Test]
        public void NegativeNumbersEnd()
        {
            Assert.AreEqual(-7, MaxValue.getMaxValaue(new int[] { -9, -8, -7 }));

        }
    }
}