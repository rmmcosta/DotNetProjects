using NUnit.Framework;
using StackExercise;

namespace StackExerciseTest
{
    public class Tests
    {
        StackExercise<int> intStack;
        StackExercise<string> stringStack;

        [SetUp]
        public void Setup()
        {
            intStack = new MyStack<int>();
            stringStack = new MyStack<string>();
        }

        [Test]
        public void PushInt()
        {
            Assert.True(intStack.IsEmpty());
            intStack.Push(5);
            Assert.False(intStack.IsEmpty());
        }

        [Test]
        public void PopInt()
        {
            intStack.Push(5);
            Assert.AreEqual(5, intStack.Pop());
        }

        [Test]
        public void PushString()
        {
            Assert.True(stringStack.IsEmpty());
            stringStack.Push("cenas");
            Assert.False(stringStack.IsEmpty());
        }

        [Test]
        public void PopString()
        {
            stringStack.Push("coisas");
            Assert.AreEqual("coisas", stringStack.Pop());
        }

        [Test]
        public void PopFromEmpty()
        {
            Assert.IsNull(stringStack.Pop());
            Assert.AreEqual(0, intStack.Pop());
        }
    }
}