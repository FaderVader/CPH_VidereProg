using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndFolders
{
    class Program
    {
        static FileSystem fileSystem;
        static void Main(string[] args)
        {
            PopulateFS();
        }

        static void PopulateFS()
        {
            fileSystem = new FileSystem();
            Folder root = fileSystem.GetRoot();

            root.AddItem(new File("file01_in_root", 100));
            root.AddItem(new Folder("folderA"));
            root.AddItem(new Folder("folderB"));

            Folder subFolder = fileSystem.GetFolderByName("folderA");            
            subFolder.AddItem(new File("file02_in_folderA", 2000));
            subFolder.AddItem(new Folder("..folderA"));

            var subFolder2 = fileSystem.GetFolderByName("..folderA");
            subFolder2.AddItem(new File("file03_in_..folderA", 20000));
            subFolder2.AddItem(new File("file04_in_..folderA", 22000));

            var subfolder3 = fileSystem.GetFolderByName("folderB");
            subfolder3.AddItem(new File("file04_in_folderB", 3000));
            subfolder3.AddItem(new File("file05_in_folderB", 30000));

            subfolder3.AddItem(new Folder("..folderB"));
            var subfolder4 = fileSystem.GetFolderByName("..folderB");
            subfolder4.AddItem(new File("file06_in_..folderB", 12343));
                    
            var totalSize = fileSystem.PrintFiles(root);
            Console.WriteLine($"Total file-size is {totalSize}");
            Console.ReadKey();
        }
    }
}
