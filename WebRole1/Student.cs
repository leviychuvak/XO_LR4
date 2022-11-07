using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;


namespace WebRole1
{
    public class Student : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    {
        public Int32 Number { get; set; }
        public String SurName { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Faculty { get; set; }
        public String FormEducation { get; set; }

    }
}