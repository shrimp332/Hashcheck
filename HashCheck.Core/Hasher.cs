using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace HashCheck.Core
{
    public static class Hasher
    {
        public static string ComputeStream(Stream stream, HashKind kind)
        {
            HashAlgorithm algo;
            switch (kind)
            {
                case HashKind.MD5:
                    algo = MD5.Create();
                    break;
                case HashKind.SHA256:
                    algo = SHA256.Create();
                    break;
                case HashKind.SHA1:
                    algo = SHA1.Create();
                    break;
                case HashKind.SHA512:
                    algo = SHA512.Create();
                    break;
                default:
                    throw new InvalidOperationException("unreachable");
            }

            using (algo)
            {
                byte[] hash = algo.ComputeHash(stream);
                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    // x2 is lowercasse hex 2 digits (ff)
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static Dictionary<HashKind, string> ComputeAllStream(Stream stream)
        {
            var dict = new Dictionary<HashKind, string>();
            foreach (HashKind kind in Enum.GetValues(typeof(HashKind)))
            {
                stream.Position = 0;
                var hash = ComputeStream(stream, kind);
                dict.Add(kind, hash);
            }
            return dict;
        }

        /// <summary>
        /// Compute all possible hashes for the file
        /// </summary>
        public static Dictionary<HashKind, string> ComputeAllPath(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return ComputeAllStream(stream);
            }
        }

        public static bool CompareString(string str1, string str2)
        {
            // stub
            return false;
        }
    }
}

