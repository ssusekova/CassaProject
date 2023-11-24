using CassaProject.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CassaProject.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public CashOperation TypeOfCashOper { get; set; }

        readonly string InstrAddInCassa = "Чтобы внести деньги в операционную кассу, " +
            "\nподготовьте необходимые документы, " +
            "\nподойдите к операционной кассе и " +
            "\nвнесите сумму ";

        readonly string InstrEncashment = "Для безопасной транспортировки денег необходимо " +
            "\nразделить их на части, внести сумму в нужное поле и " +
            "\nуказать номер сумки, в которой она будет транспортироваться";

        readonly string InstrMovingBetweenCasses = "Для перемещения денег между кассами необходимо" +
            "\nвыделить сумму для переноса, занести ее в нужное поле" +
            "\nи указать причину операции";

        private string _instruction = "";
        public string Instruction
        {
            get { return _instruction; }
            set
            {
                _instruction = value;
                OnPropertyChanged();
            }
        }
        private string _sum = null;
        public string Sum
        {
            get { return _sum; }
            set
            {
                _sum = value;
                OnPropertyChanged();
            }
        }

        private string _countOfBag = null;
        public string CountOfBag
        {
            get { return _countOfBag; }
            set
            {
                _countOfBag = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> ReasonOfOperCollection { get; }
        = new ObservableCollection<string>() { "Инкассация в бухгалтерию", "Выплаты" };


        private string _reasonOfOperText = null;
        public string ReasonOfOperText
        {
            get { return _reasonOfOperText; }
            set { _reasonOfOperText = value;
                OnPropertyChanged(); }
        }


        private bool _addInCassaIsCheched = false;
        public bool AddInCassaIsCheched
        {
            get { return _addInCassaIsCheched; }
            set { _addInCassaIsCheched = value;
                if(AddInCassaIsCheched == true)
                {
                    Instruction = InstrAddInCassa;
                    TypeOfCashOper = CashOperation.ВнесениеВОперационнуюКассу;
                    Sum = null;
                    CountOfBag = null;
                    ReasonOfOperText = null;
                }
                OnPropertyChanged(); 
            }
        }

        private bool _encashmentIsCheched = false;
        public bool EncashmentIsCheched
        {
            get { return _encashmentIsCheched; }
            set { _encashmentIsCheched = value;
                if(EncashmentIsCheched == true)
                {
                    Instruction = InstrEncashment;
                    TypeOfCashOper = CashOperation.Инкассация;
                    Sum = null;
                    CountOfBag = null;
                    ReasonOfOperText = null;
                }
                OnPropertyChanged(); 
            }
        }

        private bool _movingBetweenCassesIsCheched = false;
        public bool MovingBetweenCassesIsCheched
        {
            get { return _movingBetweenCassesIsCheched; }
            set { _movingBetweenCassesIsCheched = value;
                if(MovingBetweenCassesIsCheched == true)
                {
                    Instruction = InstrMovingBetweenCasses;
                    TypeOfCashOper = CashOperation.ПеремещениеМеждуКассами;
                    Sum = null;
                    CountOfBag = null;
                    ReasonOfOperText = null;
                }
                OnPropertyChanged(); 
            }
        }

        RecordInFileModel recordInFileModel = new RecordInFileModel();

        public void WriteInFile()
        {
            recordInFileModel.LoadDataInDocument(TypeOfCashOper, Sum, CountOfBag, ReasonOfOperText);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
