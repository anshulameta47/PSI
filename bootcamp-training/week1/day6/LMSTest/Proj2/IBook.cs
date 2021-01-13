using System;

namespace com.Sapient
{
    public interface IBook
    {
        public string getTitle();
        public string getAuthor();
        public float getPrice();
        public void setPrice(float price);  
        public void setId(int id);
        
    }
}