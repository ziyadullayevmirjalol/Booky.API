﻿namespace Booky.API.Models.Book;

public class BookUpdateModel
{
    public string Title { get; set; }
    public string Genre { get; set; }

    public long PublisherId { get; set; }
}
