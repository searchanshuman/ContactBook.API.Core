using ContactBook.API.Controllers;
using ContactBook.API.Models;
using ContactBook.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace ContactBook.Test
{
    public class ContactsControllerTest
    {
        ContactsController _contactsController;
        IContactRepository _contactRepository;
        ContactDBContext _dbContext;

        public ContactsControllerTest()
        {
            var dbOption = new DbContextOptionsBuilder<ContactDBContext>()
                                .UseSqlServer("Data Source=LAPTOP-7PEKSHB4\\SQLEXPRESS; Initial Catalog=ContactDB; Trusted_Connection=True; Integrated Security=SSPI")
                                .Options;

            _dbContext = new ContactDBContext(dbOption);
            _contactRepository = new ContactRepository(_dbContext);
            _contactsController = new ContactsController(_contactRepository);
        }


        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _contactsController.GetAllContacts();
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
