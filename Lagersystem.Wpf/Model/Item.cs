using Lagersystem.Wpf.Core;

namespace Lagersystem.Wpf.Model;

public class Item : ObservableObject
{
    private string _descriptor = string.Empty;
    public string Descriptor
    {
        get => _descriptor;
        set
        {
            _descriptor = value;
            OnPropertyChanged();
        }
    }
}