﻿using System;
using System.Collections.Generic;
using System.Text;

using Kata.DataServices;

namespace Kata.CustomTypes.RecipeDemo
{
    public class Salad : DishBase
    {
        public Salad() : base("Salad", new Pantry(new JsonDataService()))
        {
        }

        public string SaladName { get; }
    }
}