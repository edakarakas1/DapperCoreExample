using DapperCoreExample.Models;
using DapperCoreExample.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCoreExample.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private DataContext db;
        public CompanyRepositoryEF(DataContext _db)
        {
            db = _db;
        }
        public Company Add(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();
            return company;
        }

        public Company Find(int id)
        {
            return db.Companies.FirstOrDefault(x => x.Id == id);

        }

        public List<Company> GetAll()
        {
            return db.Companies.ToList();
        }

        public void Remove(int id)
        { Company c = Find(id);
            db.Companies.Remove(c);
            db.SaveChanges();
        }

        public Company Update(Company company)
        {
            db.Companies.Update(company);
            db.SaveChanges();
            return company;
        }
    }
}
