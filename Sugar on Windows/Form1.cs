using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sugar_on_Windows
{
    public partial class Form1 : Form
    {

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enable_disable(true);       
        }

        private void enable_disable(bool response)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "powershell.exe";
            if (response)
            {
                startInfo.Arguments = "Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux";
                MessageBox.Show("Feature enabled");
            }
            else
            {
                startInfo.Arguments = "Disable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux";
                MessageBox.Show("Feature disabled");

            }
            process.StartInfo = startInfo;
            process.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            enable_disable(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderDialog.SelectedPath + "\\sugar.bat"; 
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String data = @"cd C:\Windows\System32\powershell.exe 
bash -c -i sugar";

            TextWriter txt = new StreamWriter(textBox1.Text);
            txt.Write(data);
            txt.Close();
            button4.Enabled = true;
            MessageBox.Show(@"You can now run the batch file (.bat) or click on ""Start Sugar");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                System.Diagnostics.Process.Start(@"config.xlaunch");
                System.Diagnostics.Process.Start(textBox1.Text);
            }
        }
    }

 }
