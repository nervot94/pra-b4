using Microsoft.UI.Xaml.Media.Imaging;

namespace FotoKiosk.Models;

public class RollercoasterPhoto
{
    public string FilePath { get; set; }
    public BitmapImage ImageSource => new(new Uri(FilePath));
    public RollercoasterPhotoMetadata Metadata { get; set; }
}