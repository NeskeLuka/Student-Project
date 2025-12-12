# Student-Project
This project is a university management system that handles data about students, professors, courses, and study programs. The main entities are:

Student – stores information about students such as name, surname, index number, personal ID (JMBG), and the study program (Smer) they belong to.

Profesor – stores information about professors including name, surname, and academic title (Zvanje).

Predmet (Course) – stores information about courses including course name and associated study program.

Smer (Study Program) – stores study programs and the list of students and courses associated with them.

The project also includes many-to-many relationship classes:

StudentiPredmeti – connects students with the courses they are enrolled in.

ProfesoriPredmeti – connects professors with the courses they teach.

The application allows viewing, adding, and managing these entities, including showing details of courses with enrolled students or assigned professors. It is implemented in .NET with Entity Framework using a MVC architecture.