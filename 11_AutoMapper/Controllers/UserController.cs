using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _11_AutoMapper.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            // örnek bir user nesnesi oluşturduk.
            User user = new User()
            {
                Id = 1,
                FirstName = "Tahsin",
                LastName = "Canpolat",
                Email = "tcanpolat@mail.com"
            };

            // User => UserDto dönüşümünü gerçekleştirdik.
            var userDto = _mapper.Map<UserDto>(user);

            return View(userDto);
        }
    }
}
