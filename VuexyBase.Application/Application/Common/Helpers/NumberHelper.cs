namespace VuexyBase.Application.Common.Helpers
{
    public static class NumberHelper
    {
        public static int GetRandomNumber(int numberOfDigits = 4)
        {
            Random random = new Random();
            int minValue = (int)Math.Pow(10, numberOfDigits - 1);
            int maxValue = (int)Math.Pow(10, numberOfDigits) - 1;
            return random.Next(minValue, maxValue);
        }

        public static int GenerateCode(int numberOfDigits = 4, bool isTest = true)
        {
            if (isTest)
                return int.Parse("1" + new string('2', numberOfDigits - 1));

            return GetRandomNumber(numberOfDigits);
        }

    }
}
