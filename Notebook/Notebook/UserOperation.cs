using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    class UserOperation
    {
        #region Create Folder if not exists
        //-------------------------------------------------------Create Folder------------------------------------------------------------------------
        public void CreateFolder()// sarqum enq folder ete chka
        {
           string path= @"c:\NoteBook";
            try
            {
                if (Directory.Exists(path))
                {
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(path);
                //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
        #endregion

        #region Add user
        //--------------------------------------------Add user -----------------------------------------------------------------------------------
        public void AddUser()//user enq avelacnum
        {
            Console.WriteLine("You need create user");
            CreateFolder();
            string name;
            string surename;
            string login;
            string password;
            Console.Write("Enter user name: ");
            name = Console.ReadLine();
            Console.Write("Enter user surename: ");
            surename = Console.ReadLine();
            Console.Write("Enter user login: ");
            login = Console.ReadLine();
            Console.Write("Enter user password: ");
            password = Console.ReadLine();
            string path = @"c:\NoteBook\Users.txt";
            string concat = $"{name},{surename},{login},{password}";
            int index = 0;
            if (!(File.Exists(path)))
            {
                FileInfo F = new FileInfo(path);
                var create= F.Create();
                create.Close();
            }
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains($"{name},{surename}"))
                    {
                        Console.WriteLine("Error: user already exists");
                        index++;
                        //throw new ArgumentException("Error: user already exists");
                        return;
                    }
                }
            }
            if (index==0)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(concat);
                    sw.AutoFlush=true;
                }
            }
        }
        #endregion
        
    }
}
