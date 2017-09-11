namespace LitmusParser
{
    partial class FrmSubmit
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbSyntax = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.chkClipboard = new System.Windows.Forms.CheckBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gb2.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSyntax
            // 
            this.cbSyntax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSyntax.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSyntax.FormattingEnabled = true;
            this.cbSyntax.Location = new System.Drawing.Point(57, 94);
            this.cbSyntax.Name = "cbSyntax";
            this.cbSyntax.Size = new System.Drawing.Size(72, 20);
            this.cbSyntax.TabIndex = 0;
            this.cbSyntax.SelectedIndexChanged += new System.EventHandler(this.cbSyntax_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "언어";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "코드";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "제목";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "코드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "문항";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(55, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "없음";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(55, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "없음";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(55, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "없음 - 없음";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(169, 505);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 25);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "제출";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(275, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "취소";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.chkClipboard);
            this.gb2.Controls.Add(this.tbComment);
            this.gb2.Location = new System.Drawing.Point(22, 232);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(353, 267);
            this.gb2.TabIndex = 12;
            this.gb2.TabStop = false;
            // 
            // chkClipboard
            // 
            this.chkClipboard.AutoSize = true;
            this.chkClipboard.Location = new System.Drawing.Point(220, 244);
            this.chkClipboard.Name = "chkClipboard";
            this.chkClipboard.Size = new System.Drawing.Size(124, 16);
            this.chkClipboard.TabIndex = 4;
            this.chkClipboard.Text = "클립보드 자동인식";
            this.chkClipboard.UseVisualStyleBackColor = true;
            this.chkClipboard.CheckedChanged += new System.EventHandler(this.chkClipboard_CheckedChanged);
            // 
            // tbComment
            // 
            this.tbComment.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbComment.Location = new System.Drawing.Point(11, 20);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbComment.Size = new System.Drawing.Size(331, 218);
            this.tbComment.TabIndex = 4;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.tbPath);
            this.gb1.Controls.Add(this.btnPath);
            this.gb1.Location = new System.Drawing.Point(22, 159);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(353, 49);
            this.gb1.TabIndex = 13;
            this.gb1.TabStop = false;
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(11, 17);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(290, 21);
            this.tbPath.TabIndex = 1;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(302, 17);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(40, 22);
            this.btnPath.TabIndex = 2;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Location = new System.Drawing.Point(25, 146);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(75, 16);
            this.rdb1.TabIndex = 1;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "파일 첨부";
            this.rdb1.UseVisualStyleBackColor = true;
            this.rdb1.CheckedChanged += new System.EventHandler(this.rdb1_CheckedChanged);
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Location = new System.Drawing.Point(25, 219);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(99, 16);
            this.rdb2.TabIndex = 3;
            this.rdb2.TabStop = true;
            this.rdb2.Text = "직접 붙여넣기";
            this.rdb2.UseVisualStyleBackColor = true;
            this.rdb2.CheckedChanged += new System.EventHandler(this.rdb2_CheckedChanged);
            // 
            // FrmSubmit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 540);
            this.Controls.Add(this.rdb2);
            this.Controls.Add(this.rdb1);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSyntax);
            this.Controls.Add(this.gb2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSubmit";
            this.Text = "제출";
            this.Activated += new System.EventHandler(this.FrmSubmit_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSubmit_FormClosing);
            this.Load += new System.EventHandler(this.FrmSubmit_Load);
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSyntax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.CheckBox chkClipboard;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}