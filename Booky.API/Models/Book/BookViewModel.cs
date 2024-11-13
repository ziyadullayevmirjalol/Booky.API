﻿using Booky.API.Models.Author;

namespace Booky.API.Models.Book;

public class BookViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ISBN { get; set; }

    public string PublisherName { get; set; }

    public List<AuthorViewModel> Authors { get; set; }
}