using YiJingFramework.StemsAndBranches;

for (int i = 1; i <= 10; i++)
{
    var s = (HeavenlyStem)i;
    Console.WriteLine("case \"{0}\":", s.ToString("G").ToLowerInvariant());
    Console.WriteLine("case \"{0}\":", s.ToString("C").ToLowerInvariant());
    Console.WriteLine("case \"{0}\":", s.ToString("N").ToLowerInvariant());
    Console.WriteLine("result = new HeavenlyStem({0});", s.Index);
    Console.WriteLine("return true;");
}
Console.WriteLine("default:");
Console.WriteLine("result = default;");
Console.WriteLine("return false;");

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

for (int i = 1; i <= 12; i++)
{
    var s = (EarthlyBranch)i;
    Console.WriteLine("case \"{0}\":", s.ToString("G").ToLowerInvariant());
    Console.WriteLine("case \"{0}\":", s.ToString("C").ToLowerInvariant());
    Console.WriteLine("case \"{0}\":", s.ToString("N").ToLowerInvariant());
    Console.WriteLine("result = new EarthlyBranch({0});", s.Index);
    Console.WriteLine("return true;");
}
Console.WriteLine("default:");
Console.WriteLine("result = default;");
Console.WriteLine("return false;");
