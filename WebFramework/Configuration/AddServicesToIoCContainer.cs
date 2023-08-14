using Data;
using Data.Contracts;
using Data.Contracts.PostSchema;
using Data.Contracts.Report;
using Data.Contracts.UserSchema;
using Microsoft.Extensions.DependencyInjection;
using Services.DataServices;
using Services.DataServices.PostSchema;
using Services.DataServices.Report;
using Services.DataServices.UserSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFramework.Configuration;
public static partial class ServiceCollectionExtensions
{
    public static void AddServicesToIoCContainer(this IServiceCollection services)
    {
        services.AddScoped(typeof(DapperUtility));
        services.AddScoped<IDapperService, DapperService>();

        #region UserSchema

        services.AddScoped<IUserService, UserService>();

        #endregion

        #region Report

        services.AddScoped<IReportService, ReportService>();

        #endregion

        #region PostSchema

        services.AddScoped<IPostService, PostService>();

        #endregion
    }
}
