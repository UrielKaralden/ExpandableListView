
namespace ExpandableListView.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using ExpandableListView.Models;

    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class ExpandableListViewModel
    {
        public ExpandableListViewModel()
        {
            this.ExpandCommand = new Command<ItemGroupViewModel>(t =>
                {
                    MainThread.BeginInvokeOnMainThread(
                        () =>
                            {
                                var a = this.ItemsList.FirstOrDefault(x => x.Title == t.Title);
                                a.Expanded = !a.Expanded;
                                this.UpdateListContent();
                            });
                });
            this.ItemsList = new List<ItemGroupViewModel>
                                 {
                                     new ItemGroupViewModel("Juego") { new Item { ItemName = "Seleccionar juego" } },
                                     new ItemGroupViewModel("Personaje")
                                         {
                                             new Item { ItemName = "Añadir personaje" },
                                             new Item { ItemName = "Ver personaje" },
                                             new Item { ItemName = "Editar personaje" },
                                             new Item { ItemName = "Eliminar personaje" }
                                         },
                                     new ItemGroupViewModel("Habilidad")
                                         {
                                             new Item { ItemName = "Calcular tirada de habilidad" },
                                             new Item { ItemName = "Calcular tirada enfentada" }
                                         }
                                 };
            this.Data = new ObservableCollection<ItemGroupViewModel>();
            this.UpdateListContent();
        }

        public ICommand ExpandCommand { get; }

        public List<ItemGroupViewModel> ItemsList { get; }

        public ObservableCollection<ItemGroupViewModel> Data { get; }

        private void UpdateListContent()
        {
            this.Data.Clear();
            foreach (var group in this.ItemsList)
            {
                var elements = new ItemGroupViewModel(group.Title, group.Expanded);
                if (group.Expanded)
                {
                    foreach (var element in group)
                    {
                        elements.Add(element);
                    }
                }
                this.Data.Add(elements);
            }
        }
    }
}
