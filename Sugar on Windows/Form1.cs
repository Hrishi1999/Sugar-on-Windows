using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            if (response)
            {
                runCommand("Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux",
                1);
            }
            else
            {
                runCommand("Disable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux", 1);
            }
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
bash -c -i 'DISPLAY=:0 sugar'";

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
                Process.Start(@"config.xlaunch");
                Process.Start(textBox1.Text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            runCommand("sudo apt-get install sucrose", 0);
            runCommand("echo 'export DISPLAY=:0.0' >> ~/.bashrc", 0);
            runCommand("echo 'export LIBGL_ALWAYS_INDIRECT=1' >> ~/.bashrc", 0);
        }

        private void runCommand(String command, int cli) //0 for bash, 1 for powershell
        {
            String fname = "";

            switch (cli)
            {
                case 0:
                    fname = @"C:\Windows\System32\bash";
                    break;
                case 1:
                    fname = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
                    break;
            }

            var psi = new ProcessStartInfo
            {
                FileName = fname,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = string.Format("-c \"{0} \"", command)
            };

            using (var p = Process.Start(psi))
            {
                if (p != null)
                {
                    var strOutput = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }
    } 
 }
