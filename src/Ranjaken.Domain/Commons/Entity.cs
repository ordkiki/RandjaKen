﻿namespace Ranjaken.Domain.Commons
{
    public class Entity
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}