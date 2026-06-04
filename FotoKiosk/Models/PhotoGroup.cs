using System.Collections.ObjectModel;

namespace FotoKiosk.Models;

public class PhotoGroup
{
    public ObservableCollection<RollercoasterPhoto> Photos { get; set; } = [];
    
    public decimal Price { get; set; } = 5.0m;
    
    public TimeSpan DateTaken => Photos.FirstOrDefault()?.Metadata.DateTaken ?? TimeSpan.Zero;
    public string FormattedTime => DateTaken.ToString(@"hh\:mm\:ss");
    public string FormattedPrice => $"€{Price:F0}";

    public PhotoGroup(RollercoasterPhoto[] photos)
    {
        foreach (var photo in photos)
        {
            Photos.Add(photo);
        }
    }
}
