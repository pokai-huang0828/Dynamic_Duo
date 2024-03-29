﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    public class Magazine : IReading
    {
        public int IssueNumber { get; set; }
        public string Subject { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string Language { get; set; }
        public int ResourceID { get; set; }
        public string Title { get; set; }
        public int CopyInStock { get; set; }
        public int TotalNumberOfCopies { get; set; }

        public Magazine(string title, int totalNumberOfCopies)
        {
            InitializeResource(title, totalNumberOfCopies);
        }

        public void InitializeResource(string title, int totalNumberOfCopies)
        {
            Title = title;
            TotalNumberOfCopies = CopyInStock = totalNumberOfCopies;
        }
    }
}
