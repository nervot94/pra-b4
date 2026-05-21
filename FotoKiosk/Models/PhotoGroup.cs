using System.Collections.ObjectModel;

namespace FotoKiosk.Models;

public class PhotoGroup
{
    public ObservableCollection<RollercoasterPhoto> Photos { get; set; } = [];
    
    public bool IsSelected { get; set; } = false;

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
    
    public void ToggleSelection()
    {
        if (IsSelected)
            DeselectAll();
        else
            SelectAll();
    }
    
    private void SelectAll()
    {
        foreach (var photo in Photos)
        {
            photo.IsSelected = true;
        }
        IsSelected = true;
    }
    
    private void DeselectAll()
    {
        foreach (var photo in Photos)
        {
            photo.IsSelected = false;
        }
        IsSelected = false;
    }
}
