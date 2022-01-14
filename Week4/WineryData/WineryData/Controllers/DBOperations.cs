using DAL.Model;
using EFLibCore;
using System.Linq;



namespace WineryData.Controllers
{
    public class DBOperations
    {
        private WineContext _context = new WineContext();
        LoggerCls logger = new LoggerCls();

        /// <summary>
        /// A function adds new wine to list 
        /// </summary>
        /// <param name="_wine"></param>
        /// <returns></returns>
        public bool AddModel(Wine _wine)
        {
            try
            {
                _context.Wine.Add(_wine);
                _context.SaveChanges();
                return true;
            }
            catch(Exception exc)
            {
                logger.createLog("HATA " + exc.Message);
                return false;
            }
        }

        /// <summary>
        ///  A function gets winelist 
        /// </summary>
        /// <returns></returns>
        public List<Wine> GetWines()
        {
            List<Wine> wines = new List<Wine>();
            wines = _context.Wine.ToList();
            return wines;
        }

        /// <summary>
        ///  A function deletes a wine from winelist by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteModel(int Id)
        {
            try
            {
                _context.Wine.Remove(FindWine("", "", Id));
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
        ///  A function updates a wine from list by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="wine"></param>
        /// <returns></returns>
        public bool Update(int Id, Wine wine)
        {
            var existwine = _context.Wine.FirstOrDefault(w => w.Id == Id);
            if (existwine == null)
            {
                return false;
            }
            else {
                existwine.Name = wine.Name;
                existwine.Date = wine.Date;
                existwine.Place = wine.Place;
                existwine.Categorie = wine.Categorie;
                existwine.DetailId = wine.DetailId;
                _context.SaveChanges();
                return true;
            }
        }
        /// <summary>
        ///  A function finds a wine from winelist by name , place or Id 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Place"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Wine FindWine(string Name = "", string Place = "", int Id = 0)
        {
            Wine? wine = new Wine();
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Place))
                wine = _context.Wine.FirstOrDefault(m => m.Name == Name && m.Place == Place);
            else if (Id > 0)
            {
                wine = _context.Wine.FirstOrDefault(m => m.Id == Id);
            }
            return wine;
        }

        public void InnerJoinExample()
        {
          var wine = _context.Wine.Join(_context.Detail, a => a.DetailId,
                  u => u.Id,
                 (wine, detail) => new WineDet { Winery = detail.Winery, Name = wine.Name }).FirstOrDefault();
        }

    } 
}

