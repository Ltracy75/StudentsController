using StudentsController;

var studctrl = new StudentController("localhost\\sqlexpress", "EdDb");


studctrl.OpenConnection();

var student = new Student()
    {
    FirstName = "Graham",
    LastName = "Kraker",
    StateCode = "AZ",
    SAT = 3,
    GPA = 0.1m,
    MajorId = 1
    };

student.Id = 69;

var rc = studctrl.ChangeStudent(student);



studctrl.CloseConnection();
