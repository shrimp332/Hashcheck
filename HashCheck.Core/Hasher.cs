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

        public static HashVerififcation VerifyHashStream(Stream stream, string hash)
        {
            var kind = InferKind(Hasher.NormaliseHash(hash));
            if (kind == null)
            {
                throw new InvalidHashKindException();
            }
            var actual = ComputeStream(stream, kind.Value);
            return new HashVerififcation(kind.Value, hash, actual, CompareHash(hash, actual));
        }

        public static HashVerififcation VerifyHashPath(string path, string hash)
        {
            using (var stream = File.OpenRead(path))
            {
                return VerifyHashStream(stream, hash);
            }
        }

        public static bool CompareHash(string inputHash, string hash)
        {
            return NormaliseHash(inputHash) == NormaliseHash(hash);
        }

        /// <summary>
        /// lowercase
        /// </summary>
        public static string NormaliseHash(string hash)
        {
            hash = hash.ToLowerInvariant();
            return hash;
        }

        public static HashKind? InferKind(string nomralisedHash)
        {
            switch (nomralisedHash.Length)
            {
                case 32:
                    return HashKind.MD5;
                case 40:
                    return HashKind.SHA1;
                case 64:
                    return HashKind.SHA256;
                case 128:
                    return HashKind.SHA512;
                default:
                    return null;
            }
        }
    }
}

