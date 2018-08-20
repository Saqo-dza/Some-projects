using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Notebook
{
    public class User
    {
        public string Name { get;private set; }
        public string SureName { get; private set; }
        public string Login { get;private set; }
        public string Password { get; private set; }
        public User()
        {            
        }
        public User(string name,string SureName,string login,string pass)// user constructor
        {
            this.Name = name;
            this.SureName = SureName;
            this.Login = login;
            this.Password = pass;
        }

        #region  Add contact in the list
        //------------------------------------------------ Add contact in list----------------------------------------
        public void AddContact(string contact,string UserName, string UserSurename)
        {
            if (string.IsNullOrWhiteSpace(contact) && string.IsNullOrWhiteSpace(UserName) && string.IsNullOrWhiteSpace(UserSurename))
            {
                throw new ArgumentNullException("Error: The feilds are empaty");
            }
            string path = @"c:\NoteBook\" + UserName + UserSurename + ".txt";//tvyal useri hamar contact list enq sarqum
            int index = 0;

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path, true))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (contact == line)
                        {
                            //Console.WriteLine("Error: user already exists");
                            index++;
                            throw new ArgumentException("Error: user already exists");
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Error: The file not exist");
            }
            if (index == 0)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(contact);
                    sw.Flush();
                }
            }
        }
        #endregion

        #region Remove contact from list
        //----------------------------------------------------- Remove contact from list-----------------------------
        public void RemoveContact(string UserName, string UserSurename, string contact)
        {
            if (string.IsNullOrWhiteSpace(contact) && string.IsNullOrWhiteSpace(UserName) && string.IsNullOrWhiteSpace(UserSurename))
            {
                throw new ArgumentNullException("Error: The feilds are empaty");
            }
            string path = @"c:\NoteBook\" + UserName + UserSurename + ".txt";
            string NewPath = @"c:\NoteBook\" + UserName + UserSurename + 1 +".txt";
            if (File.Exists(path))
            {
                string line = null;
                using (StreamReader reader = new StreamReader(path))
                {
                    using (StreamWriter writer = new StreamWriter(NewPath))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(contact))
                            {
                                continue;
                            }
                            writer.WriteLine(line);
                        }
                    }
                }
                if (File.Exists(NewPath))
                {
                    File.Delete(path);
                    File.Move(NewPath, path);
                }
            }
            else
            {
                throw new FileNotFoundException("Error: The file not exist");
            }
        }
        #endregion

        #region Print contacts from list
        //-------------------------------------------------print contacts from list----------------------------------------
        public void Display(string UserName, string UserSurename)
        {
            if (string.IsNullOrWhiteSpace(UserName) && string.IsNullOrWhiteSpace(UserSurename))
            {
                throw new ArgumentNullException("Error: The feilds are empaty");
            }
            string path = @"c:\NoteBook\" + UserName + UserSurename + ".txt";
            int count = 0;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path, true))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(count + "." + line);
                        count++;
                    }
                }
            }
            else
            {
                FileInfo F = new FileInfo(path);
                var create = F.Create();
                create.Close();
                //throw new FileNotFoundException("Error: The file not exist");
            }
        }
        #endregion
    }
}
