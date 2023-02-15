using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Globalization;
using System.Linq;

namespace WebApi.Configurations
{
    public class OpenApiDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;
            operation.Deprecated = apiDescription.IsDeprecated();

            if (operation.Parameters == null) return;

            foreach (var parameter in operation.Parameters)
            {
                var description = context.ApiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
                var routeInfo = description.RouteInfo;

                if (string.IsNullOrWhiteSpace(parameter.Name))
                {
                    parameter.Name = description.Name;
                }

                parameter.Description ??= description.ModelMetadata?.Description;

                if (routeInfo == null)
                {
                    continue;
                }

                parameter.Required |= !routeInfo.IsOptional;
            }


            #region Overwrite description for common response codes
            var statusBadRequest = StatusCodes.Status400BadRequest.ToString(CultureInfo.InvariantCulture);
            if (operation.Responses.ContainsKey(statusBadRequest))
            {
                operation.Responses[statusBadRequest].Description =
                    "Invalid query parameter(s). Read the response description";
            }

            var statusUnauthorized = StatusCodes.Status401Unauthorized.ToString(CultureInfo.InvariantCulture);
            if (operation.Responses.ContainsKey(statusUnauthorized))
            {
                operation.Responses[statusUnauthorized].Description =
                    "Authorization has been denied for this request";
            }
            #endregion
        }
    }
}
