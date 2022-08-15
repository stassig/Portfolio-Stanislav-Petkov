using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStudentHousing
{
    public class Admin
    {
        //Properties
        public string Username { get; private set; }
        public string Password { get; private set; }
        public List<Rule> HouseRules { get; private set; }

        //Static Variables
        private static int ruleNumber = 1;

        //Constructor
        public Admin(string name, string password)
        {
            this.Username = name;
            this.Password = password;
            this.HouseRules = new List<Rule>();
        }

        //Methods
        public void AddRule(string description)
        {
            this.HouseRules.Add(new Rule(Admin.ruleNumber, description));
            Admin.ruleNumber++;
        }

        public void RemoveRule(int number)
        {
            this.HouseRules.RemoveAt(number);
            Admin.ruleNumber--;
            for (int i = 0; i < this.HouseRules.Count; i++)
            {
                this.HouseRules[i].RuleNumber = i + 1;
            }

        }

        public void ChangeRule(int ruleNumber, string description)
        {
            foreach (Rule rule in this.HouseRules)
            {
                if (rule.RuleNumber == ruleNumber)
                {
                    rule.ChangeRule(description);
                }
            }
        }

        public string GetAllRulesAsString()
        {
            string info = "";
            for (int i = 0; i < this.HouseRules.Count; i++)
            {
                info = info + this.HouseRules[i].GetInfo() + Environment.NewLine;
            }

            return info;
        }

        public string GetAllComplainsAsString(List<Complain> allComplains)
        {
            string info = "";
            foreach (Complain complain in allComplains)
            {
                info = info + complain.GetInfo() + Environment.NewLine;
            }
            return info;
        }

    }
}
