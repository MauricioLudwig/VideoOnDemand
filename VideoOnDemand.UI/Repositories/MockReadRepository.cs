using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoOnDemand.Data.Data.Entities;

namespace VideoOnDemand.UI.Repositories
{
    public class MockReadRepository : IReadRepository
    {

        #region Mock Data
        List<Course> _courses = new List<Course>
        {
            new Course{ Id = 1, InstructorId = 1, Title = "C# for Beginners", Description = "Course 1, Description"},
            new Course{ Id = 2, InstructorId = 1, Title = "Programming C#", Description = "Course 2, Description"},
            new Course{ Id = 3, InstructorId = 2, Title = "MVC 5 for Beginners", Description = "Course 3, Description"},
        };

        List<UserCourse> _userCourses = new List<UserCourse>
        {
            new UserCourse { UserId = "e97cf155-2d07-4e2c-825e-8f8c7c4a15ba", CourseId = 1 },
            new UserCourse { UserId = "e97cf155-2d07-4e2c-825e-8f8c7c4a15ba", CourseId = 2 },
            new UserCourse { UserId = "e97cf155-2d07-4e2c-825e-8f8c7c4a15ba", CourseId = 3 },
            new UserCourse { UserId = "e97cf155-2d07-4e2c-825e-8f8c7c4a15ba", CourseId = 1 },
        };

        List<Module> _modules = new List<Module>
        {
            new Module { Id = 1, Title = "Module 1", CourseId = 1 },
            new Module { Id = 2, Title = "Module 2", CourseId = 1},
            new Module { Id = 3, Title = "Module 3", CourseId = 2},
        };

        List<Download> _downloads = new List<Download>
        {
            new Download { Id = 1, ModuleId = 1, CourseId = 1, Title = "ADO.NET 1 (PDF)", Url = "abc" },
            new Download { Id = 2, ModuleId = 1, CourseId = 1, Title = "ADO.NET 2 (PDF)", Url = "def" },
            new Download { Id = 3, ModuleId = 3, CourseId = 2, Title = "ADO:NET 1 (PDF)", Url = "ghi" },
        };

        List<Instructor> _instructors = new List<Instructor>
        {
            new Instructor { Id = 1, Name = "John Doe", Thumbnail = "", Description = "Jphn Doe Description" },
            new Instructor { Id = 2, Name = "Jane Doe", Thumbnail = "", Description = "Jane Doe Description"},
        };

        List<Video> _videos = new List<Video>
        {
            new Video { Id = 1, ModuleId = 1, CourseId = 1, Position = 1, Title = "Video 1 Title", Description = "Video 1 Description", Duration = 50},
            new Video { Id = 2, ModuleId = 1, CourseId = 1, Position = 2, Title = "Video 2 Title", Description = "Video 2 Description", Duration = 45},
            new Video { Id = 3, ModuleId = 3, CourseId = 2, Position = 1, Title = "Video 3 Title", Description = "Video 3 Description", Duration = 41},
            new Video { Id = 4, ModuleId = 2, CourseId = 1, Position = 1, Title = "Video 4 Title", Description = "Video 4 Description", Duration = 42},
        };
        #endregion

        public IEnumerable<Course> GetCourses(string userId)
        {
            var courses = _userCourses.Where(uc => uc.UserId.Equals(userId))
                .Join(_courses, uc => uc.CourseId, c => c.Id,
                (uc, c) => new { Course = c })
                .Select(s => s.Course);

            foreach (var course in courses)
            {
                course.Instructor = _instructors.SingleOrDefault(s => s.Id.Equals(course.InstructorId));
                course.Modules = _modules.Where(m => m.CourseId.Equals(course.Id)).ToList();
            }

            return courses;
        }

        public Course GetCourse(string userId, int courseId)
        {
            var course = _userCourses.Where(uc => uc.UserId.Equals(userId))
                .Join(_courses, uc => uc.CourseId, c => c.Id,
                (uc, c) => new { Course = c })
                .SingleOrDefault(s => s.Course.Id.Equals(courseId)).Course;

            course.Instructor = _instructors.SingleOrDefault(s => s.Id.Equals(course.InstructorId));
            course.Modules = _modules.Where(m => m.CourseId.Equals(course.Id)).ToList();

            foreach (var module in course.Modules)
            {
                module.Downloads = _downloads.Where(d => d.ModuleId.Equals(module.Id)).ToList();
                module.Videos = _videos.Where(v => v.ModuleId.Equals(module.Id)).ToList();
            }

            return course;
        }

        public Video GetVideo(string userId, int videoId)
        {
            var video = _videos
                .Where(v => v.Id.Equals(videoId))
                .Join(_userCourses, v => v.CourseId, uc => uc.CourseId,
                (v, uc) => new { Video = v, UserCourse = uc })
                .FirstOrDefault().Video;

            return video;
        }

        public IEnumerable<Video> GetVideos(string userId, int moduleId = 0)
        {
            var videos = _videos
                .Join(_userCourses, v => v.CourseId, uc => uc.CourseId,
                (v, uc) => new { Video = v, UserCourse = uc })
                .Where(vuc => vuc.UserCourse.UserId.Equals(userId));

            return moduleId.Equals(0) ?
                videos.Select(s => s.Video) :
                videos
                    .Where(v => v.Video.ModuleId.Equals(moduleId))
                    .Select(s => s.Video);
        } 

    }
}
