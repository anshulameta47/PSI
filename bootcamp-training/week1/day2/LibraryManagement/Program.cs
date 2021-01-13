using System;
using System.Collections.Generic;
namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Library System");
            Library library=new Library();
            
        }
    }
    class Page
    {
        private uint page_number;
        private string page_header;

       public  Page(uint page_number,string page_header)
        {
            this.page_number=page_number;
            this.page_header=page_header;
        }   

    }

    class Listofpage
    {
        public static List<Page> Mylist=new List<Page>();
        static Listofpage()
        {
            Mylist.Add(new Page(1,"Title Page"));
            Mylist.Add(new Page(2,"Index"));
            Mylist.Add(new Page(3,"Proluge"));

        }
        public List<Page> getListofpage()
        {
            return Mylist;
        }
        public void Addpage(Page Newpage)
        {
            Mylist.Add(Newpage);
        }
    }

    class Book
    {
        private string title,author,isdn;
        private uint prize;
        private int publishing_year;
        private List<Page> Mypages;

       public  Book(string title,string author,string isdn,uint prize,int publishing_year,List<Page> Mypages)
        {
            this.title=title;
            this.author=author;
            this.isdn=isdn;
            this.prize=prize;
            this.publishing_year=publishing_year;
            this.Mypages=Mypages;
        }
         

        public void Updateprize(uint Updatedprize)
        {
            this.prize=Updatedprize;
        } 



    }
    class Library
    {
        
        public static List<Book> Mybooks=new List<Book>();
            
        static Library()
        {
            Mybooks.Add(new Book("Title1","Author1","ISDN1",400,2014,Listofpage.Mylist));
        }    

        public void AddBooks(Book NewBook)
        {            
            Mybooks.Add(NewBook);
        }

        public List<Book> getBooks()
        {
            return Mybooks;
        }


    }


    
}
