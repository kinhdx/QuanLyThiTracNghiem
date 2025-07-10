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
    public partial class FormKetQuaThi : Form
    {
        private string connectionString = DBConnection.ConnectionString();
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;

        public FormKetQuaThi()
        {
            InitializeComponentc();
        }

        private void InitializeComponentc()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDeThi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXuatBaoCao = new System.Windows.Forms.Button();
            this.btnChiTiet = new System.Windows.Forms.Button();
            this.dgvKetQuaThi = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaThi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 50);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1084, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ KẾT QUẢ THI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.dtpDenNgay);
            this.groupBox1.Controls.Add(this.dtpTuNgay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboDeThi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboMonHoc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboLop);
            this.groupBox1.Controls.Add(this.lblLop);
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Controls.Add(this.lblTuKhoa);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1084, 150);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(641, 101);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.TabIndex = 13;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(535, 101);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Checked = false;
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(535, 73);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.ShowCheckBox = true;
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 20);
            this.dtpDenNgay.TabIndex = 11;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Checked = false;
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(535, 43);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.ShowCheckBox = true;
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 20);
            this.dtpTuNgay.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Từ ngày:";
            // 
            // cboDeThi
            // 
            this.cboDeThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeThi.FormattingEnabled = true;
            this.cboDeThi.Location = new System.Drawing.Point(101, 104);
            this.cboDeThi.Name = "cboDeThi";
            this.cboDeThi.Size = new System.Drawing.Size(250, 21);
            this.cboDeThi.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đề thi:";
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(101, 73);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(250, 21);
            this.cboMonHoc.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Môn học:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(101, 43);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(250, 21);
            this.cboLop.TabIndex = 3;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(22, 46);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(28, 13);
            this.lblLop.TabIndex = 2;
            this.lblLop.Text = "Lớp:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(101, 16);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 20);
            this.txtTimKiem.TabIndex = 1;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(22, 19);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(50, 13);
            this.lblTuKhoa.TabIndex = 0;
            this.lblTuKhoa.Text = "Từ khóa:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXuatBaoCao);
            this.panel2.Controls.Add(this.btnChiTiet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 550);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 50);
            this.panel2.TabIndex = 2;
            // 
            // btnXuatBaoCao
            // 
            //this.btnXuatBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //this.btnXuatBaoCao.Location = new System.Drawing.Point(972, 10);
            //this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            //this.btnXuatBaoCao.Size = new System.Drawing.Size(100, 30);
            //this.btnXuatBaoCao.TabIndex = 1;
            //this.btnXuatBaoCao.Text = "Xuất báo cáo";
            //this.btnXuatBaoCao.UseVisualStyleBackColor = true;
            //this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            //// 
            // btnChiTiet
            // 
            this.btnChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiTiet.Location = new System.Drawing.Point(972, 10);
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.Size = new System.Drawing.Size(100, 30);
            this.btnChiTiet.TabIndex = 0;
            this.btnChiTiet.Text = "Xem chi tiết";
            this.btnChiTiet.UseVisualStyleBackColor = true;
            this.btnChiTiet.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // dgvKetQuaThi
            // 
            this.dgvKetQuaThi.AllowUserToAddRows = false;
            this.dgvKetQuaThi.AllowUserToDeleteRows = false;
            this.dgvKetQuaThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKetQuaThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQuaThi.Location = new System.Drawing.Point(12, 206);
            this.dgvKetQuaThi.MultiSelect = false;
            this.dgvKetQuaThi.Name = "dgvKetQuaThi";
            this.dgvKetQuaThi.ReadOnly = true;
            this.dgvKetQuaThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQuaThi.Size = new System.Drawing.Size(1060, 338);
            this.dgvKetQuaThi.TabIndex = 3;
            // 
            // FormKetQuaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 600);
            this.Controls.Add(this.dgvKetQuaThi);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FormKetQuaThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kết quả thi";
            this.Load += new System.EventHandler(this.FormKetQuaThi_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQuaThi)).EndInit();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvKetQuaThi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDeThi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Button btnXuatBaoCao;
        private System.Windows.Forms.Button btnChiTiet;

        private void FormKetQuaThi_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                connection.Open();

                // Load Lớp học vào ComboBox
                SqlCommand cmdLop = new SqlCommand("SELECT MaLop, TenLop FROM LopHoc", connection);
                SqlDataAdapter adapterLop = new SqlDataAdapter(cmdLop);
                DataTable dtLop = new DataTable();
                adapterLop.Fill(dtLop);

                cboLop.DataSource = dtLop;
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.SelectedIndex = -1;

                // Load Môn học vào ComboBox
                SqlCommand cmdMonHoc = new SqlCommand("SELECT MaMH, TenMH FROM MonHoc", connection);
                SqlDataAdapter adapterMonHoc = new SqlDataAdapter(cmdMonHoc);
                DataTable dtMonHoc = new DataTable();
                adapterMonHoc.Fill(dtMonHoc);

                cboMonHoc.DataSource = dtMonHoc;
                cboMonHoc.DisplayMember = "TenMH";
                cboMonHoc.ValueMember = "MaMH";
                cboMonHoc.SelectedIndex = -1;

                // Load Đề thi vào ComboBox
                SqlCommand cmdDeThi = new SqlCommand("SELECT MaDe, TenDe FROM DeThi", connection);
                SqlDataAdapter adapterDeThi = new SqlDataAdapter(cmdDeThi);
                DataTable dtDeThi = new DataTable();
                adapterDeThi.Fill(dtDeThi);

                cboDeThi.DataSource = dtDeThi;
                cboDeThi.DisplayMember = "TenDe";
                cboDeThi.ValueMember = "MaDe";
                cboDeThi.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadData()
        {
            try
            {
                connection.Open();
                string query = @"
                    SELECT 
                        bt.MaBaiThi, 
                        hs.HoTen AS TenHocSinh, 
                        lh.TenLop, 
                        mh.TenMH AS MonHoc, 
                        dt.TenDe AS DeThi,
                        bt.NgayThi, 
                        bt.ThoiGianBatDau, 
                        bt.ThoiGianKetThuc, 
                        bt.Diem,
                        CASE 
                            WHEN bt.TrangThai = 0 THEN N'Chưa thi'
                            WHEN bt.TrangThai = 1 THEN N'Đang thi'
                            WHEN bt.TrangThai = 2 THEN N'Đã nộp bài'
                        END AS TrangThai
                    FROM BaiThi bt
                    INNER JOIN HocSinh hs ON bt.MaHS = hs.MaHS
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    INNER JOIN DeThi dt ON bt.MaDe = dt.MaDe
                    INNER JOIN MonHoc mh ON dt.MaMH = mh.MaMH
                    ORDER BY bt.NgayThi DESC";

                adapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvKetQuaThi.DataSource = dataTable;

                // Format datagridview
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void FormatDataGridView()
        {
            dgvKetQuaThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQuaThi.Columns["MaBaiThi"].HeaderText = "Mã bài thi";
            dgvKetQuaThi.Columns["TenHocSinh"].HeaderText = "Học sinh";
            dgvKetQuaThi.Columns["TenLop"].HeaderText = "Lớp";
            dgvKetQuaThi.Columns["MonHoc"].HeaderText = "Môn học";
            dgvKetQuaThi.Columns["DeThi"].HeaderText = "Đề thi";
            dgvKetQuaThi.Columns["NgayThi"].HeaderText = "Ngày thi";
            dgvKetQuaThi.Columns["ThoiGianBatDau"].HeaderText = "Thời gian bắt đầu";
            dgvKetQuaThi.Columns["ThoiGianKetThuc"].HeaderText = "Thời gian kết thúc";
            dgvKetQuaThi.Columns["Diem"].HeaderText = "Điểm";
            dgvKetQuaThi.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemKetQua();
        }

        private void TimKiemKetQua()
        {
            try
            {
                connection.Open();
                string query = @"
                    SELECT 
                        bt.MaBaiThi, 
                        hs.HoTen AS TenHocSinh, 
                        lh.TenLop, 
                        mh.TenMH AS MonHoc, 
                        dt.TenDe AS DeThi,
                        bt.NgayThi, 
                        bt.ThoiGianBatDau, 
                        bt.ThoiGianKetThuc, 
                        bt.Diem,
                        CASE 
                            WHEN bt.TrangThai = 0 THEN N'Chưa thi'
                            WHEN bt.TrangThai = 1 THEN N'Đang thi'
                            WHEN bt.TrangThai = 2 THEN N'Đã nộp bài'
                        END AS TrangThai
                    FROM BaiThi bt
                    INNER JOIN HocSinh hs ON bt.MaHS = hs.MaHS
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    INNER JOIN DeThi dt ON bt.MaDe = dt.MaDe
                    INNER JOIN MonHoc mh ON dt.MaMH = mh.MaMH
                    WHERE 1=1";

                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    query += " AND (hs.HoTen LIKE @TuKhoa OR bt.MaBaiThi LIKE @TuKhoa)";
                }

                if (cboLop.SelectedIndex != -1)
                {
                    query += " AND lh.MaLop = @MaLop";
                }

                if (cboMonHoc.SelectedIndex != -1)
                {
                    query += " AND mh.MaMH = @MaMH";
                }

                if (cboDeThi.SelectedIndex != -1)
                {
                    query += " AND dt.MaDe = @MaDe";
                }

                if (dtpTuNgay.Checked && dtpDenNgay.Checked)
                {
                    query += " AND bt.NgayThi BETWEEN @TuNgay AND @DenNgay";
                }

                query += " ORDER BY bt.NgayThi DESC";

                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    command.Parameters.AddWithValue("@TuKhoa", "%" + txtTimKiem.Text + "%");
                }

                if (cboLop.SelectedIndex != -1)
                {
                    command.Parameters.AddWithValue("@MaLop", cboLop.SelectedValue.ToString());
                }

                if (cboMonHoc.SelectedIndex != -1)
                {
                    command.Parameters.AddWithValue("@MaMH", cboMonHoc.SelectedValue.ToString());
                }

                if (cboDeThi.SelectedIndex != -1)
                {
                    command.Parameters.AddWithValue("@MaDe", cboDeThi.SelectedValue.ToString());
                }

                if (dtpTuNgay.Checked && dtpDenNgay.Checked)
                {
                    command.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                    command.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1));
                }

                adapter = new SqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvKetQuaThi.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLop.SelectedIndex = -1;
            cboMonHoc.SelectedIndex = -1;
            cboDeThi.SelectedIndex = -1;
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            LoadData();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvKetQuaThi.SelectedRows.Count > 0)
            {
                string maBaiThi = dgvKetQuaThi.SelectedRows[0].Cells["MaBaiThi"].Value.ToString();
                FormChiTietBaiThi formChiTiet = new FormChiTietBaiThi(maBaiThi);
                formChiTiet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài thi để xem chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            // Thêm mã xuất báo cáo Excel hoặc PDF ở đây
            MessageBox.Show("Chức năng xuất báo cáo đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
