using System.Diagnostics;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewCellTest
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<TestProduct> _listData;
        public ObservableCollection<TestProduct> ListData
        {
            get { return _listData; }
            set
            {
                if (_listData == value) return;
                _listData = value;
                OnPropertyChanged("ListData");
            }
        }

        private double _collapsedHeight;
        public double CollapsedHeight
        {
            get { return _collapsedHeight; }
            set
            {
                if (_collapsedHeight == value) return;
                _collapsedHeight = value;
                OnPropertyChanged("CollapsedHeight");
            }
        }

        private double _expandedHeight;
        public double ExpandedHeight
        {
            get { return _expandedHeight; }
            set
            {
                if (_expandedHeight == value) return;
                _expandedHeight = value;
                OnPropertyChanged("ExpandedHeight");
            }
        }

        public MainPageVM()
        {
            _collapsedHeight = 120.0;
            _expandedHeight = 160.0;

            _listData = new ObservableCollection<TestProduct>();
            _listData.Add(new TestProduct()
            {
                ProductName = "Apfel",
                ProductShortName = "Apfel",
                ProductSummary = "Obst",
                ProductShortSummary = "Obst",
                ProductDescription = "Obst description",
                ProductPrice = "1,99",
                ProductShortPrice = "1,99"
            });
            _listData.Add(new TestProduct()
            {
                ProductName = "Birne",
                ProductShortName = "Birne",
                ProductSummary = "Obst",
                ProductShortSummary = "Obst",
                ProductDescription = "Obst description",
                ProductPrice = "1,99",
                ProductShortPrice = "1,99"
            });
            _listData.Add(new TestProduct()
            {
                ProductName = "Orange",
                ProductShortName = "Orange",
                ProductSummary = "Obst",
                ProductShortSummary = "Obst",
                ProductDescription = "Obst description",
                ProductPrice = "1,99",
                ProductShortPrice = "1,99"
            });
            _listData.Add(new TestProduct()
            {
                ProductName = "Banane",
                ProductShortName = "Banane",
                ProductSummary = "Obst",
                ProductShortSummary = "Obst",
                ProductDescription = "Obst description",
                ProductPrice = "1,99",
                ProductShortPrice = "1,99"
            });
        }

        private void OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine("Property changed: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
