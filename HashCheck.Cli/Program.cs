using HashCheck.Core;

string usage =
@"
Usage: HashCheck.Cli [command]
Available Commands:
    generate        Generates hashes based on input for all supported algorithms
        example: HashCheck.Cli generate <file>
    verify          Verifies a supplied hash to a file
        example: HashCheck.Cli verify <file> [hash]
Supported Algorithms:
    MD5
    SHA1
    SHA256
    SHA512";

if (args.Length < 1)
{
    Console.Error.WriteLine(usage);
    Environment.Exit(1);
}

if (args[0].ToLower() == "generate")
{
    if (args.Length > 1)
    {
        var filePath = args[1];
        var hashes = Hasher.ComputeAllPath(filePath);
        foreach (var hash in hashes)
        {
            Console.WriteLine($"{hash.Key}: {hash.Value}  {filePath}");
        }
    }
    else
    {
        Console.Error.WriteLine(usage);
        Environment.Exit(1);
    }
}
