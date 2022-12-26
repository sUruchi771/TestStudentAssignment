using TallyAssignment_5.Models;

namespace TallyAssignment5.Repository
{
    public interface ISubjectRepository
    {
        public IEnumerable<Subject> GetSubjects();
        public Subject GetSubjectById(int id);
        public Subject AddSubject(Subject subject);
        public Subject UpdateSubject(Subject subject);
        public bool DeleteSubject(int id);
    }
}
