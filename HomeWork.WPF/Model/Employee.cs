using HomeWork.WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.WPF.Model
{
    public class Employee
    {

       static  List<Employee> es = new List<Employee>
        {
                 new Employee{UserName="Tom",Sex=1,Department1=1,Department2=2},
                new Employee{UserName="Jack",Sex=1,Department1=1,Department2=2},
        };

        public static readonly ObservableCollection<Employee> EMPLOYEES = new ObservableCollection<Employee>(es);



        public Employee()
        {
            ID = Guid.NewGuid().ToString();
        }

        public string ID { get; }
        public string UserName { get; set; }
        public int Sex { get; set; }
        public int Department1 { get; set; }
        public int Department2 { get; set; }
        public bool IsValid { get; set; } = true;

    }
}
