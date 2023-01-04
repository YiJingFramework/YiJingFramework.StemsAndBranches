using YiJingFramework.StemsAndBranches;

for (int i = 1; i <= 10; i++)
{
    var s = (HeavenlyStem)i;
    Console.WriteLine("/// <summary>");
    Console.WriteLine($"/// {s:C}。");
    Console.WriteLine($"/// {s}.");
    Console.WriteLine("/// </summary>");
    Console.WriteLine(
        $"public static HeavenlyStem {s} => new HeavenlyStem({s.Index});");
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

for (int i = 1; i <= 12; i++)
{
    var s = (EarthlyBranch)i;
    Console.WriteLine("/// <summary>");
    Console.WriteLine($"/// {s:C}。");
    Console.WriteLine($"/// {s}.");
    Console.WriteLine("/// </summary>");
    Console.WriteLine(
        $"public static EarthlyBranch {s} => new EarthlyBranch({s.Index});");
}
