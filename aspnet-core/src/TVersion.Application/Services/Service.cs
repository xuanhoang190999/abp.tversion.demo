using System;
using TVersion.Models;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using TVersion.ViewModels;
using Microsoft.AspNetCore.Http;
//using System.Web.Mvc;

namespace TVersion.Services
{
    public class Service<TEntity, TKey> : ApplicationService where TEntity : MyEntity<TKey>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<TEntity> _repository;
        private readonly ICurrentUser _currentUser;

        private string _host;
        private Guid _userId;
        private ApplicationUserModel _userLogged;

        protected string Host
        {
            get { return _host ?? System.Net.Dns.GetHostName(); }
            set { _host = value; }
        }

        protected Guid UserId
        {
            get
            {
                if (string.IsNullOrEmpty(_userId.ToString()))
                {
                    _userId = (Guid)_currentUser.Id;
                }

                return _userId;
            }
            set { _userId = value; }
        }

        public ApplicationUserModel UserLogged
        {
            get
            {
                if (_currentUser != null)
                {
                    return _userLogged;
                }

                var userService = (ApplicationUserService)_httpContextAccessor
                    .HttpContext.RequestServices
                    .GetService(typeof(ApplicationUserService));

                _userLogged = userService.GetById(_currentUser.Id);

                return _userLogged;
            }
        }

        public Service(IRepository<TEntity> repository, IHttpContextAccessor httpContextAccessor = null)
        {
            _host = System.Net.Dns.GetHostName(); // System.Web.HttpContext.Current.Request.Url.DnsSafeHost;
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }


        public void Dispose()
        {
            CurrentUnitOfWork.Dispose();
        }
    }
}
