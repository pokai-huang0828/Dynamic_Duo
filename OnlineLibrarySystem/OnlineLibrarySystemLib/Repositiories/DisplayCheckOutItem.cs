using System;

namespace OnlineLibrarySystemLib
{
    public class DisplayCheckOutItem
    {
        public DisplayCheckOutItem(
            int resourceId,
            string title,
            DateTime checkOutDateTime,
            DateTime dueDateTime)
        {
            ResourceId = resourceId;
            Title = title;
            CheckOutDate = checkOutDateTime;
            DueDate = dueDateTime;
        }

        public int ResourceId { get; }
        public string Title { get; }
        public DateTime CheckOutDate { get; }
        public DateTime DueDate { get; }
    }
}
