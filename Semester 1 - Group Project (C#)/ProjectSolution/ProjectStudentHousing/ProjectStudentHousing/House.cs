using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentHousing
{
    public class House
    {
        //Static Variables
        private static int agreementNumber = 1;
        public static int eventNumber = 1;        

        //Properties       
        public string HouseAddress { get; private set; }
        public int HouseNumber { get; private set; }
        public Admin HouseAdmin { get; private set; }
        public List<Tenant> HouseMembers { get; private set; }
        public List<Suggestion> Suggestions { get; private set; }
        public List<Complain> TenantsComplains { get; private set; }
        public List<Event> Events { get; private set; }
        public List<Agreement> HouseAgreements { get; private set; }

        //Constructor
        public House(string address, int number)
        {
            this.HouseAddress = address;
            this.HouseNumber = number;
            this.HouseAdmin = new Admin("Admin", "12345");
            this.HouseMembers = new List<Tenant>();
            this.TenantsComplains = new List<Complain>();
            this.Suggestions = new List<Suggestion>();
            this.Events = new List<Event>();
            this.HouseAgreements = new List<Agreement>();
        }

        //Methods ↓ ↓ ↓

        //Complains
        public void AddComplainAnonymously(string related, string description)
        {
            this.TenantsComplains.Add(new Complain(related, description));
        }

        public void AddComplain(string related, string description, string name)
        {
            this.TenantsComplains.Add(new Complain(related, description, name));
        }

        //Suggestions
        public void AddSuggestion(string suggestion, string reason)
        {
            this.Suggestions.Add(new Suggestion(suggestion, reason));
        }

        public void RemoveSuggestion(Suggestion suggestion)
        {
            this.Suggestions.Remove(suggestion);
        }

        //Tenants
        public void AddTenant(string name, string password)
        {
            this.HouseMembers.Add(new Tenant(name, password));
           
        }
        public void RemoveTenant(int number)
        {
            this.HouseMembers.RemoveAt(number);
        }

        public Tenant GetTenant(string name)
        {
            foreach (Tenant tenant in this.HouseMembers)
            {
                if (tenant.Name == name)
                {
                    return tenant;
                }
            }
            return null;
        }

        public string GetAllTenantsAsString()
        {
            string info = "All Tenants" + Environment.NewLine;
            for (int i = 0; i < this.HouseMembers.Count; i++)
            {
                info = info + this.HouseMembers[i].GetInfo() + Environment.NewLine;
            }
            return info;
        }
        
        //Events
        public void AddEvent(Event newEvent)
        {
            this.Events.Add(newEvent);
        }

        public void RemoveEvent(int number)
        {
            this.Events.RemoveAt(number);
            House.eventNumber--;
        }

        //Agreements
        public void AddAgreement(string description)
        {
            this.HouseAgreements.Add(new Agreement(House.agreementNumber, description));
            House.agreementNumber++;
        }

        public void RemoveAgreement(int number)
        {
            this.HouseAgreements.RemoveAt(number);
            House.agreementNumber--;
            for (int i = 0; i < this.HouseAgreements.Count; i++)
            {
                this.HouseAgreements[i].AgreementNumber = i + 1;
            }
        }

        public void ChangeAgreement(int ruleNumber, string description)
        {
            foreach (Agreement agreement in HouseAgreements)
            {
                if (agreement.AgreementNumber == ruleNumber)
                {
                    agreement.Description = description;
                }
            }
        }

        public string GetAllAgreementsAsString()
        {
            string info = "";

            foreach (Agreement agreement in HouseAgreements)
            {
                info = info + agreement.GetInfo() + "\r\n";
            }

            return info;
        }

        //Login-checkers
        public bool checkTenantDetails(string name, string password)
        {
            foreach (Tenant tenant in this.HouseMembers)
            {
                if (tenant.Name == name && tenant.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkAdminDetails(string username, string password)
        {
            return (this.HouseAdmin.Username == username && this.HouseAdmin.Password == password);
        }

    }
}
