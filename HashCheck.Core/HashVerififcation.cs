namespace HashCheck.Core
{
    public readonly struct HashVerififcation
    {
        public HashKind Kind { get; }
        public string InputHash { get; }
        public string ActualHash { get; }
        public bool Verified { get; }

        public HashVerififcation(HashKind kind, string inputHash, string actualHash, bool verified)
        {
            Kind = kind;
            InputHash = inputHash;
            ActualHash = actualHash;
            Verified = verified;
        }
    }
}
