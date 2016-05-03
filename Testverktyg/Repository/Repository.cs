using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Testverktyg.Context;
using System.Data.Entity;

namespace Testverktyg.Repository {
    public class Repository<T> where T : class {
        private static Repository<T> Repo;
        public static Repository<T> Instance
        {
            get
            {
                if (Repo == null)
                    Repo = new Repository<T>();
                return Repo;
            }
        }

        public bool Add(T data) {
            using (var db = new TestverktygContext()) {
                try {
                    db.Set<T>().Add(data);
                    db.SaveChanges();
                    return true;
                } catch (Exception e) {
                    Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool Delete(T data) {
            using (var db = new TestverktygContext()) {
                try {
                    db.Set<T>().Attach(data);
                    db.Set<T>().Remove(data);
                    db.SaveChanges();
                    return true;
                } catch (Exception e) {
                    Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public T Get(int id) {
            using (var db = new TestverktygContext()) {
                try {
                    return db.Set<T>().Find(id);
                } catch (Exception e) {
                    Debug.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public IList<T> GetAll() {
            using (var db = new TestverktygContext()) {
                return db.Set<T>().ToList();
            }
        }

        public void Update(T data) {
            using (var db = new TestverktygContext()) {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
