using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndFolders
{
    public class Folder : IFolder, IEnumerable
    {
        public string FolderName { get; set; }
        public List<IFolder> SubFolders { get; set; }
        public List<IFile> Files { get; set; }

        public void AddItem(IFolder folder)
        {
            SubFolders.Add(folder);
        }

        public void AddItem(IFile file)
        {
            Files.Add(file);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)SubFolders).GetEnumerator();
        }

        public Folder(string folderName)
        {
            this.FolderName = folderName;
            SubFolders = new List<IFolder>();
            Files = new List<IFile>();
        }
    }

    public class File : IFile
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }

        public File(string fileName, int fileSize)
        {
            this.FileName = fileName;
            this.FileSize = fileSize;
        }
    }
}
