using System.Security.Cryptography;
using System.Text;
using Force.Crc32;
using PangeaCyber.Net.FileScan.Models;

namespace PangeaCyber.Net
{
    /// <summary>Utilities.</summary>
    public static class Utils
    {
        ///
        public static string StringToStringB64(string input)
        {
            // Convert the string to a byte array
            byte[] bytes = Encoding.UTF8.GetBytes(input);

            // Convert the byte array to a Base64 string
            return Convert.ToBase64String(bytes);
        }

        ///
        public static string Base64ToString(string input)
        {
            // Convert Base64 string to byte array
            byte[] bytes = Convert.FromBase64String(input);

            // Decode byte array to string
            return Encoding.UTF8.GetString(bytes);
        }

        ///
        public static string Bytes2Hex(byte[] bytes)
        {
            StringBuilder builder = new();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2")); // Convert each byte to its hexadecimal representation
            }
            return builder.ToString();
        }

        ///
        public static string GetSHA256Hash(string input)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return Bytes2Hex(hashBytes);
        }

        ///
        public static string GetSHA1Hash(string input)
        {
            using SHA1 sha1 = SHA1.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha1.ComputeHash(inputBytes);
            return Bytes2Hex(hashBytes);
        }

        ///
        public static string GetSHA512Hash(string input)
        {
            using SHA512 sha1 = SHA512.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha1.ComputeHash(inputBytes);
            return Bytes2Hex(hashBytes);
        }

        ///
        public static string GetSHA256HashFromFilepath(string filepath)
        {
            using FileStream stream = File.OpenRead(filepath);
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(stream);
            return Bytes2Hex(hashBytes);
        }

        ///
        public static string GetSHA1HashFromFilepath(string filepath)
        {
            using FileStream stream = File.OpenRead(filepath);
            using SHA1 sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(stream);
            return Bytes2Hex(hashBytes);
        }

        ///
        public static string GetHashPrefix(string input, int len = 5)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return input.Substring(0, len);
        }

        ///
        public static byte[] GetBytes(uint number)
        {
            byte[] bytes = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return bytes;
        }

        ///
        public static FileParams GetUploadFileParams(FileStream file)
        {
            String crcHash, sha256hash;
            int size = 0;
            uint crc = 0;

            // Calculate SHA256
            file.Seek(0, SeekOrigin.Begin);
            using SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(file);
            sha256hash = Bytes2Hex(hashBytes);

            // Calculate CRC32C
            file.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
            {
                size += bytesRead;
                crc = Crc32CAlgorithm.Append(crc, buffer, 0, bytesRead);
            }
            crcHash = Bytes2Hex(GetBytes(crc));

            file.Seek(0, SeekOrigin.Begin);
            return new FileParams(size, sha256hash, crcHash);
        }
    }
}
