using CqrsSample.Data.Repository;
using CqrsSample.Infrastructure.Utils;
using CqrsSample.ViewModel;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsSample.Logic.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetailListDto>>
    {
        public GetStudentListQuery()
        { 
        }

        internal class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, List<StudentDetailListDto>>
        {
            private readonly QueriesConnectionString _connectionString;

            public GetStudentListQueryHandler(QueriesConnectionString connectionString)
            {
                _connectionString = connectionString;
            }

            public async Task<List<StudentDetailListDto>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
            {
                string sql = @"SELECT  [Students].[Id] ,[Students].[FirstName],[Students].[LastName] , COUNT(1) AS EnrolledCourseCount 
                                FROM [StudentDb].[dbo].[Students] INNER JOIN [dbo].[Enrollments] ON [Enrollments].StudentId = Students.Id 
                                GROUP BY [Students].[Id] ,[Students].[FirstName],[Students].[LastName] ";

                using (SqlConnection connection = new SqlConnection(_connectionString.Value))
                {
                    var students = await connection.QueryAsync<StudentDetailListDto>(sql);

                    return students.ToList();
                }
            }
        }
    }
}
