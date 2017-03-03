using System.Collections.Generic;
using System.Linq;

namespace TestTask.Models
{
    /// <summary>
    /// The FolderViewModel.
    /// </summary>
    public class FolderViewModel
    {
        /// <summary>
        /// Gets or sets current folder.
        /// </summary>
        public string CurrentFolder { get; set; }

        /// <summary>
        /// Gets or sets child folders for current folder.
        /// </summary>
        public List<Folder> ChildFolders { get; set; }

        /// <summary>
        /// Factory methid for FolderViewModel.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static FolderViewModel Create(FolderTreeEntities context, string fullPath)
        {
            string enterFolderName = null;

            if (fullPath != null)
            {
                enterFolderName = fullPath.Split('/').LastOrDefault();
            }

            var folder = context.Folder
                .FirstOrDefault(f => f.folder_name == enterFolderName);

            var model = new FolderViewModel();

            if (folder != null)
            {
                model.CurrentFolder = folder.folder_name;
                model.ChildFolders = context.Folder.Where(f => f.parent_id == folder.id).ToList();
            }
            else
            {
                model.CurrentFolder = "";
                model.ChildFolders = context.Folder
                    .Where(f => f.parent_id == 0)
                    .ToList();
            }

            return model;
        }
    }
}