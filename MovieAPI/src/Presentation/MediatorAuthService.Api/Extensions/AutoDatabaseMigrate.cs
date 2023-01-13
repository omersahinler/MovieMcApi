﻿using MovieAPI.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Api.Extensions;

public static class AutoDatabaseMigrate
{
    public static WebApplication ApplyMigration(this WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var db = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

            db.Database.MigrateAsync().GetAwaiter().GetResult();
        }

        return app;
    }
}