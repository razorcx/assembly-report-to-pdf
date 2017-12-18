namespace AssemblyReport
{
	partial class AssemblyReportForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyReportForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonGetAssemblyReport = new System.Windows.Forms.Button();
			this.comboBoxPhase = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.buttonExportToPDF = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxBuilder = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::AssemblyReport.Properties.Resources.Logo;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(159, 51);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 16;
			this.pictureBox1.TabStop = false;
			// 
			// buttonGetAssemblyReport
			// 
			this.buttonGetAssemblyReport.Location = new System.Drawing.Point(494, 111);
			this.buttonGetAssemblyReport.Name = "buttonGetAssemblyReport";
			this.buttonGetAssemblyReport.Size = new System.Drawing.Size(162, 40);
			this.buttonGetAssemblyReport.TabIndex = 18;
			this.buttonGetAssemblyReport.Text = "Get Assembly Report";
			this.buttonGetAssemblyReport.UseVisualStyleBackColor = true;
			this.buttonGetAssemblyReport.Click += new System.EventHandler(this.buttonGetAssemblyReport_Click);
			// 
			// comboBoxPhase
			// 
			this.comboBoxPhase.FormattingEnabled = true;
			this.comboBoxPhase.Location = new System.Drawing.Point(12, 125);
			this.comboBoxPhase.Name = "comboBoxPhase";
			this.comboBoxPhase.Size = new System.Drawing.Size(159, 24);
			this.comboBoxPhase.TabIndex = 19;
			this.comboBoxPhase.SelectedIndexChanged += new System.EventHandler(this.comboBoxPhase_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 17);
			this.label1.TabIndex = 20;
			this.label1.Text = "Phase";
			// 
			// treeView1
			// 
			this.treeView1.Location = new System.Drawing.Point(12, 156);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(644, 265);
			this.treeView1.TabIndex = 21;
			// 
			// buttonExportToPDF
			// 
			this.buttonExportToPDF.Location = new System.Drawing.Point(494, 427);
			this.buttonExportToPDF.Name = "buttonExportToPDF";
			this.buttonExportToPDF.Size = new System.Drawing.Size(162, 40);
			this.buttonExportToPDF.TabIndex = 22;
			this.buttonExportToPDF.Text = "Export To PDF";
			this.buttonExportToPDF.UseVisualStyleBackColor = true;
			this.buttonExportToPDF.Click += new System.EventHandler(this.buttonExportToPDF_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(220, 43);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 17);
			this.label7.TabIndex = 33;
			this.label7.Text = "Number";
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Location = new System.Drawing.Point(284, 40);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.ReadOnly = true;
			this.textBoxNumber.Size = new System.Drawing.Size(372, 22);
			this.textBoxNumber.TabIndex = 32;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(220, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 17);
			this.label6.TabIndex = 31;
			this.label6.Text = "Builder";
			// 
			// textBoxBuilder
			// 
			this.textBoxBuilder.Location = new System.Drawing.Point(284, 68);
			this.textBoxBuilder.Name = "textBoxBuilder";
			this.textBoxBuilder.ReadOnly = true;
			this.textBoxBuilder.Size = new System.Drawing.Size(372, 22);
			this.textBoxBuilder.TabIndex = 30;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(220, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 17);
			this.label5.TabIndex = 29;
			this.label5.Text = "Name";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(284, 12);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(372, 22);
			this.textBoxName.TabIndex = 28;
			// 
			// AssemblyReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 480);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBoxNumber);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxBuilder);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.buttonExportToPDF);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxPhase);
			this.Controls.Add(this.buttonGetAssemblyReport);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AssemblyReportForm";
			this.Text = "Assembly Report";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonGetAssemblyReport;
		private System.Windows.Forms.ComboBox comboBoxPhase;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button buttonExportToPDF;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxNumber;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxBuilder;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxName;
	}
}

