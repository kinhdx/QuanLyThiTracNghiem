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
    public partial class FormNganHangCauHoi : Form
    {
        // Chuỗi kết nối database
        private string connectionString = DBConnection.ConnectionString();
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;

        public FormNganHangCauHoi()
        {
            InitializeComponentc();
        }

        private void InitializeComponentc()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.cboDoKho = new System.Windows.Forms.ComboBox();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtMaCH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCauHoi = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuanLyDapAn = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTrangThai);
            this.groupBox1.Controls.Add(this.cboDoKho);
            this.groupBox1.Controls.Add(this.cboMonHoc);
            this.groupBox1.Controls.Add(this.txtNoiDung);
            this.groupBox1.Controls.Add(this.txtMaCH);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin câu hỏi";
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Location = new System.Drawing.Point(137, 147);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(88, 20);
            this.chkTrangThai.TabIndex = 4;
            this.chkTrangThai.Text = "Kích hoạt";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // cboDoKho
            // 
            this.cboDoKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoKho.FormattingEnabled = true;
            this.cboDoKho.Location = new System.Drawing.Point(137, 117);
            this.cboDoKho.Name = "cboDoKho";
            this.cboDoKho.Size = new System.Drawing.Size(98, 24);
            this.cboDoKho.TabIndex = 3;
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(137, 87);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(235, 24);
            this.cboMonHoc.TabIndex = 2;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(137, 57);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(620, 24);
            this.txtNoiDung.TabIndex = 1;
            // 
            // txtMaCH
            // 
            this.txtMaCH.Location = new System.Drawing.Point(137, 27);
            this.txtMaCH.Name = "txtMaCH";
            this.txtMaCH.Size = new System.Drawing.Size(150, 22);
            this.txtMaCH.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Trạng thái:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Độ khó:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Môn học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nội dung:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã câu hỏi:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCauHoi);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 281);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách câu hỏi";
            // 
            // dgvCauHoi
            // 
            this.dgvCauHoi.AllowUserToAddRows = false;
            this.dgvCauHoi.AllowUserToDeleteRows = false;
            this.dgvCauHoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCauHoi.Location = new System.Drawing.Point(3, 18);
            this.dgvCauHoi.MultiSelect = false;
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.ReadOnly = true;
            this.dgvCauHoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCauHoi.Size = new System.Drawing.Size(770, 260);
            this.dgvCauHoi.TabIndex = 0;
            this.dgvCauHoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuanLyDapAn);
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Location = new System.Drawing.Point(12, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 59);
            this.panel1.TabIndex = 2;
            // 
            // btnQuanLyDapAn
            // 
            this.btnQuanLyDapAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyDapAn.Location = new System.Drawing.Point(359, 13);
            this.btnQuanLyDapAn.Name = "btnQuanLyDapAn";
            this.btnQuanLyDapAn.Size = new System.Drawing.Size(108, 33);
            this.btnQuanLyDapAn.TabIndex = 4;
            this.btnQuanLyDapAn.Text = "Quản lý đáp án";
            this.btnQuanLyDapAn.UseVisualStyleBackColor = true;
            this.btnQuanLyDapAn.Click += new System.EventHandler(this.btnQuanLyDapAn_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(271, 13);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(82, 33);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(183, 13);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 33);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(95, 13);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 33);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(7, 13);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 33);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(497, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 59);
            this.panel2.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(219, 13);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(69, 33);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(72, 19);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(141, 22);
            this.txtTimKiem.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tìm kiếm:";
            // 
            // FormNganHangCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormNganHangCauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý ngân hàng câu hỏi";
            this.Load += new System.EventHandler(this.FormNganHangCauHoi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCauHoi;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtMaCH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDoKho;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnQuanLyDapAn;

        private void FormNganHangCauHoi_Load(object sender, EventArgs e)
        {
            // Khởi tạo kết nối
            conn = new SqlConnection(connectionString);
            LoadMonHoc();
            LoadCauHoi();
            SetupCboDoKho();
        }

        private void SetupCboDoKho()
        {
            // Thiết lập combobox độ khó
            cboDoKho.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                cboDoKho.Items.Add(i.ToString());
            }
            cboDoKho.SelectedIndex = 0;
        }

        private void LoadMonHoc()
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT MaMH, TenMH FROM MonHoc", conn);
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();

                cboMonHoc.DataSource = dt;
                cboMonHoc.DisplayMember = "TenMH";
                cboMonHoc.ValueMember = "MaMH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCauHoi()
        {
            try
            {
                conn.Open();
                string query = @"SELECT ch.MaCH, ch.NoiDung, mh.TenMH, ch.DoKho, ch.NgayTao, 
                              CASE WHEN ch.TrangThai = 1 THEN N'Kích hoạt' ELSE N'Không kích hoạt' END AS TrangThai
                              FROM CauHoi ch 
                              INNER JOIN MonHoc mh ON ch.MaMH = mh.MaMH
                              ORDER BY ch.NgayTao DESC";
                cmd = new SqlCommand(query, conn);
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();

                dgvCauHoi.DataSource = dt;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi tải danh sách câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Định dạng DataGridView
            dgvCauHoi.Columns["MaCH"].HeaderText = "Mã câu hỏi";
            dgvCauHoi.Columns["NoiDung"].HeaderText = "Nội dung";
            dgvCauHoi.Columns["TenMH"].HeaderText = "Môn học";
            dgvCauHoi.Columns["DoKho"].HeaderText = "Độ khó";
            dgvCauHoi.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgvCauHoi.Columns["TrangThai"].HeaderText = "Trạng thái";

            dgvCauHoi.Columns["NoiDung"].Width = 300;
            dgvCauHoi.Columns["TenMH"].Width = 150;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCH.Text) || string.IsNullOrEmpty(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin câu hỏi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                // Kiểm tra mã câu hỏi đã tồn tại chưa
                cmd = new SqlCommand("SELECT COUNT(*) FROM CauHoi WHERE MaCH = @MaCH", conn);
                cmd.Parameters.AddWithValue("@MaCH", txtMaCH.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã câu hỏi đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    return;
                }

                // Thêm câu hỏi mới
                string query = @"INSERT INTO CauHoi (MaCH, NoiDung, MaMH, DoKho, NgayTao, TrangThai) 
                               VALUES (@MaCH, @NoiDung, @MaMH, @DoKho, GETDATE(), @TrangThai)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCH", txtMaCH.Text);
                cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
                cmd.Parameters.AddWithValue("@MaMH", cboMonHoc.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@DoKho", int.Parse(cboDoKho.Text));
                cmd.Parameters.AddWithValue("@TrangThai", chkTrangThai.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCauHoi();
                ClearForm();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi thêm câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCH.Text))
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                string query = @"UPDATE CauHoi 
                              SET NoiDung = @NoiDung, MaMH = @MaMH, DoKho = @DoKho, TrangThai = @TrangThai
                              WHERE MaCH = @MaCH";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCH", txtMaCH.Text);
                cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
                cmd.Parameters.AddWithValue("@MaMH", cboMonHoc.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@DoKho", int.Parse(cboDoKho.Text));
                cmd.Parameters.AddWithValue("@TrangThai", chkTrangThai.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Cập nhật câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCauHoi();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi cập nhật câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCH.Text))
            {
                MessageBox.Show("Vui lòng chọn câu hỏi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem câu hỏi có trong đề thi nào không
            try
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM ChiTietDeThi WHERE MaCH = @MaCH";
                cmd = new SqlCommand(checkQuery, conn);
                cmd.Parameters.AddWithValue("@MaCH", txtMaCH.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa câu hỏi này vì đã được sử dụng trong đề thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }

                // Xóa các đáp án của câu hỏi trước
                string deleteAnswersQuery = "DELETE FROM DapAn WHERE MaCH = @MaCH";
                cmd = new SqlCommand(deleteAnswersQuery, conn);
                cmd.Parameters.AddWithValue("@MaCH", txtMaCH.Text);
                cmd.ExecuteNonQuery();

                // Xóa câu hỏi
                string deleteQuery = "DELETE FROM CauHoi WHERE MaCH = @MaCH";
                cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@MaCH", txtMaCH.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Xóa câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCauHoi();
                ClearForm();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi xóa câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTimKiem.Text.Trim();
                conn.Open();
                string query = @"SELECT ch.MaCH, ch.NoiDung, mh.TenMH, ch.DoKho, ch.NgayTao, 
                              CASE WHEN ch.TrangThai = 1 THEN N'Kích hoạt' ELSE N'Không kích hoạt' END AS TrangThai
                              FROM CauHoi ch 
                              INNER JOIN MonHoc mh ON ch.MaMH = mh.MaMH
                              WHERE ch.MaCH LIKE @Search OR ch.NoiDung LIKE @Search OR mh.TenMH LIKE @Search
                              ORDER BY ch.NgayTao DESC";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();

                dgvCauHoi.DataSource = dt;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuanLyDapAn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCH.Text))
            {
                MessageBox.Show("Vui lòng chọn câu hỏi trước khi quản lý đáp án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở form quản lý đáp án - bạn cần tạo form này
            FormQuanLyDapAn formDapAn = new FormQuanLyDapAn(txtMaCH.Text);
            formDapAn.ShowDialog();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadCauHoi();
            txtTimKiem.Clear();
        }

        private void ClearForm()
        {
            txtMaCH.Clear();
            txtNoiDung.Clear();
            cboMonHoc.SelectedIndex = 0;
            cboDoKho.SelectedIndex = 0;
            chkTrangThai.Checked = true;
            txtMaCH.Enabled = true;
        }

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCauHoi.Rows[e.RowIndex];
                txtMaCH.Text = row.Cells["MaCH"].Value.ToString();
                txtNoiDung.Text = row.Cells["NoiDung"].Value.ToString();

                // Tìm và chọn giá trị trong combobox môn học
                for (int i = 0; i < cboMonHoc.Items.Count; i++)
                {
                    DataRowView drv = (DataRowView)cboMonHoc.Items[i];
                    if (drv["TenMH"].ToString() == row.Cells["TenMH"].Value.ToString())
                    {
                        cboMonHoc.SelectedIndex = i;
                        break;
                    }
                }

                cboDoKho.Text = row.Cells["DoKho"].Value.ToString();
                chkTrangThai.Checked = row.Cells["TrangThai"].Value.ToString() == "Kích hoạt";

                // Khi chọn câu hỏi từ datagridview, không cho phép sửa mã câu hỏi
                txtMaCH.Enabled = false;
            }
        }
    }
}
