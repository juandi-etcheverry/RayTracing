﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace IRepository
{
    public interface IRepositoryModel : IRepository<Model>
    {
        List<Model> FindMany(string name);
    }
}