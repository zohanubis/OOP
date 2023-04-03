using System;
namespace BaiTapSo3{
    class PhanSo{
private int tuSo;
        private int mauSo;

        public PhanSo(){
            tuSo = 0;
            mauSo = 1;
        }
        public PhanSo(int tuSo, int mauSo)
        {
            if(mauSo == 0)
            {
                throw new ArgumentException("Mau so khong duoc bang 0");
                this.tuSo = tuSo;
                this.mauSo = mauSo;
                RutGon();
            }
        }
        public int UCLN(int a, int b){
            a = Math.Abs(a);
            b = Math.Abs(b);
            while(a != b){
                if(a > b){ a -= b; }else{ b -= a; }
            }
            return a;
        }
        public void RutGon(){
            int ucln = UCLN(tuSo, mauSo);
            tuSo /= ucln;
            mauSo /= ucln;
        }
        // Nap Chong Toan Tu
        public static PhanSo Cong(PhanSo ps1, PhanSo ps2){
            int tuSo = ps1.tuSo * ps2.mauSo + ps2.tuSo * ps1.mauSo;
            int mauSo = ps1.mauSo * ps2.mauSo;
            return new PhanSo(tuSo, mauSo);
        }
        public static PhanSo Cong(PhanSo ps, int n){
            int tuSo = ps.tuSo * n * ps.mauSo;
            int mauSo = ps.mauSo;
            return new PhanSo(tuSo, mauSo);
        }
        // Ghi đề (override) ký tự và chuyển kí tự ToString
        public override string ToString()
        {
            return $"{tuSo}/{mauSo}";
        }
    }
    class Employee{
        
    }
    class HoGiaDinh{

    }
}