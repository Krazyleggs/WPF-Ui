using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Uiprogramming;


namespace Uiprogramming.ViewModel
{
    class WindowViewModel : ViewModelBase
    {
        #region Private members

        //the window we control
        private Window _window;

        // the margin around the window to allow for a dropshadow
        private int _OuterMarginSize { get; set; } = 10;

        // the radius of the edges of the window
        private int _WindowRadius { get; set; } = 10;

        #endregion

        #region Public Properties

        // Window Minimum Height
        public double WindowMinHeight { get; set; } = 70;

        // Window Minimum Width
        public double WindowMinWidth { get; set; } = 400;

        // the thickness of the resize hover area
        public int ResizeBorder { get; set; } = 6;

        // Thickness of the resize hover area taking into account the outer margin
        public Thickness ResizeBorderThickness
        {
            get
            { return new Thickness(ResizeBorder + OuterMarginSize); }
        }

        // The padding of the padding of the inner window
        public Thickness InnerContentPadding
        {
            get
            { return new Thickness(.2); }
            //{ return new Thickness(ResizeBorder); }
        }

        // the margin around the window to allow for a dropshadow
        public int OuterMarginSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _OuterMarginSize;
            }
            set
            {
                _OuterMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness
        {
            get
            { return new Thickness(OuterMarginSize); }
        }

        // the radius of the edges of the window
        public int WindowRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _WindowRadius;
            }
            set
            {
                _WindowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius
        {
            get
            { return new CornerRadius(WindowRadius); }
        }


        // The height of the title bar
        public int TitleHeight { get; set; } = 42;

        // The height of the title bar
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight +  ResizeBorder); } }

        // The current page of the application
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Main;

        #endregion

        #region Commands

        // Minimize window command property
        public RelayCommand MinimizeWindowCommand { get; private set; }

        // Maximuse window command property
        public RelayCommand MaximizeWindowCommand { get; private set; }

        // Close window command property
        public RelayCommand CloseWindowCommand { get; private set; }

        // System menu icon command
        public RelayCommand SystemMenuCommand { get; private set; }

        // Start timer command
        public RelayCommand StarttimerCommand { get; private set; }

        #endregion

        #region Default Constructor

        // Creats a new window and assigns to our private member _window
        public WindowViewModel(Window window)
        {
            _window = window;


            // Listen to window state changing
            _window.StateChanged += (s, e) =>
            {

                // fire off events for all properties that are affected by the window state changing
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Initializing commands
            MinimizeWindowCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeWindowCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseWindowCommand = new RelayCommand(() => _window.Close());
            SystemMenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));
            //Starttimer = new RelayCommand((int transactionid, DateTime currenttime, String activity) => 
            //{ DataAccess db = new DataAccess();
            //    db.RecordStartTime(0, DateTime.Now, "Yolo");
            //}
            //);
            //StarttimerCommand = new RelayCommand(() =>
            //{
            //    DataAccess db = new DataAccess();
            //    db.RecordStartTime(0, DateTime.Now, "Yolo");
            //}
            //);

            //Fix Resize issue with WPF
            var resizer = new WindowResizer(_window);
        }
        #endregion

        #region Private helpers
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_window);
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        #endregion

    }
}
