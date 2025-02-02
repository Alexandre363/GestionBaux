using projet_location.Model;

using System.ComponentModel;

namespace projet_location.ViewModel
{
    public interface ILocationVM : INotifyPropertyChanged, ILocation
    {
        ILocation Model { get; }
    }
}