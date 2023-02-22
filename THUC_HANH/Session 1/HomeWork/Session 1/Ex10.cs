//Bài 10.Tạo dãy các số nguyên ngẫu nhiên có 20 số
//(dùng ArrayList hoặc List). Mỗi phần tử là số nguyên dương và nhỏ hơn 1000.
//Thực hiện các yêu cầu sau trên dãy số:
//-Xuất dãy số.
//- Đảo dãy số
//- Tìm trong dãy số có chứa số x không? Với x nhập từ bàn phím
//- Xuất các phần tử có 2 chữ số.
//- Xuất các số có các chữ số đều là số chẵn.
//- Xuất các số nguyên tố trong dãy số (nếu có).
//- Xóa khỏi dãy số các số lẻ và là bội của 3.
//- Tăng giá trị lên 1 đơn vị cho các số mà nhỏ hơn 2 số liền kề
//(trước/và sau) nó.
//- Sắp xếp dãy số tăng dần, giảm dần

using System;
using System.Collections.Generic;
using System.Linq;

class List
{
    private List<int> list;
    public List() { 
    list = new List<int>();}

    public void AddRandomNumbers(int count)
    {
        Random random = new Random();
        for(int i = 0; i < count; i++)
        {
            list.Add(random.Next(1,1000));
        }
    }
   public void PrintList()
    {
        Console.WriteLine("Danh sach cac so nguyen : ");
        foreach(int num in list) Console.Write(num + " ");
        Console.WriteLine();
    }
    public void ReverseList() { list.Reverse(); }
    public bool Contains(int x) { return list.Contains(x); }

    public void PrintTwoDigitNumbers()
    {
        Console.WriteLine("Cac so co 2 chu so : ");
        foreach(int num in list)
        {
            if(num >= 10 && num < 100) Console.WriteLine(num + " ");
        }
        Console.WriteLine();
    }
    public void PrintEvenNumbers()
    {
        Console.WriteLine("Cac so co cac chu so deu la so chan : ");
        foreach(int num in list)
        {
            bool allEven = true;
            foreach(char c in num.ToString())
            {
                if (c % 2 != 0) { allEven = false; break; }
            }
            if (allEven) Console.Write(num + " ");
        }
    }
    public bool IsPrime(int n)
    {
        if(n < 2) return false;
        for(int i = 2; i < Math.Sqrt(n); i++)
        {
            if(n%i== 0) return false;
        } 
        return true;
    }  
    public void PrintPrimes()
    {
        Console.WriteLine("Cac so nguyen to co trong danh sach : ");
        foreach(int n in list)
        {
            if(IsPrime(n)) Console.Write(n + " ");
        }
        Console.WriteLine();
    }
    public void RemoveOddMultipleOfThree()
    {
        list.RemoveAll(num => num % 2 == 1 && num % 3 == 0);
        // Check num co chia het choa 2 3 , neu chia het cho 3 thi xoa 
    }
    public void IncreaseNeighbors()
    {
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] < list[i - 1]&& list[i] < list[i + 1])
            {
                list[i]++;
            }
        }
    }
    public void SortAscending() { list.Sort(); }
    public void SortDescending() { list.Sort((a,b)=> b.CompareTo(a)); }
}
class Program 
{
    static void Main(string[] args)
    {
        List myList = new List();
        int choice = 0;
        do
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Them so nguyen vao danh sach");
            Console.WriteLine("2. In ra danh sach");
            Console.WriteLine("3. Dao nguoc danh sach");
            Console.WriteLine("4. Tim kiem so trong danh sach");
            Console.WriteLine("5. In ra cac so co 2 chu so");
            Console.WriteLine("6. In ra cac so co cac chu so deu la so chan");
            Console.WriteLine("7. In ra cac so nguyen to trong danh sach");
            Console.WriteLine("8. Sap xep danh sach");
            Console.WriteLine("9. Thoat");

            Console.Write("Nhap lua chon cua ban : ");
             choice =int.Parse (Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Nhap so luong so nguyen can them vao danh sach: ");
                    int count = int.Parse(Console.ReadLine());
                    myList.AddRandomNumbers(count);
                    
                    break;
                case 2:
                    myList.PrintList();
                    break;
                case 3:
                    myList.ReverseList();
                    Console.WriteLine("Danh sach sau khi dao nguoc:");
                    myList.PrintList();
                    break;
                case 4:
                    Console.Write("Nhap so can tim: ");
                    int x = int.Parse(Console.ReadLine());
                    if (myList.Contains(x))
                    {
                        Console.WriteLine("So {0} co trong danh sach", x);
                    }
                    else
                    {
                        Console.WriteLine("So {0} khong co trong danh sach", x);
                    }
                    break;
                case 5:
                    myList.PrintTwoDigitNumbers();
                    break;
                case 6:
                    myList.PrintEvenNumbers();
                    break;
                case 7:
                    myList.PrintPrimes();
                    break;
                case 8:
                    Console.WriteLine("1. Sap xep tang dan");
                    Console.WriteLine("2. Sap xep giam dan");
                    Console.Write("Nhap lua chon cua ban: ");
                    int sortChoice = int.Parse(Console.ReadLine());
                    if (sortChoice == 1)
                    {
                        myList.SortAscending();
                        Console.WriteLine("Danh sach sau khi sap xep tang dan:");
                    }
                    else if (sortChoice == 2)
                    {
                        myList.SortDescending();
                        Console.WriteLine("Danh sach sau khi sap xep giam dan:");
                    }
                    myList.PrintList();
                    break;
                case 9:
                    Console.WriteLine("Tam biet!");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
            Console.WriteLine();
        } while (choice != 0 && choice < 9);
        Console.ReadLine();
    }
}


