using ExpandableListView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ExpandableListView.ViewModels
{
    public class ItemGroupViewModel : ObservableCollection<Item>, INotifyPropertyChanged
    {
        private bool _expanded;
        public string Title { get; set; }
        public static ObservableCollection<ItemGroupViewModel> ItemsList { private set; get; }
        public new event PropertyChangedEventHandler PropertyChanged;
        

        static ItemGroupViewModel()
        {
            ObservableCollection<ItemGroupViewModel> List = new ObservableCollection<ItemGroupViewModel>()
            {
                new ItemGroupViewModel("Juego")
                {
                    new Item{ ItemName = "Seleccionar juego"}
                },

                new ItemGroupViewModel("Personaje")
                {
                    new Item{ ItemName = "Añadir personaje"},
                    new Item{ ItemName = "Ver personaje"},
                    new Item{ ItemName = "Editar personaje"},
                    new Item{ ItemName = "Eliminar personaje"}
                },

                new ItemGroupViewModel("Habilidad")
                {
                    new Item{ ItemName = "Calcular tirada de habilidad"},
                    new Item{ ItemName = "Calcular tirada enfentada"}
                }
            };

            ItemsList = List;

        }

        public ItemGroupViewModel(string groupTitle, bool expanded = false)
        {
            Title = groupTitle;
            Expanded = expanded;
        }
        
        public string StateIcon
        {
            get { return Expanded ? "collapse_icon.png" : "expand_icon.png"; }
        }
        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
//Iconos diseñados por <a href="https://www.flaticon.es/autores/those-icons" title="Those Icons">Those Icons</a> from <a href="https://www.flaticon.es/" title="Flaticon"> www.flaticon.es</a>