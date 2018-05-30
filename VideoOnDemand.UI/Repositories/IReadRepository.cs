using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoOnDemand.Data.Data.Entities;

namespace VideoOnDemand.UI.Repositories
{
    public interface IReadRepository
    {
        Video GetVideo(string userId, int videoId);
        IEnumerable<Video> GetVideos(string userId, int moduleId = default(int));
        Course GetCourse(string userId, int courseId);
        IEnumerable<Course> GetCourses(string userId);
    }
}
