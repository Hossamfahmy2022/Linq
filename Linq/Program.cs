#region What is Linq
// What is Linq
using Linq;

/// LINQ: stands for Language-Integrated Query
/// LINQ: +40 Extension Methods (to the classes that implement IEnumerable interface)
/// Named [Query Operators] Existing at Enumerable Class and Categorized to 13 Categories
/// Use LINQ Operators against the Data that Stored at Sequence Regardless Data Store
/// [SQL Server, MySQL, Oracle, and etc...]
/// Sequence: Any Class Implementing IEnumerable (Like List, Array, Dictionary...)
/// 1. Local Sequence : L2O, L2XML
/// 2. Remote Sequence: L2E
List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
List<int> oddNumbers = Numbers.Where((N) => N % 2 == 1).ToList();// هاتلى الارقام الفردي

#endregion

#region Linq Syntax
/*
// 1. Fluent Syntax
عندى طريقتين بكتب بيهم  linqوهى ممكن اكتبها  static methodsوممكن اكتبها extension method
/// 1.1 Calling LINQ Operators as Static Methods through Enumerable Class*/
var Result = Enumerable.Where(Numbers, (N) => N % 2 == 0);
/// 1.2 Calling LINQ Operators as Extension Methods [RECOMMENDED]
//Result = Numbers.Where((N) => N % 2 == 0);
// 2. Query Syntax [Query Expression]: Like SQL Query Style
// Start With from, Introducing Range Variable(N): Represents Each Element At Sequence
// End With select Or group by
/// Some Cases, It's Easier To Write Queries Using Query Expression
/* 
يفضل فيها استخدام الكويري اكسبريشن وبراحتك برضو )/// Instead Of Fluent Syntax (Join, Group
بتمثل كل اليمنت موجود فى النامبرز */
var oddNumbers2 = from N in Numbers //N
                  where N % 2 == 0
                  select N;
#endregion

#region LINQ Execution
/*
 * /// Ways Of LINQ Execution طرق تنفيذ الـ لينكيو
// 1. Deffered Execution (Latest Update Of Data) // 10 category from LINQ operators
مش هيتنفذ دلوقتى هيتنفذ وقت ما ما اجي اكلمه زي المثال دا كدا هيتنفذ وقت ما اعمل  for loopعليه ودى ميزة
Deffered Execution  شغالين بطريقةLINQ operators  من الـcategory 10 وعندنا
// All LINQ Operators Except Element, Aggregate, Casting Operators رجاء الدعاء لعميAhmeed Mostafa - 01155023528 Page 4
*/
List<int> Numbers2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
var EvenNumbers = Numbers2.Where((i) => i % 2 == 0);
Numbers2.Remove(2);
Numbers2.AddRange(new int[] { 9, 10, 11, 12 });
foreach (var item in EvenNumbers)
    Console.Write($"{item},"); // 1,3,5,7,9,11
/*
// 2. Immediate Execution // 3 category from LINQ operators
بيتنفذ في التو واللحظة ودا بيتم من خلال انى استخدم حاجة من التلاتة element operators,casting operators,aggregate operators
Immediate Execution  شغالين بطريقةLINQ operators  منcategory 3 وعندنا
// Using Casting For Converting Deffered Executing LINQ Operators
usign [Element Operators, Casting Operators, Aggregate Operators]
*/
List<int> Numbers3 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
EvenNumbers = Numbers3.Where((i) => i % 2 == 0).ToList();//ToList() is casting operator
Numbers3.Remove(2);
Numbers3.AddRange(new int[] { 9, 10, 11, 12 });
foreach (var item in EvenNumbers)
    Console.Write($"{item},");
#endregion

#region Data Setup
// Data (Random data to apply all linq operators on it)
var departments = new List<Department>
        {
            new Department { Id = 1, Name = "IT" },
            new Department { Id = 2, Name = "HR" },
            new Department { Id = 3, Name = "Finance" }
        };

var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Ali",   Age = 25, Salary = 5000, DepartmentId = 1 },
            new Employee { Id = 2, Name = "Sara",  Age = 30, Salary = 7000, DepartmentId = 1 },
            new Employee { Id = 3, Name = "Omar",  Age = 28, Salary = 4000, DepartmentId = 2 },
            new Employee { Id = 4, Name = "Laila", Age = 35, Salary = 9000, DepartmentId = 3 },
            new Employee { Id = 5, Name = "Ahmed", Age = 40, Salary = 9000, DepartmentId = 3 }
        };

var students = new List<Student>
        {
            new Student { Name = "Ali", Subjects = new List<string> { "Math", "Physics" } },
            new Student { Name = "Sara", Subjects = new List<string> { "English", "History" } },
            new Student { Name = "Omar", Subjects = new List<string> { "Biology", "Chemistry", "Math" } }
        };

