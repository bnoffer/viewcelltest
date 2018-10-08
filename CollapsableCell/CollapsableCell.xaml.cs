using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Com.Example.CollapsableCell
{
    /// <summary>
    /// Provides a Collapsable and Expandable ViewCell consinsting of two sub-views.
    /// </summary>
    public partial class CollapsableCell : ViewCell
    {
        /// <summary>
        /// Indicator if the ViewCell is currently expanded.
        /// </summary>
        private bool _isExpanded;
        /// <summary>
        /// Bounds for the Frame element in the collapsed state.
        /// </summary>
        private Rectangle _collapsedBounds;
        /// <summary>
        /// Bounds for the Frame element in the expanded state.
        /// </summary>
        private Rectangle _expandedBounds;
        /// <summary>
        /// Indicates if the initial setup has been completed.
        /// </summary>
        private bool _isSetup;

        /// <summary>
        /// Sub-view for the collapsed state.
        /// </summary>
        private ContentView _collapsedView;
        /// <summary>
        /// Gets or sets the collapsed view.
        /// </summary>
        /// <value>The collapsed view.</value>
        public ContentView CollapsedView
        {
            get
            {
                Debug.WriteLine("get CollapsedView");
                return _collapsedView;
            }
            set
            {
                Debug.WriteLine("set CollapsedView");
                if ((_collapsedView == value) || (value == null)) return;

                if ((_collapsedView != null) && (CollapsableContent.Children.Contains(_collapsedView)))
                {
                    CollapsableContent.Children.Remove(_collapsedView);
                    _collapsedView = value;
                    CollapsableContent.Children.Add(_collapsedView);
                }
                else
                {
                    _collapsedView = value;
                    CollapsableContent.Children.Add(_collapsedView);
                }
                OnPropertyChanged("CollapsedView");
            }
        }

        /// <summary>
        /// Sub-view for the expanded state.
        /// </summary>
        private ContentView _expandedView;
        /// <summary>
        /// Gets or sets the expanded view.
        /// </summary>
        /// <value>The expanded view.</value>
        public ContentView ExpandedView
        {
            get
            {
                Debug.WriteLine("get ExpandedView");
                return _expandedView;
            }
            set
            {
                Debug.WriteLine("set ExpandedView");
                if ((_expandedView == value) || (value == null)) return;

                if ((_expandedView != null) && (CollapsableContent.Children.Contains(_expandedView)))
                {
                    CollapsableContent.Children.Remove(_expandedView);
                    _expandedView = value;
                    CollapsableContent.Children.Add(_expandedView);
                }
                else
                {
                    _expandedView = value;
                    CollapsableContent.Children.Add(_expandedView);
                }
                OnPropertyChanged("ExpandedView");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Real.Xamarin.Forms.Extensions.CollapsableCell"/> class.
        /// </summary>
        public CollapsableCell()
        {
            Debug.WriteLine("CollapsableCell init without params");
            InitializeComponent();

            _collapsedView = null;
            _expandedView = null;
            _isExpanded = false;
            _isSetup = false;
        }

        /// <summary>
        /// Handles Tap events on the ViewCell.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        protected void OnTapped(object sender, EventArgs args)
        {
            Debug.WriteLine("_expandedView Bounds: " + _expandedView.Bounds);
            Debug.WriteLine("_collapsedView Bounds: " + _collapsedView.Bounds);
            Debug.WriteLine("OnTapped");
            if (_isExpanded) // collapse the ViewCell
            {
                Debug.WriteLine("Collapsed: " + _collapsedBounds);
                CollapsableFrame.LayoutTo(_collapsedBounds, 500, Easing.CubicIn);
                ForceUpdateSize();
                CollapsableFrame.BackgroundColor = _collapsedView.BackgroundColor;
                _collapsedView.RotationY = -270.0;
                _expandedView.RotateYTo(-90.0, 250, Easing.SinIn);
                _expandedView.IsVisible = false;
                _collapsedView.IsVisible = true;
                _collapsedView.RotateYTo(-360.0, 250, Easing.SinOut);
                _collapsedView.RotationY = 0.0;
                _isExpanded = false;
                //ExpandedCloseLabel.IsVisible = false;
            }
            else // Expand the ViewCell
            {
                Debug.WriteLine("Expanded: " + _expandedBounds);
                CollapsableFrame.LayoutTo(_expandedBounds, 500, Easing.CubicOut);
                ForceUpdateSize();
                CollapsableFrame.BackgroundColor = _expandedView.BackgroundColor;
                _expandedView.RotationY = -270.0;
                _collapsedView.RotateYTo(-90.0, 250, Easing.SinIn);
                _collapsedView.IsVisible = false;
                _expandedView.IsVisible = true;
                _expandedView.RotateYTo(-360.0, 250, Easing.SinOut);
                _expandedView.RotationY = 0.0;
                _isExpanded = true;
                //ExpandedCloseLabel.IsVisible = true;
            }
        }

        /// <summary>
        /// Sets the collapsed bounds.
        /// </summary>
        private void SetCollapsedBounds()
        {
            Debug.WriteLine("_collapsedView Bounds: " + _collapsedView.Bounds);
            _collapsedView.ForceLayout();
            double x = CollapsableFrame.Margin.Left;
            double y = _collapsedView.Bounds.Y;
            double width = -1;
            if (Parent != null)
                width = ((ListView)Parent).Bounds.Width - CollapsableFrame.Margin.HorizontalThickness;
            double height = _collapsedView.Bounds.Height; //Math.Round(_collapsedView.Bounds.Height, 0, MidpointRounding.AwayFromZero); // * 1.2
            _collapsedBounds = new Rectangle(x, y, width, height);
            Debug.WriteLine("set _collapsedBounds = " + _collapsedBounds.ToString());
        }

        /// <summary>
        /// Sets the expanded bounds.
        /// </summary>
        private void SetExpandedBounds()
        {
            Debug.WriteLine("_expandedView Bounds: " + _expandedView.Bounds);
            _expandedView.ForceLayout();
            double x = CollapsableFrame.Margin.Left;
            double y = _expandedView.Bounds.Y;
            double width = -1;
            if (Parent != null)
                width = ((ListView)Parent).Bounds.Width - CollapsableFrame.Margin.HorizontalThickness;
            double height = _expandedView.Bounds.Height; // Math.Round((_expandedView.Bounds.Height + ExpandedCloseLabel.Bounds.Height), 0, MidpointRounding.AwayFromZero); //* 1.35
            _expandedBounds = new Rectangle(x, y, width, height);
            Debug.WriteLine("set _expandedBounds = " + _expandedBounds.ToString());
        }

        /// <summary>
        /// Handles the Appearing event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void OnAppearing(object sender, EventArgs e)
        {
            if (!_isSetup) // perform initial setup
            {
                CollapsedView.IsVisible = true;
                ExpandedView.IsVisible = false;
                //ExpandedCloseLabel.IsVisible = false;
                SetCollapsedBounds();
                SetExpandedBounds();
                CollapsableFrame.LayoutTo(_collapsedBounds);
                ForceUpdateSize();
                _isSetup = true;
            }
        }
    }
}
