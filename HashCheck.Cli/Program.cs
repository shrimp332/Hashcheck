namespace HashCheck.Cli;

using HashCheck.Core;

class Program
{
    static string usage =
@"Usage: HashCheck.Cli [command]
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

    static int Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine(usage);
            Environment.Exit(1);
        }

        switch (args[0].ToLower())
        {
            case "generate":
                try { return Generate(args); }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error: {ex.Message}");
                    return 1;
                }
            case "verify":
                return Verify(args);
            default:
                Console.Error.WriteLine($"Unknown command verb: {args[0]}");
                Console.Error.WriteLine(usage);
                return 1;
        }
    }

    static int Generate(string[] args)
    {
        if (args.Length < 2)
        {
            Console.Error.WriteLine(usage);
            return 1;
        }

        var filePath = args[1];
        var hashes = Hasher.ComputeAllPath(filePath);
        foreach (var hash in hashes)
        {
            Console.WriteLine($"{hash.Key}: {hash.Value}  {filePath}");
        }
        return 0;
    }

    static int Verify(string[] args)
    {
        if (args.Length < 3)
        {
            Console.Error.WriteLine(usage);
            return 1;
        }

        var filePath = args[1];
        var inputHash = args[2];


        HashVerififcation v;
        try
        {
            v = Hasher.VerifyHashPath(filePath, inputHash);
        }
        catch (InvalidHashKindException)
        {
            Console.Error.WriteLine($"Error: unable to infer hash type of {inputHash}");
            return 1;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return 1;
        }

        if (v.Verified)
        {
            Console.WriteLine($"Verified {v.Kind.ToString()}: {v.ActualHash}  {filePath}");
        }
        else
        {
            Console.WriteLine($"{v.Kind.ToString()}: {v.ActualHash}  {filePath}");
            Console.WriteLine($"input hash: {inputHash} is not the same as {v.ActualHash}");
        }
        return 0;
    }
}

