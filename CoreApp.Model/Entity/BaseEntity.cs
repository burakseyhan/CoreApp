
using System;

namespace CoreApp.Model.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get;  set; }

        public DateTime InsertTime { get; set; }

        public DateTime? DeleteTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
