using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndFolders
{
    public interface IFolder
    {
        string FolderName { get; set; }

        List<IFolder> SubFolders { get; set; }

        List<IFile> Files { get; set; }

        void AddItem(IFolder folder);

        void AddItem(IFile file);
    }

    public interface IFile
    {
        string FileName { get; set; }
        int FileSize { get; set; }
    }
}
