using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Atom;
using System;
using System.Xml;

namespace Wadereye.SyndicationFeed.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            using (XmlReader xmlReader = XmlReader.Create("https://stackoverflow.com/feeds/tag/c%23", new XmlReaderSettings() { Async = true }))
            {
                // Create an AtomFeedReader
                var reader = new AtomFeedReader(xmlReader);
                // Read the feed
                while (reader.Read().GetAwaiter().GetResult())
                {
                    // Check the type of the current element.
                    if (reader.ElementType == SyndicationElementType.Item)
                    {
                        IAtomEntry entry = reader.ReadEntry().GetAwaiter().GetResult();
                        System.Console.WriteLine(entry.Author.Name);
                    }
                }
            }
            System.Console.ReadLine();
        }
    }
}
