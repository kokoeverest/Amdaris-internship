//Assignment requirements
//Take a look at the Speaker class in this GitHub repo: https://github.com/mustafadagdelen/dirty-code-for-clean-code-sample/blob/master/BusinessLayer/Speaker.cs
//Create a console appliation and refactor the Speaker class from the repo, so that it adheres to clean code, SOLID principles and generally to good coding practices
//Also create the other classes needed for the app to compile, like the Session class. Don't concentrate on refactoring them. Use them just for the purpose of your application to work
//In a readme.md file, answer the following questions:
//What code smells did you see?
//What problems do you think the Speaker class has?
//Which clean code principles (or general programming principles) did it violate?
//What refactoring techniques did you use?

using BusinessLayer;
using InversionOfControl;

SpeakerRepository repo = new();

List<Speaker> speakers = [
    // A good speaker
    new(
        firstName: "Dan",
        lastName: "Patrascu",
        email: "dan@amdaris.com",
        blogUrl: "www.blog.com",
        certifications: ["C#", "Python", "MSSQL", "ASP.NET Core"],
        employer: "Amdaris",
        sessions: [new Session("Microservices are evil", "A session about microsrvices")]
        ),
    // A bad email address
    new(
        firstName: "Dan",
        lastName: "Patrascu",
        email: "dan@hotmail.com",
        blogUrl: "www.blog.com",
        certifications: [],
        employer: "Amdaris",
        sessions: [new Session("Microservices are evil", "A session about microsrvices")]
        ),
    // A good speaker
    new(
        firstName: "Dan",
        lastName: "Patrascu",
        email: "dan@amdaris.com",
        blogUrl: "",
        certifications: ["C#", "ASP.NET Core"],
        employer: "Google",
        sessions: [new Session("Microservices are evil", "A session about microsrvices")]
        ),
    // No sessions
    new(
        firstName: "Dan",
        lastName: "Patrascu",
        email: "dan@amdaris.com",
        blogUrl: "www.blog.com",
        certifications: [],
        employer: "Amdaris",
        sessions: []
        ),
    // Contains a bad session
    new(
        firstName: "Dan",
        lastName: "Patrascu",
        email: "dan@amdaris.com",
        blogUrl: "www.blog.com",
        certifications: ["C#", "Python", "MSSQL", "ASP.NET Core"],
        employer: "Amdaris",
        sessions: [new Session("Punch Cards are evil", "A session about microsrvices")]
        ) { Experience = 11},
    ];

foreach(Speaker speaker in speakers)
{
    speaker.Register(repo);
    Console.WriteLine(speaker.Id);
}