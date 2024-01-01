using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams_Planning.Views
{
    public interface ILogin
    {
        string email { get; set; }
        string password { get; set; }
    }
}
