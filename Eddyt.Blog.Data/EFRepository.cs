using Eddyt.Blog.Core;
using Eddyt.Blog.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eddyt.Blog.Data
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _entities;

        public EFRepository(IDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public T GetById(object id)
        {
            return _entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this._entities.Add(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                Debug.WriteLine(fail.Message, fail);

                throw fail;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                //if (!this._context.IsAttached(entity))
                //    this._entities.Attach(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                Debug.WriteLine(fail.Message, fail);

                throw fail;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                //if (!this._context.IsAttached(entity))
                //    this._entities.Attach(entity);

                this._entities.Remove(entity);

                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                Debug.WriteLine(fail.Message, fail);

                throw fail;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this._entities;
            }
        }


    }
}
