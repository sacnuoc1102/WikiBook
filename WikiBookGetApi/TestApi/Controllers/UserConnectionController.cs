using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConnectionController : ControllerBase
    {
        public IUserConnectionService userConnectionService;

        public UserConnectionController(IUserConnectionService service)
        {
            userConnectionService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetLikedBookByUser(string userIdentity)
        {
            return this.userConnectionService.GetUserLikedBooks(userIdentity).ToList();
        }

        [HttpPost]
        public ActionResult LikedABook([FromBody] LikedBookByUserDTO likedBook)
        {
            this.userConnectionService.LikeABook(likedBook.UserIdentity, likedBook.BookId);
        }

    }
}