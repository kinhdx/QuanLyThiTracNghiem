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
    public partial class FormQuanLyLopHoc : Form
    {
        private string connectionString = DBConnection.ConnectionString();
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public FormQuanLyLopHoc()
        {
            InitializeComponentc();
            LoadData();
        }

        private void InitializeComponentc()
        {
            this.dgvLopHoc = new System.Windows.Forms.DataGridView();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtKhoaHoc = new System.Windows.Forms.TextBox();
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.lblKhoaHoc = new System.Windows.Forms.Label();
            this.lblNienKhoa = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.grbThongTin = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).BeginInit();
            this.grbThongTin.SuspendLayout();
            this.SuspendLayout();

            // dgvLopHoc
            this.dgvLopHoc.AllowUserToAddRows = false;
            this.dgvLopHoc.AllowUserToDeleteRows = false;
            this.dgvLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopHoc.Location = new System.Drawing.Point(12, 216);
            this.dgvLopHoc.Name = "dgvLopHoc";
            this.dgvLopHoc.ReadOnly = true;
            this.dgvLopHoc.Size = new System.Drawing.Size(660, 333);
            this.dgvLopHoc.TabIndex = 0;
            this.dgvLopHoc.SelectionChanged += new System.EventHandler(this.dgvLopHoc_SelectionChanged);

            // grbThongTin
            this.grbThongTin.Controls.Add(this.txtNienKhoa);
            this.grbThongTin.Controls.Add(this.txtKhoaHoc);
            this.grbThongTin.Controls.Add(this.txtTenLop);
            this.grbThongTin.Controls.Add(this.txtMaLop);
            this.grbThongTin.Controls.Add(this.lblNienKhoa);
            this.grbThongTin.Controls.Add(this.lblKhoaHoc);
            this.grbThongTin.Controls.Add(this.lblTenLop);
            this.grbThongTin.Controls.Add(this.lblMaLop);
            this.grbThongTin.Location = new System.Drawing.Point(12, 12);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(450, 152);
            this.grbThongTin.TabIndex = 1;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin lớp học";

            // txtMaLop
            this.txtMaLop.Location = new System.Drawing.Point(120, 30);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(200, 20);
            this.txtMaLop.TabIndex = 0;

            // txtTenLop
            this.txtTenLop.Location = new System.Drawing.Point(120, 60);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(300, 20);
            this.txtTenLop.TabIndex = 1;

            // txtKhoaHoc
            this.txtKhoaHoc.Location = new System.Drawing.Point(120, 90);
            this.txtKhoaHoc.Name = "txtKhoaHoc";
            this.txtKhoaHoc.Size = new System.Drawing.Size(200, 20);
            this.txtKhoaHoc.TabIndex = 2;

            // txtNienKhoa
            this.txtNienKhoa.Location = new System.Drawing.Point(120, 120);
            this.txtNienKhoa.Name = "txtNienKhoa";
            this.txtNienKhoa.Size = new System.Drawing.Size(200, 20);
            this.txtNienKhoa.TabIndex = 3;

            // lblMaLop
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(20, 33);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(45, 13);
            this.lblMaLop.TabIndex = 4;
            this.lblMaLop.Text = "Mã lớp:";

            // lblTenLop
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Location = new System.Drawing.Point(20, 63);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(49, 13);
            this.lblTenLop.TabIndex = 5;
            this.lblTenLop.Text = "Tên lớp:";

            // lblKhoaHoc
            this.lblKhoaHoc.AutoSize = true;
            this.lblKhoaHoc.Location = new System.Drawing.Point(20, 93);
            this.lblKhoaHoc.Name = "lblKhoaHoc";
            this.lblKhoaHoc.Size = new System.Drawing.Size(58, 13);
            this.lblKhoaHoc.TabIndex = 6;
            this.lblKhoaHoc.Text = "Khóa học:";

            // lblNienKhoa
            this.lblNienKhoa.AutoSize = true;
            this.lblNienKhoa.Location = new System.Drawing.Point(20, 123);
            this.lblNienKhoa.Name = "lblNienKhoa";
            this.lblNienKhoa.Size = new System.Drawing.Size(61, 13);
            this.lblNienKhoa.TabIndex = 7;
            this.lblNienKhoa.Text = "Niên khóa:";

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(476, 22);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.Location = new System.Drawing.Point(476, 58);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(476, 94);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnLamMoi
            this.btnLamMoi.Location = new System.Drawing.Point(476, 130);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 30);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(12, 180);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(52, 13);
            this.lblTimKiem.TabIndex = 6;
            this.lblTimKiem.Text = "Tìm kiếm:";

            // txtTimKiem
            this.txtTimKiem.Location = new System.Drawing.Point(70, 177);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 20);
            this.txtTimKiem.TabIndex = 7;

            // btnTimKiem
            this.btnTimKiem.Location = new System.Drawing.Point(330, 175);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // FormQuanLyLopHoc
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.dgvLopHoc);
            this.Name = "FormQuanLyLopHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý lớp học";
            this.Load += new System.EventHandler(this.FormQuanLyLopHoc_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvLopHoc)).EndInit();
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DataGridView dgvLopHoc;
        private TextBox txtMaLop;
        private TextBox txtTenLop;
        private TextBox txtKhoaHoc;
        private TextBox txtNienKhoa;
        private Label lblMaLop;
        private Label lblTenLop;
        private Label lblKhoaHoc;
        private Label lblNienKhoa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private GroupBox grbThongTin;

        private void FormQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM LopHoc";
                dataAdapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvLopHoc.DataSource = dataTable;
                connection.Close();

                // Định dạng lại tên cột hiển thị
                dgvLopHoc.Columns["MaLop"].HeaderText = "Mã lớp";
                dgvLopHoc.Columns["TenLop"].HeaderText = "Tên lớp";
                dgvLopHoc.Columns["KhoaHoc"].HeaderText = "Khóa học";
                dgvLopHoc.Columns["NienKhoa"].HeaderText = "Niên khóa";

                // Điều chỉnh chiều rộng cột
                dgvLopHoc.Columns["MaLop"].Width = 80;
                dgvLopHoc.Columns["TenLop"].Width = 200;
                dgvLopHoc.Columns["KhoaHoc"].Width = 100;
                dgvLopHoc.Columns["NienKhoa"].Width = 120;

                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LamMoiForm()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtKhoaHoc.Text = "";
            txtNienKhoa.Text = "";
            txtMaLop.Enabled = true;
            txtMaLop.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text) || string.IsNullOrEmpty(txtTenLop.Text) ||
                string.IsNullOrEmpty(txtKhoaHoc.Text) || string.IsNullOrEmpty(txtNienKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                // Kiểm tra mã lớp đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM LopHoc WHERE MaLop = @MaLop";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã lớp đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return;
                }

                // Thêm lớp học mới
                string insertQuery = "INSERT INTO LopHoc (MaLop, TenLop, KhoaHoc, NienKhoa) VALUES (@MaLop, @TenLop, @KhoaHoc, @NienKhoa)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                insertCmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                insertCmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                insertCmd.Parameters.AddWithValue("@KhoaHoc", txtKhoaHoc.Text);
                insertCmd.Parameters.AddWithValue("@NienKhoa", txtNienKhoa.Text);

                insertCmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Thêm lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text) || string.IsNullOrEmpty(txtTenLop.Text) ||
                string.IsNullOrEmpty(txtKhoaHoc.Text) || string.IsNullOrEmpty(txtNienKhoa.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string updateQuery = "UPDATE LopHoc SET TenLop = @TenLop, KhoaHoc = @KhoaHoc, NienKhoa = @NienKhoa WHERE MaLop = @MaLop";
                SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                updateCmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                updateCmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                updateCmd.Parameters.AddWithValue("@KhoaHoc", txtKhoaHoc.Text);
                updateCmd.Parameters.AddWithValue("@NienKhoa", txtNienKhoa.Text);

                updateCmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Cập nhật thông tin lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp học để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    // Kiểm tra xem lớp có học sinh không
                    string checkStudentsQuery = "SELECT COUNT(*) FROM HocSinh WHERE MaLop = @MaLop";
                    SqlCommand checkCmd = new SqlCommand(checkStudentsQuery, connection);
                    checkCmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                    int studentCount = (int)checkCmd.ExecuteScalar();

                    if (studentCount > 0)
                    {
                        MessageBox.Show("Không thể xóa lớp học này vì đã có học sinh trong lớp!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        connection.Close();
                        return;
                    }

                    // Xóa lớp học
                    string deleteQuery = "DELETE FROM LopHoc WHERE MaLop = @MaLop";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);

                    deleteCmd.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Xóa lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string searchQuery = "SELECT * FROM LopHoc WHERE MaLop LIKE @Keyword OR TenLop LIKE @Keyword OR KhoaHoc LIKE @Keyword OR NienKhoa LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(searchQuery, connection);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                dataAdapter = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvLopHoc.DataSource = dataTable;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLopHoc.CurrentRow != null)
            {
                txtMaLop.Text = dgvLopHoc.CurrentRow.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = dgvLopHoc.CurrentRow.Cells["TenLop"].Value.ToString();
                txtKhoaHoc.Text = dgvLopHoc.CurrentRow.Cells["KhoaHoc"].Value.ToString();
                txtNienKhoa.Text = dgvLopHoc.CurrentRow.Cells["NienKhoa"].Value.ToString();

                // Không cho phép sửa mã lớp
                txtMaLop.Enabled = false;
            }
        }
    }
}
