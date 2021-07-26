using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook.API.Models;
using ContactBook.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        [Route("AddUpdateContact")]
        [HttpPost]
        public IActionResult AddUpdateContact(Contacts contact)
        {
            try
            {
                Response res = _contactRepository.AddUpdateContact(contact);
                return Ok(res);

            }catch(Exception e)
            {
                return BadRequest();
            }
        }

        [Route("DeleteContact")]
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                Response res = _contactRepository.DeleteContact(id);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("GetContact")]
        [HttpGet]
        public IActionResult GetContact(int id)
        {
            try
            {
                Contacts contact = _contactRepository.GetContact(id);
                return Ok(contact);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Route("GetAllContacts")]
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            try
            {
                List<Contacts> contactList = _contactRepository.GetContacts();
                return Ok(contactList);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
