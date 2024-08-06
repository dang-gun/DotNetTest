using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.DB.Models;

public class TestData
{
    /// <summary>
    /// 
    /// </summary>
    public DbSet<TestOC4> TestOC4 { get; set; }
}
