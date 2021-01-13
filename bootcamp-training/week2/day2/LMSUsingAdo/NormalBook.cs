using System;

namespace com.Sapient
{
   
    class NormalBook: IBook
    {
         protected string author;
         protected string title;
         protected float price;
         protected int id;

        public NormalBook(string title,string author)
        {
            this.title=title;
            this.author=author;
        }

        public NormalBook(){}

        public string getTitle()
        {
            return this.title;
        }
        public string getAuthor()
        {
            return this.author;
        }
        public float getPrice()
        {
            return this.price;
        }
        public void setPrice(float price)
        {
            if(price<0)
            throw new Exception("Price cannot be negative");
            
            this.price=price;
        }
        public void setId(int id)
        {
            this.id=id;
        }
        public override string ToString()
        {
            string output="Title:"+title +" Author:"+author+ " price:"+price+" Id:"+id;
            return output;
        }
    }
}