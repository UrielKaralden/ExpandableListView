using ExpandableListView.Models;
using ExpandableListView.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpandableListView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpandableList : ContentPage
    {
        readonly ObservableCollection<ItemGroupViewModel> getItemsList;
        ObservableCollection<ItemGroupViewModel> _expandedItemList;
        readonly ListView listView;
        public ExpandableList()
        {
            InitializeComponent();
            getItemsList = ItemGroupViewModel.ItemsList;
            listView = this.MyListView;

            UpdateListContent();
        }

        void HeaderTapped(object sender, EventArgs args)
        {
            int ListSelectedIndex = _expandedItemList.IndexOf(((ItemGroupViewModel)((Button)sender).CommandParameter));
            getItemsList[ListSelectedIndex].Expanded = !getItemsList[ListSelectedIndex].Expanded;
            UpdateListContent();
        }

        private void UpdateListContent()
        {
            _expandedItemList = new ObservableCollection<ItemGroupViewModel>();
            foreach (ItemGroupViewModel group in getItemsList)
            {
                ItemGroupViewModel elements = new ItemGroupViewModel(group.Title, group.Expanded);
                if(group.Expanded)
                {
                    foreach(Item element in group)
                    {
                        elements.Add(element);
                    }
                }
                _expandedItemList.Add(elements);
            }
            try { listView.ItemsSource = _expandedItemList; }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }
    }
}