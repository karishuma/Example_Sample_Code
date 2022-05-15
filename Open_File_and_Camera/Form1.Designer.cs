
namespace Test_Chaper4
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.PB1 = new System.Windows.Forms.PictureBox();
            this.BT1 = new System.Windows.Forms.Button();
            this.BT2 = new System.Windows.Forms.Button();
            this.LS1 = new System.Windows.Forms.ListBox();
            this.BT_CLOSE = new System.Windows.Forms.Button();
            this.PB2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB2)).BeginInit();
            this.SuspendLayout();
            // 
            // PB1
            // 
            this.PB1.Location = new System.Drawing.Point(12, 12);
            this.PB1.Name = "PB1";
            this.PB1.Size = new System.Drawing.Size(284, 255);
            this.PB1.TabIndex = 0;
            this.PB1.TabStop = false;
            // 
            // BT1
            // 
            this.BT1.Location = new System.Drawing.Point(12, 273);
            this.BT1.Name = "BT1";
            this.BT1.Size = new System.Drawing.Size(75, 23);
            this.BT1.TabIndex = 1;
            this.BT1.Text = "Load File";
            this.BT1.UseVisualStyleBackColor = true;
            this.BT1.Click += new System.EventHandler(this.BT1_Click);
            // 
            // BT2
            // 
            this.BT2.Location = new System.Drawing.Point(93, 273);
            this.BT2.Name = "BT2";
            this.BT2.Size = new System.Drawing.Size(75, 23);
            this.BT2.TabIndex = 2;
            this.BT2.Text = "Open CAM";
            this.BT2.UseVisualStyleBackColor = true;
            this.BT2.Click += new System.EventHandler(this.BT2_Click);
            // 
            // LS1
            // 
            this.LS1.FormattingEnabled = true;
            this.LS1.ItemHeight = 12;
            this.LS1.Location = new System.Drawing.Point(12, 386);
            this.LS1.Name = "LS1";
            this.LS1.Size = new System.Drawing.Size(284, 52);
            this.LS1.TabIndex = 3;
            // 
            // BT_CLOSE
            // 
            this.BT_CLOSE.Location = new System.Drawing.Point(174, 273);
            this.BT_CLOSE.Name = "BT_CLOSE";
            this.BT_CLOSE.Size = new System.Drawing.Size(75, 23);
            this.BT_CLOSE.TabIndex = 4;
            this.BT_CLOSE.Text = "Close";
            this.BT_CLOSE.UseVisualStyleBackColor = true;
            this.BT_CLOSE.Click += new System.EventHandler(this.BT_CLOSE_Click);
            // 
            // PB2
            // 
            this.PB2.Location = new System.Drawing.Point(302, 12);
            this.PB2.Name = "PB2";
            this.PB2.Size = new System.Drawing.Size(284, 255);
            this.PB2.TabIndex = 5;
            this.PB2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PB2);
            this.Controls.Add(this.BT_CLOSE);
            this.Controls.Add(this.LS1);
            this.Controls.Add(this.BT2);
            this.Controls.Add(this.BT1);
            this.Controls.Add(this.PB1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB1;
        private System.Windows.Forms.Button BT1;
        private System.Windows.Forms.Button BT2;
        private System.Windows.Forms.ListBox LS1;
        private System.Windows.Forms.Button BT_CLOSE;
        private System.Windows.Forms.PictureBox PB2;
    }
}

