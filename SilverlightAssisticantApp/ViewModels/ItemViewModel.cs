using System;
using System.Collections.Generic;
using System.Linq;
using SilverlightAssisticantApp.Models;
using System.Windows.Input;
using Assisticant;

namespace SilverlightAssisticantApp.ViewModels
{
    public class ItemViewModel
    {
        private readonly Item _item;

        public ItemViewModel(Item item)
        {
            _item = item;
        }

        public string Name
        {
            get { return _item.FoodName; }
            set { _item.FoodName = value; }
        }

        public string FoodDescription
        {
            get { return _item.FoodDescription; }
            set { _item.FoodDescription = value; }
        }

        public decimal FoodPrice
        {
            get { return _item.FoodPrice; }
            set { _item.FoodPrice = value; }
        }

        public ICommand OrderCommand
        {
            get
            {
                return MakeCommand
                   .Do(delegate
                   {
                       //place order logic
                   });
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            ItemViewModel that = obj as ItemViewModel;
            if (that == null)
                return false;
            return Object.Equals(this._item, that._item);
        }

        public override int GetHashCode()
        {
            return _item.GetHashCode();
        }
    }
}
