using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab06
{
    public class LabForm : Form
    {
        protected FlowLayoutPanel ContentPanel;
        public LabForm(string title)
        {
            Text = title;
            Font = new Font("Segoe UI", 10);
            ClientSize = new Size(920, 620);
            StartPosition = FormStartPosition.CenterScreen;
            ContentPanel = new FlowLayoutPanel();
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.FlowDirection = FlowDirection.TopDown;
            ContentPanel.WrapContents = false;
            ContentPanel.AutoScroll = true;
            ContentPanel.Padding = new Padding(15);
            Controls.Add(ContentPanel);
            Label heading = new Label();
            heading.Text = title;
            heading.Font = new Font(Font, FontStyle.Bold);
            heading.AutoSize = true;
            heading.Margin = new Padding(3, 3, 3, 14);
            ContentPanel.Controls.Add(heading);
        }

        protected FlowLayoutPanel Row()
        {
            FlowLayoutPanel row = new FlowLayoutPanel();
            row.AutoSize = true;
            row.WrapContents = false;
            ContentPanel.Controls.Add(row);
            return row;
        }

        protected void Field(string label, Control input)
        {
            FlowLayoutPanel row = Row();
            Label caption = new Label();
            caption.Text = label;
            caption.Width = 190;
            caption.Padding = new Padding(0, 5, 0, 0);
            input.Width = 370;
            row.Controls.Add(caption);
            row.Controls.Add(input);
        }

        protected Button Button(FlowLayoutPanel row, string text, Action action)
        {
            Button button = new Button();
            button.Text = text;
            button.AutoSize = true;
            button.Height = 34;
            button.Click += delegate
            {
                Guard(action);
            };
            row.Controls.Add(button);
            return button;
        }

        public static void Guard(Action action)
        {
            try
            {
                action();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Kiểm tra dữ liệu hoặc kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public virtual void LoadData()
        {
        }
    }
}
