using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Linq;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace VDisplay
{
    public partial class 基于视觉智能的多人场景视频监控平台项目演示 : Form
    {
        public 基于视觉智能的多人场景视频监控平台项目演示()
        {
            InitializeComponent();
            //this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            //this.skinEngine1.SkinFile = Application.StartupPath + "//WarmColor2.ssk";
        }

        private void videoStart_Click(object sender, EventArgs e)
        {
            isopen = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        System.Windows.Forms.FolderBrowserDialog folderdia = new FolderBrowserDialog();
        int mode = 4;
        static string foldername;
        static string[] image_file_top = null, image_file_hor1 = null, image_file_hor2 = null, image_file_hor3 = null;
        string[] pos1, pos2, pos3, pos4;
        static string[] pos_file_top, pos_file_hor1, pos_file_hor2, pos_file_hor3;
        int index = 0;
        int num;
        static bool isopen = false;
        int itemCnt;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            itemCnt = 0;
            if (isopen)
            {
                if (image_file_top == null)
                {
                    uiTextBox1.Text = "未选取文件！";
                    isopen = false;
                }
                else if (index == image_file_top.Length)
                {
                    index = 0;
                    isopen = !isopen;
                }
                else
                {
                    Bitmap buff = new Bitmap(this.Width, this.Height);
                    Graphics bufferGraphics = Graphics.FromImage(buff);
                    var items = XDocument.Load(pos_file_top[index]).Root.Element("outputs").Element("object").Elements("item");
                    foreach (var item in items)
                    {
                        itemCnt++;
                        string name = item.Element("name").Value;
                        var xmin = float.Parse(item.Element("bndbox").Element("xmin").Value);
                        var ymin = float.Parse(item.Element("bndbox").Element("ymin").Value);
                        var xmax = float.Parse(item.Element("bndbox").Element("xmax").Value);
                        var ymax = float.Parse(item.Element("bndbox").Element("ymax").Value);
                        bufferGraphics.DrawRectangle(new Pen(Color.Red, 2), xmin / 2688 * 621, ymin / 1512 * 381, (xmax - xmin) / 2688 * 621, (ymax - ymin) / 2688 * 621);
                    }
                    pictureBox1.CreateGraphics().DrawImage(buff, 0, 0);
                    pictureBox1.Image = Image.FromFile(image_file_top[index]);
                    //textBox1.Text = "当前场景人数:" + itemCnt;
                }
                index++;
            }
        }
        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            if (isopen)
            {
                if (image_file_hor1 == null)
                {
                    uiTextBox1.Text = "未选取文件！";
                    isopen = false;
                }
                else if (index == image_file_hor1.Length)
                {
                    index = 0;
                    isopen = !isopen;
                }
                else
                {
                    Bitmap buff = new Bitmap(this.Width, this.Height);
                    Graphics bufferGraphics = Graphics.FromImage(buff);
                    var items = XDocument.Load(pos_file_hor1[index]).Root.Element("outputs").Element("object").Elements("item");
                    foreach (var item in items)
                    {
                        itemCnt++;
                        string name = item.Element("name").Value;
                        var xmin = float.Parse(item.Element("bndbox").Element("xmin").Value);
                        var ymin = float.Parse(item.Element("bndbox").Element("ymin").Value);
                        var xmax = float.Parse(item.Element("bndbox").Element("xmax").Value);
                        var ymax = float.Parse(item.Element("bndbox").Element("ymax").Value);
                        bufferGraphics.DrawRectangle(new Pen(Color.Red, 2), xmin / 2688 * 621, ymin / 1512 * 381, (xmax - xmin) / 2688 * 621, (ymax - ymin) / 2688 * 621);
                    }
                    pictureBox4.CreateGraphics().DrawImage(buff, 0, 0);
                    pictureBox4.Image = Image.FromFile(image_file_hor1[index]);
                }
                index++;
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            itemCnt = 0;
            if (isopen)
            {
                if (image_file_hor2 == null)
                {
                    uiTextBox1.Text = "未选取文件！";
                    isopen = false;
                }
                else if (index == image_file_hor2.Length)
                {
                    index = 0;
                    isopen = !isopen;
                }
                else
                {
                    Bitmap buff = new Bitmap(this.Width, this.Height);
                    Graphics bufferGraphics = Graphics.FromImage(buff);
                    var items = XDocument.Load(pos_file_hor2[index]).Root.Element("outputs").Element("object").Elements("item");
                    foreach (var item in items)
                    {
                        itemCnt++;
                        string name = item.Element("name").Value;
                        var xmin = float.Parse(item.Element("bndbox").Element("xmin").Value);
                        var ymin = float.Parse(item.Element("bndbox").Element("ymin").Value);
                        var xmax = float.Parse(item.Element("bndbox").Element("xmax").Value);
                        var ymax = float.Parse(item.Element("bndbox").Element("ymax").Value);
                        bufferGraphics.DrawRectangle(new Pen(Color.Red, 2), xmin / 2688 * 621, ymin / 1512 * 381, (xmax - xmin) / 2688 * 621, (ymax - ymin) / 2688 * 621);
                    }
                    pictureBox2.CreateGraphics().DrawImage(buff, 0, 0);
                    pictureBox2.Image = Image.FromFile(image_file_hor2[index]);
                    //textBox1.Text = "当前场景人数:"+itemCnt;
                }
                index++;
            }
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            if (isopen)
            {
                if (image_file_hor3 == null)
                {
                    uiTextBox1.Text = "未选取文件！";
                    isopen = false;
                }
                else if (index == image_file_hor3.Length)
                {
                    index = 0;
                    isopen = !isopen;
                }
                else
                {
                    Bitmap buff = new Bitmap(this.Width, this.Height);
                    Graphics bufferGraphics = Graphics.FromImage(buff);
                    var items = XDocument.Load(pos_file_hor3[index]).Root.Element("outputs").Element("object").Elements("item");
                    foreach (var item in items)
                    {
                        string name = item.Element("name").Value;
                        var xmin = float.Parse(item.Element("bndbox").Element("xmin").Value);
                        var ymin = float.Parse(item.Element("bndbox").Element("ymin").Value);
                        var xmax = float.Parse(item.Element("bndbox").Element("xmax").Value);
                        var ymax = float.Parse(item.Element("bndbox").Element("ymax").Value);
                        bufferGraphics.DrawRectangle(new Pen(Color.Red, 2), xmin / 2688 * 621, ymin / 1512 * 381, (xmax - xmin) / 2688 * 621, (ymax - ymin) / 2688 * 621);
                    }
                    pictureBox3.CreateGraphics().DrawImage(buff, 0, 0);
                    pictureBox3.Image = Image.FromFile(image_file_hor3[index]);
                }
                index++;
            }
        }

        private void videoFStart_Click(object sender, EventArgs e)
        {
            isopen = true;
        }

        private void timer1Start_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) //装载窗口事件, 是窗体启动时触发的事件，一般写程序你把自己要初始化的东东可以放在Form1_Load中
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void videoFTimer_Tick(object sender, EventArgs e)
        {
            if (isopen)
            {
                pictureBox1.Refresh();
                pictureBox4.Refresh();//马上刷新
            }
        }

        private void Pic2Timer_Tick(object sender, EventArgs e)
        {
            if (isopen && mode >= 3)
            {
                pictureBox2.Refresh();
            }
        }

        private void Pic3Timer_Tick(object sender, EventArgs e)
        {
            if (isopen && mode == 4)
            {
                pictureBox3.Refresh();
            }
        }

        private void Pic4Timer_Tick(object sender, EventArgs e)
        {
            if (isopen)
            {
                pictureBox4.Refresh();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void uiComboTreeView1_NodeSelected(object sender, TreeNode node)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {

        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Line_Control_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void uiLine1_Click(object sender, EventArgs e)
        {

        }

        private void Line_View_Click(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /*private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text == "1俯视+1平视")
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                axWindowsMediaPlayer1.Width = 268;
                axWindowsMediaPlayer1.Height = 177;
                pictureBox1.Width = 268;
                pictureBox1.Height = 177;
                pictureBox1.Location = new System.Drawing.Point(226, 287);

            }
            if (treeView1.SelectedNode.Text == "1俯视+3平视")
            {
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                axWindowsMediaPlayer1.Width = 364;
                axWindowsMediaPlayer1.Height = 244;
                pictureBox1.Width = 200;
                pictureBox1.Height = 112;
                pictureBox1.Location = new System.Drawing.Point(226, 351);
            }

        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            image_file_top = null;
            image_file_hor1 = null;
            image_file_hor2 = null;
            image_file_hor3 = null;
            pos_file_top = null;
            pos_file_hor1 = null;
            pos_file_hor2 = null;
            pos_file_hor3 = null;
            isopen = false;
            index = 0;
            uiTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void walking2mpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 俯视1平视ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            label2.Visible = false;
            pictureBox3.Visible = false;
            label3.Visible = false;
            pictureBox1.Width = 268;
            pictureBox1.Height = 177;
            pictureBox4.Width = 268;
            pictureBox4.Height = 177;
            pictureBox1.Location = new System.Drawing.Point(147, 87);
            label1.Location = new System.Drawing.Point(147, 87);
            pictureBox4.Location = new System.Drawing.Point(147, 280);
            label4.Location = new System.Drawing.Point(147, 280);

        }

        private void 俯视3平视ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox1.Width = 242;
            pictureBox1.Height = 156;
            pictureBox4.Width = 242;
            pictureBox4.Height = 156;
            pictureBox1.Location = new System.Drawing.Point(146, 87);
            pictureBox4.Location = new System.Drawing.Point(270, 259);
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "媒体文件（所有类型）|*.mp3;*.mp4;*.mpeg;*.wma;*.wmv;*.wav;*.avi";
            //openFileDialog1.Filter = ""
            mode = 4;
            if (folderdia.ShowDialog() == DialogResult.OK)
            {
                uiTextBox1.Text = folderdia.SelectedPath;
                foldername = uiTextBox1.Text;
                /* 顶视 */
                string[] f1;
                f1 = System.IO.Directory.GetDirectories(foldername, "*top");
                if (f1 == null)
                {
                    uiTextBox1.Text = "未找到视频！";
                    return;
                }
                image_file_top = System.IO.Directory.GetFiles(f1[0], "*.jpg");
                pos1 = System.IO.Directory.GetDirectories(f1[0], "*xml");
                pos_file_top = System.IO.Directory.GetFiles(pos1[0], "*.xml");

                /* 平视1 */
                string[] f2;
                f2 = System.IO.Directory.GetDirectories(foldername, "*hor1");
                if (f2 == null)
                {
                    uiTextBox1.Text = "未找到视频！";
                    return;
                }
                image_file_hor1 = System.IO.Directory.GetFiles(f2[0], "*.jpg");
                pos2 = System.IO.Directory.GetDirectories(f2[0], "*xml");
                pos_file_hor1 = System.IO.Directory.GetFiles(pos2[0], "*.xml");

                /* 平视2 */
                string[] f3;
                f3 = System.IO.Directory.GetDirectories(foldername, "*hor2");
                if (f3.Length == 0)
                {
                    mode = 2;
                    pictureBox2.Visible = false;
                    label2.Visible = false;
                    pictureBox3.Visible = false;
                    label3.Visible = false;
                    pictureBox1.Width = 268;
                    pictureBox1.Height = 177;
                    pictureBox4.Width = 268;
                    pictureBox4.Height = 177;
                    pictureBox1.Location = new System.Drawing.Point(147, 87);
                    label1.Location = new System.Drawing.Point(147, 87);
                    pictureBox4.Location = new System.Drawing.Point(147, 280);
                    label4.Location = new System.Drawing.Point(147, 280);
                    label4.Text = "HorizontalView1";
                }
                else
                {
                    image_file_hor2 = System.IO.Directory.GetFiles(f3[0], "*.jpg");
                    pos3 = System.IO.Directory.GetDirectories(f3[0], "*xml");
                    pos_file_hor2 = System.IO.Directory.GetFiles(pos3[0], "*.xml");
                }

                if (mode != 2)
                {
                    /* 平视3 */
                    string[] f4;
                    f4 = System.IO.Directory.GetDirectories(foldername, "*hor3");
                    if (f4.Length == 0)
                    {
                        mode = 3;
                        pictureBox2.Visible = true;
                        label2.Visible = true;
                        pictureBox3.Visible = false;
                        label3.Visible = false;
                        pictureBox1.Width = 242;
                        pictureBox1.Height = 156;
                        pictureBox4.Width = 242;
                        pictureBox4.Height = 156;
                        pictureBox1.Location = new System.Drawing.Point(146, 87);
                        label1.Location = new System.Drawing.Point(146, 87);
                        pictureBox4.Location = new System.Drawing.Point(270, 259);
                        label4.Location = new System.Drawing.Point(270, 259);
                        label4.Text = "HorizontalView2";
                    }
                    else
                    {
                        mode = 4;
                        pictureBox2.Visible = true;
                        label2.Visible = true;
                        pictureBox3.Visible = true;
                        label3.Visible = true;
                        pictureBox1.Width = 242;
                        pictureBox1.Height = 156;
                        pictureBox4.Width = 242;
                        pictureBox4.Height = 156;
                        pictureBox1.Location = new System.Drawing.Point(22, 87);
                        label1.Location = new System.Drawing.Point(22, 87);
                        pictureBox4.Location = new System.Drawing.Point(270, 259);
                        label4.Location = new System.Drawing.Point(270, 259);
                        label4.Text = "HorizontalView3";
                        image_file_hor3 = System.IO.Directory.GetFiles(f4[0], "*.jpg");
                        pos4 = System.IO.Directory.GetDirectories(f4[0], "*xml");
                        pos_file_hor3 = System.IO.Directory.GetFiles(pos4[0], "*.xml");
                    }
                }
            }

        }

        private void 俯视ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox1.Width = 242;
            pictureBox1.Height = 156;
            pictureBox4.Width = 242;
            pictureBox4.Height = 156;
            pictureBox1.Location = new System.Drawing.Point(22, 87);
            pictureBox4.Location = new System.Drawing.Point(270, 259);
        }

        
    }
}




