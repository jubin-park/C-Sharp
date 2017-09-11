/*
 * title    LitmusParser
 * author   jubin-park
 * data     04/16/2017 ~ 05/15/2017
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Text.RegularExpressions;

using HtmlAgilityPack;
using HtmlAgilityPack.Samples;

using Microsoft.Win32;

using SHDocVw;
using mshtml;

using System.Collections;
using System.Collections.Specialized;

namespace LitmusParser
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        public static CookieContainer g_litmus_cookie;
        public static CookieContainer g_khub_cookie;
        public static int code_page = 0;
        public static string class_index;

        public static string mypath = @Application.StartupPath;
        public static int typeINT;

        // 레지스트리 생성
        public static RegistryKey rkey_create = Registry.CurrentUser.CreateSubKey(@"LitmusParser\temp");
        public static RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"LitmusParser\temp", true);

        public bool LitmusLogin(string id, string pw)
        {
            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://litmus.chonbuk.ac.kr/bbs/bbs/login_check.php");

            request.Method = "POST";
            request.Referer = "http://litmus.chonbuk.ac.kr/web/";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cookie;

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            id = str2webstr(id);
            pw = str2webstr(pw);
            sw.Write("url=%252Fweb%252F&mb_id=" + id + "&mb_password=" + pw);
            sw.Close();

            HttpWebResponse result = (HttpWebResponse)request.GetResponse();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Stream strReceive = result.GetResponseStream();
                StreamReader reqStreamReader = new StreamReader(strReceive, Encoding.UTF8);

                string strResult = reqStreamReader.ReadToEnd();

                request.Abort();
                strReceive.Close();
                reqStreamReader.Close();

                //MessageBox.Show(strResult);
                //if (strResult.Contains("가입된 회원이 아니거나 패스워드가 틀립니다.") || (strResult.Contains("회원아이디나 패스워드가 공백이면 안됩니다.")) || (strResult.Contains("history.go(-1)")) )
                
                if (strResult.Contains("location.replace"))
                { 
                    g_litmus_cookie = cookie;
                    return true;
                }
            }
            return false;
        }

        public int LitmusCodeInput(string code)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://litmus.chonbuk.ac.kr/web/exam.change_exam.exe.php");
            request.Method = "POST";
            request.Referer = "http://litmus.chonbuk.ac.kr/exam/";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = g_litmus_cookie;

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write("new_exam=" + code);
            sw.Close();

            HttpWebResponse result = (HttpWebResponse)request.GetResponse();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Stream strReceive = result.GetResponseStream();
                StreamReader reqStreamReader = new StreamReader(strReceive, Encoding.UTF8);
                string strResult = reqStreamReader.ReadToEnd();
                request.Abort();
                strReceive.Close();
                reqStreamReader.Close();

                //MessageBox.Show(strResult);

                if (strResult.Contains("잘못된 시험 코드 입니다.")) // 코드가 이상함
                    return 0;
                else
                {

                    request = (HttpWebRequest)WebRequest.Create("http://litmus.chonbuk.ac.kr/exam/");
                    request.Method = "GET";
                    request.CookieContainer = g_litmus_cookie;

                    result = (HttpWebResponse)request.GetResponse();
                    strReceive = result.GetResponseStream();
                    StreamReader srReadData1 = new StreamReader(strReceive, Encoding.UTF8);
                    strResult = srReadData1.ReadToEnd();

                    //MessageBox.Show(strResult);

                    if (strResult.Contains("잘못된 시험코드이거나 시험시간이 아님")) // 코드는 맞으나, 이미 끝난 시험코드.
                    {
                        return 1;
                    }
                    else // 지금 진행중인 시험코드
                    {

                        //Match re = Regex.Match(strResult, );


                        // -- 문제 정보 --

                        var theRegexMatches = Regex.Matches(strResult, "<tr align=center valign=center height=(.+)><td>(.*)</td><td>&nbsp;(.*)</td></tr>", RegexOptions.Compiled);
                        int[] iVariable = new int[4] { 1, 2, 3, 4 };
                        int i=1;

                        foreach (Match theMatch in theRegexMatches)
                        {
                           // MessageBox.Show(theMatch.Groups[2].Value + " : " + theMatch.Groups[3].Value); // 인덱스 1부터 시작
                            Label lbTarget = (Controls.Find("label" + i.ToString(), true)[0] as Label);
                            lbTarget.Text = theMatch.Groups[2].Value + " : " + theMatch.Groups[3].Value;
                            i++;
                        }

                        // -- 문제 리스트 --
                        // 1 : 문제 알파벳(A, B, C..)
                        // 2 : 리트머스 실습코드
                        // 3 : 문제 번호(약 1만단위)
                        // 4 : 문제 제목
                        // 5 : 성공 여부

                        string q_engnum;
                        string q_code;
                        string q_num;
                        string q_title;
                        string q_succ;

                        var theRegexMatches2 = Regex.Matches(strResult, "<tr align=center valign=center height=26><td>(.)</td>\n" + 
                            "<td><a href=\"/exam/(\\d\\d\\d\\d\\d\\d[A-Z][A-Z])/problem/(\\d+)/\">(.*)</td>\n" +
                            "<td bgcolor=(#ddffdd|#dddddd)>(성공|&nbsp;)</td>", RegexOptions.Compiled);

                        lstvQList.Items.Clear();
                        ListViewItem.ListViewSubItemCollection lvsub;

                        foreach (Match theMatch2 in theRegexMatches2)
                        {
                            q_engnum = theMatch2.Groups[1].Value;
                            q_code   = theMatch2.Groups[2].Value;
                            q_num    = theMatch2.Groups[3].Value;
                            q_title  = theMatch2.Groups[4].Value;
                            q_succ   = theMatch2.Groups[6].Value;
                            if (q_succ == "&nbsp;")
                            {
                                q_succ = "안품";
                            }

                            //MessageBox.Show(q_engnum + "\n" + q_code + "\n" + q_num + "\n" + q_title + "\n" + q_succ);

                            ListViewItem item = lstvQList.FindItemWithText(q_engnum);

                            if (item == null)
                            {
                                lvsub = lstvQList.Items.Add(q_engnum).SubItems; // ID
                                lvsub.Add(q_title);                             // Class Name
                                lvsub.Add(q_succ);
                                lvsub.Add(q_num);
                                lvsub.Add(q_code);
                            }
                                
                        }

                    
                        return 2;
                    }

                }
            }

            return 1;
        }

        public bool KhubLogin(string id, string pw)
        {
            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.khub.ac.kr/login/loginCheck.jsp");

            request.Method = "POST";
            request.Referer = "https://www.khub.ac.kr/login/login2.jsp";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cookie;

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            id = str2webstr(id);
            pw = str2webstr(pw);

            //MessageBox.Show("login=" + id + "&passwd=" + pw);

            sw.Write("login=" + id + "&passwd=" + pw);
            sw.Close();

            HttpWebResponse result = (HttpWebResponse)request.GetResponse();
            
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Stream strReceive = result.GetResponseStream();
                StreamReader reqStreamReader = new StreamReader(strReceive, Encoding.UTF8);

                string strResult = reqStreamReader.ReadToEnd();

                request.Abort();
                strReceive.Close();
                reqStreamReader.Close();
                
                //MessageBox.Show(strResult);
                if (strResult.Contains("success")) // success || success_mypage
                {
                    g_khub_cookie = cookie;
                    return true;
                }
            }
            return false;
        }

        public bool KhubBrowseClass(int page=1)
        {
            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.khub.ac.kr/mypage/group/myGroupList.jsp");

            request.Method = "POST";
            request.CookieContainer = g_khub_cookie;
            request.Referer = "https://www.khub.ac.kr/mypage/group/index.jsp"; //"javascript:check_login_form();";
            request.ContentType = "application/x-www-form-urlencoded";

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write("start=" + page.ToString()); // 현재 페이지
            sw.Close();

            HttpWebResponse result = (HttpWebResponse)request.GetResponse();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Stream strReceive = result.GetResponseStream();
                StreamReader reqStreamReader = new StreamReader(strReceive, Encoding.UTF8);

                string strResult = reqStreamReader.ReadToEnd();

                request.Abort();
                strReceive.Close();
                reqStreamReader.Close();

                //MessageBox.Show(strResult);

                if (!strResult.Contains("javascript:selectGroup"))
                    return false;

                var theRegexMatches = Regex.Matches(strResult, "javascript:selectGroup\\((\\d+),\'(.*)\',\\d+,(true|false)\\)", RegexOptions.Compiled);
                //javascript:selectGroup(498,'[2017] C언어기초 8분반',0,false)

                lstvKhubList.Items.Clear();
                ListViewItem.ListViewSubItemCollection lvsub;

                foreach (Match theMatch in theRegexMatches)
                {
                    string class_id = theMatch.Groups[1].Value;
                    string class_name = theMatch.Groups[2].Value;
                    ListViewItem item = lstvKhubList.FindItemWithText(class_id);

                    if (item == null)
                    {
                        lvsub = lstvKhubList.Items.Add(class_id).SubItems; // ID
                        lvsub.Add(class_name);                            // Class Name
                    }

                }

            }
            return true;
        }

        public bool KhubEnterClass(string index, int page = 0)
        {

            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.khub.ac.kr/sns/mainBoardList.jsp?puser_id=0&group_id=" + index + "&reload=" + page.ToString());

            request.Method = "GET";
            request.CookieContainer = g_khub_cookie;
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse result = (HttpWebResponse)request.GetResponse();

            string strResult = "";
            using (var wRes = (HttpWebResponse)request.GetResponse())
            {
                Stream respPostStream = wRes.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.UTF8, true);
                strResult = readerPost.ReadToEnd();
            }

            //MessageBox.Show(strResult);

            if (strResult.Contains("<div>no result</div>"))
            {
                code_page--;
                MessageBox.Show("추출할 코드가 더 이상 없습니다. " + "(" + code_page.ToString() + ")", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            var theRegexMatches = Regex.Matches(strResult, "(\\d\\d\\d\\d\\d\\d[A-Z][A-Z])", RegexOptions.Compiled);

            string code = "";

            foreach (Match theMatch in theRegexMatches)
            {
                code = theMatch.Groups[1].Value;
                if (!lstCode.Items.Contains(code))
                {
                    lstCode.Items.Add(code);
                }
            }

            return true;
        }

        public string LitmusViewProblem(string q_code, string q_number)
        {

            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://litmus.chonbuk.ac.kr/exam/" + q_code + "/problem/" + q_number + "/");

            request.Method = "GET";
            request.CookieContainer = g_litmus_cookie;
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse result = (HttpWebResponse)request.GetResponse();

            string strResult = "";
            using (var wRes = (HttpWebResponse)request.GetResponse())
            {
                Stream respPostStream = wRes.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.UTF8, true);
                strResult = readerPost.ReadToEnd();
            }

            if (strResult.Contains("<h1>잘못된 요청입니다.</h1>"))
            {
                MessageBox.Show("잘못된 시험코드 입니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            return strResult;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (LitmusLogin(tbId.Text, tbPw.Text))
            {
                //MessageBox.Show("로그인 성공", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbLitmus1.Enabled = false;
                gbLitmus2.Enabled = true;
                gbLitmus3.Enabled = true;
                linkLabel1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Litmus 로그인에 실패하였습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbId.Focus(); tbId.SelectAll();
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            if (tbCode.Text.Length == tbCode.MaxLength)
            {
                int result = LitmusCodeInput(tbCode.Text);

                label6.Text = "입력한 코드 : " + tbCode.Text;

                if (result != 2)
                {
                    label1.Text = "시험제목 : 존재하지 않음";
                    label2.Text = "교수님 : 존재하지 않음";
                    label3.Text = "시작시간 : 존재하지 않음";
                    label4.Text = "종료시간 : 존재하지 않음";
                    tbCode.BackColor = Color.FromArgb(255, 232, 232);
                    lstvQList.Items.Clear();

                    MessageBox.Show("코드 '" + tbCode.Text + "' 는 잘못된 시험코드거나, 현재 시험 기간이 아닙니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tbCode.BackColor = Color.FromArgb(255, 255, 225);//SystemColors.Info;
                }
            }
            else
            {
                MessageBox.Show("코드 8 자리 수를 정확하게 입력하세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbCode.Focus(); tbCode.SelectAll();
            }
        }

        private void btnLogin2_Click(object sender, EventArgs e)
        {

            int i = 1;

            if (KhubLogin(tbId2.Text, tbPw2.Text))
            {
                //MessageBox.Show("로그인 성공", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbKhub1.Enabled = false;
                gbKhub2.Enabled = true;
                while (true)
                {
                    if (KhubBrowseClass(i) == false)
                        break;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Khub 로그인에 실패하였습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbId2.Focus(); tbId2.SelectAll();
            }
            
        }

        private void lstvKhubList_DoubleClick(object sender, EventArgs e)
        {
            if (lstvKhubList.SelectedItems.Count == 1)
            {
                class_index = lstvKhubList.SelectedItems[0].SubItems[0].Text;
                code_page = 0;
                lstCode.Items.Clear();
                KhubEnterClass(class_index);
            }
        }

        private void lstvKhubList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lstvKhubList.SelectedItems.Count == 1)
                {
                    class_index = lstvKhubList.SelectedItems[0].SubItems[0].Text;
                    code_page = 0;
                    lstCode.Items.Clear();
                    KhubEnterClass(class_index);
                }
            }
        }

        private void lstCode_MouseClick(object sender, MouseEventArgs e)
        {
            if ((gbLitmus2.Enabled == true) && (lstCode.SelectedItems.Count > 0))
            {
                    tbCode.Text = lstCode.Items[lstCode.SelectedIndex].ToString();
            }
        }

        private void lstCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((gbLitmus2.Enabled == true) && (lstCode.SelectedItems.Count > 0))
            {
                tbCode.Text = lstCode.Items[lstCode.SelectedIndex].ToString();
                btnCode_Click(sender, e);
            }
        }

        private void lstCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((gbLitmus2.Enabled == true) && (lstCode.SelectedItems.Count > 0))
            {
                tbCode.Text = lstCode.Items[lstCode.SelectedIndex].ToString();
                btnCode_Click(sender, e);
            }
        }


        private void tbCode_Click(object sender, EventArgs e)
        {
            if (tbCode.Text == "NNNNNNXX") tbCode.Text = "";
            else { tbCode.Focus(); tbCode.SelectAll(); }
        }

        private void btnExtracting_Click(object sender, EventArgs e)
        {
            KhubEnterClass(class_index, ++code_page);
        }

        private void saveLitmusFile(string extension)
        {
            ListView.CheckedListViewItemCollection cItems = lstvQList.CheckedItems;

            if (cItems.Count >= 1)
            {

                string filename = "";

                string q_eng_num = "";
                string q_num = "";
                string q_code = "";
                string q_body = "";

                string body = "";
                string plain_body = "";

                HtmlToText file = new HtmlToText();

                bool savethis = false;

                mypath = tbPath.Text;

                foreach (ListViewItem item in cItems)
                {

                    savethis = false;

                    ListViewItem lvItem = item;

                    q_eng_num = lvItem.Text;
                    q_num     = lvItem.SubItems[3].Text;
                    q_code    = lvItem.SubItems[4].Text;
                    q_body    = LitmusViewProblem(q_code, q_num);

                    string[] words = Regex.Split(q_body, "시간제한: \\d+ MS");
                    words = Regex.Split(words[1], "</div><br>");
                    body = words[0];
                    body = body.Replace("&nbsp;", " ");

                    // 폴더 생성
                    System.IO.Directory.CreateDirectory(mypath + "\\" + q_code);

                    if (extension == ".html")
                    {
                        // html 폴더 생성
                        System.IO.Directory.CreateDirectory(mypath + "\\" + q_code + "\\html");
                        filename = mypath + "\\" + q_code + "\\" + "html\\" + q_eng_num + "_" + q_num + ".html";
                    }
                    else if (extension == ".c") filename = mypath + "\\" + q_code + "\\" + q_eng_num + "_" + q_num + ".c";
                    else if (extension == ".cpp") filename = mypath + "\\" + q_code + "\\" + q_eng_num + "_" + q_num + ".cpp";
                    else if (extension == ".java") filename = mypath + "\\" + q_code + "\\" + q_eng_num + "_" + q_num + ".java";

                    // 파일 존재 유무

                    if (File.Exists(filename))
                    {
                        DialogResult dialogResult;
                        dialogResult = MessageBox.Show("이미 \n\n\'" + filename + "\'\n\n 파일이 존재합니다. 덮어쓰시겠습니까?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)       // 예
                            savethis = true; 
                        else if (dialogResult == DialogResult.No)   // 아니오
                        {
                            savethis = false;
                            continue;        
                        }
                        else                                        // 취소
                        {
                            savethis = false;
                            break;           
                        }
                    }
                    else savethis = true;

                    // ==========================================================================================================================================================
                    if (extension == ".html") // html 파일
                    {
                        if (savethis)
                        {
                            // html 파일 생성
                            using (StreamWriter dw = new StreamWriter(filename, false, Encoding.UTF8))
                            {
                                dw.Write(body);
                                dw.Close();
                            }
                        }
                    }
                    // ==========================================================================================================================================================
                    else if (extension == ".c") // c 파일
                    {
                        if (savethis)
                        {
                            // 순수 텍스트만 추출
                            plain_body = file.ConvertHtml(body);
                            plain_body = plain_body.Replace("\t", "");
                            plain_body = plain_body.Replace("\r", "");

                            using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.GetEncoding("euc-kr")))
                            {
                                if (chkComment.Checked)
                                {
                                    sw.WriteLine("/*\r\n" + plain_body + "\r\n\r\n*/\r\n");
                                }
                                if (chkBaseCode.Checked)
                                {
                                    sw.WriteLine("#include <stdio.h>\n");
                                    sw.WriteLine("int main()\n{\n\t\n\treturn 0;\n}\n");
                                }
                                sw.Close();
                            }
                        }
                    }
                    else if (extension == ".cpp") // cpp 파일
                    {
                        if (savethis)
                        {
                            // 순수 텍스트만 추출
                            plain_body = file.ConvertHtml(body);
                            plain_body = plain_body.Replace("\t", "");
                            plain_body = plain_body.Replace("\r", "");

                            using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.GetEncoding("euc-kr")))
                            {
                                if (chkComment.Checked)
                                {
                                    sw.WriteLine("/*\r\n" + plain_body + "\r\n\r\n*/\r\n");
                                }
                                if (chkBaseCode.Checked)
                                {
                                    sw.WriteLine("#include <iostream>");
                                    sw.WriteLine("using namespace std;\n");
                                    sw.WriteLine("int main()\n{\n\t\n\treturn 0;\n}\n");
                                }
                                sw.Close();
                            }
                        }
                    }
                    else if (extension == ".java") // java 파일
                    {
                        if (savethis)
                        {
                            // 순수 텍스트만 추출
                            plain_body = file.ConvertHtml(body);
                            plain_body = plain_body.Replace("\t", "");
                            plain_body = plain_body.Replace("\r", "");
                            using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.GetEncoding("UTF-8")))
                            {
                                if (chkComment.Checked)
                                {
                                    sw.WriteLine("/*\r\n" + plain_body + "\r\n\r\n*/\r\n");
                                }
                                if (chkBaseCode.Checked)
                                {
                                    sw.WriteLine("public class " + q_eng_num + "_" + q_num); // A_123456
                                    sw.WriteLine("{");
                                    sw.WriteLine("\t" + "public static void main(String[] args)");
                                    sw.WriteLine("\t{");
                                    sw.WriteLine("\t\t");
                                    sw.WriteLine("\t\treturn;");
                                    sw.WriteLine("\t}");
                                    sw.WriteLine("}");
                                }
                                sw.Close();
                            }
                        }
                    }

                }

                if (savethis)
                    MessageBox.Show("저장 완료", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void lstvQList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.lstvQList.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.lstvQList.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.lstvQList.Items)
                    item.Checked = !value;

                this.lstvQList.Invalidate();
            }
        }

        private void lstvQList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lstvQList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstvQList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            cbExt.Items.Add("*.html");
            cbExt.Items.Add("*.c");
            cbExt.Items.Add("*.cpp");
            cbExt.Items.Add("*.java");

            object id, pw, id2, pw2, path, type;

            // 레지스트리 열기
            try
            {
                id = rkey.GetValue("litmus_id");
                pw = rkey.GetValue("litmus_pw");
                id2 = rkey.GetValue("khub_id");
                pw2 = rkey.GetValue("khub_pw");
                path = rkey.GetValue("path");
                type = rkey.GetValue("type");
                typeINT = (type == null ? Convert.ToInt32("110010", 2) : Convert.ToInt32(type));

                chkbId.Checked = (id != null);
                chkbPw.Checked = (pw != null);
                chkbId2.Checked = (id2 != null);
                chkbPw2.Checked = (pw2 != null);
                chkComment.Checked = (typeINT & (1 << 4)) > 0;
                chkBaseCode.Checked = (typeINT & (1 << 5)) > 0;

                cbExt.SelectedIndex = Convert.ToInt32(Math.Log(typeINT & Convert.ToInt32("001111", 2), 2));

                tbId.Text = (id == null ? "" : decodingStr(id.ToString()));
                tbPw.Text = (pw == null ? "" : decodingStr(pw.ToString()));
                tbId2.Text = (id2 == null ? "" : decodingStr(id2.ToString()));
                tbPw2.Text = (pw2 == null ? "" : decodingStr(pw2.ToString()));
                tbPath.Text = ( (path == null) || (!Directory.Exists(path.ToString())) ? mypath : path.ToString());
                
            }
            catch (Exception ex)
            {
                tbId.Text = "";
                tbPw.Text = "";
                tbId2.Text = "";
                tbPw2.Text = "";
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            rkey.SetValue("type", typeINT);
        }

        private void cbExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbExt.SelectedIndex;
            switch (index)
            {
                case 0:
                    typeINT &= ~Convert.ToInt32("001111", 2);
                    typeINT |= Convert.ToInt32("000001", 2);
                    break;
                case 1:
                    typeINT &= ~Convert.ToInt32("001111", 2);
                    typeINT |= Convert.ToInt32("000010", 2);
                    break;
                case 2:
                    typeINT &= ~Convert.ToInt32("001111", 2);
                    typeINT |= Convert.ToInt32("000100", 2);
                    break;
                case 3:
                    typeINT &= ~Convert.ToInt32("001111", 2);
                    typeINT |= Convert.ToInt32("001000", 2);
                    break;
            }
        }


        private string encodingStr(string plainString) // 변환 변환 변환 변환 변환 뒤집기
        {
            string encodedString;

            encodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainString));
            for (int i = 0; i < 4; i++)
            {
                encodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(encodedString));
            }

            encodedString = Reverse(encodedString);

            encodedString = encodedString.Remove(0, 1); // 맨 앞 = 삭제
            encodedString += "="; // 맨 뒤에 = 추가

            return encodedString;
        }

        private string decodingStr(string encodedString) // 뒤집기 변환 변환 변환 변환 변환
        {
            string plainString;
            int len;
            len = encodedString.Length;
            encodedString = encodedString.Remove(len - 1, 1);
            encodedString = "=" + encodedString;
            encodedString = Reverse(encodedString);
            
            plainString = Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
            for (int i = 0; i < 4; i++)
            {
                plainString = Encoding.UTF8.GetString(Convert.FromBase64String(plainString));
            }
            return plainString;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void chkbId_Click(object sender, EventArgs e)
        {
            if (chkbId.Checked)
            {
                rkey.SetValue("litmus_id", encodingStr(tbId.Text));
            }
            else
            {
                rkey.DeleteValue("litmus_id");
            }
        }

        private void chkbPw_Click(object sender, EventArgs e)
        {
            if (chkbPw.Checked)
            {
                rkey.SetValue("litmus_pw", encodingStr(tbPw.Text));
            }
            else
            {
                rkey.DeleteValue("litmus_pw");
            }
        }

        private void chkbId2_Click(object sender, EventArgs e)
        {
            if (chkbId2.Checked)
            {
                rkey.SetValue("khub_id", encodingStr(tbId2.Text));
            }
            else
            {
                rkey.DeleteValue("khub_id");
            }
        }

        private void chkbPw2_Click(object sender, EventArgs e)
        {
            if (chkbPw2.Checked)
            {
                rkey.SetValue("khub_pw", encodingStr(tbPw2.Text));
            }
            else
            {
                rkey.DeleteValue("khub_pw");
            }
        }

        private void chkComment_Click(object sender, EventArgs e)
        {
            typeINT &= Convert.ToInt32("101111", 2);
            if (chkComment.Checked) typeINT |= Convert.ToInt32("010000", 2);
                //rkey.SetValue("type", typeINT);
        }

        private void chkBaseCode_Click(object sender, EventArgs e)
        {
            typeINT &= Convert.ToInt32("011111", 2);
            if (chkBaseCode.Checked) typeINT |= Convert.ToInt32("100000", 2);
                //rkey.SetValue("type", typeINT);
        }

        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            string path = folderBrowserDialog1.SelectedPath;

            if (path != String.Empty)
            {
                mypath = tbPath.Text = path;
                rkey.SetValue("path", mypath);
            }
        }

        private void btnSaveC_Click(object sender, EventArgs e)
        {
            switch(cbExt.SelectedIndex)
            {
                case 0:
                    saveLitmusFile(".html");
                    break;
                case 1:
                    saveLitmusFile(".c");
                    break;
                case 2:
                    saveLitmusFile(".cpp");
                    break;
                case 3:
                    saveLitmusFile(".java");
                    break;
            }
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string id = "", pw = "";

            if (gbLitmus1.Enabled)
            {
                System.Diagnostics.Process.Start("iexplore.exe", "http://litmus.chonbuk.ac.kr/web/");
            }
            else
            {
                id = str2webstr(tbId.Text);
                pw = str2webstr(tbPw.Text);

                InternetExplorer IEControl = new InternetExplorer();
                IWebBrowserApp IE = (IWebBrowserApp)IEControl;
                IE.Visible = true;

                // Convert the string into a byte array
                ASCIIEncoding Encode = new ASCIIEncoding();
                byte[] post = Encode.GetBytes("url=%252Fweb%252F&mb_id=" + id + "&mb_password=" + pw);

                // The destination url
                string url = "http://litmus.chonbuk.ac.kr/bbs/bbs/login_check.php";

                // The same Header that its sent when you submit a form.
                string PostHeaders = "Content-Type: application/x-www-form-urlencoded";

                IE.Navigate(url, null, null, post, PostHeaders);
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(@tbPath.Text);
            if (Directory.Exists(@tbPath.Text))
                System.Diagnostics.Process.Start("explorer.exe", @tbPath.Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string id = "", pw = "";

            if (gbKhub1.Enabled)
            {
                System.Diagnostics.Process.Start("iexplore.exe", "https://www.khub.ac.kr/");
            }
            else
            {
                id = str2webstr(tbId2.Text);
                pw = str2webstr(tbPw2.Text);

                InternetExplorer IEControl = new InternetExplorer();
                IWebBrowserApp IE = (IWebBrowserApp)IEControl;
                
                // Convert the string into a byte array
                ASCIIEncoding Encode = new ASCIIEncoding();
                byte[] post = Encode.GetBytes("login=" + id + "&passwd=" + pw);

                // The destination url
                string url = "https://www.khub.ac.kr/login/loginCheck.jsp";

                // The same Header that its sent when you submit a form.
                string PostHeaders = "Content-Type: application/x-www-form-urlencoded";

                IE.Navigate(url, null, null, post, PostHeaders);
                while (IE.Busy)
                {
                    System.Threading.Thread.Sleep(1200);
                }

                IE.Navigate("https://www.khub.ac.kr/mypage/group/index.jsp");

                IE.Visible = true;
            }
        }

        private void tbId_KeyDown(object sender, KeyEventArgs e)
        {
          if (e.KeyCode == Keys.Enter)
              btnLogin_Click(sender, e);
        }

        private void tbPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void tbId2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin2_Click(sender, e);
        }

        private void tbPw2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin2_Click(sender, e);
        }


        private string str2webstr(string str1)
        {
            str1 = str1.Replace("%", "%25"); // first priority

            str1 = str1.Replace("`", "%60");
            str1 = str1.Replace("~", "%7E");
            str1 = str1.Replace("!", "%21");
            str1 = str1.Replace("#", "%23");
            str1 = str1.Replace("$", "%24");
            str1 = str1.Replace("^", "%5E");
            str1 = str1.Replace("&", "%26");
            str1 = str1.Replace("(", "%28");
            str1 = str1.Replace(")", "%29");
            str1 = str1.Replace("=", "%3D");
            str1 = str1.Replace("+", "%2B");
            str1 = str1.Replace("\\", "%5C");
            str1 = str1.Replace("|", "%7C");
            str1 = str1.Replace("/", "%2F");
            str1 = str1.Replace("[", "%5B");
            str1 = str1.Replace("]", "%5D");
            str1 = str1.Replace("{", "%7B");
            str1 = str1.Replace("}", "%7D");
            str1 = str1.Replace(";", "%3B");
            str1 = str1.Replace(":", "%3A");
            str1 = str1.Replace("'", "%27");
            str1 = str1.Replace("\"", "%22");
            str1 = str1.Replace("<", "%3C");
            str1 = str1.Replace(",", "%2C");
            str1 = str1.Replace(">", "%3E");
            str1 = str1.Replace(".", ".");
            str1 = str1.Replace("?", "%3F");

            return str1;
        }

        public bool litmusSubmit(string q_code, string q_number, string q_syntax, string q_comment, string q_filename="")
        {
            string boundary = "-----------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://litmus.chonbuk.ac.kr/web/submit.exe.php");

            request.Method = "POST";
            //request.Referer = "http://litmus.chonbuk.ac.kr/exam/" + q_code + "/submit/" + q_number;
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.CookieContainer = g_litmus_cookie;
            request.KeepAlive = true;
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = request.GetRequestStream();

            // 해시 생성
            NameValueCollection litmusCol = new NameValueCollection();
            litmusCol.Add("pid", q_number);
            litmusCol.Add("eid", q_code);
            litmusCol.Add("group", q_syntax); // c : 1 c++ : 2 java : 3
            if (q_filename != String.Empty)
                q_comment = File.ReadAllText(q_filename);
            litmusCol.Add("comment", q_comment);

            // 데이터 형식 설정
            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in litmusCol.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, litmusCol[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);

            }

            // 헤더 형식 설정
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, "upfile", "", "application/octet-stream");
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            rs.Close();

            WebResponse wresp = request.GetResponse();
            Stream strReceive = wresp.GetResponseStream();
            StreamReader reqStreamReader = new StreamReader(strReceive, Encoding.UTF8);
            string strResult = reqStreamReader.ReadToEnd();

            HttpWebResponse result = (HttpWebResponse)request.GetResponse();

            if (result.StatusCode == HttpStatusCode.OK)
            {
                request.Abort();
                strReceive.Close();
                reqStreamReader.Close();

                if (strResult.Contains("openurl(\"/exam/\")"))
                    return true;
            }

            return false;
        }

        private void lstvQList_DoubleClick(object sender, EventArgs e)
        {
            if (lstvQList.SelectedItems.Count > 0)
            {
                Form frmSubmit = new FrmSubmit(this);
                frmSubmit.Show();
                frmSubmit.Top = this.Top;
                frmSubmit.Left = this.Left + this.Width;
            }
        }

        private void lstvQList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                lstvQList_DoubleClick(sender, e);
        }

        public string GetTbPath()
        {
            return tbPath.Text;
        }

        public string GetLitmusQuestion(int index)
        {
            ListViewItem.ListViewSubItemCollection item = lstvQList.SelectedItems[0].SubItems;

            string str = "";

            switch (index)
            {
                case 0:                         // 문제제목
                    str = item[1].Text;
                    break;
                case 1:                         // 문제코드
                    str = item[4].Text;
                    break;
                case 2:                         // 문제번호(영문)
                    str = lstvQList.SelectedItems[0].Text;
                    break;
                case 3:
                    str = item[3].Text;         // 문제코드(숫자)
                    break;
            }

            return str;
        }



    }
}

