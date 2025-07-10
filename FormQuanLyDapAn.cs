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
    public partial class FormQuanLyDapAn : Form
    {
        private string connectionString = DBConnection.ConnectionString();
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter adapter;
        private string maCauHoi;

        public FormQuanLyDapAn(string maCH)
        {
            InitializeComponentc();
            this.maCauHoi = maCH;
        }

        private void InitializeComponentc()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNoiDungCauHoi = new System.Windows.Forms.TextBox();
            this.lblCauHoi = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDapAnDung = new System.Windows.Forms.CheckBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtMaDA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDapAn = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDapAn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNoiDungCauHoi);
            this.groupBox1.Controls.Add(this.lblCauHoi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin câu hỏi";
            // 
            // txtNoiDungCauHoi
            // 
            this.txtNoiDungCauHoi.Location = new System.Drawing.Point(19, 45);
            this.txtNoiDungCauHoi.Multiline = true;
            this.txtNoiDungCauHoi.Name = "txtNoiDungCauHoi";
            this.txtNoiDungCauHoi.ReadOnly = true;
            this.txtNoiDungCauHoi.Size = new System.Drawing.Size(628, 41);
            this.txtNoiDungCauHoi.TabIndex = 1;
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Location = new System.Drawing.Point(16, 26);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Size = new System.Drawing.Size(256, 16);
            this.lblCauHoi.TabIndex = 0;
            this.lblCauHoi.Text = "Đang quản lý đáp án cho câu hỏi: [MaCH]";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDapAnDung);
            this.groupBox2.Controls.Add(this.txtNoiDung);
            this.groupBox2.Controls.Add(this.txtMaDA);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 110);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đáp án";
            // 
            // chkDapAnDung
            // 
            this.chkDapAnDung.AutoSize = true;
            this.chkDapAnDung.Location = new System.Drawing.Point(111, 83);
            this.chkDapAnDung.Name = "chkDapAnDung";
            this.chkDapAnDung.Size = new System.Drawing.Size(107, 20);
            this.chkDapAnDung.TabIndex = 2;
            this.chkDapAnDung.Text = "Là đáp án đúng";
            this.chkDapAnDung.UseVisualStyleBackColor = true;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(111, 54);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(536, 22);
            this.txtNoiDung.TabIndex = 1;
            // 
            // txtMaDA
            // 
            this.txtMaDA.Location = new System.Drawing.Point(111, 26);
            this.txtMaDA.Name = "txtMaDA";
            this.txtMaDA.Size = new System.Drawing.Size(167, 22);
            this.txtMaDA.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nội dung:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã đáp án:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDapAn);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 277);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 216);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách đáp án";
            // 
            // dgvDapAn
            // 
            this.dgvDapAn.AllowUserToAddRows = false;
            this.dgvDapAn.AllowUserToDeleteRows = false;
            this.dgvDapAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDapAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDapAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDapAn.Location = new System.Drawing.Point(3, 18);
            this.dgvDapAn.MultiSelect = false;
            this.dgvDapAn.Name = "dgvDapAn";
            this.dgvDapAn.ReadOnly = true;
            this.dgvDapAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDapAn.Size = new System.Drawing.Size(662, 195);
            this.dgvDapAn.TabIndex = 0;
            this.dgvDapAn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDapAn_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Location = new System.Drawing.Point(12, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 45);
            this.panel1.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(273, 6);
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
            this.btnXoa.Location = new System.Drawing.Point(185, 6);
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
            this.btnSua.Location = new System.Drawing.Point(97, 6);
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
            this.btnThem.Location = new System.Drawing.Point(9, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 33);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // FormQuanLyDapAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 505);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormQuanLyDapAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đáp án câu hỏi";
            this.Load += new System.EventHandler(this.FormQuanLyDapAn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDapAn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCauHoi;
        private System.Windows.Forms.TextBox txtNoiDungCauHoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtMaDA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDapAnDung;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDapAn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;

        private void FormQuanLyDapAn_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            lblCauHoi.Text = "Đang quản lý đáp án cho câu hỏi: " + maCauHoi;
            LoadNoiDungCauHoi();
            LoadDapAn();
        }

        private void LoadNoiDungCauHoi()
        {
            try
            {
                conn.Open();
                string query = "SELECT NoiDung FROM CauHoi WHERE MaCH = @MaCH";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                string noiDung = (string)cmd.ExecuteScalar();
                conn.Close();

                txtNoiDungCauHoi.Text = noiDung;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi tải nội dung câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDapAn()
        {
            try
            {
                conn.Open();
                string query = "SELECT MaDA, NoiDung, LaDapAnDung FROM DapAn WHERE MaCH = @MaCH";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();

                dgvDapAn.DataSource = dt;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi tải danh sách đáp án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dgvDapAn.Columns["MaDA"].HeaderText = "Mã đáp án";
            dgvDapAn.Columns["NoiDung"].HeaderText = "Nội dung";
            dgvDapAn.Columns["LaDapAnDung"].HeaderText = "Đáp án đúng";

            dgvDapAn.Columns["NoiDung"].Width = 500;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDA.Text) || string.IsNullOrEmpty(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đáp án!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();
                // Kiểm tra mã đáp án đã tồn tại chưa
                cmd = new SqlCommand("SELECT COUNT(*) FROM DapAn WHERE MaDA = @MaDA", conn);
                cmd.Parameters.AddWithValue("@MaDA", txtMaDA.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã đáp án đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    return;
                }

                // Nếu đây là đáp án đúng và đã có đáp án đúng khác, hỏi người dùng có muốn thay đổi
                if (chkDapAnDung.Checked)
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM DapAn WHERE MaCH = @MaCH AND LaDapAnDung = 1", conn);
                    cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                    int countDapAnDung = (int)cmd.ExecuteScalar();

                    if (countDapAnDung > 0)
                    {
                        DialogResult result = MessageBox.Show("Câu hỏi này đã có đáp án đúng. Bạn có muốn thay đổi đáp án đúng không?",
                                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            // Cập nhật tất cả đáp án hiện tại thành sai
                            cmd = new SqlCommand("UPDATE DapAn SET LaDapAnDung = 0 WHERE MaCH = @MaCH", conn);
                            cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            conn.Close();
                            chkDapAnDung.Checked = false;
                            return;
                        }
                    }
                }

                // Thêm đáp án mới
                string query = "INSERT INTO DapAn (MaDA, MaCH, NoiDung, LaDapAnDung) VALUES (@MaDA, @MaCH, @NoiDung, @LaDapAnDung)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDA", txtMaDA.Text);
                cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
                cmd.Parameters.AddWithValue("@LaDapAnDung", chkDapAnDung.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm đáp án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDapAn();
                ClearForm();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi thêm đáp án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDA.Text))
            {
                MessageBox.Show("Vui lòng chọn đáp án cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                // Nếu đây là đáp án đúng và đã có đáp án đúng khác, hỏi người dùng có muốn thay đổi
                if (chkDapAnDung.Checked)
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM DapAn WHERE MaCH = @MaCH AND LaDapAnDung = 1 AND MaDA <> @MaDA", conn);
                    cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                    cmd.Parameters.AddWithValue("@MaDA", txtMaDA.Text);
                    int countDapAnDung = (int)cmd.ExecuteScalar();

                    if (countDapAnDung > 0)
                    {
                        DialogResult result = MessageBox.Show("Câu hỏi này đã có đáp án đúng khác. Bạn có muốn thay đổi đáp án đúng không?",
                                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            // Cập nhật tất cả đáp án hiện tại thành sai
                            cmd = new SqlCommand("UPDATE DapAn SET LaDapAnDung = 0 WHERE MaCH = @MaCH", conn);
                            cmd.Parameters.AddWithValue("@MaCH", maCauHoi);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            conn.Close();
                            return;
                        }
                    }
                }

                // Cập nhật đáp án
                string query = "UPDATE DapAn SET NoiDung = @NoiDung, LaDapAnDung = @LaDapAnDung WHERE MaDA = @MaDA";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaDA", txtMaDA.Text);
                cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
                cmd.Parameters.AddWithValue("@LaDapAnDung", chkDapAnDung.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Cập nhật đáp án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDapAn();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi cập nhật đáp án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDA.Text))
            {
                MessageBox.Show("Vui lòng chọn đáp án cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem đáp án có được sử dụng trong bài thi nào không
            try
            {
                conn.Open();
                string checkQuery = "SELECT COUNT(*) FROM ChiTietBaiLam WHERE MaDA = @MaDA";
                cmd = new SqlCommand(checkQuery, conn);
                cmd.Parameters.AddWithValue("@MaDA", txtMaDA.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa đáp án này vì đã được sử dụng trong bài thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return;
                }

                // Xóa đáp án
                string deleteQuery = "DELETE FROM DapAn WHERE MaDA = @MaDA";
                cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@MaDA", txtMaDA.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Xóa đáp án thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDapAn();
                ClearForm();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi xóa đáp án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtMaDA.Clear();
            txtNoiDung.Clear();
            chkDapAnDung.Checked = false;
            txtMaDA.Enabled = true;
        }

        private void dgvDapAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDapAn.Rows[e.RowIndex];
                txtMaDA.Text = row.Cells["MaDA"].Value.ToString();
                txtNoiDung.Text = row.Cells["NoiDung"].Value.ToString();
                chkDapAnDung.Checked = Convert.ToBoolean(row.Cells["LaDapAnDung"].Value);

                // Khi chọn đáp án từ datagridview, không cho phép sửa mã đáp án
                txtMaDA.Enabled = false;
            }
        }
    }
}
