#include <iostream>
#include <cmath>

using namespace std;

// Nhập mảng
void nhapMang(int A[], int n) {
    cout << "Nhap mang:\n";
    for (int i = 0; i < n; i++) {
        cout << "A[" << i << "] = ";
        cin >> A[i];
    }
}

// Xuất mảng
void xuatMang(const int A[], int n) {
    cout << "Xuat mang:\n";
    for (int i = 0; i < n; i++) {
        cout << A[i] << " ";
    }
    cout << endl;
}

// Đếm số phần tử âm
int demSoAm(const int A[], int n) {
    int count = 0;
    for (int i = 0; i < n; i++) {
        if (A[i] < 0) {
            count++;
        }
    }
    return count;
}
void swap(int& a, int& b) {
    int temp = a;
    a = b;
    b = temp;
}

// Tìm phần tử Max của mảng
int timMax(const int A[], int n) {
    int maxVal = A[0];
    for (int i = 1; i < n; i++) {
        if (A[i] > maxVal) {
            maxVal = A[i];
        }
    }
    return maxVal;
}

// Tìm phần tử Min của mảng
int timMin(const int A[], int n) {
    int minVal = A[0];
    for (int i = 1; i < n; i++) {
        if (A[i] < minVal) {
            minVal = A[i];
        }
    }
    return minVal;
}

// Tìm phần tử âm lớn nhất và dương bé nhất
void timAmDuong(const int A[], int n, int& maxAm, int& minDuong) {
    maxAm = INT_MIN;
    minDuong = INT_MAX;

    for (int i = 0; i < n; i++) {
        if (A[i] < 0 && A[i] > maxAm) {
            maxAm = A[i];
        }
        if (A[i] >= 0 && A[i] < minDuong) {
            minDuong = A[i];
        }
    }
}


// Kiểm tra số nguyên tố
bool laSoNguyenTo(int num) {
    if (num < 2) {
        return false;
    }

    for (int i = 2; i <= sqrt(num); i++) {
        if (num % i == 0) {
            return false;
        }
    }

    return true;
}

// Liệt kê các số nguyên tố trong mảng
void lietKeSoNguyenTo(const int A[], int n) {
    cout << "Cac so nguyen to trong mang:\n";
    for (int i = 0; i < n; i++) {
        if (laSoNguyenTo(A[i])) {
            cout << A[i] << " ";
        }
    }
    cout << endl;
}

// Kiểm tra số chính phương
bool laSoChinhPhuong(int num) {
    int sqrtNum = sqrt(num);
    return sqrtNum * sqrtNum == num;
}

// Liệt kê các số chính phương trong mảng
void lietKeSoChinhPhuong(const int A[], int n) {
    cout << "Cac so chinh phuong trong mang:\n";
    for (int i = 0; i < n; i++) {
        if (laSoChinhPhuong(A[i])) {
            cout << A[i] << " ";
        }
    }
    cout << endl;
}

// Sắp xếp mảng theo thứ tự tăng dần
void sapXepTangDan(int A[], int n) {
    for (int i = 0; i < n - 1; i++) {
        for (int j = i + 1; j < n; j++) {
            if (A[i] > A[j]) {
                swap(A[i], A[j]);
            }
        }
    }
}

// Sắp xếp mảng theo thứ tự giảm dần
void sapXepGiamDan(int A[], int n) {
    for (int i = 0; i < n - 1; i++) {
        for (int j = i + 1; j < n; j++) {
            if (A[i] < A[j]) {
                swap(A[i], A[j]);
            }
        }
    }
}

int main() {
    int n;
    int A[100];

    cout << "Nhap so phan tu cua mang (n < 100): ";
    cin >> n;

    nhapMang(A, n);
    xuatMang(A, n);

    int soPhanTuAm = demSoAm(A, n);
    cout << "So phan tu am trong mang: " << soPhanTuAm << endl;

    int maxVal = timMax(A, n);
    cout << "Phan tu Max trong mang: " << maxVal << endl;

    int minVal = timMin(A, n);
    cout << "Phan tu Min trong mang: " << minVal << endl;

    int maxAm, minDuong;
    timAmDuong(A, n, maxAm, minDuong);
    cout << "Phan tu am lon nhat trong mang: " << maxAm << endl;
    cout << "Phan tu duong be nhat trong mang: " << minDuong << endl;

    lietKeSoNguyenTo(A, n);

    lietKeSoChinhPhuong(A, n);

    sapXepTangDan(A, n);
    cout << "Mang sau khi sap xep tang dan:\n";
    xuatMang(A, n);

    sapXepGiamDan(A, n);
    cout << "Mang sau khi sap xep giam dan:\n";
    xuatMang(A, n);

    return 0;
}
