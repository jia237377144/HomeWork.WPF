using HomeWork.WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HomeWork.WPF.ViewModel
{
    public class EmployeeViewModel : BaseViewModel
    {
        #region command1

        public ICommand cm1click { get; set; }
        public void cm1Click()
        {
            MessageBox.Show("CM1 clicked!");
        }

        private bool Cancm1Click(object param)
        {
            return true;
        }

        #endregion command1
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                this._userName = value;
                base.RaisePropertyChanged("UserName");
            }
        }

        private ObservableCollection<Department> department1;
        public ObservableCollection<Department> Department1
        {
            get { return department1; }
            set
            {
                department1 = value;
                this.RaisePropertyChanged("Department1");
            }
        }


        private ObservableCollection<Department> department2;
        public ObservableCollection<Department> Department2
        {
            get { return department2; }
            set
            {
                department2 = value;
                this.RaisePropertyChanged("Department2");
            }
        }


        public ICommand SaveCommand
        {
            get
            {
              return  new DelegateCommand(SaveEmployee);
            }
        }
        public void SaveEmployee(object obj)
        {
            Employee employee = new Employee
            {
                UserName = this._userName
            };
            Employee.EMPLOYEES.Add(employee);
            this.WindowResult = true;
            RaisePropertyChanged("Employee.EMPLOYEES");
        }


        private bool? dialogResult;
        public bool? WindowResult
        {
            get { return this.dialogResult; }
            set
            {
                this.dialogResult = value;
                RaisePropertyChanged("WindowResult");
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    this.WindowResult = true;
                });
            }
        }



        public EmployeeViewModel()
        {
            department1 = new ObservableCollection<Department>(Department.DEPARTMENT1);
            department2 = new ObservableCollection<Department>(Department.DEPARTMENT2);
        }


    }
}
