using System.Collections.ObjectModel;

namespace FotoKiosk.Models;

public class PhotoGroup
{
    public ObservableCollection<RollercoasterPhoto> Photos { get; set; } = [];

    public PhotoGroup(RollercoasterPhoto[] photos)
    {
        foreach (var photo in photos)
        {
            Photos.Add(photo);
        }
    }
}
