﻿using System;
using System.Collections.Generic;

namespace testTask.Entities;

public class Film : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Director { get; set; }
    public DateTime Release { get; set; }

    public ICollection<Category> Categories { get; set; }
}