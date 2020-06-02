using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebGL_tester_GUI
{
    public partial class Form1 : Form
    {
                
        string nodejsapplicationpath = ".\\NodeServer";
        string nodepath = ".\\nodejs\\node";    
        Process newwindow = new Process();

        public Form1()
        {
            InitializeComponent();
            textBox2.Text = "3000";
            checkBox1.Checked = true;
            File.SetAttributes(nodejsapplicationpath,FileAttributes.ReadOnly);                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = textBox1.Text;
            string portnumber = textBox2.Text;
            if(portnumber.Length<1)
            {
                MessageBox.Show("No port number specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                return;                
            }
            else if(!portnumber.All(char.IsDigit))
            {
                MessageBox.Show("Port number entered is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text="3000";
                return;
            }
            if(filepath.Length==0)
            {
                MessageBox.Show("Please specify path to folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                return;
            }
            try
            {
                if (File.Exists(filepath + "/index.html") && File.Exists(filepath + "/Build/UnityLoader.js"))
                {                    
                    filepath = replacespace(filepath);                    
                    string browsername = getselectedbrowsername();
                    newwindow.StartInfo.WorkingDirectory = nodejsapplicationpath;
                    newwindow.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    newwindow.StartInfo.FileName = "cmd.exe";


                    // when node is already present in a system
                    newwindow.StartInfo.Arguments = "/c node app.js" + " " + filepath.Trim() + " " + portnumber.Trim() + " " + browsername.Trim();



                    // when node isn't present and is in the bundled version
                    //newwindow.StartInfo.Arguments = "/c "+nodepath+" .\\app.js" + " " + filepath.Trim() + " " + portnumber.Trim() + " " + browsername.Trim();
                    newwindow.Start();
                }
                else
                {
                    MessageBox.Show("No Unity WebGL files present in selected folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception has occured while trying to read the folder. Message:" + ex.Message, "Exception in reading folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            
        }

        string getselectedbrowsername()
        {
            if(checkBox1.Checked)
            {
                return "chrome";
            }
            else if(checkBox2.Checked)
            {
                return "firefox";
            }
            else
            {
                return "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var curDir = Directory.GetCurrentDirectory();
            //MessageBox.Show(curDir);
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    try
                    {
                        if (File.Exists(fbd.SelectedPath + "/index.html") && File.Exists(fbd.SelectedPath + "/Build/UnityLoader.js"))
                        {
                            textBox1.Text = fbd.SelectedPath;
                        }
                        else
                        {
                            MessageBox.Show("No Unity WebGL files present in selected folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Clear();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("An exception has occured while trying to read the folder. Message:"+ex.Message, "Exception in reading folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        string replacespace(string word)
        {
            char[] newword = word.ToCharArray();
            for(int i=0;i<newword.Length;i++)
            {
                if(newword[i]==' ')
                {
                    newword[i] = '~';
                }
            }
            return new string(newword);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
