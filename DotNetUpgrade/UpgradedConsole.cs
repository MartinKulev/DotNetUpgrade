namespace DotNetUpgrade
{
    public static class UpgradedConsole
    {
        public static void WriteLineRange<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
