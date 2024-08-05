using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)

    {
        var ints = new FiveIntegers(1,2,3,4,5);
        foreach (var i in ints)
        {
            Console.WriteLine(i);
        }
        Employee e1 = new Employee { Id = 100, Name = "Rand F", Salary = 1000, Department="IT" };
        Employee e2  = new Employee { Id = 100, Name = "Rand F", Salary = 1000, Department = "IT" };
        Employee e3 = e1;
    Console.WriteLine(e1==e2);
        Console.WriteLine(e1 == e3);
        Console.WriteLine(e1.Equals (e2));//refernces
        Console.WriteLine(7.GetHashCode);


        /*  var s1 = "Hello";
          var s2 = "Hello";
          Console.WriteLine(s1==s2) ;*/
    }
}

class FiveIntegers : IEnumerable
{
    int[] _values;
    public FiveIntegers(int n1, int n2, int n3, int n4, int n5)
    {
        _values = new[] { n1, n2, n3, n4, n5 };
    }
    public IEnumerator GetEnumerator() => new Enumerator(this)
        class Enumerator
    {
        int currentIndex = -1;
        FiveIntegers _integers;
        public Enumerator(FiveIntegers integers)
        {
            _integers = integers;
        }
        public object Current
        {
            get
            {
                if (currentIndex == -1)
                    throw new InvalidOperationException($"Enumeration not started");
                if (currentIndex == _integers._values.Length)
                    throw new InvalidOperationException($"Enumeration has ended");
           return _integers._values[currentIndex];
            }

        } 
        public bool MoveNext()
        {
            if(currentIndex >= _integers._values.Length-1)
                return false;
           return currentIndex++ < _integers._values.Length;
        }
        public void Reset() => currentIndex = -1;
    }
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
    public override bool Equals(object obj)
    {
        if(obj == null||!(obj is Employee))
                return false;
        var emp = obj as Employee;
        return this.Id == emp.Id 
            && this.Name==emp.Name 
            && this.Salary == emp.Salary 
            && this.Department==emp.Department;
       // if(!(obj is  Employee)) return true;
        // return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7)+Id.GetHashCode();
        hash = (hash * 7) + Name.GetHashCode();
        hash = (hash * 7) + Salary.GetHashCode();
        hash = (hash * 7) + Department.GetHashCode();
        return hash;
    }
    public static bool operator == (Employee lhs, Employee rhs) => lhs.Equals(rhs);
         public static bool operator !=(Employee lhs, Employee rhs) => !lhs.Equals(rhs);
}