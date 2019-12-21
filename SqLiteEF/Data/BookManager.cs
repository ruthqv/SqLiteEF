using SqLiteEF;
using SqLiteEF.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.SqLiteEF
{
    public class BookManager
    {
          public static List<Books> GetAllBooks()
        {
            List<Books> books;

            using (mainEntity db = new mainEntity())
            {
                books = db.Books.OrderByDescending(m => m.id).ToList();
              
            }
            return books;

        }
        public static void InsertBook(Books book)
        {
            using (mainEntity db = new mainEntity())
            {
                db.Books.Add(book);

                db.SaveChanges();

            }

            MainWindow main = new MainWindow();

            main.RefreshDatas();
        }
        public static void UpdateBook(Books book)
        {
            using (mainEntity db = new mainEntity())
            {

                db.Entry(book).State = EntityState.Modified;


                db.SaveChanges();

            }
            MainWindow main = new MainWindow();

            main.RefreshDatas();
        }

        public static void DeleteBook(Books book)
        {
            if(book != null)
            {
                using (mainEntity db = new mainEntity())
                {
                    var bookto = db.Books.Find(book.id);

                    db.Books.Remove(bookto);

                    db.SaveChanges();
                }

                MainWindow main = new MainWindow();

                main.RefreshDatas();
            }
        }
    }
}