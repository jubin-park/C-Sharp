namespace LitmusParser
{
    partial class FrmMain
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.gbLitmus1 = new System.Windows.Forms.GroupBox();
            this.tbPw = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.chkbPw = new System.Windows.Forms.CheckBox();
            this.chkbId = new System.Windows.Forms.CheckBox();
            this.gbLitmus2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCode = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.gbKhub1 = new System.Windows.Forms.GroupBox();
            this.tbPw2 = new System.Windows.Forms.TextBox();
            this.btnLogin2 = new System.Windows.Forms.Button();
            this.tbId2 = new System.Windows.Forms.TextBox();
            this.chkbPw2 = new System.Windows.Forms.CheckBox();
            this.chkbId2 = new System.Windows.Forms.CheckBox();
            this.gbLitmus3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkComment = new System.Windows.Forms.CheckBox();
            this.cbExt = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstvQList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkBaseCode = new System.Windows.Forms.CheckBox();
            this.gbKhub2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExtracting = new System.Windows.Forms.Button();
            this.lstCode = new System.Windows.Forms.ListBox();
            this.lstvKhubList = new System.Windows.Forms.ListView();
            this.chClassId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClassName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnFolderBrowse = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbLitmus1.SuspendLayout();
            this.gbLitmus2.SuspendLayout();
            this.gbKhub1.SuspendLayout();
            this.gbLitmus3.SuspendLayout();
            this.gbKhub2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(181, 20);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 52);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gbLitmus1
            // 
            this.gbLitmus1.Controls.Add(this.tbPw);
            this.gbLitmus1.Controls.Add(this.btnLogin);
            this.gbLitmus1.Controls.Add(this.tbId);
            this.gbLitmus1.Controls.Add(this.chkbPw);
            this.gbLitmus1.Controls.Add(this.chkbId);
            this.gbLitmus1.Location = new System.Drawing.Point(12, 12);
            this.gbLitmus1.Name = "gbLitmus1";
            this.gbLitmus1.Size = new System.Drawing.Size(269, 100);
            this.gbLitmus1.TabIndex = 1;
            this.gbLitmus1.TabStop = false;
            this.gbLitmus1.Text = "리트머스 로그인";
            // 
            // tbPw
            // 
            this.tbPw.Location = new System.Drawing.Point(75, 50);
            this.tbPw.Name = "tbPw";
            this.tbPw.Size = new System.Drawing.Size(100, 21);
            this.tbPw.TabIndex = 3;
            this.tbPw.UseSystemPasswordChar = true;
            this.tbPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPw_KeyDown);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(75, 22);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(100, 21);
            this.tbId.TabIndex = 2;
            this.tbId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbId_KeyDown);
            // 
            // chkbPw
            // 
            this.chkbPw.AutoSize = true;
            this.chkbPw.Location = new System.Drawing.Point(21, 53);
            this.chkbPw.Name = "chkbPw";
            this.chkbPw.Size = new System.Drawing.Size(42, 16);
            this.chkbPw.TabIndex = 1;
            this.chkbPw.Text = "PW";
            this.chkbPw.UseVisualStyleBackColor = true;
            this.chkbPw.Click += new System.EventHandler(this.chkbPw_Click);
            // 
            // chkbId
            // 
            this.chkbId.AutoSize = true;
            this.chkbId.Location = new System.Drawing.Point(21, 23);
            this.chkbId.Name = "chkbId";
            this.chkbId.Size = new System.Drawing.Size(48, 16);
            this.chkbId.TabIndex = 0;
            this.chkbId.Text = "학번";
            this.chkbId.UseVisualStyleBackColor = true;
            this.chkbId.Click += new System.EventHandler(this.chkbId_Click);
            // 
            // gbLitmus2
            // 
            this.gbLitmus2.Controls.Add(this.label6);
            this.gbLitmus2.Controls.Add(this.label4);
            this.gbLitmus2.Controls.Add(this.label3);
            this.gbLitmus2.Controls.Add(this.label2);
            this.gbLitmus2.Controls.Add(this.label1);
            this.gbLitmus2.Controls.Add(this.btnCode);
            this.gbLitmus2.Controls.Add(this.tbCode);
            this.gbLitmus2.Enabled = false;
            this.gbLitmus2.Location = new System.Drawing.Point(12, 126);
            this.gbLitmus2.Name = "gbLitmus2";
            this.gbLitmus2.Size = new System.Drawing.Size(269, 197);
            this.gbLitmus2.TabIndex = 2;
            this.gbLitmus2.TabStop = false;
            this.gbLitmus2.Text = "리트머스 코드";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "  ";
            // 
            // btnCode
            // 
            this.btnCode.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCode.Location = new System.Drawing.Point(87, 47);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(75, 23);
            this.btnCode.TabIndex = 1;
            this.btnCode.Text = "코드변경";
            this.btnCode.UseVisualStyleBackColor = true;
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(75, 20);
            this.tbCode.MaxLength = 8;
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(100, 21);
            this.tbCode.TabIndex = 0;
            this.tbCode.Text = "NNNNNNXX";
            this.tbCode.Click += new System.EventHandler(this.tbCode_Click);
            // 
            // gbKhub1
            // 
            this.gbKhub1.Controls.Add(this.tbPw2);
            this.gbKhub1.Controls.Add(this.btnLogin2);
            this.gbKhub1.Controls.Add(this.tbId2);
            this.gbKhub1.Controls.Add(this.chkbPw2);
            this.gbKhub1.Controls.Add(this.chkbId2);
            this.gbKhub1.Location = new System.Drawing.Point(291, 12);
            this.gbKhub1.Name = "gbKhub1";
            this.gbKhub1.Size = new System.Drawing.Size(291, 100);
            this.gbKhub1.TabIndex = 3;
            this.gbKhub1.TabStop = false;
            this.gbKhub1.Text = "Khub 로그인";
            // 
            // tbPw2
            // 
            this.tbPw2.Location = new System.Drawing.Point(73, 50);
            this.tbPw2.Name = "tbPw2";
            this.tbPw2.Size = new System.Drawing.Size(118, 21);
            this.tbPw2.TabIndex = 3;
            this.tbPw2.UseSystemPasswordChar = true;
            this.tbPw2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPw2_KeyDown);
            // 
            // btnLogin2
            // 
            this.btnLogin2.Location = new System.Drawing.Point(200, 20);
            this.btnLogin2.Name = "btnLogin2";
            this.btnLogin2.Size = new System.Drawing.Size(77, 52);
            this.btnLogin2.TabIndex = 0;
            this.btnLogin2.Text = "로그인";
            this.btnLogin2.UseVisualStyleBackColor = true;
            this.btnLogin2.Click += new System.EventHandler(this.btnLogin2_Click);
            // 
            // tbId2
            // 
            this.tbId2.Location = new System.Drawing.Point(73, 23);
            this.tbId2.Name = "tbId2";
            this.tbId2.Size = new System.Drawing.Size(118, 21);
            this.tbId2.TabIndex = 2;
            this.tbId2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbId2_KeyDown);
            // 
            // chkbPw2
            // 
            this.chkbPw2.AutoSize = true;
            this.chkbPw2.Location = new System.Drawing.Point(22, 54);
            this.chkbPw2.Name = "chkbPw2";
            this.chkbPw2.Size = new System.Drawing.Size(42, 16);
            this.chkbPw2.TabIndex = 1;
            this.chkbPw2.Text = "PW";
            this.chkbPw2.UseVisualStyleBackColor = true;
            this.chkbPw2.Click += new System.EventHandler(this.chkbPw2_Click);
            // 
            // chkbId2
            // 
            this.chkbId2.AutoSize = true;
            this.chkbId2.Location = new System.Drawing.Point(22, 25);
            this.chkbId2.Name = "chkbId2";
            this.chkbId2.Size = new System.Drawing.Size(35, 16);
            this.chkbId2.TabIndex = 0;
            this.chkbId2.Text = "ID";
            this.chkbId2.UseVisualStyleBackColor = true;
            this.chkbId2.Click += new System.EventHandler(this.chkbId2_Click);
            // 
            // gbLitmus3
            // 
            this.gbLitmus3.Controls.Add(this.btnSave);
            this.gbLitmus3.Controls.Add(this.chkComment);
            this.gbLitmus3.Controls.Add(this.cbExt);
            this.gbLitmus3.Controls.Add(this.label8);
            this.gbLitmus3.Controls.Add(this.lstvQList);
            this.gbLitmus3.Controls.Add(this.chkBaseCode);
            this.gbLitmus3.Enabled = false;
            this.gbLitmus3.Location = new System.Drawing.Point(12, 336);
            this.gbLitmus3.Name = "gbLitmus3";
            this.gbLitmus3.Size = new System.Drawing.Size(587, 203);
            this.gbLitmus3.TabIndex = 9;
            this.gbLitmus3.TabStop = false;
            this.gbLitmus3.Text = "리트머스 문제 리스트";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(499, 125);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "파일로 저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSaveC_Click);
            // 
            // chkComment
            // 
            this.chkComment.AutoSize = true;
            this.chkComment.Location = new System.Drawing.Point(426, 156);
            this.chkComment.Name = "chkComment";
            this.chkComment.Size = new System.Drawing.Size(100, 16);
            this.chkComment.TabIndex = 8;
            this.chkComment.Text = "문제주석 삽입";
            this.chkComment.UseVisualStyleBackColor = true;
            this.chkComment.Click += new System.EventHandler(this.chkComment_Click);
            // 
            // cbExt
            // 
            this.cbExt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExt.FormattingEnabled = true;
            this.cbExt.Location = new System.Drawing.Point(424, 127);
            this.cbExt.Name = "cbExt";
            this.cbExt.Size = new System.Drawing.Size(71, 20);
            this.cbExt.TabIndex = 7;
            this.cbExt.SelectedIndexChanged += new System.EventHandler(this.cbExt_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(424, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "체크한 문제를";
            // 
            // lstvQList
            // 
            this.lstvQList.CheckBoxes = true;
            this.lstvQList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstvQList.FullRowSelect = true;
            this.lstvQList.Location = new System.Drawing.Point(10, 20);
            this.lstvQList.Name = "lstvQList";
            this.lstvQList.OwnerDraw = true;
            this.lstvQList.Size = new System.Drawing.Size(404, 177);
            this.lstvQList.TabIndex = 0;
            this.lstvQList.UseCompatibleStateImageBehavior = false;
            this.lstvQList.View = System.Windows.Forms.View.Details;
            this.lstvQList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstvQList_ColumnClick);
            this.lstvQList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstvQList_DrawColumnHeader);
            this.lstvQList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstvQList_DrawItem);
            this.lstvQList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstvQList_DrawSubItem);
            this.lstvQList.DoubleClick += new System.EventHandler(this.lstvQList_DoubleClick);
            this.lstvQList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstvQList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "번호";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "제목";
            this.columnHeader2.Width = 255;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "결과";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 38;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "문제번호";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "실습코드";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // chkBaseCode
            // 
            this.chkBaseCode.AutoSize = true;
            this.chkBaseCode.Location = new System.Drawing.Point(426, 178);
            this.chkBaseCode.Name = "chkBaseCode";
            this.chkBaseCode.Size = new System.Drawing.Size(100, 16);
            this.chkBaseCode.TabIndex = 9;
            this.chkBaseCode.Text = "기초코드 삽입";
            this.chkBaseCode.UseVisualStyleBackColor = true;
            this.chkBaseCode.Click += new System.EventHandler(this.chkBaseCode_Click);
            // 
            // gbKhub2
            // 
            this.gbKhub2.Controls.Add(this.label5);
            this.gbKhub2.Controls.Add(this.btnExtracting);
            this.gbKhub2.Controls.Add(this.lstCode);
            this.gbKhub2.Controls.Add(this.lstvKhubList);
            this.gbKhub2.Enabled = false;
            this.gbKhub2.Location = new System.Drawing.Point(291, 126);
            this.gbKhub2.Name = "gbKhub2";
            this.gbKhub2.Size = new System.Drawing.Size(308, 197);
            this.gbKhub2.TabIndex = 10;
            this.gbKhub2.TabStop = false;
            this.gbKhub2.Text = "Khub에서 코드 추출하기";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "추출된 코드";
            // 
            // btnExtracting
            // 
            this.btnExtracting.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExtracting.Location = new System.Drawing.Point(209, 161);
            this.btnExtracting.Name = "btnExtracting";
            this.btnExtracting.Size = new System.Drawing.Size(82, 27);
            this.btnExtracting.TabIndex = 12;
            this.btnExtracting.Text = "더 추출하기";
            this.btnExtracting.UseVisualStyleBackColor = true;
            this.btnExtracting.Click += new System.EventHandler(this.btnExtracting_Click);
            // 
            // lstCode
            // 
            this.lstCode.FormattingEnabled = true;
            this.lstCode.ItemHeight = 12;
            this.lstCode.Location = new System.Drawing.Point(210, 44);
            this.lstCode.Margin = new System.Windows.Forms.Padding(0);
            this.lstCode.Name = "lstCode";
            this.lstCode.Size = new System.Drawing.Size(81, 112);
            this.lstCode.TabIndex = 10;
            this.lstCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstCode_MouseClick);
            this.lstCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstCode_KeyDown);
            this.lstCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCode_MouseDoubleClick);
            // 
            // lstvKhubList
            // 
            this.lstvKhubList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chClassId,
            this.chClassName});
            this.lstvKhubList.FullRowSelect = true;
            this.lstvKhubList.Location = new System.Drawing.Point(7, 20);
            this.lstvKhubList.Name = "lstvKhubList";
            this.lstvKhubList.Size = new System.Drawing.Size(197, 168);
            this.lstvKhubList.TabIndex = 9;
            this.lstvKhubList.UseCompatibleStateImageBehavior = false;
            this.lstvKhubList.View = System.Windows.Forms.View.Details;
            this.lstvKhubList.DoubleClick += new System.EventHandler(this.lstvKhubList_DoubleClick);
            this.lstvKhubList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstvKhubList_KeyDown);
            // 
            // chClassId
            // 
            this.chClassId.Text = "index";
            this.chClassId.Width = 43;
            // 
            // chClassName
            // 
            this.chClassName.Text = "수강중인 과목명";
            this.chClassName.Width = 150;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(198, 90);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "브라우저로";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(498, 90);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(65, 12);
            this.linkLabel2.TabIndex = 16;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "브라우저로";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(436, 407);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(155, 28);
            this.btnOpenFolder.TabIndex = 22;
            this.btnOpenFolder.Text = "폴더 열기";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnFolderBrowse
            // 
            this.btnFolderBrowse.Location = new System.Drawing.Point(558, 358);
            this.btnFolderBrowse.Name = "btnFolderBrowse";
            this.btnFolderBrowse.Size = new System.Drawing.Size(33, 20);
            this.btnFolderBrowse.TabIndex = 21;
            this.btnFolderBrowse.Text = "...";
            this.btnFolderBrowse.UseVisualStyleBackColor = true;
            this.btnFolderBrowse.Click += new System.EventHandler(this.btnFolderBrowse_Click);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(435, 381);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(156, 21);
            this.tbPath.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(437, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "문제 파일 저장경로";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 552);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnFolderBrowse);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.gbKhub2);
            this.Controls.Add(this.gbLitmus3);
            this.Controls.Add(this.gbKhub1);
            this.Controls.Add(this.gbLitmus2);
            this.Controls.Add(this.gbLitmus1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LitmusParser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gbLitmus1.ResumeLayout(false);
            this.gbLitmus1.PerformLayout();
            this.gbLitmus2.ResumeLayout(false);
            this.gbLitmus2.PerformLayout();
            this.gbKhub1.ResumeLayout(false);
            this.gbKhub1.PerformLayout();
            this.gbLitmus3.ResumeLayout(false);
            this.gbLitmus3.PerformLayout();
            this.gbKhub2.ResumeLayout(false);
            this.gbKhub2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox gbLitmus1;
        private System.Windows.Forms.CheckBox chkbId;
        private System.Windows.Forms.CheckBox chkbPw;
        private System.Windows.Forms.TextBox tbPw;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.GroupBox gbLitmus2;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Button btnCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbKhub1;
        private System.Windows.Forms.TextBox tbPw2;
        private System.Windows.Forms.Button btnLogin2;
        private System.Windows.Forms.TextBox tbId2;
        private System.Windows.Forms.CheckBox chkbPw2;
        private System.Windows.Forms.CheckBox chkbId2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbLitmus3;
        private System.Windows.Forms.ListView lstvQList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox gbKhub2;
        private System.Windows.Forms.Button btnExtracting;
        private System.Windows.Forms.ListBox lstCode;
        private System.Windows.Forms.ListView lstvKhubList;
        private System.Windows.Forms.ColumnHeader chClassId;
        private System.Windows.Forms.ColumnHeader chClassName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnFolderBrowse;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkComment;
        private System.Windows.Forms.CheckBox chkBaseCode;
        private System.Windows.Forms.ComboBox cbExt;
    }
}

