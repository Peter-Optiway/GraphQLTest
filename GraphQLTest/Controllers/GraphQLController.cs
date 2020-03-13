using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EntityGraphQL;
using EntityGraphQL.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GraphQLTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GraphQLController : ControllerBase
    {
        private readonly DBContext dbContext;
        private readonly MappedSchemaProvider<DBContext> schemaProvider;

        public GraphQLController(DBContext dbContext, MappedSchemaProvider<DBContext> schemaProvider)
        {
            this.dbContext = dbContext;
            this.schemaProvider = schemaProvider;
        }

        [HttpPost]
        public object Post([FromBody]QueryRequest query)
        {
            try
            {
                var results = dbContext.QueryObject(query, schemaProvider);
                return results;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
