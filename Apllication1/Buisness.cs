using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace Apllication1
{
    class Buisness
    {
        public static ObservableCollection<RéparationPhone> clients { get; set; }

        static Buisness ()
        {
            clients = new ObservableCollection<RéparationPhone>();
        }
    }
}
