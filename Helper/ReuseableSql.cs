using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DotnetAPI.Data;
using DotnetAPI.Models;

namespace DotnetAPI.Helper
{
    public class ReuseableSql
    {
        private readonly DataContextDapper _dapper;
        public ReuseableSql(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public bool UpsertUser(UserComplete user)
        {
            // string sql = @"EXEC [TutorialAppSchema].[spUser_Upsert]
            //     @FirstName = '" + user.FirstName +
            //     "', @LastName = '" + user.LastName +
            //     "', @Email = '" + user.Email +
            //     "', @Gender = '" + user.Gender +
            //     "', @Active = '" + user.Active +
            //     "', @JobTitle = '" + user.JobTitle +
            //     "', @Department = '" + user.Department +
            //     "', @salary = '" + user.Salary +
            //     "', @UserId = " + user.UserId;
            string sql = @"EXEC [TutorialAppSchema].[spUser_Upsert]
                @FirstName = @FirstNameParameter, 
                @LastName = @LastNameParameter, 
                @Email = @EmailParameter, 
                @Gender = @GenderParameter, 
                @Active = @ActiveParameter, 
                @JobTitle = @JobTitleParameter, 
                @Department = @DepartmentParameter, 
                @salary = @SalaryParameter, 
                @UserId = @UserIdParameter";

            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@FirstNameParameter", user.FirstName, DbType.String);
            sqlParameters.Add("@LastNameParameter", user.LastName, DbType.String);
            sqlParameters.Add("@EmailParameter", user.Email, DbType.String);
            sqlParameters.Add("@GenderParameter", user.Gender, DbType.String);
            sqlParameters.Add("@ActiveParameter", user.Active, DbType.Boolean);
            sqlParameters.Add("@JobTitleParameter", user.JobTitle, DbType.String);
            sqlParameters.Add("@DepartmentParameter", user.Department, DbType.String);
            sqlParameters.Add("@SalaryParameter", user.Salary, DbType.Decimal);
            sqlParameters.Add("@UserIdParameter", user.UserId, DbType.Int32);


            return _dapper.ExecuteSqlWithParameters(sql, sqlParameters);
        }
    }
}