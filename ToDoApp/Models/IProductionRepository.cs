﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    interface IProductionRepository
    {
        void Add(ToDoItem item);
        IEnumerable<ToDoItem> GetAll();
        ToDoItem Find(string key);
        ToDoItem Remove(string key);
        void Update(ToDoItem item);
    }
}
