extern alias Bai5c_bai1;
extern alias Bai5c_bai2;
extern alias Bai5c_btvn1;
extern alias Bai5c_btvn2;
extern alias Bai5c_btvn3;
extern alias Bai5c_nangcao;
extern alias Bai5d_bai1;
extern alias Bai5d_bai2;
extern alias Bai5d_btvn1;
extern alias Bai5d_nangcao;

namespace BTVN_Tuan5
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            SuspendLayout();

            // ----- khởi tạo menu -----
            menuMain = new MenuStrip();
            mnu5c = new ToolStripMenuItem(); mnu5d = new ToolStripMenuItem();
            mnu5cBai1 = new ToolStripMenuItem(); mnu5cBai2 = new ToolStripMenuItem();
            mnu5cBtvn1 = new ToolStripMenuItem(); mnu5cBtvn2 = new ToolStripMenuItem();
            mnu5cBtvn3 = new ToolStripMenuItem(); mnu5cNangcao = new ToolStripMenuItem();
            mnu5dBai1 = new ToolStripMenuItem(); mnu5dBai2 = new ToolStripMenuItem();
            mnu5dBtvn1 = new ToolStripMenuItem(); mnu5dNangcao = new ToolStripMenuItem();
            mnuCuaSo = new ToolStripMenuItem(); mnuXepChong = new ToolStripMenuItem();
            mnuXepNgang = new ToolStripMenuItem(); mnuXepDoc = new ToolStripMenuItem();
            mnuDongTatCa = new ToolStripMenuItem(); mnuThoat = new ToolStripMenuItem();

            // ----- nhóm 5c: mỗi mục mở một form -----
            Muc(mnu5cBai1, "mnu5cBai1", "bai1 - Combobox: ước số");
            mnu5cBai1.Click += (s, e) => MoForm<Bai5c_bai1::bai1.Form1>();

            Muc(mnu5cBai2, "mnu5cBai2", "bai2 - TreeView: quản lý sinh viên theo lớp");
            mnu5cBai2.Click += (s, e) => MoForm<Bai5c_bai2::bai2.Form1>();

            Muc(mnu5cBtvn1, "mnu5cBtvn1", "btvn1 - Từ điển Anh - Việt");
            mnu5cBtvn1.Click += (s, e) => MoForm<Bai5c_btvn1::btvn1.Form1>();

            Muc(mnu5cBtvn2, "mnu5cBtvn2", "btvn2 - Listbox: số tự nhiên");
            mnu5cBtvn2.Click += (s, e) => MoForm<Bai5c_btvn2::btvn2.Form1>();

            Muc(mnu5cBtvn3, "mnu5cBtvn3", "btvn3 - Danh bạ TreeView A-Z");
            mnu5cBtvn3.Click += (s, e) => MoForm<Bai5c_btvn3::btvn3.Form1>();

            Muc(mnu5cNangcao, "mnu5cNangcao", "nangcao - Xử lý chuỗi (Listbox)");
            mnu5cNangcao.Click += (s, e) => MoForm<Bai5c_nangcao::nangcao.Form1>();

            mnu5c.DropDownItems.AddRange(new ToolStripItem[]
                { mnu5cBai1, mnu5cBai2, mnu5cBtvn1, mnu5cBtvn2, mnu5cBtvn3, mnu5cNangcao });
            mnu5c.Name = "mnu5c";
            mnu5c.Text = "5c";

            // ----- nhóm 5d -----
            Muc(mnu5dBai1, "mnu5dBai1", "bai1 - ListView: sinh viên");
            mnu5dBai1.Click += (s, e) => MoForm<Bai5d_bai1::bai1.Form1>();

            Muc(mnu5dBai2, "mnu5dBai2", "bai2 - ListView: tài khoản");
            mnu5dBai2.Click += (s, e) => MoForm<Bai5d_bai2::bai2.Form1>();

            Muc(mnu5dBtvn1, "mnu5dBtvn1", "btvn1 - Đồng hồ đếm ngược");
            mnu5dBtvn1.Click += (s, e) => MoForm<Bai5d_btvn1::btvn1.Form1>();

            Muc(mnu5dNangcao, "mnu5dNangcao", "nangcao - MenuStrip: quản lý học viên");
            mnu5dNangcao.Click += (s, e) => MoForm<Bai5d_nangcao::nangcao.Form1>();

            mnu5d.DropDownItems.AddRange(new ToolStripItem[]
                { mnu5dBai1, mnu5dBai2, mnu5dBtvn1, mnu5dNangcao });
            mnu5d.Name = "mnu5d";
            mnu5d.Text = "5d";

            // ----- menu Cửa sổ: sắp xếp các form con đang mở -----
            Muc(mnuXepChong, "mnuXepChong", "Xếp chồng");
            mnuXepChong.Click += (s, e) => LayoutMdi(MdiLayout.Cascade);

            Muc(mnuXepNgang, "mnuXepNgang", "Xếp ngang");
            mnuXepNgang.Click += (s, e) => LayoutMdi(MdiLayout.TileHorizontal);

            Muc(mnuXepDoc, "mnuXepDoc", "Xếp dọc");
            mnuXepDoc.Click += (s, e) => LayoutMdi(MdiLayout.TileVertical);

            Muc(mnuDongTatCa, "mnuDongTatCa", "Đóng tất cả");
            mnuDongTatCa.Click += mnuDongTatCa_Click;

            mnuCuaSo.DropDownItems.AddRange(new ToolStripItem[]
                { mnuXepChong, mnuXepNgang, mnuXepDoc, new ToolStripSeparator(), mnuDongTatCa });
            mnuCuaSo.Name = "mnuCuaSo";
            mnuCuaSo.Text = "Cửa sổ";

            mnuThoat.Name = "mnuThoat";
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;

            menuMain.Items.AddRange(new ToolStripItem[] { mnu5c, mnu5d, mnuCuaSo, mnuThoat });
            menuMain.MdiWindowListItem = mnuCuaSo;   // menu Cửa sổ tự liệt kê các form đang mở
            menuMain.Name = "menuMain";

            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 720);
            Controls.Add(menuMain);
            IsMdiContainer = true;           // form chứa các form con
            MainMenuStrip = menuMain;
            MinimumSize = new Size(760, 640);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BTVN_Tuan5";
            FormClosing += frmMain_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private static void Muc(ToolStripMenuItem m, string ten, string chu)
        {
            m.Name = ten;
            m.Text = chu;
        }

        private MenuStrip menuMain;
        private ToolStripMenuItem mnu5c;
        private ToolStripMenuItem mnu5d;
        private ToolStripMenuItem mnu5cBai1;
        private ToolStripMenuItem mnu5cBai2;
        private ToolStripMenuItem mnu5cBtvn1;
        private ToolStripMenuItem mnu5cBtvn2;
        private ToolStripMenuItem mnu5cBtvn3;
        private ToolStripMenuItem mnu5cNangcao;
        private ToolStripMenuItem mnu5dBai1;
        private ToolStripMenuItem mnu5dBai2;
        private ToolStripMenuItem mnu5dBtvn1;
        private ToolStripMenuItem mnu5dNangcao;
        private ToolStripMenuItem mnuCuaSo;
        private ToolStripMenuItem mnuXepChong;
        private ToolStripMenuItem mnuXepNgang;
        private ToolStripMenuItem mnuXepDoc;
        private ToolStripMenuItem mnuDongTatCa;
        private ToolStripMenuItem mnuThoat;
    }
}
