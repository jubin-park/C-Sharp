using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// RegistryKey
using Microsoft.Win32;

// Directory
using System.IO;

namespace LitmusParser
{
    public partial class FrmSubmit : Form
    {

        public string q0, q1, q2, q3;
        public string old_data;

        // 레지스트리 생성
        public static RegistryKey rkey_create = Registry.CurrentUser.CreateSubKey(@"LitmusParser\temp");
        public static RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"LitmusParser\temp", true);
        public static int typeINT2;

        public FrmSubmit()
        {
            InitializeComponent();
        }

        private FrmMain mainForm = null;
        public FrmSubmit(Form callingForm)
        {
            mainForm = callingForm as FrmMain; 
            InitializeComponent();
        }

        private void FrmSubmit_Load(object sender, EventArgs e)
        {
            q0 = this.mainForm.GetLitmusQuestion(0); // 제목
            q1 = this.mainForm.GetLitmusQuestion(1); // 코드
            q2 = this.mainForm.GetLitmusQuestion(2); // 문제번호 영문
            q3 = this.mainForm.GetLitmusQuestion(3); // 문제번호 숫자

            label6.Text = q0;
            label7.Text = q1;
            label8.Text = q2 + " (" + q3 + ")";

            cbSyntax.Items.Insert(0, "C");
            cbSyntax.Items.Insert(1, "Cpp");
            cbSyntax.Items.Insert(2, "Java");

            openFileDialog1.Title = "파일 선택";
            openFileDialog1.Filter = "코드 파일 (*.c, *.cpp, *.java, *.txt)|*.c;*.cpp;*.java;*.txt";

            string path = this.mainForm.GetTbPath() + "\\" + q1;

            if (Directory.Exists(path))
                openFileDialog1.InitialDirectory = path;
            else
                openFileDialog1.InitialDirectory = @Application.StartupPath;

            openFileDialog1.FileName = q2 + "_" + q3;

            try
            {
                object type2 = rkey.GetValue("type2");
                typeINT2 = (type2 == null ? Convert.ToInt32("110001", 2) : Convert.ToInt32(type2));
                // 문법 선택
                cbSyntax.SelectedIndex = Convert.ToInt32(Math.Log(typeINT2 & Convert.ToInt32("000111", 2), 2));
                // 라디오 버튼
                if ((typeINT2 & 8) > 0) // 파일첨부
                {
                    rdb1.Checked = gb1.Enabled = true;
                    rdb2.Checked = gb2.Enabled = false;
                }
                if ((typeINT2 & 16) > 0)
                {
                    rdb1.Checked = gb1.Enabled = false;
                    rdb2.Checked = gb2.Enabled = true;
                }
                // 클립보드 자동 복사
                if ((typeINT2 & 32) > 0)
                {
                    chkClipboard.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool result = false;

            if (gb1.Enabled)
            {
                if (tbPath.Text == String.Empty)
                {
                    MessageBox.Show("소스 파일을 첨부하십시오.", this.mainForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    result = this.mainForm.litmusSubmit(q1, q3, (cbSyntax.SelectedIndex + 1).ToString(), tbComment.Text, tbPath.Text);
            }

            if (gb2.Enabled)
            {
                if (tbComment.Text == String.Empty)
                {
                    MessageBox.Show("코드를 입력하십시오.", this.mainForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    result = this.mainForm.litmusSubmit(q1, q3, (cbSyntax.SelectedIndex + 1).ToString(), tbComment.Text);
            }

            if (result)
            {
                MessageBox.Show("코드 제출에 성공하였습니다.", this.mainForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("코드 제출에 실패하였습니다.", this.mainForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmSubmit_Activated(object sender, EventArgs e)
        {
            if (!chkClipboard.Checked || !gb2.Enabled) return;

            string data = Clipboard.GetText();

            if (data.Length > 0 && old_data != data)
            {
                old_data = data;
                tbComment.Text = data;
                btnSubmit.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = openFileDialog1.FileName;
            }
            
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            gb1.Enabled = rdb1.Checked;
            if (rdb1.Checked)
            {
                typeINT2 &= ~Convert.ToInt32("011000", 2);
                typeINT2 |= Convert.ToInt32("001000", 2);
            }
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            gb2.Enabled = rdb2.Checked;
            if (rdb2.Checked)
            {
                typeINT2 &= ~Convert.ToInt32("011000", 2);
                typeINT2 |= Convert.ToInt32("010000", 2);
            }
        }


        private void cbSyntax_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbSyntax.SelectedIndex;
            switch (index)
            {
                case 0:
                    typeINT2 &= Convert.ToInt32("111000", 2);
                    typeINT2 |= Convert.ToInt32("000001", 2);
                    break;
                case 1:
                    typeINT2 &= Convert.ToInt32("111000", 2);
                    typeINT2 |= Convert.ToInt32("000010", 2);
                    break;
                case 2:
                    typeINT2 &= Convert.ToInt32("111000", 2);
                    typeINT2 |= Convert.ToInt32("000100", 2);
                    break;
            }
        }

        private void chkClipboard_CheckedChanged(object sender, EventArgs e)
        {
            typeINT2 &= ~Convert.ToInt32("100000", 2);

            if (chkClipboard.Checked)
            {
                typeINT2 |= Convert.ToInt32("100000", 2);
            }
            
        }

        private void FrmSubmit_FormClosing(object sender, FormClosingEventArgs e)
        {
            rkey.SetValue("type2", typeINT2);
        }
    }
}

