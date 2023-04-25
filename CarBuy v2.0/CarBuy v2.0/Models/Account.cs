using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuy_v2._0.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Theme { get; set; }

    public Account(int id, string name, string password, string theme)
    {
        Id = id;
        Name = name;
        Password = password;
        Theme = theme;
    }
}
