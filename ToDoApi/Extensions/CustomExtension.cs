using Data.IRepositories;
using Data.Repositories;
using Services.IServices;
using Services.Services;

namespace ToDoApi.Extensions
{
    public static class CustomExtension
    {
        public static void AddCUstomExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(GenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITaskRepositoryAsync, TaskRepositoryAsync>();
            services.AddScoped<ITaskBaseService, TaskBaseService>();

            services.AddScoped<IAddDueDateRepositoryAsync, AddDueDateRepositoryAsync>();
            services.AddScoped<IAddDueDateService, AddDueDateService>();

            services.AddScoped<IAddFileRepositoryAsync, AddFileRepositoryAsync>();
            services.AddScoped<IAddFileService, AddFileService>();

            services.AddScoped<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IRepeatTimeRepositoryAsync, RepeatTimeRepositoryAsync>();
            services.AddScoped<IRepeatTimeService, RepeatTimeService>();
        }
    }
}
