using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System.Web;
using Abp.Runtime.Session;
using Volo.Abp.Users;
using TVersion.Dto;
using TVersion.ViewModels;
using System.Web.Mvc;

namespace TVersion.Services
{
    public class Service<TEntity, TKey> : ApplicationService where TEntity : MyEntity<TKey>
    {
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

                var userObj = DependencyResolver.Current.GetService<ApplicationUserService>();
                _userLogged = userObj.GetById(UserId);

                return _userLogged;
            }
        }

        public Service(IRepository<TEntity> repository)
        {
            _host = System.Net.Dns.GetHostName(); // System.Web.HttpContext.Current.Request.Url.DnsSafeHost;

            _repository = repository;
        }


        public void Dispose()
        {
            CurrentUnitOfWork.Dispose();
        }
    }
}
