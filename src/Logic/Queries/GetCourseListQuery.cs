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
    public class GetCourseListQuery : IRequest<List<CourseDetailListDto>>
    {
        public GetCourseListQuery()
        { 
        }

        internal class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, List<CourseDetailListDto>>
        {
            private readonly QueriesConnectionString _connectionString;

            public GetCourseListQueryHandler(QueriesConnectionString connectionString)
            {
                _connectionString = connectionString;
            }

            public async Task<List<CourseDetailListDto>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
            {
                string sql = @"SELECT [Id] , [CourseName] FROM [dbo].[Courses]";

                using (SqlConnection connection = new SqlConnection(_connectionString.Value))
                {
                    var courses = await connection.QueryAsync<CourseDetailListDto>(sql);

                    return courses.ToList();
                }
            }
        }
    }
}
