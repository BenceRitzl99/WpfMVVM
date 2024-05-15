using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM.Command;
using WpfMVVM.View;

namespace WpfMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
		private object currentView;

		public object CurrentView
		{
			get { return currentView; }
			set { currentView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentView"));  // ? --> lehet null is az értéke
            }

		}
		private GreenView greenView;
		private YellowView yellowView;
		private PurpleView purpleView;

        public event PropertyChangedEventHandler? PropertyChanged;



        public RelayCommand YellowViewCommand { get; }
		public RelayCommand GreenViewCommand { get; }
		public RelayCommand PurpleViewCommand { get; }

		public MainViewModel()
		{
			yellowView = new YellowView();
			greenView = new GreenView();
			purpleView = new PurpleView();
			CurrentView = greenView;

			YellowViewCommand = new RelayCommand(setYellow);
			
			GreenViewCommand = new RelayCommand(x => CurrentView = greenView);

			PurpleViewCommand = new RelayCommand(x => CurrentView = purpleView);


        }

        private void setYellow(object v) 
		{
			CurrentView = yellowView;
		}

        
        						
        

    }
}
