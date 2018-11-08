using Lab.Management.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Management.Engine.Utils
{
    public class ObjectQueryExtensions<T> : IDisposable where T : class
    {
        public LabManagementEntities DbEntities { get; set; }

        public virtual int AddNewObject(T objToAdd)
        {
            DbEntities.Set<T>().Add(objToAdd);
            return DbEntities.SaveChanges();
        }

        public virtual int EditObject(T objToEdit)
        {
            if (DbEntities.Entry(objToEdit).State == EntityState.Detached)
            {
                DbEntities.Set<T>().Attach(objToEdit);
                DbEntities.Entry(objToEdit).State = EntityState.Modified;
            }
            else
            {
                DbEntities.Entry(objToEdit).State = EntityState.Modified;
            }

            return DbEntities.SaveChanges();
        }

        public virtual int DeleteObject(T objToDelete)
        {
            DbEntities.Set<T>().Remove(objToDelete);
            return DbEntities.SaveChanges();
        }

        public virtual List<T> GetAllList()
        {
            return DbEntities.Set<T>().ToList();
        }

        public virtual T GetObjectById(int id)
        {
            return DbEntities.Set<T>().AsEnumerable().SingleOrDefault(x => Convert.ToInt64(x) == id);
        }

        public ObjectQueryExtensions(LabManagementEntities objLabManagementEntities)
        {
            DbEntities = objLabManagementEntities;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
