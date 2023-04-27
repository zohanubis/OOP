using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Buoi4_PhamHoDangHuy_2001215828
{
    class CandidateList
    {
        private List<Candidate> candidates;

        // Phương thức khởi tạo mặc định
        public CandidateList()
        {
            candidates = new List<Candidate>();
        }

        // Phương thức nhập danh sách thí sinh từ bàn phím
        public void Input()
        {
            Console.Write("Nhap so luong thi sinh: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap thong tin thi sinh thu {0}", i + 1);
                Console.Write("SBD: ");
                string sbd = Console.ReadLine();
                Console.Write("Ho ten: ");
                string name = Console.ReadLine();
                Console.Write("Nam sinh: ");
                int yearOfBirth = int.Parse(Console.ReadLine());
                Console.Write("Diem toan: ");
                double mathScore = double.Parse(Console.ReadLine());
                Console.Write("Diem van: ");
                double literatureScore = double.Parse(Console.ReadLine());
                Console.Write("Diem ngoai ngu: ");
                double foreignLanguageScore = double.Parse(Console.ReadLine());

                candidates.Add(new Candidate(sbd, name, yearOfBirth, mathScore, literatureScore, foreignLanguageScore));
            }
        }
            // Phương thức nhập danh sách thí sinh từ file XML
            public void ImportFromXml(string file)
            {
                XmlDocument read = new XmlDocument();
                read.Load(file);

                XmlNodeList candidateNodes = read.SelectNodes("candidates/candidate");

                foreach (XmlNode candidateNode in candidateNodes)
                {
                    string sbd = candidateNode["sbd"].InnerText;
                    string name = candidateNode["name"].InnerText;
                    int yearOfBirth = int.Parse(candidateNode["yearOfBirth"].InnerText);
                    double mathScore = double.Parse(candidateNode["mathScore"].InnerText);
                    double literatureScore = double.Parse(candidateNode["literatureScore"].InnerText);
                    double foreignLanguageScore = double.Parse(candidateNode["foreignLanguageScore"].InnerText);

                    candidates.Add(new Candidate(sbd, name, yearOfBirth, mathScore, literatureScore, foreignLanguageScore));
                }
            }

        // Phương thức in ra màn hình danh sách thí sinh
        public void PrintCandidates()
        {
            Console.WriteLine("DANH SÁCH THÍ SINH:");
            Console.WriteLine("SBD\tHọ và Tên\t\tNăm Sinh\tĐiểm Toán\tĐiểm Văn\tĐiểm Ngoại Ngữ\tTổng Điểm\tKết Quả");
            foreach (Candidate candidate in candidates)
            {
                candidate.Display();
            }
        }

        // Sắp xếp danh sách thí sinh theo tổng điểm giảm dần
        public void SortByTotalScoreDescending()
        {
            candidates.Sort((x, y) => y.TotalScore.CompareTo(x.TotalScore));
        }
        // Sắp xếp danh sách thí sinh theo họ tên tăng dần và nếu tên trùng nhau thì thí sinh có điểm toán lớn hơn đứng trên
        public void SortByNameAscendingThenByMathScoreDescending()
        {
            candidates.Sort((x, y) => {
                int result = x.Name.CompareTo(y.Name);
                if (result == 0)
                {
                    result = y.MathScore.CompareTo(x.MathScore);
                }
                return result;
            });
        }
        // Lấy ra danh sách các thí sinh có kết quả Đậu
        public List<Candidate> GetPassedCandidates()
        {
            return candidates.Where(candidate => candidate.Result == "Đậu").ToList();
        }

        // Lấy ra danh sách thí sinh có năm sinh > 1995 hoặc có điểm toán từ 9 trở lên
        public List<Candidate> GetCandidatesByYearOfBirthAndMathScore()
        {
            return candidates.Where(candidate => candidate.YearOfBirth > 1995 || candidate.MathScore >= 9).ToList();
        }

    }
}


