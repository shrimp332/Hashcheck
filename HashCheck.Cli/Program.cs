using HashCheck.Core;

bool x = Hasher.CompareString("", "");
string y = Hasher.ComputeFile("File Path", HashKind.Md5);

Console.WriteLine($"{x}, {y}");
