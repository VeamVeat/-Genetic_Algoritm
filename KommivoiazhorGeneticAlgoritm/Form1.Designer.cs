namespace KommivoiazhorGeneticAlgoritm
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose( bool disposing )
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.OneMain = new System.Windows.Forms.TextBox();
			this.TwoMain = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ShasTextBoks = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.BStartAlgoritm = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// OneMain
			// 
			this.OneMain.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.OneMain.Location = new System.Drawing.Point(7, 58);
			this.OneMain.Multiline = true;
			this.OneMain.Name = "OneMain";
			this.OneMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.OneMain.Size = new System.Drawing.Size(753, 30);
			this.OneMain.TabIndex = 0;
			// 
			// TwoMain
			// 
			this.TwoMain.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
			this.TwoMain.Location = new System.Drawing.Point(7, 125);
			this.TwoMain.Multiline = true;
			this.TwoMain.Name = "TwoMain";
			this.TwoMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TwoMain.Size = new System.Drawing.Size(753, 302);
			this.TwoMain.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(348, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 21);
			this.label1.TabIndex = 2;
			this.label1.Text = "OneMain";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(333, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 21);
			this.label2.TabIndex = 2;
			this.label2.Text = "LastOneMain";
			// 
			// ShasTextBoks
			// 
			this.ShasTextBoks.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
			this.ShasTextBoks.Location = new System.Drawing.Point(687, 24);
			this.ShasTextBoks.Name = "ShasTextBoks";
			this.ShasTextBoks.Size = new System.Drawing.Size(73, 28);
			this.ShasTextBoks.TabIndex = 3;
			this.ShasTextBoks.Text = "0";
			this.ShasTextBoks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold);
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(694, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 21);
			this.label3.TabIndex = 4;
			this.label3.Text = "KolShag";
			// 
			// BStartAlgoritm
			// 
			this.BStartAlgoritm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
			this.BStartAlgoritm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BStartAlgoritm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
			this.BStartAlgoritm.ForeColor = System.Drawing.Color.White;
			this.BStartAlgoritm.Location = new System.Drawing.Point(7, 9);
			this.BStartAlgoritm.Name = "BStartAlgoritm";
			this.BStartAlgoritm.Size = new System.Drawing.Size(75, 43);
			this.BStartAlgoritm.TabIndex = 5;
			this.BStartAlgoritm.Text = "Start";
			this.BStartAlgoritm.UseVisualStyleBackColor = false;
			this.BStartAlgoritm.Click += new System.EventHandler(this.BStartAlgoritm_Click);
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
			this.ClientSize = new System.Drawing.Size(772, 448);
			this.Controls.Add(this.BStartAlgoritm);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ShasTextBoks);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TwoMain);
			this.Controls.Add(this.OneMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "Form1";
			this.Text = "GeneticAlgoritm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ShasTextBoks;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button BStartAlgoritm;
		public System.Windows.Forms.TextBox OneMain;
		public System.Windows.Forms.TextBox TwoMain;
	}
}

