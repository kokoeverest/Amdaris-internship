using System;
using System.Collections;
using TheBestOfMe;

namespace StaticVsNonstatic;

public class Person
{
    private string _name;
    private DateTime _birthDate;
    private string _email;

    public Person() { }
    public Person(string birthDate) => _birthDate = DateTime.Parse(birthDate);
    public Person(string name, DateTime birthDate, string email)
    {
        _birthDate = birthDate;
        _name = name;
        _email = email;
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Length > 2 && value.Length < 20)
                _name = value;
            else
                throw new ApplicationException("Invalid name length");
        }
    }

    public int Age
    {
        get
        {
            return (int)((DateTime.Now.Year - _birthDate.Year));
        }
    }
    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            if (value.Contains("@") && value.Length > 8)
                _email = value;
            else
                throw new ApplicationException("Invalid email format");
        }
    }
    public static void Work(string work = "I live to work")
    {
        Console.WriteLine(work);
    }
}