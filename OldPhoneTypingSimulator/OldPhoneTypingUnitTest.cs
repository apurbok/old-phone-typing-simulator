using OldPhoneTypingSimulator;
using Xunit;

namespace OldPhoneTypingUnitTest
{
    public class OldPhoneTest
    {
        public static IEnumerable<object[]> UnitTestValidData()
        {
            yield return new object[] { "227*#", "B" };
            yield return new object[] { "4433555 555666#", "HELLO" };
            yield return new object[] { "231242 22#", "AD&AGAB" };
            yield return new object[] { "998422222#", "XTGB" };
            yield return new object[] { "4533*5#", "GJJ" };
            yield return new object[] { "45***3 78 *9 9*4#", "DPWG" };
            yield return new object[] { "6059 999#", "M JWY" };
            yield return new object[] { "2000308#", "A   D T" };
            yield return new object[] { "11111111111111111111 111111111111#", "'(" };
            yield return new object[] { "***1#", "&" };
            yield return new object[] { "*#", "" };
            yield return new object[] { "#", "" };
        }

        [Theory]
        [MemberData(nameof(UnitTestValidData))]
        public void TestCaseForValidInput(string input, string actualResult)
        {
            var testResult = OldPhone.OldPhonePad(input);
            Assert.Equal(testResult, actualResult);
        }


        [Theory]
        [InlineData("20#00308#")]
        [InlineData("32AB4#")]
        [InlineData("@#$%^&*")]
        [InlineData("1243534")]
        [InlineData("fdsfsf")]
        [InlineData("##")]
        public void TestCaseForInvalidInput(string input)
        {
            Assert.Throws<ArgumentException>(() => OldPhone.OldPhonePad(input));
        }
    }
}

