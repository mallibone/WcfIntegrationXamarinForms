using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WcfIntegrationXamarinForms.Service.WebService;

namespace WcfIntegrationXamarinForms.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IWcfServiceWrapper _wcfServiceWrapper;
        private string _response;
        private readonly IList<string> _numbers;
        private bool _isCallingWebservice;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IWcfServiceWrapper wcfServiceWrapper)
        {
            if (wcfServiceWrapper == null) throw new ArgumentNullException("wcfServiceWrapper");
            _wcfServiceWrapper = wcfServiceWrapper;

            _numbers = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
            Response = "Pick a number and click submit";
            SubmitCommand = new RelayCommand(GetResponseAsync, () => CanGetResponse);
            CanGetResponse = true;
        }

        private async void GetResponseAsync()
        {
            CanGetResponse = false;
            IsCallingWebservice = true;

            Response = await _wcfServiceWrapper.GetDataAsync(Int32.Parse(_numbers[SelectedNumberIndex]));

            CanGetResponse = true;
            IsCallingWebservice = true;
        }

        public int SelectedNumberIndex { get; set; }

        public bool CanGetResponse { get; set; }

        public ICommand SubmitCommand { get; set; }

        public bool IsCallingWebservice
        {
            get { return _isCallingWebservice; }
            set
            {
                if (value == _isCallingWebservice) return;
                _isCallingWebservice = value;
                RaisePropertyChanged(() => IsCallingWebservice);
            }
        }

        public string Response
        {
            get { return _response; }
            set
            {
                if (_response == value) return;
                _response = value;
                RaisePropertyChanged(() => Response);
            }
        }
    }
}