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
    public partial class FormQuanLyHocSinh : Form
    {
        private string connectionString = DBConnection.ConnectionString();
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        private Panel panel1;
        private Label lblHeader;
        private GroupBox gbSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private GroupBox gbInfo;
        private Label lblMaHS;
        private TextBox txtMaHS;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private RadioButton radNam;
        private RadioButton radNu;
        private Label lblDiaChi;
        private TextBox txtDiaChi;

        //c
        private TextBox txtRating;
        private Label lblRating;


        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblMaLop;
        private ComboBox cboMaLop;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Panel panel2;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnHuy;
        private DataGridView dgvHocSinh;

        public FormQuanLyHocSinh()
        {
            InitializeComponentc();
            LoadClassList();
            LoadStudentData();
        }

        private void InitializeComponentc()
        {
            panel1 = new Panel();
            lblHeader = new Label();
            gbSearch = new GroupBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            gbInfo = new GroupBox();
            lblMaHS = new Label();
            txtMaHS = new TextBox();

            //c
            txtRating = new TextBox();
            lblRating = new Label();

            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            radNam = new RadioButton();
            radNu = new RadioButton();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblMaLop = new Label();
            cboMaLop = new ComboBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            panel2 = new Panel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            dgvHocSinh = new DataGridView();

            // Panel 1 - Header
            panel1.Dock = DockStyle.Top;
            panel1.Height = 0;
            panel1.BackColor = Color.FromArgb(0, 150, 136);

            //// Header Label
            //lblHeader.Text = "QUẢN LÝ HỌC SINH";
            //lblHeader.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            //lblHeader.ForeColor = Color.White;
            //lblHeader.Dock = DockStyle.Fill;
            //lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            //panel1.Controls.Add(lblHeader);

            // Search GroupBox
            gbSearch.Text = "Tìm kiếm";
            gbSearch.Font = new Font("Microsoft Sans Serif", 10F);
            gbSearch.Location = new Point(12, 70);
            gbSearch.Size = new Size(976, 60);

            txtSearch.Location = new Point(20, 22);
            txtSearch.Size = new Size(800, 26);
            txtSearch.Text = "Nhập mã hoặc tên học sinh...";

            btnSearch.Text = "Tìm kiếm";
            btnSearch.Location = new Point(840, 22);
            btnSearch.Size = new Size(120, 30);
            btnSearch.BackColor = Color.FromArgb(0, 150, 136);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Click += new EventHandler(btnSearch_Click);

            gbSearch.Controls.Add(txtSearch);
            gbSearch.Controls.Add(btnSearch);

            // Student Info GroupBox
            gbInfo.Text = "Thông tin học sinh";
            gbInfo.Font = new Font("Microsoft Sans Serif", 10F);
            gbInfo.Location = new Point(12, 140);
            gbInfo.Size = new Size(976, 230);

            // Student ID
            lblMaHS.Text = "Mã học sinh:";
            lblMaHS.Location = new Point(20, 30);
            lblMaHS.AutoSize = true;

            txtMaHS.Location = new Point(120, 30);
            txtMaHS.Size = new Size(200, 26);

            // Full Name
            lblHoTen.Text = "Họ tên:";
            lblHoTen.Location = new Point(20, 70);
            lblHoTen.AutoSize = true;

            txtHoTen.Location = new Point(120, 70);
            txtHoTen.Size = new Size(200, 26);

            // Birth Date
            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.Location = new Point(20, 110);
            lblNgaySinh.AutoSize = true;

            dtpNgaySinh.Location = new Point(120, 110);
            dtpNgaySinh.Size = new Size(200, 26);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;

            // Gender
            lblGioiTinh.Text = "Giới tính:";
            lblGioiTinh.Location = new Point(20, 150);
            lblGioiTinh.AutoSize = true;

            radNam.Text = "Nam";
            radNam.Location = new Point(120, 150);
            radNam.AutoSize = true;
            radNam.Checked = true;

            radNu.Text = "Nữ";
            radNu.Location = new Point(200, 150);
            radNu.AutoSize = true;

            // Address
            lblDiaChi.Text = "Địa chỉ:";
            lblDiaChi.Location = new Point(20, 190);
            lblDiaChi.AutoSize = true;

            txtDiaChi.Location = new Point(120, 190);
            txtDiaChi.Size = new Size(200, 26);

            // Email
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(350, 30);
            lblEmail.AutoSize = true;

            txtEmail.Location = new Point(450, 30);
            txtEmail.Size = new Size(200, 26);

            // Phone
            lblSDT.Text = "Số điện thoại:";
            lblSDT.Location = new Point(350, 70);
            lblSDT.AutoSize = true;

            txtSDT.Location = new Point(450, 70);
            txtSDT.Size = new Size(200, 26);

            // Class
            lblMaLop.Text = "Lớp:";
            lblMaLop.Location = new Point(350, 110);
            lblMaLop.AutoSize = true;

            cboMaLop.Location = new Point(450, 110);
            cboMaLop.Size = new Size(200, 26);
            cboMaLop.DropDownStyle = ComboBoxStyle.DropDownList;

            // Password
            lblMatKhau.Text = "Mật khẩu:";
            lblMatKhau.Location = new Point(350, 150);
            lblMatKhau.AutoSize = true;

            txtMatKhau.Location = new Point(450, 150);
            txtMatKhau.Size = new Size(200, 26);
            txtMatKhau.UseSystemPasswordChar = true;

            //c
            lblRating.Text = "Weight:";
            lblRating.Location = new Point(350, 180);
            lblRating.AutoSize = true;
            txtRating.Location = new Point(450, 180);
            txtRating.Size = new Size(200, 26);

            // Add controls to info group box
            gbInfo.Controls.Add(lblMaHS);
            gbInfo.Controls.Add(txtMaHS);
            gbInfo.Controls.Add(lblHoTen);
            gbInfo.Controls.Add(txtHoTen);
            gbInfo.Controls.Add(lblNgaySinh);
            gbInfo.Controls.Add(dtpNgaySinh);
            gbInfo.Controls.Add(lblGioiTinh);
            gbInfo.Controls.Add(radNam);
            gbInfo.Controls.Add(radNu);
            gbInfo.Controls.Add(lblDiaChi);
            gbInfo.Controls.Add(txtDiaChi);
            gbInfo.Controls.Add(lblEmail);
            gbInfo.Controls.Add(txtEmail);
            gbInfo.Controls.Add(lblSDT);
            gbInfo.Controls.Add(txtSDT);
            gbInfo.Controls.Add(lblMaLop);
            gbInfo.Controls.Add(cboMaLop);
            gbInfo.Controls.Add(lblMatKhau);
            gbInfo.Controls.Add(txtMatKhau);

            //c
            gbInfo.Controls.Add(txtRating);
            gbInfo.Controls.Add(lblRating);

            // Button Panel
            panel2.Height = 50;
            panel2.Location = new Point(12, 380);
            panel2.Size = new Size(976, 50);

            // Add Button
            btnThem.Text = "Thêm";
            btnThem.Location = new Point(120, 10);
            btnThem.Size = new Size(100, 30);
            btnThem.BackColor = Color.FromArgb(0, 150, 136);
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Click += new EventHandler(btnThem_Click);

            // Edit Button
            btnSua.Text = "Sửa";
            btnSua.Location = new Point(240, 10);
            btnSua.Size = new Size(100, 30);
            btnSua.BackColor = Color.FromArgb(0, 150, 136);
            btnSua.ForeColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Click += new EventHandler(btnSua_Click);

            // Delete Button
            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(360, 10);
            btnXoa.Size = new Size(100, 30);
            btnXoa.BackColor = Color.FromArgb(0, 150, 136);
            btnXoa.ForeColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Click += new EventHandler(btnXoa_Click);

            // Save Button
            btnLuu.Text = "Lưu";
            btnLuu.Location = new Point(480, 10);
            btnLuu.Size = new Size(100, 30);
            btnLuu.BackColor = Color.FromArgb(0, 150, 136);
            btnLuu.ForeColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Enabled = false;
            btnLuu.Click += new EventHandler(btnLuu_Click);

            // Cancel Button
            btnHuy.Text = "Hủy";
            btnHuy.Location = new Point(600, 10);
            btnHuy.Size = new Size(100, 30);
            btnHuy.BackColor = Color.FromArgb(0, 150, 136);
            btnHuy.ForeColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Enabled = false;
            btnHuy.Click += new EventHandler(btnHuy_Click);

            panel2.Controls.Add(btnThem);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnLuu);
            panel2.Controls.Add(btnHuy);

            // DataGridView
            dgvHocSinh.Location = new Point(12, 440);
            dgvHocSinh.Size = new Size(976, 300);
            dgvHocSinh.AllowUserToAddRows = false;
            dgvHocSinh.AllowUserToDeleteRows = false;
            dgvHocSinh.ReadOnly = true;
            dgvHocSinh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHocSinh.CellClick += new DataGridViewCellEventHandler(dgvHocSinh_CellClick);

            // Form
            Text = "Quản Lý Học Sinh";
            Size = new Size(1000, 800);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;

            Controls.Add(panel1);
            Controls.Add(gbSearch);
            Controls.Add(gbInfo);
            Controls.Add(panel2);
            Controls.Add(dgvHocSinh);

            SetControlsState(false);
        }

        private void LoadClassList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaLop, TenLop FROM LopHoc ORDER BY TenLop";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    cboMaLop.Items.Clear();
                    while (reader.Read())
                    {
                        string displayText = reader["MaLop"].ToString() + " - " + reader["TenLop"].ToString();
                        cboMaLop.Items.Add(new ComboBoxItem(reader["MaLop"].ToString(), displayText));
                    }

                    if (cboMaLop.Items.Count > 0)
                        cboMaLop.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudentData(string searchTerm = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {                                                   //c
                    string query = @"SELECT hs.MaHS, hs.HoTen, hs.NgaySinh, hs.GioiTinh, 
                               hs.DiaChi, hs.Email, hs.SDT, hs.MaLop, l.TenLop, hs.Rating
                        FROM HocSinh hs
                        LEFT JOIN LopHoc l ON hs.MaLop = l.MaLop";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE hs.MaHS LIKE @SearchTerm OR hs.HoTen LIKE @SearchTerm";
                    }

                    query += " ORDER BY hs.MaHS";

                    dataAdapter = new SqlDataAdapter(query, connection);

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    }

                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    dgvHocSinh.DataSource = dt;

                    // Format GridView
                    dgvHocSinh.Columns["MaHS"].HeaderText = "Mã học sinh";
                    dgvHocSinh.Columns["HoTen"].HeaderText = "Họ tên";
                    dgvHocSinh.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    dgvHocSinh.Columns["GioiTinh"].HeaderText = "Giới tính";
                    dgvHocSinh.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvHocSinh.Columns["Email"].HeaderText = "Email";
                    dgvHocSinh.Columns["SDT"].HeaderText = "Số điện thoại";
                    dgvHocSinh.Columns["MaLop"].HeaderText = "Mã lớp";
                    dgvHocSinh.Columns["TenLop"].HeaderText = "Tên lớp";

                    // Format boolean column
                    dgvHocSinh.Columns["GioiTinh"].DefaultCellStyle.Format = "Nam;Nữ";

                    // Hide password column
                    if (dt.Columns.Contains("MatKhau"))
                        dgvHocSinh.Columns["MatKhau"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetControlsState(bool isEditing)
        {
            // Enable or disable text fields
            txtMaHS.Enabled = isEditing;
            txtHoTen.Enabled = isEditing;
            dtpNgaySinh.Enabled = isEditing;
            radNam.Enabled = isEditing;
            radNu.Enabled = isEditing;
            txtDiaChi.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtSDT.Enabled = isEditing;
            cboMaLop.Enabled = isEditing;
            txtMatKhau.Enabled = isEditing;

            // Enable or disable buttons according to the state
            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing && dgvHocSinh.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditing && dgvHocSinh.SelectedRows.Count > 0;
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
        }

        private void ClearFields()
        {
            txtMaHS.Text = "";
            txtHoTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            if (cboMaLop.Items.Count > 0)
                cboMaLop.SelectedIndex = 0;
            txtMatKhau.Text = "";
        }

        private bool ValidateFields()
        {

            //c
            int temp;
            if (!int.TryParse(txtRating.Text, out temp) || (temp<1 || temp>5))
            {
                MessageBox.Show("Rating phải từ 1 đến 5", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRating.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaHS.Text))
            {
                MessageBox.Show("Mã học sinh không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHS.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }

            if (dtpNgaySinh.Value >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNgaySinh.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return false;
            }

            return true;
        }

        // Button Event Handlers
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtMaHS.Focus();
            SetControlsState(true);
            txtMaHS.ReadOnly = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHocSinh.SelectedRows.Count > 0)
            {
                SetControlsState(true);
                txtMaHS.ReadOnly = true; // Can't change the primary key
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học sinh để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHocSinh.SelectedRows.Count > 0)
            {
                string studentId = dgvHocSinh.SelectedRows[0].Cells["MaHS"].Value.ToString();
                string studentName = dgvHocSinh.SelectedRows[0].Cells["HoTen"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa học sinh {studentName} ({studentId})?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Check if student has any related data in BaiThi table
                            string checkQuery = "SELECT COUNT(*) FROM BaiThi WHERE MaHS = @MaHS";
                            SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                            checkCommand.Parameters.AddWithValue("@MaHS", studentId);

                            int relatedRecords = (int)checkCommand.ExecuteScalar();

                            if (relatedRecords > 0)
                            {
                                MessageBox.Show(
                                    "Không thể xóa học sinh này vì đã tồn tại dữ liệu bài thi liên quan.",
                                    "Lỗi xóa dữ liệu",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }

                            // Delete student
                            string deleteQuery = "DELETE FROM HocSinh WHERE MaHS = @MaHS";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@MaHS", studentId);

                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa học sinh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadStudentData();
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa học sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn học sinh để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get selected class ID
                    string maLop = null;
                    if (cboMaLop.SelectedItem != null)
                    {
                        maLop = ((ComboBoxItem)cboMaLop.SelectedItem).Value;
                    }

                    // Check if we're adding or updating
                    if (!txtMaHS.ReadOnly) // Adding new student
                    {
                        // Check if student ID already exists
                        string checkQuery = "SELECT COUNT(*) FROM HocSinh WHERE MaHS = @MaHS";
                        SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                        checkCommand.Parameters.AddWithValue("@MaHS", txtMaHS.Text.Trim());

                        int exists = (int)checkCommand.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("Mã học sinh đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMaHS.Focus();
                            return;
                        }

                        // Insert new student                                                               //c
                        string insertQuery = @"                                                             
                            INSERT INTO HocSinh (MaHS, HoTen, NgaySinh, GioiTinh, DiaChi, Email, SDT, MaLop, MatKhau, Rating)
                            VALUES (@MaHS, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @Email, @SDT, @MaLop, @MatKhau, @Rating)";

                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@MaHS", txtMaHS.Text.Trim());
                        insertCommand.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        insertCommand.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        insertCommand.Parameters.AddWithValue("@GioiTinh", radNam.Checked ? 1 : 0);
                        insertCommand.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        insertCommand.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        insertCommand.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        insertCommand.Parameters.AddWithValue("@Rating", txtRating.Text.Trim());
                        if (maLop != null)
                        {
                            insertCommand.Parameters.AddWithValue("@MaLop", maLop);
                        }
                        else
                        {
                            insertCommand.Parameters.AddWithValue("@MaLop", DBNull.Value);
                        }
                        insertCommand.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm học sinh mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm học sinh mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else // Updating existing student
                    {
                        string updateQuery = @"
                            UPDATE HocSinh 
                            SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, 
                                DiaChi = @DiaChi, Email = @Email, SDT = @SDT, MaLop = @MaLop, MatKhau = @MatKhau
                            WHERE MaHS = @MaHS";

                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@MaHS", txtMaHS.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                        updateCommand.Parameters.AddWithValue("@GioiTinh", radNam.Checked ? 1 : 0);
                        updateCommand.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        if (maLop == null)
                        {
                            updateCommand.Parameters.AddWithValue("@MaLop", DBNull.Value);
                        }
                        else
                        {
                            updateCommand.Parameters.AddWithValue("@MaLop", maLop);
                        }
                        updateCommand.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin học sinh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật thông tin học sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Reset UI
                    SetControlsState(false);
                    LoadStudentData();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetControlsState(false);

            if (dgvHocSinh.SelectedRows.Count > 0)
            {
                LoadStudentDetails(dgvHocSinh.SelectedRows[0].Cells["MaHS"].Value.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudentData(txtSearch.Text.Trim());
        }

        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadStudentDetails(dgvHocSinh.Rows[e.RowIndex].Cells["MaHS"].Value.ToString());
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void LoadStudentDetails(string studentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM HocSinh WHERE MaHS = @MaHS";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHS", studentId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Fill form fields with student data
                        txtMaHS.Text = reader["MaHS"].ToString();
                        txtHoTen.Text = reader["HoTen"].ToString();
                        dtpNgaySinh.Value = Convert.ToDateTime(reader["NgaySinh"]);
                        radNam.Checked = Convert.ToBoolean(reader["GioiTinh"]);
                        radNu.Checked = !Convert.ToBoolean(reader["GioiTinh"]);
                        txtDiaChi.Text = reader["DiaChi"] != DBNull.Value ? reader["DiaChi"].ToString() : "";
                        txtEmail.Text = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                        txtSDT.Text = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString() : "";
                        txtMatKhau.Text = reader["MatKhau"] != DBNull.Value ? reader["MatKhau"].ToString() : "";

                        // Select class in combo box
                        if (reader["MaLop"] != DBNull.Value)
                        {
                            string classId = reader["MaLop"].ToString();
                            for (int i = 0; i < cboMaLop.Items.Count; i++)
                            {
                                if (((ComboBoxItem)cboMaLop.Items[i]).Value == classId)
                                {
                                    cboMaLop.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ComboBox Item class to store ID and display text
        private class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }

            public ComboBoxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }

       
    }
}
