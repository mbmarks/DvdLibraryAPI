using DvdLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryWebApi.Interfaces
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        Dvd GetById(int id);
        List<Dvd> GetByTitle(string title);
        List<Dvd> GetByReleaseYear(string year);
        List<Dvd> GetByDirector(string name);
        List<Dvd> GetByRating(string rating);
        Dvd Create(Dvd dvd);
        void Update(Dvd dvd);
        void Delete(int id);
    }
}
