using FluentAssertions;
using NUnit.Framework;

namespace ArrayFlatten.Specs
{
    public class TheFlattenerStringSpecs
    {
        [Test]
        public void FlattensExampleString()
        {
            TheFlattener.Flattenize("[[1,2,[3]],4]").Should().Equal(new[] { 1, 2, 3, 4 });
        }

        [Test]
        public void FlattensWhitespaceString()
        {
            TheFlattener.Flattenize("    ").Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensEmptyString()
        {
            TheFlattener.Flattenize(string.Empty).Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensNullString()
        {
            TheFlattener.Flattenize(null).Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensEmptyArrayString()
        {
            TheFlattener.Flattenize("[]").Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensEmptyNestedArrayString()
        {
            TheFlattener.Flattenize("[[[]]]").Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensWeirdlyNestedArrayString()
        {
            TheFlattener.Flattenize("[[[3,4,[1,2]]]]").Should().Equal(new int[] { 3, 4, 1, 2 });
        }
    }
}