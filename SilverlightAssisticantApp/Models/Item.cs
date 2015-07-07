using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assisticant.Collections;
using Assisticant.Fields;

namespace SilverlightAssisticantApp.Models
{
    public enum FoodCategory
    {
        MainMeal,
        Soup,
        JacketOption,
        Jacket,
        Sushi,
        Sandwich,
        Refreshment,
        BapOption,
        Bap,
        None
    }

    public class Item
    {
        private Observable<string> _foodname = new Observable<string>();
        private Observable<DateTime> _itemdate = new Observable<DateTime>();
        private Observable<FoodCategory> _itemcategory = new Observable<FoodCategory>();
        private Observable<string> _description = new Observable<string>();
        private Observable<decimal> _price = new Observable<decimal>();
        

        public DateTime ItemDate
        {
            get { return _itemdate; }
            set { _itemdate.Value = value; }
        }

        public string FoodName
        {
            get { return _foodname; }
            set { _foodname.Value = value; }
        }

        public FoodCategory FoodCategory
        {
            get { return _itemcategory; }
            set { _itemcategory.Value = value; }
        }

        public string FoodDescription
        {
            get { return _description; }
            set { _description.Value = value; }
        }
        public decimal FoodPrice
        {
            get { return _price; }
            set { _price.Value = value; }
        }
    }
}
