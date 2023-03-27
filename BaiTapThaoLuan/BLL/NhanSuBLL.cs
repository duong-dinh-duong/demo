using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using BaiTapThaoLuan.DTO;
//cần có thư viện xml để dùng các thư viện trong xml
//khai báo để sử dụng đối tượng trong lớp DTO bằng cách namespace.DTO
namespace BaiTapThaoLuan.BLL
{
    public class NhanSuBLL
    {
        XmlDocument doc = new XmlDocument();//khai báo đối tượng xml
        XmlElement root;
        string fileName = @"F:\XML VA UNG DUNG\BaiTapThaoLuan\BaiTapThaoLuan\NhanSu.xml";//cho @ để làm mất lỗi gạch dưới
        //hàm khởi tạo
        public NhanSuBLL()
        {
            doc.Load(fileName);//khi tạo đối tượng xml sẽ mặc định load file;
            root = doc.DocumentElement;// node gốc để khi truy vấn thì viết từ đây luôn sẽ dễ dàng hơn;
        }
        public void Them(NhanSuDTO NVMOI)
        {
            //tạo nút NhanVien mới
            XmlNode nvthem = doc.CreateElement("NhanVien");

            //tạo nút con của nhân viên là MaNV
            XmlElement MaNV = doc.CreateElement("MaNV");
            MaNV.InnerText = NVMOI.manv;//gán giá trị cho mã sách
            nvthem.AppendChild(MaNV);//thêm MaNV vào trong sách(sach nhận masach là con)

            XmlElement TenNV = doc.CreateElement("TenNV");
            TenNV.InnerText = NVMOI.tennv;
            nvthem.AppendChild(TenNV);

            XmlElement NamSinh = doc.CreateElement("NamSinh");
            NamSinh.InnerText = NVMOI.namsinh.ToString();
            // vì số lượng là kiểu int nên phải ép sang string
            nvthem.AppendChild(NamSinh);

            XmlElement DiaChi = doc.CreateElement("DiaChi");
            DiaChi.InnerText = NVMOI.diachi;
            nvthem.AppendChild(DiaChi);

            XmlElement SDT = doc.CreateElement("SDT");
            SDT.InnerText = NVMOI.sdt.ToString();
            nvthem.AppendChild(SDT);

            XmlElement PhongBan = doc.CreateElement("PhongBan");
            PhongBan.InnerText = NVMOI.phongban;
            nvthem.AppendChild(PhongBan);

            XmlElement ChucVu = doc.CreateElement("ChucVu");
            ChucVu.InnerText = NVMOI.chucvu;
            nvthem.AppendChild(ChucVu);

            XmlElement Luong = doc.CreateElement("Luong");
            Luong.InnerText = NVMOI.luong.ToString();
            nvthem.AppendChild(Luong);

            //sau khi tạo xong nhân viên, thì thêm nhân vien vào gốc root
            root.AppendChild(nvthem);
            doc.Save(fileName);//lưu dữ liệu

        }
        public void Sua(NhanSuDTO nvSua)
        {
            //lấy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode nvcu = root.SelectSingleNode("NhanVien[MaNV ='" + nvSua.manv + "']");
            //truy vấn từ root
            //SelectSingleNode là chọn một node có nv chứa ptu maNV + mã nvSua đưa vào;
            if (nvcu != null)
            {
                XmlNode nv_sua_xong = doc.CreateElement("NhanVien");

                //tạo nút con của nhân viên là MaNV
                XmlElement MaNV = doc.CreateElement("MaNV");
                MaNV.InnerText = nvSua.manv;//gán giá trị cho mã sách
                nv_sua_xong.AppendChild(MaNV);//thêm MaNV vào trong sách(sach nhận masach là con)

                XmlElement TenNV = doc.CreateElement("TenNV");
                TenNV.InnerText = nvSua.tennv;
                nv_sua_xong.AppendChild(TenNV);

                XmlElement NamSinh = doc.CreateElement("NamSinh");
                NamSinh.InnerText = nvSua.namsinh.ToString();// vì số lượng là kiểu int mà lại innertext nên phải ép kiểu
                nv_sua_xong.AppendChild(NamSinh);

                XmlElement DiaChi = doc.CreateElement("DiaChi");
                DiaChi.InnerText = nvSua.diachi;
                nv_sua_xong.AppendChild(DiaChi);

                XmlElement SDT = doc.CreateElement("SDT");
                SDT.InnerText = nvSua.sdt.ToString();
                nv_sua_xong.AppendChild(SDT);

                XmlElement PhongBan = doc.CreateElement("PhongBan");
                PhongBan.InnerText = nvSua.phongban;
                nv_sua_xong.AppendChild(PhongBan);

                XmlElement ChucVu = doc.CreateElement("ChucVu");
                ChucVu.InnerText = nvSua.chucvu;
                nv_sua_xong.AppendChild(ChucVu);

                XmlElement Luong = doc.CreateElement("Luong");
                Luong.InnerText = nvSua.luong.ToString();
                nv_sua_xong.AppendChild(Luong);

                //thay thế sách cũ bằng sách mới(sửa)
                root.ReplaceChild(nv_sua_xong, nvcu);
                //ReplaceChild là phương thức thay thế 2 đối tượng
                doc.Save(fileName);//lưu lại
            }
        }
        public void Xoa(NhanSuDTO nvXoa)
        {
            //tìm vị trí cần xóa
            XmlNode nv_can_xoa = root.SelectSingleNode("NhanVien[MaNV ='" + nvXoa.manv + "']");
            if (nv_can_xoa != null)
            {
                root.RemoveChild(nv_can_xoa);//RemoveChild là xóa con;

                doc.Save(fileName);
            }
        }
        public void TimKiem(NhanSuDTO nvTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            //tìm vị trí bằng câu lệnh truy vấn xpath
            XmlNode nvCanTim = root.SelectSingleNode("NhanVien[MaNV ='" + nvTim.manv + "']");
            if (nvCanTim != null)
            {
                dgv.ColumnCount = 8;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = nvCanTim.SelectSingleNode("MaNV").InnerText;

                dgv.Rows[0].Cells[1].Value = nvCanTim.SelectSingleNode("TenNV").InnerText;
                dgv.Rows[0].Cells[2].Value = nvCanTim.SelectSingleNode("NamSinh").InnerText;
                dgv.Rows[0].Cells[3].Value = nvCanTim.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[0].Cells[4].Value = nvCanTim.SelectSingleNode("SDT").InnerText;
                dgv.Rows[0].Cells[5].Value = nvCanTim.SelectSingleNode("PhongBan").InnerText;
                dgv.Rows[0].Cells[6].Value = nvCanTim.SelectSingleNode("ChucVu").InnerText;
                dgv.Rows[0].Cells[7].Value = nvCanTim.SelectSingleNode("Luong").InnerText;
            }
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 8;

            XmlNodeList ds = root.SelectNodes("NhanVien");
            //XmlNodeList là hiển thị danh sách
            //SelectNodes là chọn tất cả các node
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaNV").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenNV").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("NamSinh").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("SDT").InnerText;
                dgv.Rows[sd].Cells[5].Value = item.SelectSingleNode("PhongBan").InnerText;
                dgv.Rows[sd].Cells[6].Value = item.SelectSingleNode("ChucVu").InnerText;
                dgv.Rows[sd].Cells[7].Value = item.SelectSingleNode("Luong").InnerText;
                sd++;
            }
        }

    }
}
