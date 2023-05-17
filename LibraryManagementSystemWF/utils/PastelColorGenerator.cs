using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.utils
{
    internal class PastelColorGenerator
    {
        public static string GeneratePastelColor(string username)
        {
            // Calculate the hash code for the username using the MurmurHash3 algorithm
            byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
            uint hashCode = MurmurHash3.ComputeHash(usernameBytes);

            // Convert the hash code to a positive value
            int positiveHashCode = (int)(hashCode & 0x7FFFFFFF);

            // Map the positive hash code to the RGB range (0-16777215)
            int rgbValue = positiveHashCode % 16777216;

            // Extract the individual RGB values
            int red = (rgbValue & 0xFF0000) >> 16;
            int green = (rgbValue & 0x00FF00) >> 8;
            int blue = rgbValue & 0x0000FF;

            // Adjust the RGB values to create a pastel color
            int adjustedRed = (red + 255) / 2;
            int adjustedGreen = (green + 255) / 2;
            int adjustedBlue = (blue + 255) / 2;

            // Format the RGB values as a hexadecimal color string
            string colorHex = string.Format("#{0:X2}{1:X2}{2:X2}", adjustedRed, adjustedGreen, adjustedBlue);

            return colorHex;
        }
    }


    public class MurmurHash3
    {
        public static uint ComputeHash(byte[] data)
        {
            const uint c1 = 0xcc9e2d51;
            const uint c2 = 0x1b873593;
            const int r1 = 15;
            const int r2 = 13;
            const uint m = 5;
            const uint n = 0xe6546b64;

            uint hash = 0;
            uint remainingBytes = (uint)data.Length & 3;
            int length = data.Length - (int)remainingBytes;

            for (int i = 0; i < length; i += 4)
            {
                uint k = BitConverter.ToUInt32(data, i);

                k *= c1;
                k = RotateLeft(k, r1);
                k *= c2;

                hash ^= k;
                hash = RotateLeft(hash, r2);
                hash = hash * m + n;
            }

            if (remainingBytes > 0)
            {
                uint remainingData = 0;
                for (int i = (int)(length + remainingBytes - 1), shift = 0; i >= length; i--, shift += 8)
                    remainingData |= (uint)data[i] << shift;

                remainingData *= c1;
                remainingData = RotateLeft(remainingData, r1);
                remainingData *= c2;

                hash ^= remainingData;
            }

            hash ^= (uint)data.Length;
            hash = Fmix(hash);

            return hash;
        }

        private static uint RotateLeft(uint value, int count)
        {
            return (value << count) | (value >> (32 - count));
        }

        private static uint Fmix(uint value)
        {
            value ^= value >> 16;
            value *= 0x85ebca6b;
            value ^= value >> 13;
            value *= 0xc2b2ae35;
            value ^= value >> 16;

            return value;
        }
    }
}
