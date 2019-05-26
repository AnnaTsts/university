using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class StudentsMarkService : IStudentsMarkService
    {
        IUnitOfWork db { get; set; }

        public StudentsMarkService(IUnitOfWork uow)
        {
            db = uow;
        }
        
        public IEnumerable<StudentsMarkDTO> GetAllMarks()
        {
            IEnumerable<StudentsMark> marks = db.StudentsMarks.GetAll();
            return Mapper.Map<IEnumerable<StudentsMark>, IEnumerable<StudentsMarkDTO>>(marks);
        }

        public StudentsMarkDTO GetMark(int id)
        {
            var mark = db.StudentsMarks.Get(id);
            return Mapper.Map<StudentsMark, StudentsMarkDTO>(mark);
        }

        public void Insert(StudentsMarkDTO studentsMark)
        {
            db.StudentsMarks.Insert(Mapper.Map<StudentsMarkDTO, StudentsMark>(studentsMark));
            db.Save();
        }

        public IEnumerable<StudentsMarkDTO> GetAllMarksByGroup(int groupId)
        {
            IEnumerable<StudentsMark> groupsMark = db.StudentsMarks.Find((sm) => sm.Student.GroupId == groupId);
            return Mapper.Map<IEnumerable<StudentsMark>, IEnumerable<StudentsMarkDTO>>(groupsMark);
        }

        public IEnumerable<StudentsMarkDTO> GetAllMarksByTeacher(string teacherId)
        {
            IEnumerable<StudentsMark> groupsMark = db.StudentsMarks.Find((sm) => sm.TeacherSubject.TeacherId == teacherId);
            return Mapper.Map<IEnumerable<StudentsMark>, IEnumerable<StudentsMarkDTO>>(groupsMark);
        }

        public IEnumerable<StudentsMarkDTO> GetAllMarksByStudent(string userId)
        {
            IEnumerable<StudentsMark> groupsMark = db.StudentsMarks.Find((sm) => sm.ApplicationUserId == userId);
            return Mapper.Map<IEnumerable<StudentsMark>, IEnumerable<StudentsMarkDTO>>(groupsMark);
        }
        
        
        public IEnumerable<StudentsMarkDTO> GetAllMarksByTeacherAndGroup(string userId,int groupId)
        {
            IEnumerable<StudentsMark> groupsMark = db.StudentsMarks.Find((sm) => sm.Student.GroupId == groupId);
            IEnumerable<StudentsMark> teacherMark = db.StudentsMarks.Find((sm) => sm.TeacherSubject.TeacherId == userId);

            var result = groupsMark.Intersect(teacherMark).Distinct();
            return Mapper.Map<IEnumerable<StudentsMark>, IEnumerable<StudentsMarkDTO>>(result);

        }
        
        
        
        
    }
}