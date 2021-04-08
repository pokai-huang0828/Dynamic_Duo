using System;

namespace OnlineLibrarySystemLib
{
    public class DisplayCheckOutItem
    {
        public DisplayCheckOutItem(
            int checkOutId,
            int resourceId,
            string title,
            DateTime checkOutDateTime,
            DateTime dueDateTime,
            bool isReturn)
        {
            CheckOutId = checkOutId;
            ResourceId = resourceId;
            Title = title;
            CheckOutDate = checkOutDateTime;
            DueDate = dueDateTime;
            IsReturn = isReturn;
        }

        public int CheckOutId { get; }
        public int ResourceId { get; }
        public string Title { get; }
        public Boolean IsReturn { get; }
        public DateTime CheckOutDate { get; }
        public DateTime DueDate { get; }
    }
}
