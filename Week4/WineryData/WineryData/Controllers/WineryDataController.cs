using Microsoft.AspNetCore.Mvc;
using DAL.Model;

namespace WineryData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WineryDataController : ControllerBase
    {
        Result _result = new Result();
        DBOperations dbOperation = new DBOperations();


        /// <summary>
        /// Get Wine List 
        /// </summary>
        /// <returns></returns>
        [HttpGet] // Works
        public List<Wine> GetWine()
        {
            return dbOperation.GetWines();
        }

        /// <summary>
        /// Get only one Wine by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] //Works
        public Wine GetWineById(int id)
        {
            Wine resultObject = dbOperation.FindWine("", "", id);
            return resultObject;
        }

        /// <summary>
        /// Add new Wine to WineList
        /// </summary>
        /// <param name="wine"></param>
        /// <returns></returns>
        [HttpPost]  //Works
        public Result Post(Wine wine)
        {
            Wine? Rwine = dbOperation.FindWine(wine.Name, wine.Place, wine.Id);
            bool wineCheck = (Rwine != null) ? true : false;

            if (wineCheck == false)
            {
               if(dbOperation.AddModel(wine)== true)
                {
                    _result.status = 1;
                    _result.Message = "New wine added to list.";
                }
                else
                {
                    _result.status = 0;
                    _result.Message = "Error, Wine can not add to list.";
                }
            }
            else
            {
                _result.status = 0;
                _result.Message = "This wine is already on the list! ";
            }
            return _result;
        }

        /// <summary>
        /// Update wine from WineList by Id
        /// </summary>
        /// <param name="WineId"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        [HttpPut("{WineId}")]  //Works
        public Result Update(int WineId, Wine newValue)
        {

            bool wine = dbOperation.Update( Id:WineId, wine:newValue);
            if(wine == true)
            {
                _result.status = 1;
                _result.Message = "Changes have been made successfully!";
            }
            else
            {
                _result.status = 0;
                _result.Message = "Wine Not found!";
            }

            return _result;
        }

        /// <summary>
        /// Delete wine from Winelist by Id
        /// </summary>
        /// <param name="WineId"></param>
        /// <returns></returns>
        [HttpDelete("{WineId}")]  //Works
        public Result Delete(int WineId)
        {
            
            if(dbOperation.DeleteModel(WineId))
            {
                _result.status = 1;
                _result.Message = "Wine Deleted successfully!";
            }
            else
            {
                _result.status = 0;
                _result.Message = "Wine Not found!";
            }
            return _result;
        }

    }
}