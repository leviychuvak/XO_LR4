using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Data.Services.Client;


namespace WebRole1
{
    public class StudentContext : TableServiceContext
    {
        public StudentContext(Uri baseAddress, StorageCredentials credentials) : base(baseAddress.AbsoluteUri, credentials) { }

        public IQueryable<Student> StudentData
        {
            get
            {
                return this.CreateQuery<Student>("Students");
            }
        }

        public void Add(Student stud)
        {
            this.AddObject("Students", stud);
            this.SaveChanges();
        }

        public void Delete(Student stud)
        {
            this.DeleteObject(stud);
            this.SaveChanges();
        }

        public void Update(Student stud)
        {
            this.UpdateObject(stud);
            this.SaveChanges();
        }


    }

}