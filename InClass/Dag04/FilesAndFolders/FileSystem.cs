using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndFolders
{
    public class FileSystem
    {
        private List<Folder> folders;
        private List<File> files;

        private int totalSize = 0;

        public List<Folder> Folders
        {
            get { return folders; }
            set { folders = value; }
        }


        public List<File> Files
        {
            get { return files; }
            set { files = value; }
        }

        public FileSystem()
        {
            folders = new List<Folder>();
            files = new List<File>();

            Folders.Add(new Folder("root"));
        }

        public int PrintFiles(Folder targetFolder)
        {
            foreach (var folder in targetFolder.SubFolders)
            {
                Console.WriteLine($"<{targetFolder.FolderName}> {folder.FolderName}");
            }

            foreach (var file in targetFolder.Files)
            {
                Console.WriteLine($"@{targetFolder.FolderName}: {file.FileName} - {file.FileSize} bytes");
                totalSize += file.FileSize;
            }

            Console.WriteLine("");

            foreach (var folder in targetFolder.SubFolders)
            {
                PrintFiles(folder as Folder);
            }            
            return totalSize;
        }

        public Folder GetRoot()
        {
            return Folders.Where(folder => folder.FolderName == "root").First();
        }

        public Folder GetFolderByName(string folderName)
        {
            Folder placeHolder = Folders.Where(folder => folder.FolderName == folderName).FirstOrDefault();

            if (placeHolder == null)
            {
                foreach (var folder in Folders)
                {
                    if (folder.SubFolders.Count > 0)
                    {
                        placeHolder = GetFolderByName(folderName, folder);
                        if (placeHolder != null)
                        {
                            return placeHolder as Folder;
                        }
                    }
                }
            }
            return placeHolder;
        }

        private Folder GetFolderByName(string folderName, Folder targetFolder)
        {
            Folder placeHolder = targetFolder.SubFolders.Where(subfolder => subfolder.FolderName == folderName).FirstOrDefault() as Folder;
            if (placeHolder != null) return placeHolder as Folder;

            foreach (var folder in targetFolder.SubFolders)
            {
                if (placeHolder != null)
                {
                    return placeHolder as Folder;
                }

                if (folder.SubFolders.Count > 0)
                {
                    placeHolder = GetFolderByName(folderName, folder as Folder);
                }
            }
            return placeHolder;
        }
    }
}
