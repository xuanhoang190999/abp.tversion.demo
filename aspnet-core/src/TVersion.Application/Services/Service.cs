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

namespace TVersion.Services
{
    public class Service<TEntity, TKey> : ApplicationService where TEntity : MyEntity<TKey>
    {
        private readonly IRepository<TEntity> _repository;

        private string _host;

        protected string Host
        {
            get { return _host ?? System.Net.Dns.GetHostName(); }
            set { _host = value; }
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
