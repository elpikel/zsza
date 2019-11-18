using Xunit;

namespace zsza
{
  public class Unit2
    {
        [Theory]
        [InlineData(5, new [] { 1, 4, 3, 2, 5 }, "TAK")]
        [InlineData(5, new [] { 1, 4, 3, 3, 5 }, "NIE")]
        public void Permutations(int n, int [] numbers, string result)
        {
            Assert.Equal(result, IsPermutation(n, numbers));
        }

        private string IsPermutation(int n, int [] numbers)
        {
            var counts = new int[n + 1];

            for (int i = 0; i < n; i++) {
                counts[numbers[i]] += 1;

                if (counts[numbers[i]] > 1)
                    return "NIE";
            }

            return "TAK";
        }
    }
}
