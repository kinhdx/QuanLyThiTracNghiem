using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class MainForm : Form
    {
        private Form activeForm = null;
        private Button currentButton = null;

        public MainForm()
        {
            InitializeComponentc();
            CustomizeDesign();
        }

        private void InitializeComponentc()
        {
            this.panelMenu = new Panel();
            this.panelLogo = new Panel();
            this.panelDesktop = new Panel();
            this.panelTitleBar = new Panel();
            this.lblTitle = new Label();

            // Main Form
            this.Text = "Hệ Thống Quản Lý Thi Trắc Nghiệm";
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            // Menu Panel
            this.panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            this.panelMenu.Dock = DockStyle.Left;
            this.panelMenu.Width = 220;

            // Logo Panel
            this.panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            this.panelLogo.Dock = DockStyle.Top;
            this.panelLogo.Height = 80;
            this.panelMenu.Controls.Add(panelLogo);

            // Create Logo Label
            Label lblLogo = new Label();
            lblLogo.Text = "QUẢN LÝ THI";
            lblLogo.ForeColor = Color.White;
            lblLogo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            panelLogo.Controls.Add(lblLogo);

            // Title Bar Panel
            this.panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            this.panelTitleBar.Dock = DockStyle.Top;
            this.panelTitleBar.Height = 80;
            this.panelTitleBar.Controls.Add(lblTitle);

            // Title Label
            this.lblTitle.Text = "HOME";
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular);
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Desktop Panel
            this.panelDesktop.Dock = DockStyle.Fill;
            this.panelDesktop.BackColor = Color.White;

            // Add Menu Buttons
            CreateMenuButton("Quản Lý Học Sinh", "btnStudent");
            CreateMenuButton("Quản Lý Lớp Học", "btnClass");
            CreateMenuButton("Quản Lý Môn Học", "btnSubject");
            CreateMenuButton("Ngân Hàng Câu Hỏi", "btnQuestion");
            CreateMenuButton("Quản Lý Đề Thi", "btnExam");
            CreateMenuButton("Kết Quả Thi", "btnResult");
            CreateMenuButton("Báo Cáo Thống Kê", "btnReport");
            CreateMenuButton("Thoát", "btnExit");

            // Add Controls to Form
            this.Controls.Add(panelDesktop);
            this.Controls.Add(panelTitleBar);
            this.Controls.Add(panelMenu);
        }

        private void CustomizeDesign()
        {
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateMenuButton(string text, string name)
        {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Dock = DockStyle.Top;
            btn.Height = 60;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
            btn.ForeColor = Color.Gainsboro;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 0, 0);
            btn.Click += new EventHandler(Button_Click);
            panelMenu.Controls.Add(btn);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ActivateButton(btn);
                OpenChildForm(btn.Name);
            }
        }

        private void ActivateButton(Button btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != null)
                {
                    DisableButton();
                    currentButton.BackColor = Color.FromArgb(51, 51, 76);
                    currentButton.ForeColor = Color.Gainsboro;
                }

                currentButton = btnSender;
                currentButton.BackColor = Color.FromArgb(0, 150, 136);
                currentButton.ForeColor = Color.White;
                lblTitle.Text = currentButton.Text.ToUpper();
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                }
            }
        }

        private void OpenChildForm(string buttonName)
        {
            if (activeForm != null)
                activeForm.Close();

            switch (buttonName)
            {
                case "btnStudent":
                     activeForm = new FormQuanLyHocSinh();
                    break;
                case "btnClass":
                     activeForm = new FormQuanLyLopHoc();
                    break;
                case "btnSubject":
                     activeForm = new FormQuanLyMonHoc();
                    break;
                case "btnQuestion":
                     activeForm = new FormNganHangCauHoi();
                    break;
                case "btnExam":
                     activeForm = new FormQuanLyDeThi();
                    break;
                case "btnResult":
                     activeForm = new FormKetQuaThi();
                    //MessageBox.Show("Mở form Kết quả thi");
                    break;
                case "btnReport":
                    activeForm = new FormBaoCaoThongKe();
                    break;
                case "btnExit":
                    if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    return;
            }

            if (activeForm != null)
            {
                activeForm.TopLevel = false;
                activeForm.FormBorderStyle = FormBorderStyle.None;
                activeForm.Dock = DockStyle.Fill;
                panelDesktop.Controls.Add(activeForm);
                panelDesktop.Tag = activeForm;
                activeForm.BringToFront();
                activeForm.Show();
            }
        }

        private Panel panelMenu;
        private Panel panelLogo;
        private Panel panelTitleBar;
        private Panel panelDesktop;
        private Label lblTitle;
    }
}
