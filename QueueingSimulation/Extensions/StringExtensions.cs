namespace QueueingSimulation.Extensions
{
    public static class StringExtensions
    {
        public static bool Equals(this string str, params string[] values)
        {
            foreach (var value in values)
            {
                if (string.Equals(str, value, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
