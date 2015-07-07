using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SilverlightAssisticantApp.Models;
using Assisticant;

namespace SilverlightAssisticantApp.ViewModels
{
    public class MainViewModel
    {
        private readonly Menu _menu;
        private readonly Selection _selection;
        private readonly Document _document;



        public MainViewModel(Menu menu)
        {
            _menu = menu;
        }

        public IEnumerable<ItemHeader> Items
        {
            get
            {
                return
                    from item in _document.Items
                    select new ItemHeader(item);
            }
        }

        public DateTime CurrentMenuDate
        {
            get
            {
                return _menu.MenuDate == DateTime.MinValue ? DateTime.Today : _menu.MenuDate;
            }
            set
            {
                _menu.UpdateMenuDate(value);
            }
        }

        public IEnumerable<ItemViewModel> AllSoups
        {
            get
            {
                return from item in _menu.CurrentItems
                       where item.ItemDate == _menu.MenuDate && item.FoodCategory == FoodCategory.Soup
                       select new ItemViewModel(item);
            }
        }

        public IEnumerable<ItemViewModel> AllMains
        {
            get
            {
                return from item in _menu.CurrentItems
                       where item.ItemDate == _menu.MenuDate && item.FoodCategory == FoodCategory.MainMeal
                       select new ItemViewModel(item);
            }
        }

        public IEnumerable<ItemViewModel> AllSandwiches
        {
            get
            {
                return from item in _menu.CurrentItems
                       where item.ItemDate == _menu.MenuDate && item.FoodCategory == FoodCategory.Sandwich
                       select new ItemViewModel(item);
            }
        }

        public IEnumerable<ItemViewModel> AllSushi
        {
            get
            {
                return from item in _menu.CurrentItems
                       where item.ItemDate == _menu.MenuDate && item.FoodCategory == FoodCategory.Sushi
                       select new ItemViewModel(item);
            }
        }

        public IEnumerable<ItemViewModel> AllJackets
        {
            get
            {
                return from item in _menu.CurrentItems
                       where item.ItemDate == _menu.MenuDate && item.FoodCategory == FoodCategory.Jacket
                       select new ItemViewModel(item);
            }
        }

        public ItemHeader SelectedItem
        {
            get
            {
                return _selection.SelectedItem == null
                    ? null
                    : new ItemHeader(_selection.SelectedItem);
            }
            set
            {
                if (value != null)
                    _selection.SelectedItem = value.Item;
            }
        }

        public ItemViewModel ItemDetail
        {
            get
            {
                return _selection.SelectedItem == null
                    ? null
                    : new ItemViewModel(_selection.SelectedItem);
            }
        }

        public ICommand AddItem
        {
            get
            {
                return MakeCommand
                    .Do(delegate
                    {
                        _selection.SelectedItem = _document.NewItem();
                    });
            }
        }

        public ICommand DeleteItem
        {
            get
            {
                return MakeCommand
                    .When(() => _selection.SelectedItem != null)
                    .Do(delegate
                    {
                        _document.DeleteItem(_selection.SelectedItem);
                        _selection.SelectedItem = null;
                    });
            }
        }

        public ICommand MoveItemDown
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedItem != null &&
                        _document.CanMoveDown(_selection.SelectedItem))
                    .Do(delegate
                    {
                        _document.MoveDown(_selection.SelectedItem);
                    });
            }
        }

        public ICommand MoveItemUp
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _selection.SelectedItem != null &&
                        _document.CanMoveUp(_selection.SelectedItem))
                    .Do(delegate
                    {
                        _document.MoveUp(_selection.SelectedItem);
                    });
            }
        }
    }
}
