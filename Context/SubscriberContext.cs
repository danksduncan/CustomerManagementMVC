using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCPatientApp.Models;

namespace MVCPatientApp.Context
{
    public class SubscriberContext : DbContext
    {
        public DbSet<Subscribe> Subscriber { get; set; }
    }
}