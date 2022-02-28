using Dapper;
using DapperCoreExample.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCoreExample.Repository
{
    public class CompanyRepositoryDapper : ICompanyRepository
    {
        private IDbConnection db;
        public CompanyRepositoryDapper(IConfiguration configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Company Add(Company company)
        {
            var sql = "INSERT INTO Companies(Name,Adress,State,City) VALUES (@Name,@Adress,@State,@City);" + " SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql, company).Single();
            company.Id = id;
            return company;
        }

        public Company Find(int id)
        {
            var sql = "SELECT * FROM Companies WHERE Id=@Companyid";
            return db.Query<Company>(sql, new { @Companyid = id }).Single();
        }

        public List<Company> GetAll()
        {
            var sql = "SELECT * FROM Companies";
            return db.Query<Company>(sql).ToList();
        }

        public void Remove(int id)
        {
            var sql = "DELETE FROM Companies WHERE Id=@id";
            db.Execute(sql, new { id });
        }

        public Company Update(Company company)
        {
            var sql = "UPDATE Companies SET Name=@Name,Adress=@Adress,City=@City,State=@State WHERE ID=@id";
            db.Execute(sql, company);
            return company;
        }
    }
}
