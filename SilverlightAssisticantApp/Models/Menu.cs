using Assisticant.Collections;
using Assisticant.Fields;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightAssisticantApp.Models
{
    public class Menu
    {
        private Observable<DateTime> _menudate = new Observable<DateTime>(); 
        private ObservableList<Item> _currentitems = new ObservableList<Item>();

        public IEnumerable<Item> CurrentItems
        {
            get { return _currentitems.Where(x => x.ItemDate == MenuDate); }
        }

        public Menu(DateTime dateTime)
        {
            UpdateMenuDate(dateTime);
        }

        public void UpdateMenuDate(DateTime dateTime)
        {
            MenuDate = dateTime;
        }

        public void AddFoodItem(string name, string description, decimal price, FoodCategory category, DateTime itemdate)
        {
            _currentitems.Add(new Item
            {
                FoodCategory = category,
                FoodDescription = description,
                FoodName = name,
                FoodPrice = price,
                ItemDate = itemdate
            });
        }

        public DateTime MenuDate
        {
            get
            {
                return _menudate;
            }
            set { _menudate.Value = value; }
        }
    }
}
