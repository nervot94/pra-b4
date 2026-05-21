namespace FotoKiosk.Models;

public class RollercoasterPhoto
{
    public string FilePath { get; set; }
    public RollercoasterPhotoMetadata Metadata { get; set; }

    public bool IsSelected { get; set; } = false;
    
}