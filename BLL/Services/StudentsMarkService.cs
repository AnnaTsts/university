using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class StudentsMarkService : IStudentsMarkService
    {
        IUnitOfWork db { get; set; }
        // private IRepository<int,StudentsMark> sr;
        
        
        public StudentsMarkService(IUnitOfWork uow)
        {
            db = uow;
        //    sr = uow.StudentsMarks;
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

        public IEnumerable<IEnumerable<StudentsMarkDTO>> GetAllMarksByTeacherAndGroupSorted(string userId, int groupId)
        {
            IEnumerable<StudentsMarkDTO> marks = GetAllMarksByTeacherAndGroup(userId, groupId);
            List<StudentsMarkDTO>markss= new List<StudentsMarkDTO>();
            foreach (var mark in marks)
            {
                markss.Add(mark);
            }
            List<string> names = new List<string>();
            foreach (var m in markss)
            {
                if(!(names.Contains(m.Student.FirstName+" "+m.Student.SecondName)))
                    names.Add(m.Student.FirstName+" "+m.Student.SecondName);
            }
            
            List<List<StudentsMarkDTO>> marksInList= new List<List<StudentsMarkDTO>>();
            foreach (var m in markss)
            {
                if (names.Contains(m.Student.FirstName + " " + m.Student.SecondName))
                {
                    int id = names.FindIndex((st)=>st==m.Student.FirstName + " " + m.Student.SecondName);
                    marksInList[id].Add(m);
                }
              
            }

            return marksInList;
        }


        public void Update(StudentsMarkDTO st)
        {
            StudentsMark newObj = Mapper.Map<StudentsMarkDTO, StudentsMark>(st);
            if (newObj.Id == null)
            {
                db.StudentsMarks.Insert(newObj);
            }
            else
            {
                StudentsMark obj=  db.StudentsMarks.Get(newObj.Id);
                obj.Mark = newObj.Mark;
                obj.NameOfWork = newObj.NameOfWork;
                db.Save();
            }
        }
    }

    }
