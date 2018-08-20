using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
   public class Operations
    {
        UserOperation userOperation = new UserOperation ();
        
        #region Login
        //-------------------------------Login---------------------------------------------------------------
        public int UserLogIn( User[] users)
        {
            Console.WriteLine("Login password-nern a");
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine(users[i].Login + " " + users[i].Password);
            }
            Console.WriteLine("if you want add user enter 1 else press any key ");
            int n;
            int.TryParse(Console.ReadLine(), out n);
            if (n == 1)
            {
                userOperation.AddUser();
                Console.Clear();
                return 1;
            }
            Console.WriteLine("Enter Your Login  and Password ");
            return 0;
        }
        #endregion

        #region select operation
        //--------------------------------------select operation ---------------------------------------------------
        public int SelectOperation(int i,int num,User[] users)
        {
            Console.WriteLine($"\n{users[i].Name} {users[i].SureName}'s contact list\n");
            users[i].Display(users[i].Name, users[i].SureName);//print user contacts
            Console.WriteLine(" If tou want add contact entre 1 \n if remove enter 2 \n if change contact enter 3 \n if you want Sign Up another user enter 4");
            int.TryParse(Console.ReadLine(), out num);
            return num;
        }
        #endregion

        #region Add Contact
        //-------------------------------------------------Add---------------------------------------------------------
        public void InsertContact(int i, string contact, string name, string surname, int age, string email, int phone, User[] users)
        {
            Console.WriteLine("Pleas enter new contact in this format:  name,  surname,  age,  email,  phone");
            name = Console.ReadLine();
            surname = Console.ReadLine();
            int.TryParse(Console.ReadLine(), out age);
            email = Console.ReadLine();

            int.TryParse(Console.ReadLine(), out phone);
            if (!(string.IsNullOrWhiteSpace(name)) && !(string.IsNullOrWhiteSpace(surname)) && phone != 0)
            {
                contact = $"{name}, {surname}, {age}, {email}, {phone}";
            }
            try
            {
                users[i].AddContact(contact, users[i].Name, users[i].SureName);
                Console.WriteLine($"{users[i].Name} {users[i].SureName} updated contact list\n");
                users[i].Display(users[i].Name, users[i].SureName);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error: Invalid data.\n{users[i].Name} {users[i].SureName}  contact  has not been Added");
            }
        }
        #endregion

        #region Delete Contact
        //-------------------------------Delete--------------------------------------------------------------------------------
        public void DeleteContact(int i, string contact, string name, string surname, User[] users)
        {
            Console.WriteLine("Pleas enter the name and surename of contact which you want to remove from your list");
            name = Console.ReadLine();
            surname = Console.ReadLine();
            if (!(string.IsNullOrWhiteSpace(name)) && !(string.IsNullOrWhiteSpace(surname)))
            {
                contact = $"{name}, {surname}";
            }
            try
            {
                users[i].RemoveContact(users[i].Name, users[i].SureName, contact);
                Console.WriteLine($"conatct  {name} {surname} has been successfully deleted");
                Console.WriteLine($"{users[i].Name} {users[i].SureName} updated contact list\n");
                users[i].Display(users[i].Name, users[i].SureName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: ther wher no conatc {contact}. {e.Source}");
            }
        }
        #endregion

        #region Change Contact
        //-----------------------------change-----------------------------------------------------------
        public void ChangeContact(int i, string contact, string name, string surname, int age, string email, int phone, User[] users)
        {
            Console.WriteLine("Pleas enter the name and surename of contact which you want to change");
            name = Console.ReadLine();
            surname = Console.ReadLine();

            try
            {
                if (!(string.IsNullOrWhiteSpace(name)) && !(string.IsNullOrWhiteSpace(surname)))
                {
                    contact = $"{name}, {surname}";
                }
                users[i].RemoveContact(users[i].Name, users[i].SureName, contact);
                Console.WriteLine("Pleas enter new contact in this format:  name,  surname,  age,  email,  phone");
                name = Console.ReadLine();
                surname = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out age);
                email = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out phone);
                if (!(string.IsNullOrWhiteSpace(name)) && !(string.IsNullOrWhiteSpace(surname)) && phone != 0)
                {
                    contact = $"{name}, {surname}, {age}, {email}, {phone}";
                }
                try
                {
                    users[i].AddContact(contact, users[i].Name, users[i].SureName);
                    Console.WriteLine($"{users[i].Name} {users[i].SureName}  contact  has been changed\n");
                    users[i].Display(users[i].Name, users[i].SureName);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Error: Invalid data.\n{users[i].Name} {users[i].SureName}  contact  has not been changed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: ther wher no conatc {contact}. {e.Source}");
            }
        }
        //-----------------------------------------------------------------------------------------------
        #endregion
        
        
    }
}
