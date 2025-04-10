using System;
using ClassLibrary;

namespace Proxy
{
    class Program
    {
        static void Main()
        {
            string testFile = "test.txt";
            File.WriteAllText(testFile, "Hello\nWorld");

            SmartTextReader reader = new SmartTextChecker(testFile);
            reader.Read();
            //SmartTextReader lockedReader = new SmartTextReaderLocker("restricted.txt", "restricted");
            //lockedReader.Read();
        }
    }
}