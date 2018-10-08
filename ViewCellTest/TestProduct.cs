using System;
using Xamarin.Forms;

namespace ViewCellTest
{
    public class TestProduct : BindableObject
    {
        public static readonly BindableProperty ProductNameProperty =
            BindableProperty.Create("ProductName", typeof(string), typeof(TestProduct), "");

        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }

        public static readonly BindableProperty ProductSummaryProperty =
            BindableProperty.Create("ProductSummary", typeof(string), typeof(TestProduct), "");

        public string ProductSummary
        {
            get { return (string)GetValue(ProductSummaryProperty); }
            set { SetValue(ProductSummaryProperty, value); }
        }

        public static readonly BindableProperty ProductDescriptionProperty =
            BindableProperty.Create("ProductDescription", typeof(string), typeof(TestProduct), "");

        public string ProductDescription
        {
            get { return (string)GetValue(ProductDescriptionProperty); }
            set { SetValue(ProductDescriptionProperty, value); }
        }

        public static readonly BindableProperty ProductPriceProperty =
            BindableProperty.Create("ProductPrice", typeof(string), typeof(TestProduct), "");

        public string ProductPrice
        {
            get { return (string)GetValue(ProductPriceProperty); }
            set { SetValue(ProductPriceProperty, value); }
        }

        public static readonly BindableProperty ProductShortNameProperty =
            BindableProperty.Create("ProductShortName", typeof(string), typeof(TestProduct), "");

        public string ProductShortName
        {
            get { return (string)GetValue(ProductShortNameProperty); }
            set { SetValue(ProductShortNameProperty, value); }
        }

        public static readonly BindableProperty ProductShortSummaryProperty =
            BindableProperty.Create("ProductShortSummary", typeof(string), typeof(TestProduct), "");

        public string ProductShortSummary
        {
            get { return (string)GetValue(ProductShortSummaryProperty); }
            set { SetValue(ProductShortSummaryProperty, value); }
        }

        public static readonly BindableProperty ProductShortPriceProperty =
            BindableProperty.Create("ProductShortPrice", typeof(string), typeof(TestProduct), "");

        public string ProductShortPrice
        {
            get { return (string)GetValue(ProductShortPriceProperty); }
            set { SetValue(ProductShortPriceProperty, value); }
        }
    }
}
