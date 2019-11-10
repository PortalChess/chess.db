﻿using System.Linq;

namespace AspNetCore.MVC.RESTful.Parameters
{
    public interface IResourceQuery<T>
    {
        bool Empty { get; }
        IQueryable<T> Apply(IQueryable<T> set);
    }
}