using DAL.Model;
using EFLibCore;

namespace WineryData.Controllers
{
    public class DBDetailOperations
    {
        private WineContext _context = new WineContext();
        LoggerCls logger = new LoggerCls();

        /// <summary>
        /// A function adds new detail to list 
        /// </summary>
        /// <param name="det"></param>
        /// <returns></returns>
        public bool AddModel(Detail det)
        {
            try
            {
                _context.Detail.Add(det);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                logger.createLog("HATA " + exc.Message);
                return false;
            }
        }

        /// <summary>
        ///  A function gets detail list 
        /// </summary>
        /// <returns></returns>
        public List<Detail> GetDetails()
        {
            List<Detail> details = new List<Detail>();
            details = _context.Detail.ToList();
            return details;
        }

        /// <summary>
        ///  A function deletes a detail from detail list by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteModel(int Id)
        {
            try
            {
                _context.Detail.Remove(FindDetail("", Id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                logger.createLog("HATA " + exc.Message);
                return false;
            }
        }
        /// <summary>
        ///  A function updates a detail from detail list by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        public bool Update(int Id, Detail detail)
        {
            var existDetail = _context.Detail.FirstOrDefault(w => w.Id == Id);
            if (existDetail == null)
            {
                return false;
            }
            else
            {
                existDetail.Id = detail.Id;
                existDetail.Winery = detail.Winery;
                existDetail.Price = detail.Price;
                existDetail.Stock = detail.Stock;
                _context.SaveChanges();
                return true;
            }
        }
        /// <summary>
        ///  A function finds a detail from detail list by winery or id
        /// </summary>
        /// <param name="Winery"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Detail FindDetail(string Winery = "", int Id = 0)
        {
            Detail? detail = new Detail();
            if (!string.IsNullOrEmpty(Winery))
                detail = _context.Detail.FirstOrDefault(m => m.Winery == Winery);
            else if (Id > 0)
            {
                detail = _context.Detail.FirstOrDefault(m => m.Id == Id);
            }
            return detail;
        }

    }
}

