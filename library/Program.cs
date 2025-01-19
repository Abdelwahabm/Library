namespace library
{

    class Book
    {
        string Title;
        string Author;
        string ISBN;
        bool Available;

        public Book(string title, string author, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Available = true;
        }

        //Setters
        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public void SetAuthor(string author)
        {
            this.Author = author;
        }

        public void SetIsbn(string isbn)
        {
            this.ISBN = isbn;
        }

        public void SetAvailable(bool available)
        {
            this.Available = available;
        }

        //Getters
        public string GetTitle()
        {
            return this.Title;
        }
        public string GetAuthor()
        {
            return this.Author;
        }

        public string GetIsbn()
        {
            return this.ISBN;
        }
        public bool IsAvailable()
        {
            return this.Available;
        }

    }

    class Library
    {
        List<Book> Books;
        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public bool SearchBook(string title)
        {

            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].GetTitle() == title)
                {
                    return true;

                }
            }

            return false;
        }
        public void BorrowBook(string title)
        {
            if (SearchBook(title))
            {
                for (int i = 0; i < Books.Count(); i++)
                {
                    if (Books[i].GetTitle() == title)
                    {
                        if (Books[i].IsAvailable())
                        {
                            Console.WriteLine($"You can borrow {title} book, thank you for visiting our library");
                            Books[i].SetAvailable(false);
                        }
                        else
                        {
                            Console.WriteLine($"Sorry,{Books[i].GetTitle()} book is borrowed to someone else ");
                        }
                        break;
                    }
                }

            }
            else
            {
                Console.WriteLine($"we don't have this book {title} in our library");
            }
        }
        public void ReturnBook(string title)
        {
            if (SearchBook(title))
            {
                for (int i = 0; i < Books.Count(); i++)
                {
                    if (Books[i].GetTitle() == title)
                    {
                        Books[i].SetAvailable(true);

                        break;
                    }
                }
                Console.WriteLine($"Thank you for returning {title} book");

            }
            else
            {
                Console.WriteLine("we don't have this book in our library,so it has to be to a another library");
            }
        }

        public void GetBookInfo(string title)
        {
            if (SearchBook(title))
            {
                for (int i = 0; i < Books.Count(); i++)
                {
                    if (Books[i].GetTitle() == title)
                    {
                        Console.WriteLine($"Title: {Books[i].GetTitle()}");
                        Console.WriteLine($"Author: {Books[i].GetAuthor()}");
                        Console.WriteLine($"ISBN: {Books[i].GetIsbn()}");
                        Console.WriteLine($"Availability: {Books[i].IsAvailable()}");
                    }

                }
            }
            else
            {
                Console.WriteLine("we don't have this book in our library,so it has to be to a another library");
            }
        }
    }
        internal class Program
        {
            static void Main(string[] args)
            {
                //Book Batman =  new Book ("Batman" ,"Bob Kane" , "123456" ) ;
                //Book Spiderman = new Book("Spiderman", "Stan Lee", "132546" );
                //Book Pharaohs = new Book ("Pharaohs" , "Zahy Hwas" , "145263" ) ;


                Library Alexandria = new Library();

                Alexandria.AddBook(new Book("Hamlet", "SHAKESPEARE", "123456"));
                Alexandria.AddBook(new Book("Moby-Dick", "HERMAN MELVILLE", "132546"));
                Alexandria.AddBook(new Book("1984", "GEORGE ORWELL", "145263"));

                Alexandria.BorrowBook("Hamlet");    // Borrowing Book

                Alexandria.BorrowBook("Hamlet");    // You can't borrow the book because it had been borrowed

                Alexandria.ReturnBook("Hamlet");    // Returning the borrowed book

                Alexandria.BorrowBook("Hamlet");    // Borrowing Book

                Alexandria.GetBookInfo("1984");     // Displaying Book information
            }
        }

    }
