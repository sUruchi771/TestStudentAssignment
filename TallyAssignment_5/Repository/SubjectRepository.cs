using TallyAssignment_5.Models;
using TallyAssignment5.Data;

namespace TallyAssignment5.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public SubjectRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Subject AddSubject(Subject subject)
        {
            var result = _dbContext.Subjects.Add(subject);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteSubject(int id)
        {
            var filtredData = _dbContext.Subjects.FirstOrDefault(s => s.SubId == id);
            if (filtredData != null)
            {
                var result = _dbContext.Remove(filtredData);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Subject GetSubjectById(int id)
        {
            return _dbContext.Subjects.Where(s => s.SubId == id).FirstOrDefault();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _dbContext.Subjects.ToList();
        }

        public Subject UpdateSubject(Subject subject)
        {
            var result = _dbContext.Subjects.Update(subject);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
