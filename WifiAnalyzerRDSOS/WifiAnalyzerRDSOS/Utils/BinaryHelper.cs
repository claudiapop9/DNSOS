using System;

namespace WifiAnalyzerRDSOS.Utils
{
    public static class BinaryHelper
    {
        #region Short

        public static short Read16Bits(byte[] rawData, int offset)
        {
            var toConvert = GetInterval<byte>(rawData, offset, 2);
            return ConvertToShort(toConvert);
        }

        public static short ConvertToShort(byte[] source)
        {
            var normalizedList = new byte[2] { 0, 0 };

            if (source.Length > 2) throw new Exception("Byte array too long to be converted to int16.");
            for (int i = 0; i < source.Length; i++)
            {
                normalizedList[source.Length - i - 1] = source[i];
            }
            var result = BitConverter.ToInt16(normalizedList, 0);
            return result;
        }

        #endregion

        #region Int

        public static int Read32Bits(byte[] rawData, int offset)
        {
            var toConvert = GetInterval<byte>(rawData, offset, 4);
            return ConvertToInt(toConvert);
        }

        public static int ConvertToInt(byte[] source)
        {
            var normalizedList = new byte[4] { 0, 0, 0, 0 };

            if (source.Length > 4) throw new Exception("Byte array too long to be converted to int16.");
            for (int i = 0; i < source.Length; i++)
            {
                normalizedList[source.Length - i - 1] = source[i];
            }
            var result = BitConverter.ToInt32(normalizedList, 0);
            return result;
        } 

        #endregion

        public static T[] GetInterval<T>(this T[] source, long startIndex, long length)
        {
            if (startIndex < 0 || startIndex + length >= source.Length) throw new Exception("Invalid subsequence");

            var result = new T[length];


            for (int i = 0; i < length; i++)
            {
                result[i] = source[i + startIndex];
            }

            return result;
        }

        
    }
}
