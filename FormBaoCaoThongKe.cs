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
    public partial class FormBaoCaoThongKe : Form
    {
        private string connectionString = DBConnection.ConnectionString();
        private ComboBox cboLoaiBaoCao;
        private ComboBox cboLop;
        private ComboBox cboMonHoc;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnXemBaoCao;
        private Button btnInBaoCao;
        private Button btnDong;
        private DataGridView dgvKetQua;
        private Panel pnlFilter;
        private Label lblTongSo;

        public FormBaoCaoThongKe()
        {
            InitializeComponentc();
            LoadData();
        }

        private void InitializeComponentc()
        {
            this.pnlFilter = new Panel();
            this.cboLoaiBaoCao = new ComboBox();
            this.cboLop = new ComboBox();
            this.cboMonHoc = new ComboBox();
            this.dtpTuNgay = new DateTimePicker();
            this.dtpDenNgay = new DateTimePicker();
            this.btnXemBaoCao = new Button();
            this.btnInBaoCao = new Button();
            this.btnDong = new Button();
            this.dgvKetQua = new DataGridView();
            this.lblTongSo = new Label();

            // Panel Filter
            this.pnlFilter.BorderStyle = BorderStyle.FixedSingle;
            this.pnlFilter.Dock = DockStyle.Top;
            this.pnlFilter.Height = 140;
            this.pnlFilter.Padding = new Padding(10);

            // Label Loại báo cáo
            Label lblLoaiBaoCao = new Label();
            lblLoaiBaoCao.Text = "Loại báo cáo:";
            lblLoaiBaoCao.Location = new Point(20, 20);
            lblLoaiBaoCao.AutoSize = true;

            // ComboBox Loại báo cáo
            this.cboLoaiBaoCao.Location = new Point(120, 17);
            this.cboLoaiBaoCao.Size = new Size(200, 24);
            this.cboLoaiBaoCao.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.SelectedIndexChanged += new EventHandler(CboLoaiBaoCao_SelectedIndexChanged);

            // Label Lớp
            Label lblLop = new Label();
            lblLop.Text = "Lớp:";
            lblLop.Location = new Point(20, 50);
            lblLop.AutoSize = true;

            // ComboBox Lớp
            this.cboLop.Location = new Point(120, 47);
            this.cboLop.Size = new Size(200, 24);
            this.cboLop.DropDownStyle = ComboBoxStyle.DropDownList;

            // Label Môn học
            Label lblMonHoc = new Label();
            lblMonHoc.Text = "Môn học:";
            lblMonHoc.Location = new Point(350, 20);
            lblMonHoc.AutoSize = true;

            // ComboBox Môn học
            this.cboMonHoc.Location = new Point(450, 17);
            this.cboMonHoc.Size = new Size(200, 24);
            this.cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;

            // Label Từ ngày
            Label lblTuNgay = new Label();
            lblTuNgay.Text = "Từ ngày:";
            lblTuNgay.Location = new Point(20, 80);
            lblTuNgay.AutoSize = true;

            // DateTimePicker Từ ngày
            this.dtpTuNgay.Location = new Point(120, 77);
            this.dtpTuNgay.Size = new Size(200, 24);
            this.dtpTuNgay.Format = DateTimePickerFormat.Short;

            // Label Đến ngày
            Label lblDenNgay = new Label();
            lblDenNgay.Text = "Đến ngày:";
            lblDenNgay.Location = new Point(350, 80);
            lblDenNgay.AutoSize = true;

            // DateTimePicker Đến ngày
            this.dtpDenNgay.Location = new Point(450, 77);
            this.dtpDenNgay.Size = new Size(200, 24);
            this.dtpDenNgay.Format = DateTimePickerFormat.Short;

            // Button Xem báo cáo
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.Location = new Point(350, 47);
            this.btnXemBaoCao.Size = new Size(120, 30);
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new EventHandler(BtnXemBaoCao_Click);

            // Button In báo cáo
            //this.btnInBaoCao.Text = "In báo cáo";
            //this.btnInBaoCao.Location = new Point(480, 47);
            //this.btnInBaoCao.Size = new Size(120, 30);
            //this.btnInBaoCao.UseVisualStyleBackColor = true;
            //this.btnInBaoCao.Click += new EventHandler(BtnInBaoCao_Click);

            // Button Đóng
            this.btnDong.Text = "Đóng";
            this.btnDong.Location = new Point(480, 47);
            this.btnDong.Size = new Size(120, 30);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new EventHandler(BtnDong_Click);

            // DataGridView Kết quả
            this.dgvKetQua.Dock = DockStyle.Fill;
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.RowHeadersVisible = false;

            // Label Tổng số
            this.lblTongSo.Text = "Tổng số: 0 bản ghi";
            this.lblTongSo.Dock = DockStyle.Bottom;
            this.lblTongSo.Padding = new Padding(10);
            this.lblTongSo.Height = 40;
            this.lblTongSo.TextAlign = ContentAlignment.MiddleLeft;

            // Thêm controls vào panel filter
            this.pnlFilter.Controls.Add(lblLoaiBaoCao);
            this.pnlFilter.Controls.Add(this.cboLoaiBaoCao);
            this.pnlFilter.Controls.Add(lblLop);
            this.pnlFilter.Controls.Add(this.cboLop);
            this.pnlFilter.Controls.Add(lblMonHoc);
            this.pnlFilter.Controls.Add(this.cboMonHoc);
            this.pnlFilter.Controls.Add(lblTuNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.btnXemBaoCao);
            this.pnlFilter.Controls.Add(this.btnInBaoCao);
            this.pnlFilter.Controls.Add(this.btnDong);

            // Thêm controls vào form
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.pnlFilter);

            // Thiết lập form
            this.ClientSize = new Size(800, 600);
            this.MinimumSize = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Báo cáo thống kê";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void LoadData()
        {
            // Load dữ liệu cho các combobox
            LoadLoaiBaoCao();
            LoadLopHoc();
            LoadMonHoc();

            // Thiết lập giá trị mặc định cho DateTimePicker
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
        }

        private void LoadLoaiBaoCao()
        {
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("Kết quả thi theo lớp");
            cboLoaiBaoCao.Items.Add("Kết quả thi theo môn học");
            cboLoaiBaoCao.Items.Add("Điểm trung bình theo lớp");
            cboLoaiBaoCao.Items.Add("Thống kê số lượng bài thi đã hoàn thành");
            cboLoaiBaoCao.SelectedIndex = 0;
        }

        private void LoadLopHoc()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaLop, TenLop FROM LopHoc ORDER BY TenLop";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboLop.DisplayMember = "TenLop";
                    cboLop.ValueMember = "MaLop";
                    cboLop.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonHoc()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaMH, TenMH FROM MonHoc ORDER BY TenMH";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboMonHoc.DisplayMember = "TenMH";
                    cboMonHoc.ValueMember = "MaMH";
                    cboMonHoc.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboLoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cập nhật giao diện tùy theo loại báo cáo
            switch (cboLoaiBaoCao.SelectedIndex)
            {
                case 0: // Kết quả thi theo lớp
                    cboLop.Enabled = true;
                    cboMonHoc.Enabled = true;
                    break;
                case 1: // Kết quả thi theo môn học
                    cboLop.Enabled = true;
                    cboMonHoc.Enabled = true;
                    break;
                case 2: // Điểm trung bình theo lớp
                    cboLop.Enabled = true;
                    cboMonHoc.Enabled = false;
                    break;
                case 3: // Thống kê số lượng bài thi
                    cboLop.Enabled = true;
                    cboMonHoc.Enabled = true;
                    break;
                default:
                    cboLop.Enabled = true;
                    cboMonHoc.Enabled = true;
                    break;
            }
        }

        private void BtnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                string maLop = cboLop.SelectedValue.ToString();
                string maMH = cboMonHoc.SelectedValue.ToString();
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                switch (cboLoaiBaoCao.SelectedIndex)
                {
                    case 0: // Kết quả thi theo lớp
                        query = @"SELECT hs.MaHS, hs.HoTen, bt.NgayThi, mh.TenMH, dt.TenDe, bt.Diem
                                FROM BaiThi bt
                                INNER JOIN HocSinh hs ON bt.MaHS = hs.MaHS
                                INNER JOIN DeThi dt ON bt.MaDe = dt.MaDe
                                INNER JOIN MonHoc mh ON dt.MaMH = mh.MaMH
                                WHERE hs.MaLop = @MaLop 
                                AND dt.MaMH = @MaMH
                                AND bt.NgayThi BETWEEN @TuNgay AND @DenNgay
                                AND bt.TrangThai = 2
                                ORDER BY hs.HoTen, bt.NgayThi DESC";
                        break;
                    case 1: // Kết quả thi theo môn học
                        query = @"SELECT mh.TenMH, lh.TenLop, COUNT(bt.MaBaiThi) AS SoLuotThi, 
                                AVG(bt.Diem) AS DiemTrungBinh,
                                MIN(bt.Diem) AS DiemThapNhat,
                                MAX(bt.Diem) AS DiemCaoNhat
                                FROM BaiThi bt
                                INNER JOIN HocSinh hs ON bt.MaHS = hs.MaHS
                                INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                                INNER JOIN DeThi dt ON bt.MaDe = dt.MaDe
                                INNER JOIN MonHoc mh ON dt.MaMH = mh.MaMH
                                WHERE dt.MaMH = @MaMH
                                AND bt.NgayThi BETWEEN @TuNgay AND @DenNgay
                                AND bt.TrangThai = 2
                                GROUP BY mh.TenMH, lh.TenLop
                                ORDER BY lh.TenLop";
                        break;
                    case 2: // Điểm trung bình theo lớp
                        query = @"SELECT hs.HoTen, mh.TenMH, AVG(bt.Diem) AS DiemTrungBinh,
                                COUNT(bt.MaBaiThi) AS SoLanThi
                                FROM BaiThi bt
                                INNER JOIN HocSinh hs ON bt.MaHS = hs.MaHS
                                INNER JOIN DeThi dt ON bt.MaDe = dt.MaDe
                                INNER JOIN MonHoc mh ON dt.MaMH = mh.MaMH
                                WHERE hs.MaLop = @MaLop
                                AND bt.NgayThi BETWEEN @TuNgay AND @DenNgay
                                AND bt.TrangThai = 2
                                GROUP BY hs.HoTen, mh.TenMH
                                ORDER BY hs.HoTen, mh.TenMH";
                        break;
                    case 3: // Thống kê số lượng bài thi
                        query = @"SELECT lh.TenLop, mh.TenMH, 
                                COUNT(CASE WHEN bt.TrangThai = 0 THEN 1 END) AS ChuaThi,
                                COUNT(CASE WHEN bt.TrangThai = 1 THEN 1 END) AS DangThi,
                                COUNT(CASE WHEN bt.TrangThai = 2 THEN 1 END) AS DaNopBai,
                                COUNT(bt.MaBaiThi) AS TongSo
                                FROM BaiThi bt
                                INNER JOIN HocSinh hs ON bt.MaHS = hs.MaHS
                                INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                                INNER JOIN DeThi dt ON bt.MaDe = dt.MaDe
                                INNER JOIN MonHoc mh ON dt.MaMH = mh.MaMH
                                WHERE bt.NgayThi BETWEEN @TuNgay AND @DenNgay
                                GROUP BY lh.TenLop, mh.TenMH
                                ORDER BY lh.TenLop, mh.TenMH";
                        break;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaLop", maLop);
                    command.Parameters.AddWithValue("@MaMH", maMH);
                    command.Parameters.AddWithValue("@TuNgay", tuNgay);
                    command.Parameters.AddWithValue("@DenNgay", denNgay);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvKetQua.DataSource = dataTable;
                    lblTongSo.Text = "Tổng số: " + dataTable.Rows.Count + " bản ghi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng In báo cáo sẽ được cài đặt sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBaoCaoThongKe
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormBaoCaoThongKe";
            this.Load += new System.EventHandler(this.FormBaoCaoThongKe_Load);
            this.ResumeLayout(false);

        }

        private void FormBaoCaoThongKe_Load(object sender, EventArgs e)
        {

        }
    }
}
