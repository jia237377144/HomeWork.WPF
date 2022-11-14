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
using HomeWork.WPF.View;

namespace HomeWork.WPF.ViewModel
{
    public class EmployeeDataViewModel : BaseViewModel
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


        public ICommand OpenWindowCommand
        {
            get
            {
                return new DelegateCommand(OpenWindow);
            }
        }
        public void OpenWindow(object o)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            EmployeeViewModel? employeeViewModel = employeeWindow.DataContext as EmployeeViewModel;
            if (employeeViewModel != null)
            {
                employeeViewModel.AddEmployee = AddEmployee;
            }
            employeeWindow.ShowDialog();
        }

        public ICommand SearchCommand
        {
            get
            {
                return new DelegateCommand(Search);
            }
        }

        public void Search(object o)
        {
            if (!string.IsNullOrEmpty(this.UserName))
            {
                this.employees = new ObservableCollection<Employee>(Employee.EMPLOYEES.Where(x => x.UserName == this.UserName));
            }
            else
            {
                this.employees = new ObservableCollection<Employee>(Employee.EMPLOYEES);
            }
            this.RaisePropertyChanged("Employees");

        }

        public string UserName { get; set; }

        public ICommand DeleCommand
        {
            get
            {
                return new DelegateCommand<string>(Delete);
            }
        }
        public void Delete(string id)
        {
            var employee = this.employees.FirstOrDefault(x => x.ID == id);
            if (employee != null)
            {
                employee.IsValid = false;
                this.RaisePropertyChanged("Employees");
            }
        }



        public EmployeeDataViewModel()
        {
            employees = new ObservableCollection<Employee>(Employee.EMPLOYEES);
            department1 = new ObservableCollection<Department>(Department.DEPARTMENT1);
            department2 = new ObservableCollection<Department>(Department.DEPARTMENT2);
        }

        public void AddEmployee(Employee employee)
        {
            Employee.EMPLOYEES.Add(employee);
            this.employees.Add(employee);
            this.RaisePropertyChanged("Employees");
        }
    }
}
