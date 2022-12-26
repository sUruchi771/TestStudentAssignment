using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallyAssignment_5.Models;
using TallyAssignment5.Repository;

namespace TallyAssignment_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectRepository @object;

        public SubjectController(ISubjectRepository @object)
        {
            this.@object = @object;
        }

        public object AddSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public object DeleteSubject(int v)
        {
            throw new NotImplementedException();
        }

        public object GetSubject(int v)
        {
            throw new NotImplementedException();
        }

        public object GetSubjects()
        {
            throw new NotImplementedException();
        }
    }
}