var depts = new List<Department>
        {
            new Department
            {
                Name = "IT",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        Name = "Ali",
                        Projects = new List<Project>
                        {
                            new Project { Title = "Migration", DurationMonths = 12 },
                            new Project { Title = "BugFixing", DurationMonths = 3 }
                        }
                    },
                    new Employee
                    {
                        Name = "Mona",
                        Projects = new List<Project>
                        {
                            new Project { Title = "AI Research", DurationMonths = 8 }
                        }
                    }
                }
            },
            new Department
            {
                Name = "HR",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        Name = "Sara",
                        Projects = new List<Project>
                        {
                            new Project { Title = "Hiring Campaign", DurationMonths = 7 }
                        }
                    }
                }
            }
        }; 
#endregion

#region 1- Filtration (Restrictions) Operator – Where
// Verision 1
// public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
// fluent Syntax
var fluentquery1 = employees.Where(e => e.Name == "Ali").ToList();
// Query Synatx
var query1 = from emp in employees
             where emp.Name == "Ali" // can add && with another condtion
             select emp;
// Verision 2 (apply only in fluent Syntax)
// public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
var fluentquery2 = employees.Where((e, i) => e.Name == "Ali" && i < 10).ToList();
#endregion

#region Transformation (Projection Operators) - Select / SelectMany
// Version 1 Of Select
// public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
// Fluent Syntax
var fluentquery3 = employees.Select(emp => new { emp.Name, emp.Salary }).ToList();

// Query Syntax
var query2 = from emp in employees
             select emp;
// Version 2 Of Select
// public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector);
// Fluent Validation Only
var fluentquery4 = employees.Select((emp, index) => new { index, emp.Name, emp.Salary }).ToList();

//Select Many
var fluentquery5 = departments.Select(x => x.Employees).ToList(); // not correct

var fluentquery6 = departments.SelectMany(x => x.Employees).ToList();

// Query Synatx

var query3 =
            from dept in departments
            from emp in dept.Employees
            select emp;


/*
/ SelectMany ل Flatten كل المشاريع مع الشروط
 * عندنا Department (قسم) وكل قسم يحتوي على مجموعة موظفين (Employees).

كل موظف عنده قائمة من المشاريع (Projects).

عايزين نجيب قائمة مسطّحة فيها:

اسم القسم

اسم الموظف

اسم المشروع
لكن بشرط: المشاريع اللي مدتها أكبر من 6 شهور فقط.
 */
/*
 * */
var query =
   depts
   .SelectMany(dept => dept.Employees, (dept, emp) => new { dept.Name, emp }) // flatten employees
   .SelectMany(x => x.emp.Projects, (x, proj) => new
   {
       DepartmentName = x.Name,
       EmployeeName = x.emp.Name,
       ProjectTitle = proj.Title,
       proj.DurationMonths
   })
  .Where(result => result.DurationMonths > 6);







// Distict operator
var DistictNames = employees.Select(e => e.Name).Distinct().ToList();

#endregion

#region Ordering Operators
// Version 1
// public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector);
// Fluent Synatx (Ascending)
var Fluentquery7 = employees.OrderBy(x => x.Salary);
// Query Synatx
var query7 = from emp in employees
             orderby emp.Salary
             select emp;
// Fluent Synatx (Desending)
var Fluentquery8 = employees.OrderByDescending(x => x.Salary);

var query8 = from emp in employees
             orderby emp.Salary descending
             select emp;
// OrderBy Multiple Columns
var Fluentquery9 = employees.OrderBy(x => x.Name).ThenBy(x => x.Salary);
var query9 = from emp in employees
             orderby emp.Name ascending, emp.Salary descending
             select emp;
// // Reverse Operator Do the same of desing
// var Result = ProductList.Select(P => P.ProductName).Reverse();
var nums = new[] { 1, 2, 3, 4, 5 };
var reversed = nums.Reverse();
#endregion

#region Grouping Operators
// CASE 1: 🧠 Example 1 – Simple group by key  
var people = new[]
{
    new { Name = "Ali", City = "Cairo" },
    new { Name = "Sara", City = "Cairo" },
    new { Name = "Omar", City = "Giza" }
};

var groups = people.GroupBy(p => p.City);

foreach (var g in groups)
{
    Console.WriteLine($"City: {g.Key}");
    foreach (var person in g)
        Console.WriteLine($" - {person.Name}");
}
// 🧠 Example 2 – Group and project
var cityGroups = people.GroupBy(
    p => p.City,
    (city, members) => new { City = city, Count = members.Count() }
);

