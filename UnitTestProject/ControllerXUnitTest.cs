using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallyAssignment_5.Controllers;
using TallyAssignment_5.Models;
using TallyAssignment5.Repository;

namespace UnitTestProject
{
    public class ControllerXUnitTest
    {
        private readonly Mock<ISubjectRepository> mockSubRepo;
        public ControllerXUnitTest()
        {
            mockSubRepo = new Mock<ISubjectRepository>();
        }
        [Fact]
        public void GetSubjects_SubjectList()
        {
            //arrange
            var subjectList = GetSubjectsData();
            mockSubRepo.Setup(s => s.GetSubjects()).Returns(subjectList);
            var subjectController = new SubjectController(mockSubRepo.Object);

            //act
            var subjectResult = subjectController.GetSubjects();

            //assert
            Assert.NotNull(subjectResult);
            Assert.Equal(GetSubjectsData().Count(), actual: subjectResult.Count());
            Assert.True(subjectList.Equals(subjectResult));
            Assert.Equal(GetSubjectsData().ToString(), subjectResult.ToString());
        }

        [Fact]
        public void GetSubjectById_ReturnSubject()
        {
            var subjectList = GetSubjectsData();
            mockSubRepo.Setup(s => s.GetSubjectById(2)).Returns(subjectList[1]);
            var subjectController = new SubjectController(mockSubRepo.Object);

            var subjectResult = subjectController.GetSubject(2);

            Assert.NotNull(subjectResult);
            Assert.Equal(subjectList[1].SubId, subjectResult.SubId);
            Assert.True(subjectList[1].SubId == subjectResult.SubId);
        }

        [Theory]
        [InlineData("Science")]
        public void CheckSubjectExistByPassingSubjectName_Subject(string subName)
        {
            var subjectList = GetSubjectsData();
            mockSubRepo.Setup(s => s.GetSubjects()).Returns(subjectList);
            var subjectController = new SubjectController(mockSubRepo.Object);

            var subjectResult = subjectController.GetSubjects();
            var expectedSubjectName = subjectResult.ToList()[1].SubName;

            Assert.Equal(subName, expectedSubjectName);
        }

        [Fact]
        public void CheckAddSubject_Subject()
        {
            var subjectList = GetSubjectsData();
            mockSubRepo.Setup(s => s.AddSubject(subjectList[1])).Returns(subjectList[1]);
            var subjectController = new SubjectController(mockSubRepo.Object);

            var subjectResult = subjectController.AddSubject(subjectList[1]);

            Assert.NotNull(subjectResult);
            Assert.Equal(subjectList[1].SubId, subjectResult.SubId);
            Assert.True(subjectList[1].SubId == subjectResult.SubId);
        }

        [Fact]
        public void CheckDeleteSubject_Subject()
        {
            mockSubRepo.Setup(s => s.DeleteSubject(1)).Returns(true);
            var subjectController = new SubjectController(mockSubRepo.Object);

            var subjectResult = subjectController.DeleteSubject(1);

            Assert.True((bool)subjectResult);
        }

        private List<Subject> GetSubjectsData()
        {
            List<Subject> subjectsData = new List<Subject>()
            {
                new Subject()
                {
                    SubId = 1,
                    SubName = "Social",
                    MaxMarks = 100,
                    MarksObtained = 92,
                    StudentStudId = 1
                },
                new Subject()
                {
                    SubId = 2,
                    SubName = "Science",
                    MaxMarks = 100,
                    MarksObtained = 84,
                    StudentStudId = 1
                },
                new Subject()
                {
                    SubId = 3,
                    SubName = "Maths",
                    MaxMarks = 100,
                    MarksObtained = 78,
                    StudentStudId = 1
                },
            };
            return subjectsData;
        }
    }
}
