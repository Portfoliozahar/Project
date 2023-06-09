﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public abstract class Transaction
    {
        public string Description { get; protected set; }
        public double Value { get; protected set; }
        public DateTime Date { get; protected set; }
        public ItemCategory Category { get; protected set; }
        public string Comment { get; protected set; }



        public void UpdateDate(DateTime date)
        {
            Date = date;
        }

        public void UpdateCategory(ItemCategory category)
        {
            Category = category;
        }
        public abstract void Move(Double value);
    }
}
