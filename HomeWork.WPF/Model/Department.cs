using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.WPF.Model
{
    public class Department
    {
        public static readonly List<Department> DEPARTMENT1 = new List<Department>
        {
            new Department(1,"Department1"),
            new Department(2,"Department2"),
            new Department(3,"Department3"),

        };

        public static readonly List<Department> DEPARTMENT2 = new List<Department>
        {
            new Department(3,"Department1-1",1),
            new Department(4,"Department1-2",1),
            new Department(5,"Department1-3",1),
            new Department(6,"Department2-1",2),
            new Department(7,"Department3-1",2),
        };
        public Department(int id, string name) : this(id, name, 0)
        {

        }
        public Department(int id, string name, int parentId)
        {
            this.Id = id;
            this.Name = name;
            this.ParentID = parentId;
        }

        public int Id { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public List<Department> SubDepartments { get; set; }
    }
}
