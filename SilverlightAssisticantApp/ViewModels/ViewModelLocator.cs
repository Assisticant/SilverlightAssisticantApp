using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assisticant;
using SilverlightAssisticantApp.Models;
using Assisticant.XAML;

namespace SilverlightAssisticantApp.ViewModels
{
    public class ViewModelLocator : ViewModelLocatorBase
    {
        private Menu _menu;

        public ViewModelLocator()
        {
            if (DesignMode)
                _menu = LoadDesignModeMenu();
            else
                _menu = LoadMenu();


            for (int i = 0; i < 100; i++)
            {
                PopulateTestData(DateTime.Today.AddDays(i));
            }

        }

        private void PopulateTestData(DateTime date)
        {
            _menu.AddFoodItem("Soup 1", "Soup Description " + date.ToShortDateString(), 1.5m, FoodCategory.Soup, date);
            _menu.AddFoodItem("Soup 2", "Soup Description 2" + date.ToShortDateString(), 2m, FoodCategory.Soup, date);
            _menu.AddFoodItem("Main Meal 1", "Main Description 1" + date.ToShortDateString(), 2m, FoodCategory.MainMeal, date);
            _menu.AddFoodItem("Main Meal 2", "Main Description 2" + date.ToShortDateString(), 2m, FoodCategory.MainMeal, date);
            _menu.AddFoodItem("Sushi 1", "Sushi Description 1" + date.ToShortDateString(), 6m, FoodCategory.Sushi, date);
            _menu.AddFoodItem("Sushi 2", "Sushi Description 2" + date.ToShortDateString(), 5m, FoodCategory.Sushi, date);
        }

        private Menu LoadMenu()
        {
            return new Menu(DateTime.Today);
        }

        private Menu LoadDesignModeMenu()
        {
            return new Menu(DateTime.Today);
        }

        public object Main
        {
            get { return ViewModel(() => new MainViewModel(_menu)); }
        }

        //public object Item
        //{
        //    get
        //    {
        //        return ViewModel(() => _selection.SelectedItem == null
        //            ? null
        //            : new ItemViewModel(_selection.SelectedItem));
        //    }
        //}

    }
}
