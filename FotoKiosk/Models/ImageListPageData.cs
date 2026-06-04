using System.Collections.ObjectModel;

namespace FotoKiosk.Models;

public class ImageListPageData()
{
    public required ObservableCollection<RollercoasterPhoto> Images { get; set; }
}