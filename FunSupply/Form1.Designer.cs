namespace FunSupply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProfileDir1 = new System.Windows.Forms.TextBox();
            this.txtProfile1 = new System.Windows.Forms.TextBox();
            this.txtProfile2 = new System.Windows.Forms.TextBox();
            this.txtProfileDir2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.btnWorker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(16, 111);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(273, 79);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Browser";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Profile 1";
            // 
            // txtProfileDir1
            // 
            this.txtProfileDir1.Location = new System.Drawing.Point(79, 27);
            this.txtProfileDir1.Name = "txtProfileDir1";
            this.txtProfileDir1.Size = new System.Drawing.Size(298, 22);
            this.txtProfileDir1.TabIndex = 2;
            this.txtProfileDir1.Text = "D:\\Data Funsupply\\user1\\User Data";
            // 
            // txtProfile1
            // 
            this.txtProfile1.Location = new System.Drawing.Point(383, 28);
            this.txtProfile1.Name = "txtProfile1";
            this.txtProfile1.Size = new System.Drawing.Size(122, 22);
            this.txtProfile1.TabIndex = 3;
            this.txtProfile1.Text = "Profile 1";
            // 
            // txtProfile2
            // 
            this.txtProfile2.Location = new System.Drawing.Point(383, 67);
            this.txtProfile2.Name = "txtProfile2";
            this.txtProfile2.Size = new System.Drawing.Size(122, 22);
            this.txtProfile2.TabIndex = 6;
            // 
            // txtProfileDir2
            // 
            this.txtProfileDir2.Location = new System.Drawing.Point(79, 67);
            this.txtProfileDir2.Name = "txtProfileDir2";
            this.txtProfileDir2.Size = new System.Drawing.Size(298, 22);
            this.txtProfileDir2.TabIndex = 5;
            this.txtProfileDir2.Text = "D:\\Data Funsupply\\user3\\User Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Profile 2";
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Location = new System.Drawing.Point(511, 27);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse1.TabIndex = 7;
            this.btnBrowse1.Text = "Browse...";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(511, 67);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse2.TabIndex = 8;
            this.btnBrowse2.Text = "Browse...";
            this.btnBrowse2.UseVisualStyleBackColor = true;
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // btnWorker
            // 
            this.btnWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.btnWorker.Location = new System.Drawing.Point(313, 111);
            this.btnWorker.Name = "btnWorker";
            this.btnWorker.Size = new System.Drawing.Size(273, 79);
            this.btnWorker.TabIndex = 9;
            this.btnWorker.Text = "Start Worker";
            this.btnWorker.UseVisualStyleBackColor = true;
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 327);
            this.Controls.Add(this.btnWorker);
            this.Controls.Add(this.btnBrowse2);
            this.Controls.Add(this.btnBrowse1);
            this.Controls.Add(this.txtProfile2);
            this.Controls.Add(this.txtProfileDir2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProfile1);
            this.Controls.Add(this.txtProfileDir1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Funsupply Tool Auction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProfileDir1;
        private System.Windows.Forms.TextBox txtProfile1;
        private System.Windows.Forms.TextBox txtProfile2;
        private System.Windows.Forms.TextBox txtProfileDir2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.Button btnBrowse2;
        private System.Windows.Forms.Button btnWorker;
    }
}

