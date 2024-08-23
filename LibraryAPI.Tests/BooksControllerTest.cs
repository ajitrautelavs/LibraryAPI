using LibraryAPI.Business.Interfaces;
using LibraryAPI.Controllers;
using LibraryAPI.Models.Domain;
using Moq;

namespace LibraryAPI.Tests;

public class BooksControllerTest
{
    Mock<IBookService> _bookServiceMock;
    BooksController _booksContoller;

    public BooksControllerTest()
    {
        _bookServiceMock = new Mock<IBookService>();
        _booksContoller = new BooksController(_bookServiceMock.Object);
    }

    [Fact]
    public void Add_Book_Success()
    {
        var result = _booksContoller.AddBook(new Book { Title = "RatBags", Author = "Tim Harris", ISBN = "984651354652", PublishedDate = new DateTime(2023, 11, 2) });
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
        var result = _booksContoller.UpdateBook(1, new Book { Title = "Rat Bags", Author = "Tim Harris", ISBN = "684891146521", PublishedDate = new DateTime(2024, 2, 1) });
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAll_Book_Success()
    {
        var result = _booksContoller.GetAllBooks();
        Assert.NotNull(result);
    }
}