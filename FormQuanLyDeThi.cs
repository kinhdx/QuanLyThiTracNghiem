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
    public partial class FormQuanLyDeThi : Form
    {
        // Khai báo chuỗi kết nối
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyThiTracNghiem;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;

        public FormQuanLyDeThi()
        {
            InitializeComponentc();
            LoadDeThi();
            LoadMonHoc();
        }

        private void InitializeComponentc()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTrangThai = new System.Windows.Forms.CheckBox();
            this.nudThoiGian = new System.Windows.Forms.NumericUpDown();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.txtTenDe = new System.Windows.Forms.TextBox();
            this.txtMaDe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvDeThi = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGian)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeThi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 150);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTrangThai);
            this.groupBox1.Controls.Add(this.nudThoiGian);
            this.groupBox1.Controls.Add(this.cboMonHoc);
            this.groupBox1.Controls.Add(this.txtTenDe);
            this.groupBox1.Controls.Add(this.txtMaDe);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đề thi";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.AutoSize = true;
            this.cbTrangThai.Checked = true;
            this.cbTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTrangThai.Location = new System.Drawing.Point(517, 105);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(82, 17);
            this.cbTrangThai.TabIndex = 5;
            this.cbTrangThai.Text = "Kích hoạt";
            this.cbTrangThai.UseVisualStyleBackColor = true;
            // 
            // nudThoiGian
            // 
            this.nudThoiGian.Location = new System.Drawing.Point(517, 67);
            this.nudThoiGian.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudThoiGian.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThoiGian.Name = "nudThoiGian";
            this.nudThoiGian.Size = new System.Drawing.Size(120, 20);
            this.nudThoiGian.TabIndex = 4;
            this.nudThoiGian.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(517, 30);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(200, 21);
            this.cboMonHoc.TabIndex = 3;
            // 
            // txtTenDe
            // 
            this.txtTenDe.Location = new System.Drawing.Point(163, 67);
            this.txtTenDe.Name = "txtTenDe";
            this.txtTenDe.Size = new System.Drawing.Size(200, 20);
            this.txtTenDe.TabIndex = 2;
            // 
            // txtMaDe
            // 
            this.txtMaDe.Location = new System.Drawing.Point(163, 30);
            this.txtMaDe.MaxLength = 10;
            this.txtMaDe.Name = "txtMaDe";
            this.txtMaDe.Size = new System.Drawing.Size(200, 20);
            this.txtMaDe.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(426, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Trạng thái:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thời gian (phút):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Môn học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đề:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đề:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 70);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 70);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(517, 30);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(163, 32);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(331, 20);
            this.txtTimKiem.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tìm kiếm đề thi:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnChiTiet);
            this.panel3.Controls.Add(this.btnXoa);
            this.panel3.Controls.Add(this.btnSua);
            this.panel3.Controls.Add(this.btnThem);
            this.panel3.Controls.Add(this.btnLamMoi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 220);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 50);
            this.panel3.TabIndex = 2;
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.Location = new System.Drawing.Point(573, 14);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(120, 23);
            this.btnChiTiet.TabIndex = 0;
            this.btnChiTiet.Text = "Chi tiết đề thi";
            this.btnChiTiet.UseVisualStyleBackColor = true;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(448, 14);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(327, 14);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 0;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(206, 14);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(82, 14);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 23);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvDeThi);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 270);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 230);
            this.panel4.TabIndex = 3;
            // 
            // dgvDeThi
            // 
            this.dgvDeThi.AllowUserToAddRows = false;
            this.dgvDeThi.AllowUserToDeleteRows = false;
            this.dgvDeThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeThi.Location = new System.Drawing.Point(0, 0);
            this.dgvDeThi.MultiSelect = false;
            this.dgvDeThi.Name = "dgvDeThi";
            this.dgvDeThi.ReadOnly = true;
            this.dgvDeThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeThi.Size = new System.Drawing.Size(800, 230);
            this.dgvDeThi.TabIndex = 0;
            this.dgvDeThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeThi_CellClick);
            // 
            // FormQuanLyDeThi
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormQuanLyDeThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Đề Thi";
            this.Load += new System.EventHandler(this.FormQuanLyDeThi_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGian)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeThi)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbTrangThai;
        private System.Windows.Forms.NumericUpDown nudThoiGian;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.TextBox txtTenDe;
        private System.Windows.Forms.TextBox txtMaDe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnChiTiet;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvDeThi;

        private void FormQuanLyDeThi_Load(object sender, EventArgs e)
        {
            LoadDeThi();
            LoadMonHoc();
        }

        private void LoadDeThi()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                string query = @"SELECT d.MaDe, d.TenDe, m.TenMH, d.ThoiGianLamBai, 
                               d.NgayTao, d.TrangThai, d.MaMH
                               FROM DeThi d 
                               JOIN MonHoc m ON d.MaMH = m.MaMH
                               ORDER BY d.NgayTao DESC";

                adapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvDeThi.DataSource = dataTable;

                // Thiết lập hiển thị cột
                if (dgvDeThi.Columns.Count > 0)
                {
                    dgvDeThi.Columns["MaDe"].HeaderText = "Mã đề";
                    dgvDeThi.Columns["TenDe"].HeaderText = "Tên đề";
                    dgvDeThi.Columns["TenMH"].HeaderText = "Môn học";
                    dgvDeThi.Columns["ThoiGianLamBai"].HeaderText = "Thời gian (phút)";
                    dgvDeThi.Columns["NgayTao"].HeaderText = "Ngày tạo";
                    dgvDeThi.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvDeThi.Columns["MaMH"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu đề thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonHoc()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                string query = "SELECT MaMH, TenMH FROM MonHoc ORDER BY TenMH";

                adapter = new SqlDataAdapter(query, connection);
                DataTable dtMonHoc = new DataTable();
                adapter.Fill(dtMonHoc);

                cboMonHoc.DataSource = dtMonHoc;
                cboMonHoc.DisplayMember = "TenMH";
                cboMonHoc.ValueMember = "MaMH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LamMoiForm()
        {
            txtMaDe.Text = "";
            txtTenDe.Text = "";
            nudThoiGian.Value = 60;
            cbTrangThai.Checked = true;
            txtMaDe.Enabled = true;

            if (cboMonHoc.Items.Count > 0)
                cboMonHoc.SelectedIndex = 0;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDe.Text) || string.IsNullOrWhiteSpace(txtTenDe.Text) || cboMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đề thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                // Kiểm tra mã đề thi đã tồn tại chưa
                string queryCheck = "SELECT COUNT(*) FROM DeThi WHERE MaDe = @MaDe";
                SqlCommand cmdCheck = new SqlCommand(queryCheck, connection);
                cmdCheck.Parameters.AddWithValue("@MaDe", txtMaDe.Text.Trim());
                int count = (int)cmdCheck.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã đề thi đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm đề thi mới
                string queryInsert = @"INSERT INTO DeThi(MaDe, MaMH, TenDe, ThoiGianLamBai, TrangThai)
                                     VALUES (@MaDe, @MaMH, @TenDe, @ThoiGianLamBai, @TrangThai)";

                SqlCommand cmdInsert = new SqlCommand(queryInsert, connection);
                cmdInsert.Parameters.AddWithValue("@MaDe", txtMaDe.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@MaMH", cboMonHoc.SelectedValue.ToString());
                cmdInsert.Parameters.AddWithValue("@TenDe", txtTenDe.Text.Trim());
                cmdInsert.Parameters.AddWithValue("@ThoiGianLamBai", (int)nudThoiGian.Value);
                cmdInsert.Parameters.AddWithValue("@TrangThai", cbTrangThai.Checked ? 1 : 0);

                cmdInsert.ExecuteNonQuery();

                MessageBox.Show("Thêm đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDeThi();
                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đề thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDe.Text) || string.IsNullOrWhiteSpace(txtTenDe.Text) || cboMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đề thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                // Cập nhật thông tin đề thi
                string queryUpdate = @"UPDATE DeThi
                                     SET MaMH = @MaMH, TenDe = @TenDe, 
                                         ThoiGianLamBai = @ThoiGianLamBai, TrangThai = @TrangThai
                                     WHERE MaDe = @MaDe";

                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connection);
                cmdUpdate.Parameters.AddWithValue("@MaDe", txtMaDe.Text.Trim());
                cmdUpdate.Parameters.AddWithValue("@MaMH", cboMonHoc.SelectedValue.ToString());
                cmdUpdate.Parameters.AddWithValue("@TenDe", txtTenDe.Text.Trim());
                cmdUpdate.Parameters.AddWithValue("@ThoiGianLamBai", (int)nudThoiGian.Value);
                cmdUpdate.Parameters.AddWithValue("@TrangThai", cbTrangThai.Checked ? 1 : 0);

                int rowsAffected = cmdUpdate.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDeThi();
                    LamMoiForm();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đề thi để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật đề thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDe.Text))
            {
                MessageBox.Show("Vui lòng chọn đề thi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đề thi này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    // Kiểm tra xem đề thi đã được sử dụng chưa
                    string queryCheck = "SELECT COUNT(*) FROM BaiThi WHERE MaDe = @MaDe";
                    SqlCommand cmdCheck = new SqlCommand(queryCheck, connection);
                    cmdCheck.Parameters.AddWithValue("@MaDe", txtMaDe.Text.Trim());
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa đề thi này vì đã có học sinh làm bài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xóa chi tiết đề thi trước
                    string queryDeleteDetail = "DELETE FROM ChiTietDeThi WHERE MaDe = @MaDe";
                    SqlCommand cmdDeleteDetail = new SqlCommand(queryDeleteDetail, connection);
                    cmdDeleteDetail.Parameters.AddWithValue("@MaDe", txtMaDe.Text.Trim());
                    cmdDeleteDetail.ExecuteNonQuery();

                    // Xóa đề thi
                    string queryDelete = "DELETE FROM DeThi WHERE MaDe = @MaDe";
                    SqlCommand cmdDelete = new SqlCommand(queryDelete, connection);
                    cmdDelete.Parameters.AddWithValue("@MaDe", txtMaDe.Text.Trim());

                    int rowsAffected = cmdDelete.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa đề thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDeThi();
                        LamMoiForm();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đề thi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa đề thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDe.Text))
            {
                MessageBox.Show("Vui lòng chọn đề thi để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ở đây bạn sẽ mở form chi tiết đề thi (có thể truyền mã đề qua để hiển thị chi tiết)
            MessageBox.Show("Chức năng xem chi tiết đề thi sẽ được triển khai trong form riêng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Ví dụ:
            // FormChiTietDeThi frm = new FormChiTietDeThi(txtMaDe.Text.Trim());
            // frm.ShowDialog();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                LoadDeThi();
                return;
            }

            try
            {
                connection = new SqlConnection(connectionString);
                string query = @"SELECT d.MaDe, d.TenDe, m.TenMH, d.ThoiGianLamBai, 
                               d.NgayTao, d.TrangThai, d.MaMH
                               FROM DeThi d 
                               JOIN MonHoc m ON d.MaMH = m.MaMH
                               WHERE d.MaDe LIKE @keyword OR d.TenDe LIKE @keyword OR m.TenMH LIKE @keyword
                               ORDER BY d.NgayTao DESC";

                adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + txtTimKiem.Text.Trim() + "%");

                dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvDeThi.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm đề thi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDeThi.Rows[e.RowIndex];

                txtMaDe.Text = row.Cells["MaDe"].Value.ToString();
                txtTenDe.Text = row.Cells["TenDe"].Value.ToString();

                // Chọn môn học
                string maMH = row.Cells["MaMH"].Value.ToString();
                for (int i = 0; i < cboMonHoc.Items.Count; i++)
                {
                    DataRowView drv = (DataRowView)cboMonHoc.Items[i];
                    if (drv["MaMH"].ToString() == maMH)
                    {
                        cboMonHoc.SelectedIndex = i;
                        break;
                    }
                }

                nudThoiGian.Value = Convert.ToDecimal(row.Cells["ThoiGianLamBai"].Value);
                cbTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);

                // Không cho phép sửa mã đề thi
                txtMaDe.Enabled = false;
            }
        }
    }
}
