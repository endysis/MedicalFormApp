using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFJA
{
    class PatientInfo
    {
        string pFullName;
        string pAge;
        string pStatus;
        string pSymptons;

        public string FullName
        {
            get { return pFullName;}
            set { pFullName = value;}
        }

        public string Age
        {
            get {return pAge;}
            set { pAge = value;}
        }

        public string Status
        {
            get {return pStatus;}
            set {pStatus = value;}
        }
        public string Symptons
        {
            get { return pSymptons; }
            set { pSymptons = value; }
        }





        /*
        public string ReturnFullName() {
         return pFullName;
        }
        */


    }
}
