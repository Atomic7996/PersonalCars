using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCars
{
    public partial class Owners
    {
        public override string ToString()
        {
            return string.Format(LastName + " " + FirstName + " " + Patronymic);
        }
    }
}
