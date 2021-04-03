using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Models.Data
{
    public class ResourceData
    {
        private static List<IResource> _list;
        private static int _lastID;

        private ResourceData() { }

        public static List<IResource> ResourceList
        {
            get
            {
                if (_list == null)
                {
                    _list = GetResources();
                    _lastID = _list.Count;
                }
                return _list;
            }
        }

        public static int LastID => _lastID;

        public static void IncrementLastID()
        {
            ++_lastID;
        }

        private static List<IResource> GetResources()
        {
            return new List<IResource>
            {
                new Book ("Harry Potter 1", 6){ ResourceID = 1, Author="JK Rowling", YearOfPublish = 1997, Genre = "Fantasy", NumberOfPages = 223, Publisher = "Bloomsbury", Language = "English", PublishDate = new DateTime(2005, 6, 16)},
                new Book ("Harry Potter 6", 0){ ResourceID = 2, Author="JK Rowling", YearOfPublish = 2005, Genre = "Fantasy", NumberOfPages = 607, Publisher = "Bloomsbury", Language = "English", PublishDate = new DateTime(1997, 6, 26), TotalNumberOfCopies = 6},
                new Book ("Lord of the Rings", 6){ ResourceID = 3, Author="J. R. R. Tolkien", YearOfPublish = 1954, Genre = "Fantasy", NumberOfPages = 1178, Publisher = "Allen & Unwin", Language = "English", PublishDate = new DateTime(1954, 7, 29) },
                new Magazine("Glamour", 4){ ResourceID = 4, IssueNumber = 306, Publisher = "Condé Nast", Language = "English", Subject = "Fashion", NumberOfPages = 113, PublishDate = new DateTime(2021, 1, 31)},
                new Magazine("QC", 4){ ResourceID = 5, IssueNumber = 29, Publisher = "Condé Nast", Language = "English", Subject = "Fashion", NumberOfPages = 89, PublishDate = new DateTime(2021, 3, 8) },
                new CD("folklore", 3){ ResourceID = 6, Producer = "Aaron Dessner, Jack Antonoff, Taylor Swift", Language = "English", Genre = "Indie folk", Artist = "Taylor Swift", DurationInMins = 63.33f, TrackNumber = 16},
                new CD("Hot Pink", 2){ ResourceID = 7, Producer = "Tyson Trax, Yeti Beats, Doja Cat, Tizhimself, Kurtis McKenzie, Ben Billions, Salaam Remi, Mike Crook, Fallen, Ari Pen Smith, P2J, Blaq Tuxedo, Troy NöKA, Johng Beats", Language = "English", Genre = "R&B", Artist = "Doja Cat", DurationInMins = 39.48f, TrackNumber = 12 },
                new DVD("Mad Max: Fury Road", 2){ ResourceID = 8, Producer = "George Miller, Brendan McCarthy, Nico Lathouris", DurationInMins = 120f, Language = "English", Genre = "Action", TrackNumber = 2015 },
                new DVD("X-MEN", 3){ ResourceID = 9, Producer = "Lauren Shuler Donner, Ralph Winter", DurationInMins = 104f, Language = "English", Genre = "Action", TrackNumber = 2000 },
                new Bluray("Tron Legacy", 2){ ResourceID = 10, Producer = "Sean Bailey, Jeffrey Silver, Steven Lisberger", DurationInMins = 125f, Language = "English", Genre = "Action", TrackNumber = 2010 },
                new Bluray("Pacific Rim: Uprising",3){ ResourceID = 11, Producer = "Mary Parent, Cale Boyter, Guillermo del Toro, John Boyega, Femi Oguns, Thomas Tull, Jon Jashni", DurationInMins = 111f, Language = "English", Genre = "Adventure", TrackNumber = 2018 },
                new Videogame("Gear of War", 3){ ResourceID = 12, Producer = "XBox Game Studios", YearOfPublish = 2006, Genre = "Third-person shooter", DurationInMins = 720f, TrackNumber = 001},
                new Videogame("Call of Duty", 4){ ResourceID = 13, Producer = "Activision", YearOfPublish = 2003, Genre = "First-person shooter", DurationInMins = 780f, TrackNumber = 002 }
            };
        }



    }
}
