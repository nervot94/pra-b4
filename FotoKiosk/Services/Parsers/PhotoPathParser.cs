using FotoKiosk.Models;

namespace FotoKiosk.Services.Parsers;

public static class PhotoPathParser
{
    /// <summary>
    /// Parses a roller‑coaster photo file name into a <see cref="RollercoasterPhoto"/> instance.
    /// </summary>
    /// <param name="filePath">The full path to the photo file.</param>
    /// <returns>A <see cref="RollercoasterPhoto"/> object</returns>
    /// <exception cref="FormatException">Thrown when the file name does not conform to the expected pattern.</exception>
    public static RollercoasterPhoto Parse(string filePath)
    {
        var nameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
        var parts = nameWithoutExtension.Split('_');

        var timestampString = string.Join(":", parts[..3]);
        var timestamp = TimeSpan.Parse(timestampString); 
        
        var idString = parts[3];
        if (!int.TryParse(idString[2..], out var id))
        {
            throw new FormatException($"Invalid ID format: {idString[..2]}. Expected format: idXXXX");
        }

        var metadata = new RollercoasterPhotoMetadata()
        {
            DateTaken = timestamp,
            Id = id
        };
        
        return new RollercoasterPhoto()
        {
            FilePath = filePath,
            Metadata = metadata,
        };
    }
}