foreach (var item in cityGroups)
    Console.WriteLine($"{item.City}: {item.Count}");
#endregion

#region Join Operators

// Inner Join : Join only returns matching elements (inner join).
var innerJoin = from emp in employees
                join dept in departments
                on emp.DepartmentId equals dept.Id
                select new
                {
                    EmployeeName = emp.Name,
                    DepartmentName = dept.Name
                };

// Group Join :Performs a left outer join
var groupJoin = from dept in departments
                join emp in employees
                on dept.Id equals emp.DepartmentId into emps
                select new
                {
                    DepartmentName = dept.Name,
                    Employees = emps
                };

var customers = new[]
{
    new { Id = 1, Name = "Ali" },
    new { Id = 2, Name = "Sara" }
};

var orders = new[]
{
    new { OrderId = 100, CustomerId = 1 },
    new { OrderId = 101, CustomerId = 1 },
    new { OrderId = 102, CustomerId = 2 }
};

var joined = customers.Join(
    orders,
    c => c.Id,
    o => o.CustomerId,
    (c, o) => new { c.Name, o.OrderId }
);

foreach (var item in joined)
    Console.WriteLine($"{item.Name} - Order {item.OrderId}");

var result = customers.GroupJoin(
    orders,
    c => c.Id,
    o => o.CustomerId,
    (c, ords) => new { c.Name, Orders = ords.Select(o => o.OrderId).ToList() }
);

foreach (var item in result)
{
    Console.WriteLine($"{item.Name} Orders: {string.Join(", ", item.Orders)}");
}

#endregion

#region ANy/All/Contains Operators
var numbers = new[] { 1, 2, 3, 4, 5 };

// 1️⃣ Check if sequence has any elements
bool hasAny = numbers.Any();            // true

// 2️⃣ Check if any number is greater than 3
bool anyGreaterThan3 = numbers.Any(n => n > 3);   // true

numbers = new[] { 2, 4, 6, 8 };

// Are all numbers even?
bool allEven = numbers.All(n => n % 2 == 0);   // true

// Are all numbers > 5?
bool allGreaterThan5 = numbers.All(n => n > 5); // false

var names = new[] { "Hossam", "Ali", "Omar" };

// 1️⃣ Default comparison
bool containsAli = names.Contains("Ali"); // true

// 2️⃣ Case-insensitive comparison
bool containsOmarInsensitive = names.Contains("omar", StringComparer.OrdinalIgnoreCase); // true
#endregion

#region Element Operators
numbers = new[] { 3, 6, 9 };

// First element
var first = numbers.First();                     // 3

// First element greater than 5
var firstGreaterThan5 = numbers.First(n => n > 5); // 6

// If empty → throws InvalidOperationException
var empty = new int[] { };
// var error = empty.First(); // ❌ Exception

// Safe version
var safeFirst = empty.FirstOrDefault(); // 0 (default for int)

var ids = new[] { 10 };

// Single element
var id = ids.Single(); // ✅ 10

// If multiple elements → exception
// var error = new[] { 1, 2 }.Single(); // ❌ InvalidOperationException

// With condition
nums = new[] { 1, 2, 3 };
var two = nums.Single(n => n == 2); // ✅ 2

// Not found
var none = nums.SingleOrDefault(n => n == 10); // 0

nums = new[] { 2, 4, 6, 8 };

var last = nums.Last();                  // 8
var lastEven = nums.Last(n => n < 8);    // 6

// If empty → exception
empty = new int[] { };
// var err = empty.Last(); ❌

// Safe version
var safeLast = empty.LastOrDefault(); // 0
#endregion

#region Aggregation Operators
numbers = new[] { 1, 2, 3, 4, 5 };
// Sum of numbers
var sum = numbers.Sum(); // 15
// Sum of squares
var sumOfSquares = numbers.Sum(n => n * n); // 55
// Average of numbers
var average = numbers.Average(); // 3.0
// Average of squares
var averageOfSquares = numbers.Average(n => n * n); // 11.0
// Minimum value
var min = numbers.Min(); // 1
 // Maximum value
var max = numbers.Max(); // 5
 // Count of numbers
var count = numbers.Count(); // 5
 // Count of even numbers
var evenCount = numbers.Count(n => n % 2 == 0); // 2



#endregion

#region New Operator like MaxBy , MinBy 

// MaxBy and MinBy Operators
var products = new[]
{
    new { Name = "Laptop", Price = 1200 },
    new { Name = "Smartphone", Price = 800 },
    new { Name = "Tablet", Price = 600 }
};
var mostExpensive = products.MaxBy(p => p.Price); // Laptop

var cheapest = products.MinBy(p => p.Price); // Tablet


#endregion