using System;

namespace com.Sapient
{

    class AudioBook: NormalBook
    {
       
        private string cd;

        public AudioBook(string title,string author):base(title,author){}
        
        public string getCd()
        {
            return cd;

        }
        public void setCd(string cd)
        {
            this.cd=cd;
        }
        public void Play()
        {
            Console.WriteLine("Cd is playing");
        }

    }
}