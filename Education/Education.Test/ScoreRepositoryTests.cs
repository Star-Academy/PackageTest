using Education.Models;

namespace Education.Test
{
    public class ScoreRepositoryTests : RepositoryTests<StudentScore>
    {
        protected override StudentScore CreateEntity()
        {
            return new StudentScore
            {
                StudentId = 1,
                Score = 16.5,
                Course = "Linear Algebra"
            };
        }
    }
}