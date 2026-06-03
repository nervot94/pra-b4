using FotoKiosk.Models;
using FotoKiosk.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FotoKiosk;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class GalleryPage : Page
{
    public ObservableCollection<RollercoasterPhoto> Images { get; } = [];
    private LocalPhotoService PhotoService { get; } = new();

    public GalleryPage()
    {
        DataContext = this;
        InitializeComponent();

        _ = GetRollercoasterPhotos();
    }
    
    private async Task GetRollercoasterPhotos()
    {
        var photosDirectory = PhotoService.GetDirectory();
        var photos = await PhotoService.GetPhotosAsync(photosDirectory);
        var groupedPhotos = await PhotoService.GroupPhotosAsync(photos);
        
        foreach (var group in groupedPhotos)
        {
            var photoGroup = new PhotoGroup(group);
            
            foreach (var photo in photoGroup.Photos)
            {
                Images.Add(photo);
            }
        }
    }
}