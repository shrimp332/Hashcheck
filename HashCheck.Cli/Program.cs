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

    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.Error.WriteLine(usage);
            Environment.Exit(1);
        }

        switch (args[0].ToLower())
        {
            case "generate":
                try { Generate(args); }
                catch (FileNotFoundException ex) { Console.Error.WriteLine($"Error: {ex.Message}"); }
                catch (UnauthorizedAccessException ex) { Console.Error.WriteLine($"Error: {ex.Message}"); }
                break;
            case "verify":
                Verify(args);
                break;
            default:
                Console.Error.WriteLine($"Unknown command verb: {args[0]}");
                Console.Error.WriteLine(usage);
                Environment.Exit(1);
                break;
        }

    }

    static void Generate(string[] args)
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

    static void Verify(string[] args)
    {

    }
}

