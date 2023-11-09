using Lab1;

List<Student> students = new List<Student>
{
    new Student("Alex", "Johnson", 1, 15, 152),
    new Student("John", "Lawrence", 3, 33, 331),
    new Student("George", "Steward", 2, 24, 243),
    new Student("Mike", "Tyson", 2, 23, 231)
};

// Initializing Alex Johnson
students[0].AddMark(new Subject("Discrete Mathematics", 5, 7.3));
students[0].AddMark(new Subject("Linear Algebra", 6, 9));
students[0].AddMark(new Subject("Artificial Intelligence", 7, 8));
students[0].AddMark(new Subject("Ethics", 4, 10));
students[0].AddMark(new Subject("Algorithms and Data Structures", 6, 10));
students[0].AddMark(new Subject("Functional Programming", 5, 6));

// Initializing John Lawrence
students[1].AddMark(new Subject("Discrete Mathematics", 5, 8.75));
students[1].AddMark(new Subject("Linear Algebra", 6, 5.50));
students[1].AddMark(new Subject("Artificial Intelligence", 7, 8));
students[1].AddMark(new Subject("Ethics", 4, 7));
students[1].AddMark(new Subject("Algorithms and Data Structures", 6, 8.20));
students[1].AddMark(new Subject("Functional Programming", 5, 9.60));

// Initializing George Steward
students[2].AddMark(new Subject("Discrete Mathematics", 5, 7.3));
students[2].AddMark(new Subject("Linear Algebra", 6, 8.13));
students[2].AddMark(new Subject("Artificial Intelligence", 7, 9));
students[2].AddMark(new Subject("Ethics", 4, 10));
students[2].AddMark(new Subject("Algorithms and Data Structures", 6, 9));
students[2].AddMark(new Subject("Functional Programming", 5, 10));

// Initializing Mike Tyson
students[3].AddMark(new Subject("Discrete Mathematics", 5, 10));
students[3].AddMark(new Subject("Linear Algebra", 6, 10));
students[3].AddMark(new Subject("Artificial Intelligence", 7, 10));
students[3].AddMark(new Subject("Ethics", 4, 10));
students[3].AddMark(new Subject("Algorithms and Data Structures", 6, 10));
students[3].AddMark(new Subject("Functional Programming", 5, 10));

foreach (var currStudent in students)
{
    var gpa = decimal.Round(new decimal(currStudent.GetGpa()), 2);
    var finalGrade = decimal.Round(new decimal(currStudent.FinalGrade()), 2);
    Console.WriteLine($"{currStudent.FirstName} {currStudent.LastName}, GPA: {gpa}, Final grade: {finalGrade}");
}