using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment_System__Task4_
{
    public class TeacherMember : Member , IFineCalculator
    {
        public TeacherMember(int id, string name,string phone) : base(id, name,phone)
        {
        }
        public override int GetMaxBorrowLimit()
        {
            return 5;
        }
        public double CalculateFine(int daysLate)
        {
            if (daysLate <= 0)
                return 0.0;
            return daysLate * 1.0; // Fine is $1 per day late
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Member Type: Teacher");
            base.DisplayInfo();
        }
    }
}
