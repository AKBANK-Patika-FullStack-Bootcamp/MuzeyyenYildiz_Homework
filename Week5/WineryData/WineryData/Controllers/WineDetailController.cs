using Microsoft.AspNetCore.Mvc;
using DAL.Model;
using WineryData.Controllers;

namespace WineDetail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WineDetailController : ControllerBase
    {
        Result _result = new Result();
        DBDetailOperations dbDetailOperation = new DBDetailOperations();


        /// <summary>
        /// Get Detail List 
        /// </summary>
        /// <returns></returns>
        [HttpGet] // Works
        public List<Detail> GetDetails()
        {
            return dbDetailOperation.GetDetails();
        }

        /// <summary>
        /// Get only one Detail by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] //Works
        public Detail GetWineById(int id)
        {
            Detail resultObject = dbDetailOperation.FindDetail(Winery:"", Id: id);
            return resultObject;
        }

        /// <summary>
        /// Add new detail to detail list
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        [HttpPost]  //Works
        public Result Post(Detail detail)
        {
            Detail? Rdetail = dbDetailOperation.FindDetail(detail.Winery, detail.Id);
            bool detailCheck = (Rdetail != null) ? true : false;

            if (detailCheck == false)
            {
                if (dbDetailOperation.AddModel(detail) == true)
                {
                    _result.status = 1;
                    _result.Message = "New detail added to list.";
                }
                else
                {
                    _result.status = 0;
                    _result.Message = "Error, detail can not add to list.";
                }
            }
            else
            {
                _result.status = 0;
                _result.Message = "This detail is already on the list! ";
            }
            return _result;
        }

        /// <summary>
        /// Update detail from detail list by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]  //Works
        public Result Update(int Id, Detail newValue)
        {

            bool detail = dbDetailOperation.Update(Id: Id, detail: newValue);
            if (detail == true)
            {
                _result.status = 1;
                _result.Message = "Changes have been made successfully!";
            }
            else
            {
                _result.status = 0;
                _result.Message = "Detail Not found!";
            }

            return _result;
        }

        /// <summary>
        /// Delete detail from Detail list by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]  //Works
        public Result Delete(int Id)
        {

            if (dbDetailOperation.DeleteModel(Id))
            {
                _result.status = 1;
                _result.Message = "Detail Deleted successfully!";
            }
            else
            {
                _result.status = 0;
                _result.Message = "Detail Not found!";
            }
            return _result;
        }

    }
}
