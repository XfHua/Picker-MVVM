using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App364
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            myViewModel vm = new myViewModel();
            this.BindingContext = vm;

            //This will also work
            //myPicker.SelectedIndex = 0;
        }
    }

    public class myViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<myClass> myList
        {
            get;
            set;
        }

        public myViewModel()
        {
            GetList();
            SelectedObject = myList[0];
        }

        public void GetList() {

            myList = new List<myClass>();

            myList.Add(new myClass(1,"firstTitle","FirstDesc"));
            myList.Add(new myClass(2, "SecondTitle", "SecondDesc"));
            myList.Add(new myClass(3, "ThirdTitle", "ThirdDesc"));

        }

        public myClass _selectedObject;


        public myClass SelectedObject
        {
            get
            {
                return _selectedObject;
            }
            set
            {
                _selectedObject = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedObject"));
            }
        }
    }

    public class myClass
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        public myClass(int a , string title , string desc) {

            ID = a;
            Title = title;
            Desc = desc;
        }
    }
}
