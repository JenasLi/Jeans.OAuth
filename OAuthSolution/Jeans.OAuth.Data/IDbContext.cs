﻿using Jeans.OAuth.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        Task<int> SaveChangesAsync();
    }
}
