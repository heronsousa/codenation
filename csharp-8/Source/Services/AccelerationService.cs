using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            return _context.Candidates
                .Where(c => c.CompanyId == companyId)
                .Select(c => c.Acceleration)
                .Distinct()
                .ToList();
        }

        public Acceleration FindById(int id)
        {
            return _context.Accelerations
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public Acceleration Save(Acceleration acceleration)
        {
            if (acceleration.Id == 0)
                _context.Accelerations.Add(acceleration);
            else
                _context.Accelerations.Update(acceleration);
                _context.SaveChanges();

            return acceleration;
        }
    }
}
