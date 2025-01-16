namespace DotNetUpgrade
{
    public static class Console
    {
        public static void WriteLineRange<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
