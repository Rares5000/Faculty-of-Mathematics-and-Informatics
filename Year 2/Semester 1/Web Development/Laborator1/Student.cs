namespace Lab1;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Year { get; set; }
    public int Series { get; set; }
    public int Group { get; set; }

    private List<Subject> _marks = new List<Subject>();
    
    public Student(string firstName, string lastName, int year, int series, int group)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Year = year;
        this.Series = series;
        this.Group = group;
    }

    public void AddMark(Subject mark)
    {
        _marks.Add(mark);
    }

    public double GetGpa()
    {
        double sum = 0;
        foreach (var currSubject in _marks)
        {
            sum += currSubject.Grade;
        }

        return sum / _marks.Count;
    }

    public double FinalGrade()
    {
        double sum = 0;
        double max = 0;
        foreach (var currSubject in _marks)
        {
            sum += currSubject.Grade * currSubject.EctsCount;
            max += 10 * currSubject.EctsCount;
        }

        return sum / max * 10;
    }
}