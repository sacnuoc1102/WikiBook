using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.Services;
using WikiBookGetApi.DataAccessLayer.Repositories;

namespace TestApi.Services
{
    public class UserConnectionService : IUserConnectionService
    {
        public readonly IUserConnectionRepository userConnectionRepository;
        private readonly IMapper mapper;

        public UserConnectionService(IUserConnectionRepository repository, IMapper mapper)
        {
            userConnectionRepository = repository;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<BookDTO> GetUserLikedBooks(string UserIdentity)
        {
            return mapper.Map<IEnumerable<BookDTO>>(this.userConnectionRepository.GetUserLikedBooks(UserIdentity));
        }

        public LikedBookByUserDTO LikeABook(string UserIdentity, int BookId)
        {
            return mapper.Map<LikedBookByUserDTO>(this.userConnectionRepository.LikeABook(UserIdentity, BookId));
        }
    }
}
