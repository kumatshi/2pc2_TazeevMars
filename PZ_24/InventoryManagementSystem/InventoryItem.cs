using System;

namespace InventoryManagementSystem
{
    public class InventoryItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Status { get; set; }
        public Guid UserId { get; set; }
    }
}
