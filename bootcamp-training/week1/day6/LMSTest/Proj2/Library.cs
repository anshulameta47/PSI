using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions; 
namespace com.Sapient
{
    public class Library
    {
        public static List<IBook> books=new List<IBook>();
        private float total;
        private int NumberOfBooks=0;    
    
        public List<IBook> SearchBook(string searchtitle,string searchBy)  //Search a book in library.
        {
            List<IBook> searchresult=new List<IBook>();
            
            foreach(var book in books)
                {
                    switch(searchBy)
                    {
                        case "title":                                     //Search by title.
                        {
                            if((book.getTitle()).Contains(searchtitle))
                            {
                                searchresult.Add(book);
                            }
                            break;
                        }

                        case "author":                                    //Search by autor.
                        {
                            if((book.getAuthor()).Contains(searchtitle))
                            {
                                searchresult.Add(book);
                            }
                            break;
                        }
                    }
                }
            return searchresult;    
        }

        public void AddBook()                                             //Adding book to library
        {
            Console.WriteLine("Enter:\n1:For NormalBook\n2:For AudioBook");
            int TypeOfBook=Convert.ToInt32(Console.ReadLine());
            IBook NewBook;        
            
            switch(TypeOfBook)  
            {
                case 1:
                {
                    var (title,author,price)=TakeInput();
                    NewBook=new NormalBook(title,author);
                    NewBook.setPrice(price);
                    break;
                }
                case 2:
                {
                    var (title,author,price)=TakeInput();
                    NewBook=new AudioBook(title,author);
                    NewBook.setPrice(price);
                    break;
                }
                default:
                {
                    throw new Exception("Please enter valid input for book type");
                }
            }
            NewBook.setId(NumberOfBooks);
            books.Add(NewBook);
            AddBookToTextFile(NewBook);
            NumberOfBooks++;
            Console.WriteLine("one Book added");
        }

        public float TotalPrice()
        {
            foreach(var book in books)
            {
                total+=book.getPrice();
            }
            return total;
        }

        private (string,string,float) TakeInput()           
        {
            string title,author;
            do
            {Console.WriteLine("Title:");
            title=Console.ReadLine();
            }while(!validateType(title));
            
            do
            {Console.WriteLine("Author:");
            author=Console.ReadLine();
            }while(!validateType(author));
                
            Console.WriteLine("Price:");
            float price=float.Parse(Console.ReadLine());
            
            Console.WriteLine("Plese press 1 to confirm else 0");
            bool confirm=Convert.ToInt32(Console.ReadLine())==1?true:false;
            
            if(!confirm)
                throw new Exception("Addition of book rejected");
            
            return (title,author,price);
                    
        }

        public bool validateType(string input)                             //Check if input is null. 
        {
            if(string.IsNullOrEmpty(input) || Regex.IsMatch(input, @"^\d+$"))
            {
                Console.WriteLine("Please enter text(not blank) value for this field and ");
                return false;
            }
            else
            return true;
        }

        private void AddBookToTextFile(IBook NewBook)                       //Adding book to name.txt file. 
        {
            using (StreamWriter sw = File.AppendText("names.txt")) 
            {
                sw.Write(NewBook.getTitle()+"|");
            }
        }

    }
}