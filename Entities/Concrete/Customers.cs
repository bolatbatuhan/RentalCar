using CorePackages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Customers : IEntity
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public Users Users { get; set; }
}
