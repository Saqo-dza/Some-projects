using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Operations
    {
        public Operations()
        {
            CreateFolder();
        }
        #region Create Folder if not exists
        //-------------------------------------------------------Create Folder------------------------------------------------------------------------
        public void CreateFolder()
        {
            string path = @"c:\CoffeeMachine";
            try
            {
                if (Directory.Exists(path))
                {
                    ConnectToDB();
                    return;
                }
                DirectoryInfo dir = Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            ConnectToDB();
        }
        #endregion

        #region connect to db and set defoult values
        public void ConnectToDB()
        {            
            string water = "water: 1000";
            string sugar = "sugar: 400";
            string coffee = "coffee: 200";

            string path = @"c:\CoffeeMachine\DB.txt";

            if (!(File.Exists(path)))
            {
                FileInfo F = new FileInfo(path);
                var create = F.Create();
                create.Close();
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(water);
                        sw.WriteLine(sugar);
                        sw.WriteLine(coffee);
                        sw.AutoFlush = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
               
            }
           
        }
        #endregion
    }
}
