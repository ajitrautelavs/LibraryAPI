using LibraryAPI.Business.Interfaces;
using LibraryAPI.Controllers;
using LibraryAPI.Models.Domain;
using Microsoft.Extensions.Logging;
using Moq;

namespace LibraryAPI.Tests;

public class BooksControllerTest
{
    Mock<IBookService> _bookServiceMock;
    Mock<ILogger<BooksController>> _logger;
    BooksController _booksContoller;

    public BooksControllerTest()
    {
        _bookServiceMock = new Mock<IBookService>();
        _logger = new Mock<ILogger<BooksController>>();
        _booksContoller = new BooksController(_logger.Object, _bookServiceMock.Object);
    }

    [Fact]
    public void Add_Book_Success()
    {
        var result = _booksContoller.PostBook(new Book { Title = "RatBags", Author = "Tim Harris", ISBN = "984651354652", PublishedDate = new DateOnly(2023, 11, 2) });
        Assert.NotNull(result);
    }

    [Fact]
    public void Get_Book_Success()
    {
        var result = _booksContoller.GetBook(1);
        Assert.NotNull(result);
    }

    [Fact]
    public void Update_Book_Success()
    {
        var result = _booksContoller.PutBook(1, new Book { Title = "Rat Bags", Author = "Tim Harris", ISBN = "684891146521", PublishedDate = new DateOnly(2024, 2, 1) });
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAll_Book_Success()
    {
        var result = _booksContoller.GetBooks();
        Assert.NotNull(result);
    }
}