using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyLuong
{
    public partial class QuanLyTienLuong : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public QuanLyTienLuong()
        {
            InitializeComponent();
        }

        private void QuanLyTienLuong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyTienLuongDataSet4.bKhauTru' table. You can move, or remove it, as needed.
            this.bKhauTruTableAdapter.Fill(this.quanLyTienLuongDataSet4.bKhauTru);
            // TODO: This line of code loads data into the 'quanLyTienLuongDataSet3.bThuong' table. You can move, or remove it, as needed.
            this.bThuongTableAdapter.Fill(this.quanLyTienLuongDataSet3.bThuong);
            // TODO: This line of code loads data into the 'quanLyTienLuongDataSet2.bNgayCong' table. You can move, or remove it, as needed.
            this.bNgayCongTableAdapter.Fill(this.quanLyTienLuongDataSet2.bNgayCong);
            // TODO: This line of code loads data into the 'quanLyTienLuongDataSet1.bTroCap' table. You can move, or remove it, as needed.
            this.bTroCapTableAdapter.Fill(this.quanLyTienLuongDataSet1.bTroCap);
            // TODO: This line of code loads data into the 'quanLyTienLuongDataSet.bBacLuong' table. You can move, or remove it, as needed.
            this.bBacLuongTableAdapter.Fill(this.quanLyTienLuongDataSet.bBacLuong);
            HienDataGrid_QLTL();
        }
        private void HienDataGrid_QLTL()
        {
            try
            {
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("select a.MaNhanVien,HoDem,Ten,PhongBan,ChucVu,TenBacLuong,TenTroCap,a.MaNgayCong,TenThuong,TenKhauTru,SoTienLuong,ThanhToan from bThongTinNhanVien a left join bBacLuong b ON a.MaBacLuong=b.MaBacLuong left join bTroCap c ON a.MaTroCap=c.MaTroCap left join bNgayCong d On a.MaNgayCong=d.MaNgayCong left join bThuong e on a.MaThuong=e.MaThuong left join bKhauTru f on a.MaKhauTru=f.MaKhauTru left join bLuong g on a.MaNhanVien=g.MaNhanVien", conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "NhanVien");
                
                dtGrid_QLTL.DataSource = ds.Tables["NhanVien"].DefaultView;
                conn.Close();

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }
 
        }

        private void btnQLL_TimKiem_Click(object sender, EventArgs e)
        {
            string TKMaNV = txtTimMa.Text;
            string TKTenNV = txtTimTen.Text;
            try
            {
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("select a.MaNhanVien,HoDem,Ten,PhongBan,ChucVu,TenBacLuong,TenTroCap,a.MaNgayCong,TenThuong,TenKhauTru,SoTienLuong,ThanhToan from bThongTinNhanVien a left join bBacLuong b ON a.MaBacLuong=b.MaBacLuong left join bTroCap c ON a.MaTroCap=c.MaTroCap left join bNgayCong d On a.MaNgayCong=d.MaNgayCong left join bThuong e on a.MaThuong=e.MaThuong left join bKhauTru f on a.MaKhauTru=f.MaKhauTru left join bLuong g on a.MaNhanVien=g.MaNhanVien where  a.MaNhanVien ='" + TKMaNV + "' or a.Ten like'" + TKTenNV + "'", conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "TimKiem");
                dtGrid_QLTL.DataSource = ds.Tables["TimKiem"].DefaultView;
                conn.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }
        }
        private string MaNV;
        private void btnQLL_Xem_Click(object sender, EventArgs e)
        {
            if (dtGrid_QLTL.CurrentRow != null)
            {
                MaNV            = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[0].Value.ToString();
                txtHoDem.Text   = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[1].Value.ToString();
                txtTen.Text     = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[2].Value.ToString();
                cbPhongBan.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[3].Value.ToString();
                txtChucVu.Text  = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[4].Value.ToString();
                cbBacLuong.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[5].Value.ToString();
                cbTroCap.Text     = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[6].Value.ToString();
                cbNgayCong.Text   = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[7].Value.ToString();
                cbThuong.Text     = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[8].Value.ToString();
                cbKhauTru.Text    = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[9].Value.ToString();
                txtTongLuong.Text = dtGrid_QLTL.Rows[dtGrid_QLTL.CurrentRow.Index].Cells[10].Value.ToString();
            }
            HienDataGrid_QLTL();
        }

        private void btnQLL_Tinh_Click(object sender, EventArgs e)
        {
            int BacLuong, TroCap, NgayCong, Thuong, KhauTru, TongLuong;
            BacLuong = Convert.ToInt32(cbBacLuong.SelectedValue.ToString());
            TroCap   = Convert.ToInt32(cbTroCap.SelectedValue.ToString());
            NgayCong = Convert.ToInt32(cbNgayCong.SelectedValue.ToString());
            Thuong   = Convert.ToInt32(cbThuong.SelectedValue.ToString());
            KhauTru  = Convert.ToInt32(cbKhauTru.SelectedValue.ToString());
            TongLuong = ((BacLuong + TroCap) / 23) * NgayCong + Thuong - KhauTru;
            txtTongLuong.Text = TongLuong.ToString();
            //MessageBox.Show(TongLuong);
        }

        private void btnQLL_CapNhat_Click(object sender, EventArgs e)
        {
            if (txtTen.Text != "")
            {
                //Tim MaThuong,MaTroCap,MaNgayCong,MaBacLuong,MaKhauTru cua 1 Nhan Vien
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                String str = "select MaBacLuong,MaTroCap,MaThuong,MaKhauTru from bBacLuong,bTroCap,bThuong,bKhauTru where TenBacLuong='" + cbBacLuong.Text + "' and TenTroCap='" + cbTroCap.Text + "' and TenThuong='" + cbThuong.Text + "' and TenKhauTru='" + cbKhauTru.Text + "'";
                SqlCommand commnd;
                commnd = new SqlCommand(str, conn);
                SqlDataAdapter sqlda;
                sqlda = new SqlDataAdapter(commnd);
                DataSet dataset = new DataSet();
                sqlda.Fill(dataset, "MaLuong");
                DataTable dataTB = new DataTable();
                dataTB = dataset.Tables["MaLuong"];
                string MaBL = dataTB.Rows[0]["MaBacLuong"].ToString();
                string MaTC = dataTB.Rows[0]["MaTroCap"].ToString();
                string MaT = dataTB.Rows[0]["MaThuong"].ToString();
                string MaKT = dataTB.Rows[0]["MaKhauTru"].ToString();
                string MaNC = cbNgayCong.Text;
                conn.Close();

                //Cap Nhat thong tin ve luong cho NV
                try
                {
                    conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                    conn.Open();
                    string strCommand;
                    strCommand = "Update bThongTinNhanVien Set MaBacLuong='" + MaBL + "',MaTroCap='" + MaTC + "',MaNgayCong='" + MaNC + "',MaThuong='" + MaT + "',MaKhauTru='" + MaKT + "' where MaNhanVien='" + MaNV + "'";
                    SqlCommand updateCommnd;
                    updateCommnd = new SqlCommand(strCommand, conn);
                    updateCommnd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    MessageBox.Show(excep.StackTrace);
                }

                //Kiem tra Nhan Vien ung voi MaNhanVien do da co luong trong bLuong hay chua!

                try
                {
                    int TongLuong = Convert.ToInt32(txtTongLuong.Text);
                    conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                    conn.Open();
                    string strCommand1;
                    strCommand1 = "Update bLuong set SoTienLuong=" + TongLuong + ",ThanhToan=" + 0 + " where MaNhanVien='" + MaNV + "'";
                    SqlCommand selectUpdate_bLuong;
                    selectUpdate_bLuong = new SqlCommand(strCommand1, conn);
                    selectUpdate_bLuong.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    MessageBox.Show(excep.StackTrace);
                }

                HienDataGrid_QLTL();
                MessageBox.Show("Đã Cập Nhật Dữ Liệu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


    }
}