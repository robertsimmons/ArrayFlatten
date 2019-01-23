using FluentAssertions;
using NUnit.Framework;

namespace ArrayFlatten.Specs
{
    public class TheFlattenerStringRegexSpecs
    {
        [Test]
        public void FlattensExampleStringWithRegex()
        {
            TheFlattener.FlattenizeWithRegex("[[1,2,[3]],4]").Should().Equal(new[] { 1, 2, 3, 4 });
        }

        [Test]
        public void FlattensWhitespaceString()
        {
            TheFlattener.FlattenizeWithRegex("    ").Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensEmptyString()
        {
            TheFlattener.FlattenizeWithRegex(string.Empty).Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensNullString()
        {
            TheFlattener.FlattenizeWithRegex(null).Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensEmptyArrayString()
        {
            TheFlattener.FlattenizeWithRegex("[]").Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensEmptyNestedArrayString()
        {
            TheFlattener.FlattenizeWithRegex("[[[]]]").Should().Equal(new int[0]);
        }

        [Test]
        public void FlattensWeirdlyNestedArrayString()
        {
            TheFlattener.FlattenizeWithRegex("[[[3,4,[1,2]]]]").Should().Equal(new int[] { 3, 4, 1, 2 });
        }
    }
}