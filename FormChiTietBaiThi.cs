using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class FormChiTietBaiThi : Form
    {
        private string connectionString = DBConnection.ConnectionString();
        private SqlConnection connection;
        private string maBaiThi;

        public FormChiTietBaiThi(string maBaiThi)
        {
            InitializeComponentc();
            this.maBaiThi = maBaiThi;
            connection = new SqlConnection(connectionString);
        }

        private void FormChiTietBaiThi_Load(object sender, EventArgs e)
        {
            LoadThongTinBaiThi();
            LoadChiTietBaiLam();
        }

        private void LoadThongTinBaiThi()
        {
            try
            {
                connection.Open();
                string query = @"
                    SELECT 
                        bt.MaBaiThi, 
                        hs.HoTen, 
                        lh.TenLop,
                        mh.TenMH, 
                        dt.TenDe,
                        bt.NgayThi, 
                        bt.ThoiGianBatDau, 
                        bt.ThoiGianKetThuc, 
                        bt.Diem,
                        bt.TrangThai
                    FROM BaiThi bt
                    INNER JOIN HocSinh hs ON bt.MaHS = hs.MaHS
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    INNER JOIN DeThi dt ON bt.MaDe = dt.MaDe
                    INNER JOIN MonHoc mh ON dt.MaMH = mh.MaMH
                    WHERE bt.MaBaiThi = @MaBaiThi";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaBaiThi", maBaiThi);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    lblMaBaiThi.Text = reader["MaBaiThi"].ToString();
                    lblHoTen.Text = reader["HoTen"].ToString();
                    lblLop.Text = reader["TenLop"].ToString();
                    lblMonHoc.Text = reader["TenMH"].ToString();
                    lblDeThi.Text = reader["TenDe"].ToString();
                    lblNgayThi.Text = Convert.ToDateTime(reader["NgayThi"]).ToString("dd/MM/yyyy HH:mm:ss");

                    if (reader["ThoiGianBatDau"] != DBNull.Value)
                        lblThoiGianBatDau.Text = Convert.ToDateTime(reader["ThoiGianBatDau"]).ToString("dd/MM/yyyy HH:mm:ss");

                    if (reader["ThoiGianKetThuc"] != DBNull.Value)
                        lblThoiGianKetThuc.Text = Convert.ToDateTime(reader["ThoiGianKetThuc"]).ToString("dd/MM/yyyy HH:mm:ss");

                    lblDiem.Text = reader["Diem"].ToString();

                    int trangThai = Convert.ToInt32(reader["TrangThai"]);
                    switch (trangThai)
                    {
                        case 0:
                            lblTrangThai.Text = "Chưa thi";
                            break;
                        case 1:
                            lblTrangThai.Text = "Đang thi";
                            break;
                        case 2:
                            lblTrangThai.Text = "Đã nộp bài";
                            break;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin bài thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadChiTietBaiLam()
        {
            try
            {
                connection.Open();
                string query = @"
                    SELECT 
                        ch.MaCH,
                        ch.NoiDung AS NoiDungCauHoi,
                        da.NoiDung AS NoiDungDapAn,
                        da.LaDapAnDung,
                        CASE 
                            WHEN da.LaDapAnDung = 1 THEN N'Đúng'
                            ELSE N'Sai'
                        END AS KetQua
                    FROM ChiTietBaiLam ctbl
                    INNER JOIN CauHoi ch ON ctbl.MaCH = ch.MaCH
                    INNER JOIN DapAn da ON ctbl.MaDA = da.MaDA
                    WHERE ctbl.MaBaiThi = @MaBaiThi
                    ORDER BY ch.MaCH";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@MaBaiThi", maBaiThi);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvChiTietBaiLam.DataSource = dataTable;

                // Format datagridview
                dgvChiTietBaiLam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvChiTietBaiLam.Columns["MaCH"].HeaderText = "Mã câu hỏi";
                dgvChiTietBaiLam.Columns["NoiDungCauHoi"].HeaderText = "Nội dung câu hỏi";
                dgvChiTietBaiLam.Columns["NoiDungDapAn"].HeaderText = "Nội dung đáp án";
                dgvChiTietBaiLam.Columns["LaDapAnDung"].Visible = false;
                dgvChiTietBaiLam.Columns["KetQua"].HeaderText = "Kết quả";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết bài làm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponentc()
        {
            this.lblMaBaiThiTitle = new System.Windows.Forms.Label();
            this.lblMaBaiThi = new System.Windows.Forms.Label();
            this.lblHoTenTitle = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblLopTitle = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblMonHocTitle = new System.Windows.Forms.Label();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.lblDeThiTitle = new System.Windows.Forms.Label();
            this.lblDeThi = new System.Windows.Forms.Label();
            this.lblNgayThiTitle = new System.Windows.Forms.Label();
            this.lblNgayThi = new System.Windows.Forms.Label();
            this.lblThoiGianBatDauTitle = new System.Windows.Forms.Label();
            this.lblThoiGianBatDau = new System.Windows.Forms.Label();
            this.lblThoiGianKetThucTitle = new System.Windows.Forms.Label();
            this.lblThoiGianKetThuc = new System.Windows.Forms.Label();
            this.lblDiemTitle = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.lblTrangThaiTitle = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.dgvChiTietBaiLam = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBaiLam)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // label1
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHI TIẾT BÀI THI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panel1
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTrangThai);
            this.panel1.Controls.Add(this.lblTrangThaiTitle);
            this.panel1.Controls.Add(this.lblDiem);
            this.panel1.Controls.Add(this.lblDiemTitle);
            this.panel1.Controls.Add(this.lblThoiGianKetThuc);
            this.panel1.Controls.Add(this.lblThoiGianKetThucTitle);
            this.panel1.Controls.Add(this.lblThoiGianBatDau);
            this.panel1.Controls.Add(this.lblThoiGianBatDauTitle);
            this.panel1.Controls.Add(this.lblNgayThi);
            this.panel1.Controls.Add(this.lblNgayThiTitle);
            this.panel1.Controls.Add(this.lblDeThi);
            this.panel1.Controls.Add(this.lblDeThiTitle);
            this.panel1.Controls.Add(this.lblMonHoc);
            this.panel1.Controls.Add(this.lblMonHocTitle);
            this.panel1.Controls.Add(this.lblLop);
            this.panel1.Controls.Add(this.lblLopTitle);
            this.panel1.Controls.Add(this.lblHoTen);
            this.panel1.Controls.Add(this.lblHoTenTitle);
            this.panel1.Controls.Add(this.lblMaBaiThi);
            this.panel1.Controls.Add(this.lblMaBaiThiTitle);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 150);
            this.panel1.TabIndex = 1;

            // lblMaBaiThiTitle
            this.lblMaBaiThiTitle.AutoSize = true;
            this.lblMaBaiThiTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMaBaiThiTitle.Location = new System.Drawing.Point(10, 10);
            this.lblMaBaiThiTitle.Name = "lblMaBaiThiTitle";
            this.lblMaBaiThiTitle.Size = new System.Drawing.Size(80, 13);
            this.lblMaBaiThiTitle.TabIndex = 0;
            this.lblMaBaiThiTitle.Text = "Mã bài thi:";

            // lblMaBaiThi
            this.lblMaBaiThi.AutoSize = true;
            this.lblMaBaiThi.Location = new System.Drawing.Point(100, 10);
            this.lblMaBaiThi.Name = "lblMaBaiThi";
            this.lblMaBaiThi.Size = new System.Drawing.Size(25, 13);
            this.lblMaBaiThi.TabIndex = 1;
            this.lblMaBaiThi.Text = "...";

            // lblHoTenTitle
            this.lblHoTenTitle.AutoSize = true;
            this.lblHoTenTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblHoTenTitle.Location = new System.Drawing.Point(10, 35);
            this.lblHoTenTitle.Name = "lblHoTenTitle";
            this.lblHoTenTitle.Size = new System.Drawing.Size(80, 13);
            this.lblHoTenTitle.TabIndex = 2;
            this.lblHoTenTitle.Text = "Họ tên:";

            // lblHoTen
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(100, 35);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(25, 13);
            this.lblHoTen.TabIndex = 3;
            this.lblHoTen.Text = "...";

            // lblLopTitle
            this.lblLopTitle.AutoSize = true;
            this.lblLopTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLopTitle.Location = new System.Drawing.Point(10, 60);
            this.lblLopTitle.Name = "lblLopTitle";
            this.lblLopTitle.Size = new System.Drawing.Size(80, 13);
            this.lblLopTitle.TabIndex = 4;
            this.lblLopTitle.Text = "Lớp:";

            // lblLop
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(100, 60);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(25, 13);
            this.lblLop.TabIndex = 5;
            this.lblLop.Text = "...";

            // lblMonHocTitle
            this.lblMonHocTitle.AutoSize = true;
            this.lblMonHocTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMonHocTitle.Location = new System.Drawing.Point(10, 85);
            this.lblMonHocTitle.Name = "lblMonHocTitle";
            this.lblMonHocTitle.Size = new System.Drawing.Size(80, 13);
            this.lblMonHocTitle.TabIndex = 6;
            this.lblMonHocTitle.Text = "Môn học:";

            // lblMonHoc
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(100, 85);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(25, 13);
            this.lblMonHoc.TabIndex = 7;
            this.lblMonHoc.Text = "...";

            // lblDeThiTitle
            this.lblDeThiTitle.AutoSize = true;
            this.lblDeThiTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDeThiTitle.Location = new System.Drawing.Point(10, 110);
            this.lblDeThiTitle.Name = "lblDeThiTitle";
            this.lblDeThiTitle.Size = new System.Drawing.Size(80, 13);
            this.lblDeThiTitle.TabIndex = 8;
            this.lblDeThiTitle.Text = "Đề thi:";

            // lblDeThi
            this.lblDeThi.AutoSize = true;
            this.lblDeThi.Location = new System.Drawing.Point(100, 110);
            this.lblDeThi.Name = "lblDeThi";
            this.lblDeThi.Size = new System.Drawing.Size(25, 13);
            this.lblDeThi.TabIndex = 9;
            this.lblDeThi.Text = "...";

            // lblNgayThiTitle
            this.lblNgayThiTitle.AutoSize = true;
            this.lblNgayThiTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNgayThiTitle.Location = new System.Drawing.Point(400, 10);
            this.lblNgayThiTitle.Name = "lblNgayThiTitle";
            this.lblNgayThiTitle.Size = new System.Drawing.Size(80, 13);
            this.lblNgayThiTitle.TabIndex = 10;
            this.lblNgayThiTitle.Text = "Ngày thi:";

            // lblNgayThi
            this.lblNgayThi.AutoSize = true;
            this.lblNgayThi.Location = new System.Drawing.Point(490, 10);
            this.lblNgayThi.Name = "lblNgayThi";
            this.lblNgayThi.Size = new System.Drawing.Size(25, 13);
            this.lblNgayThi.TabIndex = 11;
            this.lblNgayThi.Text = "...";

            // lblThoiGianBatDauTitle
            this.lblThoiGianBatDauTitle.AutoSize = true;
            this.lblThoiGianBatDauTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThoiGianBatDauTitle.Location = new System.Drawing.Point(400, 35);
            this.lblThoiGianBatDauTitle.Name = "lblThoiGianBatDauTitle";
            this.lblThoiGianBatDauTitle.Size = new System.Drawing.Size(80, 13);
            this.lblThoiGianBatDauTitle.TabIndex = 12;
            this.lblThoiGianBatDauTitle.Text = "TG bắt đầu:";

            // lblThoiGianBatDau
            this.lblThoiGianBatDau.AutoSize = true;
            this.lblThoiGianBatDau.Location = new System.Drawing.Point(490, 35);
            this.lblThoiGianBatDau.Name = "lblThoiGianBatDau";
            this.lblThoiGianBatDau.Size = new System.Drawing.Size(25, 13);
            this.lblThoiGianBatDau.TabIndex = 13;
            this.lblThoiGianBatDau.Text = "...";

            // lblThoiGianKetThucTitle
            this.lblThoiGianKetThucTitle.AutoSize = true;
            this.lblThoiGianKetThucTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblThoiGianKetThucTitle.Location = new System.Drawing.Point(400, 60);
            this.lblThoiGianKetThucTitle.Name = "lblThoiGianKetThucTitle";
            this.lblThoiGianKetThucTitle.Size = new System.Drawing.Size(80, 13);
            this.lblThoiGianKetThucTitle.TabIndex = 14;
            this.lblThoiGianKetThucTitle.Text = "TG kết thúc:";

            // lblThoiGianKetThuc
            this.lblThoiGianKetThuc.AutoSize = true;
            this.lblThoiGianKetThuc.Location = new System.Drawing.Point(490, 60);
            this.lblThoiGianKetThuc.Name = "lblThoiGianKetThuc";
            this.lblThoiGianKetThuc.Size = new System.Drawing.Size(25, 13);
            this.lblThoiGianKetThuc.TabIndex = 15;
            this.lblThoiGianKetThuc.Text = "...";

            // lblDiemTitle
            this.lblDiemTitle.AutoSize = true;
            this.lblDiemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDiemTitle.Location = new System.Drawing.Point(400, 85);
            this.lblDiemTitle.Name = "lblDiemTitle";
            this.lblDiemTitle.Size = new System.Drawing.Size(80, 13);
            this.lblDiemTitle.TabIndex = 16;
            this.lblDiemTitle.Text = "Điểm:";

            // lblDiem
            this.lblDiem.AutoSize = true;
            this.lblDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDiem.Location = new System.Drawing.Point(490, 85);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(25, 13);
            this.lblDiem.TabIndex = 17;
            this.lblDiem.Text = "...";

            // lblTrangThaiTitle
            this.lblTrangThaiTitle.AutoSize = true;
            this.lblTrangThaiTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiTitle.Location = new System.Drawing.Point(400, 110);
            this.lblTrangThaiTitle.Name = "lblTrangThaiTitle";
            this.lblTrangThaiTitle.Size = new System.Drawing.Size(80, 13);
            this.lblTrangThaiTitle.TabIndex = 18;
            this.lblTrangThaiTitle.Text = "Trạng thái:";

            // lblTrangThai
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(490, 110);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(25, 13);
            this.lblTrangThai.TabIndex = 19;
            this.lblTrangThai.Text = "...";

            // dgvChiTietBaiLam
            this.dgvChiTietBaiLam.AllowUserToAddRows = false;
            this.dgvChiTietBaiLam.AllowUserToDeleteRows = false;
            this.dgvChiTietBaiLam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietBaiLam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietBaiLam.Location = new System.Drawing.Point(12, 200);
            this.dgvChiTietBaiLam.Name = "dgvChiTietBaiLam";
            this.dgvChiTietBaiLam.ReadOnly = true;
            this.dgvChiTietBaiLam.Size = new System.Drawing.Size(776, 300);
            this.dgvChiTietBaiLam.TabIndex = 2;

            // btnDong
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(713, 510);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 28);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            // FormChiTietBaiThi
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvChiTietBaiLam);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormChiTietBaiThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết bài thi";
            this.Load += new System.EventHandler(this.FormChiTietBaiThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBaiLam)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMaBaiThiTitle;
        private System.Windows.Forms.Label lblMaBaiThi;
        private System.Windows.Forms.Label lblHoTenTitle;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblLopTitle;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblMonHocTitle;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.Label lblDeThiTitle;
        private System.Windows.Forms.Label lblDeThi;
        private System.Windows.Forms.Label lblNgayThiTitle;
        private System.Windows.Forms.Label lblNgayThi;
        private System.Windows.Forms.Label lblThoiGianBatDauTitle;
        private System.Windows.Forms.Label lblThoiGianBatDau;
        private System.Windows.Forms.Label lblThoiGianKetThucTitle;
        private System.Windows.Forms.Label lblThoiGianKetThuc;
        private System.Windows.Forms.Label lblDiemTitle;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Label lblTrangThaiTitle;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.DataGridView dgvChiTietBaiLam;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
