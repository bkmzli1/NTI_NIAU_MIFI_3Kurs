namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предПросмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выводНаПечатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выравниваниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.левоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.центрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветТекстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветФонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.абзацToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new NewRTB2.NewRTB();
            this.miniToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.miniToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.файлToolStripMenuItem, this.форматированиеToolStripMenuItem });
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(800, 40);
            this.miniToolStrip.TabIndex = 0;
            this.miniToolStrip.Visible = false;
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.создатьДокументToolStripMenuItem, this.открытьToolStripMenuItem, this.сохранитьToolStripMenuItem, this.сохранитьКакToolStripMenuItem, this.toolStripSeparator1, this.печатьToolStripMenuItem, this.выходToolStripMenuItem });
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(88, 36);
            this.файлToolStripMenuItem.Text = "файл";
            // 
            // создатьДокументToolStripMenuItem
            // 
            this.создатьДокументToolStripMenuItem.Name = "создатьДокументToolStripMenuItem";
            this.создатьДокументToolStripMenuItem.Size = new System.Drawing.Size(258, 36);
            this.создатьДокументToolStripMenuItem.Text = "создать";
            this.создатьДокументToolStripMenuItem.Click += new System.EventHandler(this.создатьДокументToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(258, 36);
            this.открытьToolStripMenuItem.Text = "открыть";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(258, 36);
            this.сохранитьToolStripMenuItem.Text = "сохранить";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(258, 36);
            this.сохранитьКакToolStripMenuItem.Text = "сохранить как";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(255, 6);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.параметрыToolStripMenuItem, this.предПросмотрToolStripMenuItem, this.выводНаПечатьToolStripMenuItem });
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(258, 36);
            this.печатьToolStripMenuItem.Text = "печать";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(289, 36);
            this.параметрыToolStripMenuItem.Text = "параметры";
            // 
            // предПросмотрToolStripMenuItem
            // 
            this.предПросмотрToolStripMenuItem.Name = "предПросмотрToolStripMenuItem";
            this.предПросмотрToolStripMenuItem.Size = new System.Drawing.Size(289, 36);
            this.предПросмотрToolStripMenuItem.Text = "пред просмотр";
            // 
            // выводНаПечатьToolStripMenuItem
            // 
            this.выводНаПечатьToolStripMenuItem.Name = "выводНаПечатьToolStripMenuItem";
            this.выводНаПечатьToolStripMenuItem.Size = new System.Drawing.Size(289, 36);
            this.выводНаПечатьToolStripMenuItem.Text = "вывод на печать";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(258, 36);
            this.выходToolStripMenuItem.Text = "выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // форматированиеToolStripMenuItem
            // 
            this.форматированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.шрифтToolStripMenuItem, this.выравниваниеToolStripMenuItem, this.цветТекстToolStripMenuItem, this.цветФонаToolStripMenuItem, this.абзацToolStripMenuItem });
            this.форматированиеToolStripMenuItem.Name = "форматированиеToolStripMenuItem";
            this.форматированиеToolStripMenuItem.Size = new System.Drawing.Size(235, 36);
            this.форматированиеToolStripMenuItem.Text = "Форматирование";
            // 
            // шрифтToolStripMenuItem
            // 
            this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(266, 36);
            this.шрифтToolStripMenuItem.Text = "шрифт";
            // 
            // выравниваниеToolStripMenuItem
            // 
            this.выравниваниеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.левоToolStripMenuItem, this.правоToolStripMenuItem, this.центрToolStripMenuItem });
            this.выравниваниеToolStripMenuItem.Name = "выравниваниеToolStripMenuItem";
            this.выравниваниеToolStripMenuItem.Size = new System.Drawing.Size(266, 36);
            this.выравниваниеToolStripMenuItem.Text = "выравнивание";
            // 
            // левоToolStripMenuItem
            // 
            this.левоToolStripMenuItem.Name = "левоToolStripMenuItem";
            this.левоToolStripMenuItem.Size = new System.Drawing.Size(162, 36);
            this.левоToolStripMenuItem.Text = "лево";
            // 
            // правоToolStripMenuItem
            // 
            this.правоToolStripMenuItem.Name = "правоToolStripMenuItem";
            this.правоToolStripMenuItem.Size = new System.Drawing.Size(162, 36);
            this.правоToolStripMenuItem.Text = "право";
            // 
            // центрToolStripMenuItem
            // 
            this.центрToolStripMenuItem.Name = "центрToolStripMenuItem";
            this.центрToolStripMenuItem.Size = new System.Drawing.Size(162, 36);
            this.центрToolStripMenuItem.Text = "центр";
            // 
            // цветТекстToolStripMenuItem
            // 
            this.цветТекстToolStripMenuItem.Name = "цветТекстToolStripMenuItem";
            this.цветТекстToolStripMenuItem.Size = new System.Drawing.Size(266, 36);
            this.цветТекстToolStripMenuItem.Text = "цвет текст";
            // 
            // цветФонаToolStripMenuItem
            // 
            this.цветФонаToolStripMenuItem.Name = "цветФонаToolStripMenuItem";
            this.цветФонаToolStripMenuItem.Size = new System.Drawing.Size(266, 36);
            this.цветФонаToolStripMenuItem.Text = "цвет фона";
            // 
            // абзацToolStripMenuItem
            // 
            this.абзацToolStripMenuItem.Name = "абзацToolStripMenuItem";
            this.абзацToolStripMenuItem.Size = new System.Drawing.Size(266, 36);
            this.абзацToolStripMenuItem.Text = "абзац";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(80, 151);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.SelectionAlignment = NewRTB2.TextAlign.Left;
            this.richTextBox1.Size = new System.Drawing.Size(615, 101);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.miniToolStrip);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.miniToolStrip.ResumeLayout(false);
            this.miniToolStrip.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предПросмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выводНаПечатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выравниваниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem левоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem центрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветТекстToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветФонаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem абзацToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem встToolStripMenuItem;
        private NewRTB2.NewRTB richTextBox1;
    }
}