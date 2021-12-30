using Microsoft.AspNetCore.Mvc;
using WineryData.Model;

namespace WineryData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WineryDataController : ControllerBase
    {
        List<Wine> WineList = new List<Wine>();
        Result _result = new Result();

        [HttpGet]
        public List<Wine> GetUser()
        {
            WineList = AddWine().OrderBy(x => x.Date).ToList(); 
            return WineList;
        }

        [HttpGet("{id}")]
        public Wine GetWineById(int id)
        {
            List<Wine> WineList = new List<Wine>();
            WineList = AddWine();

            Wine resultObject = new Wine();
            resultObject = WineList.FirstOrDefault(x => x.Id == id);
            return resultObject;
        }


        [HttpPost]
        public Result Post(Wine wine)
        {
            WineList = AddWine();
            bool wineCheck = WineList.Select(x => x.Id == wine.Id || x.Name == wine.Name).FirstOrDefault();

            if (wineCheck == false)
            {
                WineList.Add(wine);
                _result.status = 1;
                _result.Message = "New Wine Added!";
                _result.Winelist = WineList;
            }
            else
            {
                _result.status = 0;
                _result.Message = "This wine is already on the list! ";
            }
            return _result;
        }

        [HttpPut("{WineId}")]
        public Result Update(int WineId, Wine newValue)
        {
            WineList = AddWine();

            Wine _oldValue = WineList.Find(o => o.Id == WineId);
            if (_oldValue != null)
            {
                WineList.Add(newValue);
                WineList.Remove(_oldValue);

                _result.status = 1;
                _result.Message = "Changes have been made successfully!";
                _result.Winelist  = WineList;
            }
            else
            {
                _result.status = 0;
                _result.Message = "Wine Not found!";
            }

            return _result;
        }

        [HttpDelete("{WineId}")]
        public Result Delete(int WineId)
        {
            WineList = AddWine();
            
            Wine? _oldValue = WineList.Find(o => o.Id == WineId);
            if (_oldValue != null)
            {
                WineList.Remove(_oldValue);
                _result.status = 1;
                _result.Message = "Wine Deleted successfully!";
                _result.Winelist = WineList;
            }
            else
            {
                _result.status = 0;
                _result.Message = "Wine Not found!";
            }
            return _result;
        }


        public List<Wine> AddWine()
        {
            List<Wine> lst = new List<Wine>();
            lst.Add(new Model.Wine { Id = 1, Name = "Cabarnet Sauvignon", Date = 2012, Place = "United States - Rutferhord", Categorie= "Red"});
            lst.Add(new Model.Wine { Id = 2, Name = "Pera-Manco Tinto", Date = 1990, Place = "Portugal - Alentino", Categorie = "Red" });
            lst.Add(new Model.Wine { Id = 3, Name = "Collection Brut Champagne", Date = 1998, Place = "France - Champagne", Categorie = "Sparkling" });
            lst.Add(new Model.Wine { Id = 4, Name = "Meursault Les Rougeots", Date = 2001, Place = "France - Meursoult", Categorie = "White" });
            lst.Add(new Model.Wine { Id = 5, Name = "Think Pink Rosedo", Date = 2017, Place = "Spain - Ribera de Duero", Categorie = "Rose" });
            lst.Add(new Model.Wine { Id = 6, Name = "Eszencia", Date = 2005, Place = "Hungary - Tokaj", Categorie = "Dessert" });
            return lst;
        }

    }
}