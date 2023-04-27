using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4_PhamHoDangHuy_2001215828
{
    class Candidate
    {
        public string SBD { get; set; }
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public double MathScore { get; set; }
        public double LiteratureScore { get; set; }
        public double ForeignLanguageScore { get; set; }

        // Phương thức khởi tạo mặc định
        public Candidate()
        {
        }

        // Phương thức khởi tạo có tham số
        public Candidate(string sbd, string name, int yearOfBirth, double mathScore, double literatureScore, double foreignLanguageScore)
        {
            SBD = sbd;
            Name = name;
            YearOfBirth = yearOfBirth;
            MathScore = mathScore;
            LiteratureScore = literatureScore;
            ForeignLanguageScore = foreignLanguageScore;
        }

        // Phương thức khởi tạo sao chép
        public Candidate(Candidate candidate)
        {
            SBD = candidate.SBD;
            Name = candidate.Name;
            YearOfBirth = candidate.YearOfBirth;
            MathScore = candidate.MathScore;
            LiteratureScore = candidate.LiteratureScore;
            ForeignLanguageScore = candidate.ForeignLanguageScore;
        }

        // Property tính tổng điểm
        public double TotalScore
        {
            get { return MathScore + LiteratureScore + ForeignLanguageScore * 2; }
        }

        // Property kết quả thi
        public string Result
        {
            get { return TotalScore >= 25 ? "Đậu" : "Rớt"; }
        }

        // Phương thức xuất thông tin thí sinh
        public void Display()
        {
            Console.WriteLine("{0,-1} {1,-20} \t{2,-12} \t{3,-15} {4,-20} {5,-13} {6,-15} {7}", SBD, Name, YearOfBirth, MathScore, LiteratureScore, ForeignLanguageScore, TotalScore, Result);
        }

    }

}
