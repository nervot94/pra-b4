using FotoKiosk.Models;
using FotoKiosk.Services.Parsers;

namespace FotoKiosk.Services;

public class LocalPhotoService : IPhotoService
{
    private static TimeSpan _timeSpanRange = new(0, 15, 0);
    private static TimeSpan _timeOffset = new(0, 1, 0);

    public string GetDirectory()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var currentDate = DateTime.Now;

        var folder = ((IPhotoService)this).GetFolderName(currentDate.DayOfWeek);
        return Path.Combine(currentDirectory, "fotos", folder);
    }

    // I hope this parallel stuff works fine lol
    public Task<IEnumerable<RollercoasterPhoto>> GetPhotosAsync(string directoryPath)
    {
        if (!Directory.Exists(directoryPath)) throw new DirectoryNotFoundException();

        var entries = Directory.EnumerateFiles(directoryPath).ToList();

        var parsedFileNames = entries
            .AsParallel()
            .Select(PhotoPathParser.Parse) // Its fineeeeee
            .ToList();

#if DEBUG
        var timeOfDay = TimeSpan.Parse("14:10:17");
#else
        var timeOfDay = DateTime.Now.TimeOfDay;
#endif

        var minTime = timeOfDay - _timeSpanRange;
        var maxTime = timeOfDay + _timeSpanRange;

        var photos = parsedFileNames
            .AsParallel()
            .Where(f => f.Metadata.DateTaken >= minTime && f.Metadata.DateTaken <= maxTime)
            .ToList();

        return Task.FromResult<IEnumerable<RollercoasterPhoto>>(photos);
    }

    public Task<IEnumerable<RollercoasterPhoto[]>> GroupPhotosAsync(IEnumerable<RollercoasterPhoto> photos)
    {
        List<RollercoasterPhoto[]> results = [];

        var rollercoasterPhotos = photos.ToList();
        foreach (var photo in rollercoasterPhotos)
        {
            var timestamp = photo.Metadata.DateTaken;
            var timeOffset = timestamp + _timeOffset;

            var secondPhoto = rollercoasterPhotos.FirstOrDefault(f => f.Metadata.DateTaken == timeOffset);
            if (secondPhoto != null)
            {
                results.Add([photo, secondPhoto]);
            }
        }

        return Task.FromResult<IEnumerable<RollercoasterPhoto[]>>(results.ToArray());
    }
}