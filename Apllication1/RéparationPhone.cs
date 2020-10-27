using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apllication1
{
    class RéparationPhone
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string ModelPhone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string DateRecue { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string PrixReparation { get; set; }


        public RéparationPhone(string nom, string prenom, string modelPhone, string mobile, string email,
                                string dateRecu, string description, string status, string prixReparation)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.ModelPhone = modelPhone;
            this.Mobile = mobile;
            this.Email = email;
            this.DateRecue = dateRecu;
            this.Description = description;
            this.Status = status;
            this.PrixReparation = prixReparation;

        }
    }
}
