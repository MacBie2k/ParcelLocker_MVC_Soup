using System;

namespace ParcelLocker.ExtensionMethods
{
    public static class GenerateNumber
    {
        public static string RandomNumber(int index)
        {
            Random rnd = new();
            string number ="";
            for (int i = 0; i < index; i++)
            {
                number += rnd.Next(10).ToString();
            }

            return number;
        }

    }
}
