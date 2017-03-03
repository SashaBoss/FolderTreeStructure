using System.Linq;
using System.Web.Mvc;

namespace TestTask.Helpers
{
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Creates Friendly Url for folder.
        /// </summary>
        /// <param name="urlHelper"></param>
        /// <param name="folder"></param>
        /// <returns>Folder's Friendly Url</returns>
        public static string CreateFolderUrl(this UrlHelper urlHelper, Folder folder)
        {
            var ctx = new FolderTreeEntities();
            string path = folder.folder_name;

            if (folder.parent_id == 0)
            {
                return urlHelper.Action("ShowFolders", "Home", new
                {
                    fullPath = path
                });
            }

            do
            {
                folder = ctx.Folder.FirstOrDefault(f => f.id == folder.parent_id);
                path = $"{folder?.folder_name}{"/"}{path}";
            }
            while (folder.parent_id != 0);

            return urlHelper.Action("ShowFolders", "Home", new
            {
                fullPath = path
            });
        }
    }
}