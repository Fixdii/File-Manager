using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          //  GetDat.EventHandler = new GetDat.GetData(GetDataFunc);
            DriveTreeInit();
        }

        /// Инициализация окна древовидного списка дисковых устройств
        public void DriveTreeInit()
        {
            //получить список логических дисков
            string[] drivesArray = Directory.GetLogicalDrives();  

            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            foreach (string s in drivesArray)
            {
                //Хранит все узлы дерева
                TreeNode drive = new TreeNode(s, 0, 0);
                treeView1.Nodes.Add(drive);

                GetDirs(drive);
            }


            treeView1.EndUpdate();
        }

        /// Получение списка каталогов
        public void GetDirs(TreeNode node)
        {
            //получить список всех подкаталогов заданного каталога
            DirectoryInfo[] diArray;

            node.Nodes.Clear();

            string fullPath = node.FullPath;
            DirectoryInfo di = new DirectoryInfo(fullPath);

            try
            {
                diArray = di.GetDirectories();
            }
            catch
            {
                return;
            }

            foreach (DirectoryInfo dirinfo in diArray)
            {
                TreeNode dir = new TreeNode(dirinfo.Name, 1, 2);
                node.Nodes.Add(dir);
            }
        }

        /* void GetDataFunc(string name, DialogResult dr)
         {
             if (dr == DialogResult.OK)
             {
                 try
                 {
                     // пробуем переименовать

                     string fullPath = null;
                     System.IO.Directory.Move(fullPath + "\\" + listView1.SelectedItems[0].Text, fullPath + "\\" + name);
                     listView1.SelectedItems[0].Text = name;
                     //MessageBox.Show(fullPath + "\\" + listView1.SelectedItems[0].Text);
                     //MessageBox.Show(fullPath + "\\" + name);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }

         }*/

        ///Обработчик события BeforeExpand
        private void treeView1_OnBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeView1.BeginUpdate();

            foreach (TreeNode node in e.Node.Nodes)
            {
                GetDirs(node);
            }

            treeView1.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            string fullPath = selectedNode.FullPath;
            DirectoryInfo di = new DirectoryInfo(fullPath);
            FileInfo[] fiArray;
            DirectoryInfo[] diArray;

            try
            {
                fiArray = di.GetFiles();
                diArray = di.GetDirectories();
            }
            catch
            {
                return;
            }

            listView1.Items.Clear();

            foreach (DirectoryInfo dirInfo in diArray)
            {
                ListViewItem lvi = new ListViewItem(dirInfo.Name);
                lvi.SubItems.Add("0");
                lvi.SubItems.Add(dirInfo.LastWriteTime.ToString());
                lvi.ImageIndex = 0;

                listView1.Items.Add(lvi);
            }


            foreach (FileInfo fileInfo in fiArray)
            {
                ListViewItem lvi = new ListViewItem(fileInfo.Name);
                lvi.Tag = fileInfo.FullName;
                lvi.Tag = fileInfo.FullName;
                lvi.SubItems.Add(fileInfo.Length.ToString());
                lvi.SubItems.Add(fileInfo.LastWriteTime.ToString());

                string filenameExtension =
                  Path.GetExtension(fileInfo.Name).ToLower();
                listView1.Items.Add(lvi);
            }
        }

    }

}
