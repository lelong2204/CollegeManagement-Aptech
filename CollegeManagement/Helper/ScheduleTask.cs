using CollegeManagement.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CollegeManagement.Helper
{
    internal class ScheduleTask : IHostedService, IDisposable
    {
        private readonly DataContext _context;
        private Timer _timer;

        public ScheduleTask(DataContext context)
        {
            _context = context;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            try
            {
                var courses = _context.Courses.Where(c => c.Deleted != 1 && c.Status != 1 && c.EndDate < DateTime.Now);

                if (courses.Any())
                {
                    foreach (var c in courses)
                    {
                        if (_context.Students.Count(s => s.Deleted != 1 && s.CourseID == c.ID) <= c.StudentNumber)
                        {
                            _context.Students.Where(s => s.Deleted != 1 && s.CourseID == c.ID).ToList()
                                .ForEach(s => s.Status = (int)Student.StudentStatus.Admission);
                        }
                        else
                        {
                            _context.Students.OrderByDescending(s => s.TestScore)
                                .Where(s => s.Deleted != 1 && s.CourseID == c.ID).Take((int)c.StudentNumber).ToList()
                                .ForEach(s => s.Status = (int)Student.StudentStatus.Admission);
                            _context.Students.OrderByDescending(s => s.TestScore)
                                .Where(s => s.Deleted != 1 && s.CourseID == c.ID).Take((int)c.StudentNumber).ToList()
                                .ForEach(s => s.Status = (int)Student.StudentStatus.Fail);
                        }
                        c.Status = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
