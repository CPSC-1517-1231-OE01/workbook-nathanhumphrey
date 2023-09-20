namespace Utils
{
    public static class Utilities
    {
        public static bool IsNullEmptyOrWhiteSpace(string value) => string.IsNullOrWhiteSpace(value);

        public static bool IsZeroOrNegative(int value) => value <= 0;

        public static bool IsPositive(int value) => value > 0;

        /// <summary>
        /// Determines if a DateOnly is in the future, tomorrow or greater
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInTheFuture(DateOnly value) => value > DateOnly.FromDateTime(DateTime.Now);
    }
}