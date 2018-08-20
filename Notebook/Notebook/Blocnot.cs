using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Blocnot : Operations
    {
        public static int userquantity;
        User[] users;
        UserOperation userOperation;
        string login;
        string password;
        string exit="no";
        public Blocnot()
        {
            userOperation = new UserOperation();
        }
        #region Get all users
        //----------------------------------------get user---------------------------------------------
        public void GetUser()
        {
            string name;
            string surname;
            string login;
            string password;
            int index = 0;
            string path = @"c:\NoteBook\Users.txt";
            if (File.Exists(path))
            {
                userquantity= File.ReadAllLines(path).Count();
                using (StreamReader sr = new StreamReader(path))
                {
                    users = new User[userquantity];
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arr= line.Split(',');
                        name = arr[0];
                        surname = arr[1];
                        login = arr[2];
                        password = arr[3];
                        users[index] = new User(name, surname, login, password);
                        index++;
                    }
                } 
            }
            else
            {
                userOperation.AddUser();
                GetUser();
            }
        }
        #endregion

        #region Sign Up user
        //-----------------------------------Login-----------------------------------------------
        public void Sign_Up()
        { 
            if (UserLogIn(users) == 1)
            {
                GetUser();
                UserLogIn(users);
            }
            login = Console.ReadLine();
            password = Console.ReadLine();
            do
            {
                try
                {
                    Console.Clear();
                    UserContact();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: enter correct data: \n{e.Message}: \n{e.Source}");
                }
            }
            while (exit.ToLower() == "yes");
        }
        #endregion

        #region Add Contact, Remove Contact, Change Contact, Select another Contact
        //----------------------------------------user contacts-----------------------------
        public void UserContact()
        {
            int num = 0;
            int index = 0;
            string name = null;
            string surname = null;
            int age = 0;
            string email = null;
            int phone = 0;
            string contact=null;

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Login == login.ToLower() && users[i].Password == password.ToLower())
                {
                    index++;
                    num= SelectOperation(i, num, users);
                    switch (num)
                    {
                        case 1:
                            InsertContact(i, contact, name, surname, age, email, phone, users);
                            break;
                        case 2:
                            DeleteContact(i, contact, name, surname, users);
                            break;
                        case 3:
                            ChangeContact(i, contact, name, surname, age, email, phone, users);
                            break;
                        case 4:
                            Console.Clear();
                            Sign_Up();
                            break;
                        default:
                            Console.WriteLine("somthing is wrong");
                            break;
                    }
                }
            }
            if (index == 0)
            {
                Console.Clear();
                Console.WriteLine("Error: invalid login or password");
            }
            
            ExitOrNot();
        }
        #endregion

        #region Exit Or Not
        public void ExitOrNot()
        {
            Console.WriteLine("if you want exit enter no else yes");
            exit = Console.ReadLine();
            if (exit.ToLower() == "yes")
            {
                Console.Clear();
                Sign_Up();
            }
            else
            {
                return;
            }
        }
        #endregion
    }
}
