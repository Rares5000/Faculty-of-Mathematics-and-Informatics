namespace Lab1;

public class Subject
{
    public string Name { get; set; }
    public int EctsCount { get; set; }
    public double Grade { get; set; }

    public Subject(string name, int ectsCount, double grade)
    {
        this.Name = name;
        this.EctsCount = ectsCount;
        this.Grade = grade;
    }
}