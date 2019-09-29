using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemObject
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
        public Folder GetRoot()
        {
            return Folders.Where(folder => folder.Name == "root").First();
        }

        public void PrintFiles()
        {
            PrintFiles(GetRoot());
        }

        private void PrintFiles(Folder targetFolder)
        {
            foreach (var folder in targetFolder.SubFolders)
            {
                Console.WriteLine($"<{targetFolder.Name}> {folder.Name}");
            }

            foreach (var file in targetFolder.Files)
            {
                Console.WriteLine($"@{targetFolder.Name}: {file.Name} - {file.GetSize()} bytes");
            }

            Console.WriteLine("");

            foreach (var folder in targetFolder.SubFolders)
            {
                PrintFiles(folder as Folder);
            }
        }

        public int GetTotalSize()
        {
            return GetTotalSize(GetRoot());
        }

        private int GetTotalSize(Folder targetFolder)
        {
            foreach (Folder folder in targetFolder)
            {
                totalSize += folder.GetSize();

                if (folder.SubFolders.Count > 0)
                {
                    GetTotalSize(folder);
                }
            }
            return totalSize;
        }

        public Folder GetFolderByName(string folderName)
        {
            Folder placeHolder = Folders.Where(folder => folder.Name == folderName).FirstOrDefault();

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
            Folder placeHolder = targetFolder.SubFolders.Where(subfolder => subfolder.Name == folderName).FirstOrDefault() as Folder;
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
