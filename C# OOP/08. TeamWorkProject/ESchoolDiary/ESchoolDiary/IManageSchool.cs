using System;

namespace ESchoolDiary
{
    interface IManageSchool
    {
        // Adding
        void AddStudent(Student student);
        void AddSubject(Subject subject);
        void AddSchoolClasses(SchoolClass schoolClass);

        void AddTeacher(Teacher teacher);
        void AddMainTeacher(MainTeacher mainTeacher);

        // Removing
        void RemoveStudent(Student student);
        void RemoveSubject(Subject subject);
        void RemoveSchoolClasses(SchoolClass schoolClass);

        void RemoveTeacher(Teacher teacher);
        void RemoveMainTeacher(MainTeacher mainTeacher);
    }
}