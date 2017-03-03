using System.Linq;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Folder entities.
        /// </summary>
        private FolderTreeEntities _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/>
        /// </summary>
        public HomeController()
        {
            _context = new FolderTreeEntities();
        }

        /// <summary>
        /// Get folder and it's childs.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public ActionResult ShowFolders(string fullPath)
        {
            return View(FolderViewModel.Create(_context, fullPath));
        }
    }
}