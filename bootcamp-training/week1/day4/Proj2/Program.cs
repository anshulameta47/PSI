using System;
using System.Collections.Generic;

namespace com.Sapient
{
     static class Program
    {
        static void Main(String[] args)
        {
            int operation;
            Console.WriteLine("Welcome to Lms");
            
            Library library=new Library();
            do
            {
            Console.WriteLine("Enter:\n1.Add new book to library\n2.Search book from library"); 
            operation=Convert.ToInt32(Console.ReadLine());

            try
            {
            switch(operation)
            {
                case 1:
                {
                    library.AddBook();
                    break; 
                }

                case 2: 
                {
                    string searchKey,searchBy;
                    
                    Console.WriteLine("Enter:\n1:Search by title\n2:Search by author");
                    int typeOfSearch=Convert.ToInt32(Console.ReadLine());
                    switch(typeOfSearch)
                    {
                        case 1:
                        {searchBy="title";break;}

                        case 2:
                        {searchBy="author";break;}

                        default:
                        {
                           throw new Exception("Please enter valid input for search operation");
                        }
                    }

                    do{
                    Console.WriteLine($"Enter book {searchBy}'s name to search");
                    searchKey=Console.ReadLine();
                    }while(!library.validateType(searchKey));  
                    
                    List<IBook> result=library.SearchBook(searchKey,searchBy);

                    if(result.Count==0)
                        throw new Exception("No book found");
                    
                    foreach(var book in result)
                    {
                        Console.WriteLine(book);
                    }
                    break;
                }
                default:
                {
                    throw new Exception("Please enter valid operation type");
                }
            }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            }while(operation<=2);
        }
    }
}
