using HomeWork.WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HomeWork.WPF.ViewModel
{
    public class EmployeeDataViewModel :BaseViewModel
    {


        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                this.RaisePropertyChanged("Employees");
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

        public Department SelectDepartment1 { get; set; }


        public EmployeeDataViewModel()
        {
            employees = new ObservableCollection<Employee>(Employee.EMPLOYEES);
            department1 = new ObservableCollection<Department>(Department.DEPARTMENT1);
            department2 = new ObservableCollection<Department>(Department.DEPARTMENT2);
        }
    }
}
