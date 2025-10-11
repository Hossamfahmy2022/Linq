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

#region 1- Filtration (Restrictions) Operator – Where
// Verision 1
// public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate);
// fluent Syntax
var fluentquery1 = employees.Where(e => e.Name =="Ali").ToList();
// Query Synatx
var query1 =  from emp in employees
              where emp.Name== "Ali" // can add && with another condtion
              select emp;
// Verision 2 (apply only in fluent Syntax)
// public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
var fluentquery2 = employees.Where((e,i) => e.Name == "Ali" && i < 10 ).ToList();
#endregion

#region Transformation (Projection Operators) - Select / SelectMany
// Version 1 Of Select
// public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector);
// Fluent Syntax
var fluentquery3 = employees.Select(emp => new {emp.Name,emp.Salary}).ToList();

// Query Syntax
var query2 = from emp in employees
             select emp;
// Version 2 Of Select
// public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector);
// Fluent Validation Only
var fluentquery4 = employees.Select((emp,index) => new { index, emp.Name, emp.Salary }).ToList();

//Select Many
var fluentquery5 = departments.Select(x => x.Employees).ToList(); // not correct

var fluentquery6 = departments.SelectMany(x => x.Employees).ToList();

// Query Synatx

var query3 = 
            from dept in departments
            from emp in dept.Employees
            select emp;

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
             orderby emp.Name ascending,emp.Salary descending
             select emp;
// // Reverse Operator Do the same of desing
// var Result = ProductList.Select(P => P.ProductName).Reverse();
#endregion