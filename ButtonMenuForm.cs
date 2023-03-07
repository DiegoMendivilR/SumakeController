using CESATAutomationDevelop.Screens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CESATAutomationDevelop
{
    class ButtonMenuForm : System.Windows.Forms.Button
    {
        System.Windows.Forms.Form form;
        public ButtonMenuForm(Form form, string name, string text, Image image)
        {
            //Name = "buttonIOCard";
            //Text = " I/O";
            //Image = global::CESATAutomationDevelop.Properties.Resources.icons8_chip_white_24;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.form = form;
            Name = name;
            Text = text;
            Image = image;
            BackColor = System.Drawing.Color.Transparent;
            Dock = System.Windows.Forms.DockStyle.Top;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ForeColor = System.Drawing.Color.White;
            ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Location = new System.Drawing.Point(0, 262);
            Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            Size = new System.Drawing.Size(200, 54);
            //TabIndex = 33;
            TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            UseVisualStyleBackColor = false;

            Click += ButtonMenuForm_Click;
        }
        public void ShowForm()
        {
            form.BringToFront();
            form.Show();
        }
        public Form Form { get => form; set
            {
                Form form = value;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.form = form;
            }
        }
        private void ButtonMenuForm_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(form is null);
            form?.BringToFront();
        }
    }
}
