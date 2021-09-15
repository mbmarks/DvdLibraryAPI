using DvdLibraryWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryWebApi.Models
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd
            {
                Id = 1,
                Title = "Back to the Future",
                Director = "Robert Zemicks",
                ReleaseYear = "1985",
                Rating = "PG",
                Notes = "Where we're going we don't need roads."
            },
            new Dvd
            {
                Id = 2,
                Title = "Fargo",
                Director = "Joel & Ethan Coen",
                ReleaseYear = "1996",
                Rating = "R",
                Notes = "Oh, you bet-cha!"
            },
            new Dvd
            {
                Id = 3,
                Title = "Hamlet",
                Director = "Bill Colleran",
                ReleaseYear = "1964",
                Rating = null,
                Notes = "There are more things in heaven and earth."
            }
        };

        public Dvd Create(Dvd dvd)
        {
            dvd.Id = _dvds.Max(d => d.Id) + 1;
            _dvds.Add(dvd);
            return dvd;
        }

        public void Delete(int id)
        {
            _dvds.RemoveAll(d => d.Id == id);
        }

        public List<Dvd> GetAll()
        {
            return _dvds;
        }

        public List<Dvd> GetByDirector(string name)
        {
            return _dvds.Where(d => d.Director.ToLower().Contains(name.ToLower())).ToList();
        }

        public Dvd GetById(int id)
        {
            return _dvds.FirstOrDefault(d => d.Id == id);
        }

        public List<Dvd> GetByRating(string rating)
        {
            return _dvds.Where(d => 
            {
                if (d.Rating == null)
                    return false;
                return d.Rating.Equals(rating);    
            }).ToList();
        }

        public List<Dvd> GetByReleaseYear(string year)
        {
            return _dvds.Where(d => d.ReleaseYear.Equals(year)).ToList();
        }

        public List<Dvd> GetByTitle(string title)
        {
            return _dvds.Where(d => d.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public void Update(Dvd dvd)
        {
            _dvds.RemoveAll(m => m.Id == dvd.Id);
            _dvds.Add(dvd);
        }
    }
}