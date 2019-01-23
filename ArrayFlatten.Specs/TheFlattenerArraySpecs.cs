using FluentAssertions;
using NUnit.Framework;

namespace ArrayFlatten.Specs
{
    public class TheFlattenerArraySpecs
    {
        [Test]
        public void FlattensExampleArray()
        {
            TheFlattener.FlattenizeObject(new object[] { new object[] { 1, 2, new[] { 3 } }, 4 }).Should().Equal(new[] { 1, 2, 3, 4 });
        }

        [Test]
        public void FlattensEmptyArray()
        {
            TheFlattener.FlattenizeObject(new object[0]).Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensNull()
        {
            TheFlattener.FlattenizeObject(null).Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensEmptyNestedArray()
        {
            TheFlattener.FlattenizeObject(new object[] { new object[] { new object[] { new object[] { } } } }).Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensWeirdlyNestedArray()
        {
            TheFlattener.FlattenizeObject(new object[] { new object[] { new object[] { 3, 4, new object[] { 1, 2 } } } }).Should().Equal(new int[] { 3, 4, 1, 2 });
        }
    }
}