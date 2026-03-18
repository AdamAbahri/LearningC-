using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment_System__Task4_
{
    public class StudentMember : Member , IFineCalculator
    {
        public StudentMember(int Id,string name, string Phone): base(Id,name,Phone)
        {
        }
        public override int GetMaxBorrowLimit()
        {
            return 3;
        }
        public double CalculateFine(int daysLate)
        {
            if (daysLate <= 0)
                return 0.0;
            return daysLate * 0.5; // Fine is $0.5 per day late
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Member Type: Student");
            base.DisplayInfo();
        }
    }
}
