using System;
using System.Collections.Generic;
using System.Globalization;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("Chọn chức năng:");
            Console.WriteLine("1. Tính độ dài đoạn thẳng AB");
            Console.WriteLine("2. Tính chu vi và diện tích hình tròn");
            Console.WriteLine("3. Giải phương trình bậc 2");
            Console.WriteLine("4. Tính lãi suất gửi tiết kiệm (1 khách hàng)");
            Console.WriteLine("5. Tính lãi suất gửi tiết kiệm (danh sách khách hàng)");
            Console.WriteLine("6. Tính thuế thu nhập cá nhân");
            Console.WriteLine("7. Tính tiền vay trả góp");
            Console.WriteLine("8. Quản lý sinh viên và điểm môn học");
            Console.WriteLine("0. Thoát");
            Console.Write("Nhập lựa chọn của bạn: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    TinhDoDaiAB();
                    break;
                case "2":
                    TinhHinhTron();
                    break;
                case "3":
                    GiaiPTBacHai();
                    break;
                case "4":
                    TinhLaiSuatGuiTietKiem();
                    break;
                case "5":
                    LaiDanhSach();
                    break;
                case "6":
                    TinhThueThuNhapCaNhan();
                    break;
                case "7":
                    TinhTienVayTraGop();
                    break;
                case "8":
                    QuanLySinhVien();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                    break;
            }
        }
    }
    static void TinhDoDaiAB()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập tọa độ điểm A (x1, y1): ");
        string[] toadoA = Console.ReadLine().Split();
        double x1 = double.Parse(toadoA[0]);
        double y1 = double.Parse(toadoA[1]);

        Console.Write("Nhập tọa độ điểm B (x2, y2): ");
        string[] toadoB = Console.ReadLine().Split();
        double x2 = double.Parse(toadoB[0]);
        double y2 = double.Parse(toadoB[1]);

        double dodaiAB = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

        Console.WriteLine($"Độ dài đoạn thẳng AB là: {dodaiAB:F2}");
    }
    static void TinhHinhTron()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập bán kính hình tròn: ");
        double r = double.Parse(Console.ReadLine());
        double chuVi = 2 * Math.PI * r;
        double dienTich = Math.PI * Math.Pow(r, 2);
        Console.WriteLine($"Chu vi hình tròn là: {chuVi:F2}");
        Console.WriteLine($"Diện tích hình tròn là: {dienTich:F2}");
    }
    static void GiaiPTBacHai()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập hệ số a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Nhập hệ số b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Nhập hệ số c: ");
        double c = double.Parse(Console.ReadLine());
        double delta = b * b - 4 * a * c;
        if(delta < 0)
        {
            Console.WriteLine("Phương trình vô nghiệm.");
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Phương trình có nghiệm kép: x = {x:F2}");
        }
        else
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"Phương trình có hai nghiệm phân biệt: x1 = {x1:F2}, x2 = {x2:F2}");
        }
    }
    static void TinhLaiSuatGuiTietKiem()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập tên khách hàng: ");
        string tenKhachHang = Console.ReadLine();
        Console.Write("Nhập số tiền gửi (VNĐ): ");
        double soTienGui = double.Parse(Console.ReadLine());
        Console.Write("Nhập Kỳ hạn gửi: ");
        int kyHan = int.Parse(Console.ReadLine());
        double laisuat = kyHan switch
        {
            3 or <6 => 0.032,
            >=6 and <=9 => 0.038,
            >=12 => 0.055,
            _ => throw new ArgumentException("Kỳ hạn không hợp lệ.")
        };
        double tienLai = soTienGui * laisuat * kyHan / 12;
        Console.WriteLine($"Khách hàng {tenKhachHang} sẽ nhận được số tiền lãi là: {tienLai:F2} VNĐ sau {kyHan} tháng.");
    }
    static void LaiDanhSach()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<(string Ten, double SoTienGui, int KyHan)> danhSachKhachHang = new List<(string, double, int)>();
        while (true)
        {
            Console.Write("Nhập tên khách hàng (hoặc 'exit' để kết thúc): ");
            string tenKhachHang = Console.ReadLine();
            if (tenKhachHang.ToLower() == "exit") break;
            Console.Write("Nhập số tiền gửi (VNĐ): ");
            double soTienGui = double.Parse(Console.ReadLine());
            Console.Write("Nhập Kỳ hạn gửi: ");
            int kyHan = int.Parse(Console.ReadLine());
            danhSachKhachHang.Add((tenKhachHang, soTienGui, kyHan));
        }
        foreach (var kh in danhSachKhachHang)
        {
            double laisuat = kh.KyHan switch
            {
                3 or < 6 => 0.032,
                >= 6 and <= 9 => 0.038,
                >= 12 => 0.055,
                _ => throw new ArgumentException("Kỳ hạn không hợp lệ.")
            };
            double tienLai = kh.SoTienGui * laisuat * kh.KyHan / 12;
            Console.WriteLine($"Khách hàng {kh.Ten} sẽ nhận được số tiền lãi là: {tienLai:F2} VNĐ sau {kh.KyHan} tháng.");
        }
    }
    static void TinhThueThuNhapCaNhan()
    {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Tên NV: ");
            string tenNV = Console.ReadLine();
            Console.Write("Nhập lương (triệu): ");
            double luong = double.Parse(Console.ReadLine());
            Console.Write("Nhập số người phụ thuộc: ");
            int soNguoiPhuThuoc = int.Parse(Console.ReadLine());
            double thuNhapChiuThue = luong - 11 - (soNguoiPhuThuoc * 4.4);
            double thue = 0;
            if (thuNhapChiuThue > 0)
            {
                if (thuNhapChiuThue < 60)
                {
                    thue = thuNhapChiuThue * 0.05;
                }
                else if (thuNhapChiuThue < 120)
                {
                    thue = thuNhapChiuThue * 0.1;
                }
            }
            Console.WriteLine($"Thuế TNCN của {tenNV} là : {thue:F2} triệu VNĐ");
    }
    static void TinhTienVayTraGop()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập tên khách hàng: ");
        string tenKH = Console.ReadLine();
        Console.Write("Nhập số tiền vay (triệu VNĐ): ");
        double soTienVay = double.Parse(Console.ReadLine());
        Console.Write("Nhập lãi suất hàng năm (%): ");
        double laiSuat = double.Parse(Console.ReadLine()) / 100;
        Console.Write("Nhập số tháng vay: ");
        int soThang = int.Parse(Console.ReadLine());
        double tienLai = soTienVay * laiSuat * soThang / 12;
        double tongTienTra = soTienVay + tienLai;
        double tienTraHangThang = tongTienTra / soThang;
        Console.WriteLine($"Khách hàng {tenKH} sẽ trả tổng cộng: {tongTienTra:F2} triệu VNĐ");
        Console.WriteLine($"Số tiền trả hàng tháng là: {tienTraHangThang:F2} triệu VNĐ");
    }
    static void QuanLySinhVien()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập họ tên sinh viên: ");
        string hoTen = Console.ReadLine();
        DateTime ngaySinh;
        while (true)
        {
            try
            {
                Console.Write("Nhập ngày sinh (dd/MM/yyyy): ");
                ngaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Định dạng ngày sinh không hợp lệ, vui lòng nhập lại.");
            }
        }
        Console.Write("Nhập tên môn học: ");
        string tenMonHoc = Console.ReadLine();
        double dg1 = NhapDiem("điểm chuyên càn");
        double dg2 = NhapDiem("điểm giữa kỳ");
        double diemthi = NhapDiem("điểm cuối kỳ");
        double diemMon = Math.Round(0.15 * dg1 + 0.23 * dg2 + 0.65 * diemthi, 1);
        string ketQua = diemMon >= 4 ? "Đạt" : "Không đạt";

        Console.WriteLine("\n=== Thông tin sinh viên ===");
        Console.WriteLine($"Họ tên: {hoTen}");
        Console.WriteLine($"Ngày sinh: {ngaySinh:dd/MM/yyyy}");
        Console.WriteLine($"Môn học: {tenMonHoc}");
        Console.WriteLine($"Điểm môn: {diemMon:F1}");
        Console.WriteLine($"Kết quả: {ketQua}");

    }
    static double NhapDiem(String tenDiem)
    {
        double diem = -1;
        while (true)
        {
            try
            {
                Console.Write($"Nhập điểm {tenDiem}: ");
                diem = double.Parse(Console.ReadLine());
                if (diem < 0 || diem > 10)
                {
                    Console.WriteLine("Điểm phải nằm trong khoảng từ 0 đến 10. Vui lòng nhập lại.");
                }
                return diem;
            }
            catch (FormatException)
            {
                Console.WriteLine("Định dạng điểm không hợp lệ. Vui lòng nhập lại.");
            }
        }
    }
}