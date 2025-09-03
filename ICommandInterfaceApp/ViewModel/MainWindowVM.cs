using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandInterfaceApp.ViewModel
{
    public class MainWindowVM : ObservableObject
    {
        public string _result = "0";
        
        public string Result
        {
            get => _result;
            set
            {
                if(_result != value)
                {
                    _result = value;
                    //notify everyone / all control binded to this property to show the change
                    RaisePropertyChanged(nameof(Result));
                }
            }
        }

        private string _selectedOperation = "";
        public double _storedValue = 0;

        public double StoredValue
        {
            get => _storedValue;
            set {
                _storedValue = value;
                RaisePropertyChanged(nameof(StoredValue));
            }
        }
        public string SelectedOperation
        {
            get => _selectedOperation;
            set=> _selectedOperation = value;
        }

      
        public ICommand BtnCmd { get; private set; }

        public MainWindowVM()
        {
            BtnCmd = new RelayCommand(ExecuteBtnCmd, CanExecuteBtnCmd);
        }

        private bool CanExecuteBtnCmd()
        {
            return true;
        }

        private void ExecuteBtnCmd()
        {
            
                if (string.IsNullOrEmpty(SelectedOperation))
                {
                    StoredValue = double.Parse(Result);
                }
                else
                {
                    switch (SelectedOperation)
                    {
                        case "+":
                            StoredValue += double.Parse(Result);
                            break;
                        case "-":
                            StoredValue -= double.Parse(Result);
                            break;

                        case "*":
                            StoredValue *= double.Parse(Result);
                            break;
                        case "/":
                            if (double.Parse(Result) == 0)
                            {
                                Result = "Error";
                                SelectedOperation = "";
                                return;
                            }
                            StoredValue /= double.Parse(Result);
                            break;
                    }
                Result = "";
                SelectedOperation = ""; //resetting after operation
                }
        }
        
    }
}
