using FotoKiosk.Models;

namespace FotoKiosk.Services;

public interface IPhotoService
{
    string GetDirectory();
    
    Task<IEnumerable<RollercoasterPhoto>> GetPhotosAsync(string directoryPath);
    
    Task<IEnumerable<RollercoasterPhoto[]>> GroupPhotosAsync(IEnumerable<RollercoasterPhoto> photos);

    string GetFolderName(DayOfWeek dayOfWeek)
    {
        return dayOfWeek switch
        {
            DayOfWeek.Sunday => "0_Zondag",
            DayOfWeek.Monday => "1_Maandag",
            DayOfWeek.Tuesday => "2_Dinsdag",
            DayOfWeek.Wednesday => "3_Woensdag",
            DayOfWeek.Thursday => "4_Donderdag",
            DayOfWeek.Friday => "5_Vrijdag",
            DayOfWeek.Saturday => "6_Zaterdag",
            _ => throw new ArgumentException($"Invalid day of week")
        };
    }
}