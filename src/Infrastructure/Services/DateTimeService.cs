using CleanArchitecture.Solution.Application.Common.Interfaces;
using System;

namespace CleanArchitecture.Solution.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
