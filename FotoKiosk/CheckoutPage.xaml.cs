using System.Collections.ObjectModel;
using FotoKiosk.Models;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FotoKiosk;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class CheckoutPage : Page
{
    public ObservableCollection<RollercoasterPhoto> SelectedImages { get; set;  } = [];
    
    public CheckoutPage()
    {
        InitializeComponent();
    }
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (e.Parameter is ImageListPageData pageData)
        {
            SelectedImages = new ObservableCollection<RollercoasterPhoto>(pageData.Images);
            
            Console.WriteLine($"Selected images count: {SelectedImages.Count}");
        }
    }

}
