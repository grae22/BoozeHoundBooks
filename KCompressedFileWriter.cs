using System.IO.Compression;

namespace BoozeHoundBooks
{
  internal static class KCompressedFileWriter
  {
    //---------------------------------------------------------------------------------------------

    public static void WriteFile(
      string outputFilename,
      string archiveEntryFilename,
      string content)
    {
      using (var zipToOpen = new FileStream(outputFilename, FileMode.Create))
      {
        using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
        {
          ZipArchiveEntry entry = archive.CreateEntry(archiveEntryFilename, CompressionLevel.Optimal);

          using (var writer = new StreamWriter(entry.Open()))
          {
            writer.Write(content);
          }
        }
      }
    }

    //---------------------------------------------------------------------------------------------
  }
}