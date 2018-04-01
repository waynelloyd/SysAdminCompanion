namespace SysAdminCompanion
{
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            if (Properties.Settings.Default.ComboItems == null)
            {
                Properties.Settings.Default.ComboItems = new System.Collections.Specialized.StringCollection();
            }
           //// Adds each stored string from user.config to combobox autocompletecustomsource stringcollection
            foreach (string s in Properties.Settings.Default.ComboItems)
            {
                this.comboBox1.AutoCompleteCustomSource.Add(s);
                this.comboBox2.AutoCompleteCustomSource.Add(s);
            }
            
            if (this.comboBox1.Text == "Example: computer.fabrikam.com")
            {
                this.label5.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                this.comboBox1.ForeColor = Color.Gray;
            }
            
            if (this.comboBox1.Text.Length == 0)
            {
                this.label5.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                this.comboBox1.Text = "Example: computer.fabrikam.com";
                this.comboBox1.ForeColor = Color.Gray;
            }
            
            this.button1.Text = "OK";
            this.radioButton1.Checked = true;
            this.pictureBox1.Image = Properties.Resources.compmgmnt;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private string GetCharacter()
        {
            string[] lower = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] upper = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] number = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] symbol = new string[] { "!", "@", "#", "$", "%", "&", "*", "?" };

            ////Generate a random number
            ////shows a neat method to randomize the seed, on the default time, fast computers create a password characters on the same seed
            Random rand = new System.Random(Guid.NewGuid().GetHashCode());
            int rplace = rand.Next(0, 4);
            int rplace2 = 0;
            while (!this.IsChecked(rplace))
            {
                rplace = rand.Next(0, 4);
            }
            
            switch (rplace)
            {
                case 0:
                    rplace2 = rand.Next(0, 26);
                    return lower[rplace2];
                case 1:
                    rplace2 = rand.Next(0, 26);
                    return upper[rplace2];
                case 2:
                    rplace2 = rand.Next(0, 10);
                    return number[rplace2];
                case 3:
                    rplace2 = rand.Next(0, 8);
                    return symbol[rplace2];
                default:
                    return string.Empty;
            }
        }

        ////Routine to see if a random value matches with a check box
        private bool IsChecked(int r)
        {
            switch (r)
            {
                case 0:
                    return this.cbLower.Checked;
                case 1:
                    return this.cbUpper.Checked;
                case 2:
                    return this.cdNumbers.Checked;
                case 3:
                    return this.cbSymbols.Checked;
                default:
                    return true;
            }
        }

        #region Tabs

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vncviewerPath = Properties.Settings.Default.vncviewerPath;
            string vncviewer = Properties.Settings.Default.vncviewer;

            if (this.tabControl1.SelectedTab == this.tabPage1)
            {
                this.Text = String.Format(this.AssemblyTitle + " - Tools");
                this.AcceptButton = this.button1;
                this.comboBox1.Text = this.comboBox2.Text = this.comboBox4.Text;
                //this.comboBox1.Text = this.comboBox4.Text;
                if (this.comboBox1.Text == "Example: computer.fabrikam.com")
                {
                    this.comboBox2.Text = "Example: computer.fabrikam.com";
                    this.comboBox4.Text = "Example: computer.fabrikam.com";
                    this.label5.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                    this.comboBox1.ForeColor = Color.Gray;
                }
                else if (this.comboBox1.Text.Length == 0)
                {
                    this.comboBox2.Text = String.Empty;
                    this.comboBox4.Text = String.Empty;
                    this.label5.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                    this.comboBox2.ForeColor = Color.Gray;
                }
                else if (this.comboBox1.Text == this.comboBox2.Text)
                {
                    this.label5.Text = string.Empty;
                    this.comboBox1.ForeColor = Color.Black;
                }
                else if (this.comboBox1.Text == this.comboBox4.Text)
                {
                    this.label5.Text = string.Empty;
                    this.comboBox1.ForeColor = Color.Black;
                }
            }
            
            if (this.tabControl1.SelectedTab == this.tabPage2)
            {
                this.Text = String.Format(this.AssemblyTitle + " - Remote Control");
                this.AcceptButton = this.button3;
                this.pictureBox2.Image = Properties.Resources.uvnc;
                this.radioButton11.Checked = true;
                this.radioButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.button3.Text = "Connect";
                this.comboBox2.Text = this.comboBox1.Text = this.comboBox4.Text;
                //this.comboBox2.Text = this.comboBox4.Text;
                if (this.comboBox2.Text == "Example: computer.fabrikam.com")
                {
                    this.comboBox1.Text = "Example: computer.fabrikam.com";
                    this.comboBox4.Text = "Example: computer.fabrikam.com";
                    this.label2.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                    this.comboBox2.ForeColor = Color.Gray;
                }
                else if (this.comboBox2.Text.Length == 0)
                {
                    this.comboBox1.Text = String.Empty;
                    this.comboBox4.Text = String.Empty;
                    this.label2.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                    this.comboBox2.ForeColor = Color.Gray;
                }
                else if (this.comboBox2.Text == this.comboBox1.Text)
                {
                    this.label2.Text = string.Empty;
                    this.comboBox2.ForeColor = Color.Black;
                }
                else if (this.comboBox2.Text == this.comboBox4.Text)
                {
                    this.label2.Text = string.Empty;
                    this.comboBox2.ForeColor = Color.Black;
                }
                
                if (File.Exists(vncviewerPath + "\\" + vncviewer))
                {
                    this.button3.Enabled = true;
                    this.linkLabel1.Text = "Edit path to vncviewer.exe";
                }
                else
                {
                    this.button3.Enabled = false;
                    this.linkLabel1.Text = "Set path to vncviewer.exe";
                }
            }

            if (this.tabControl1.SelectedTab == this.tabPage5)
            {
                this.Text = String.Format(this.AssemblyTitle + " - Get Info");
                this.AcceptButton = this.button8;
                this.pictureBox8.Image = Properties.Resources.usr;
                this.checkBox9.Checked = true;
                this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.button8.Enabled = true;
                this.comboBox4.Text = this.comboBox2.Text = this.comboBox1.Text;
                //this.comboBox4.Text = this.comboBox1.Text;
                if (this.comboBox4.Text == "Example: computer.fabrikam.com")
                {
                    this.comboBox1.Text = "Example: computer.fabrikam.com";
                    this.comboBox2.Text = "Example: computer.fabrikam.com";
                    this.label41.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                    this.comboBox4.ForeColor = Color.Gray;
                }
                else if (this.comboBox4.Text.Length == 0)
                {
                    this.comboBox1.Text = String.Empty;
                    this.comboBox2.Text = String.Empty;
                    this.label41.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                    this.comboBox4.ForeColor = Color.Gray;
                }
                else if (this.comboBox4.Text == this.comboBox1.Text)
                {
                    this.label41.Text = string.Empty;
                    this.comboBox4.ForeColor = Color.Black;
                }
                else if (this.comboBox4.Text == this.comboBox2.Text)
                {
                    this.label41.Text = string.Empty;
                    this.comboBox4.ForeColor = Color.Black;
                }
            
            if (this.tabControl1.SelectedTab == this.tabPage3)
            {
                this.Text = String.Format(this.AssemblyTitle + " - Password Generator");
                this.AcceptButton = this.btnGenerate;
            }
            
            if (this.tabControl1.SelectedTab == this.tabPage4)
            {
                this.Text = String.Format("About {0}", this.AssemblyTitle);
                this.AcceptButton = this.button4;
                this.label9.Text = this.AssemblyProduct;
                this.label10.Text = String.Format("Version {0}", this.AssemblyVersion);
                this.label11.Text = this.AssemblyCopyright;
                this.linkLabel2.Text = this.AssemblyCompany;
                this.label14.Text = System.Environment.MachineName.ToString();
                this.label16.Text = System.Environment.OSVersion.ToString();
                this.label18.Text = System.Environment.OSVersion.ServicePack.ToString();
                TimeSpan ts = TimeSpan.FromMilliseconds(Environment.TickCount);
                this.label20.Text = (ts.Days + " days " + ts.Hours + " hrs and " + ts.Minutes + " mins");
            }
                
            }  
            
        }

        #endregion

        #region Comboboxes

        private void ComboBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.comboBox1.Text == "Example: computer.fabrikam.com")
            {
                this.comboBox1.Text = string.Empty;
            }
        }

        private void ComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.comboBox1.Text == "Example: computer.fabrikam.com")
            {
                this.comboBox1.Text = string.Empty;
            }
        }

        private void ComboBox1_TextUpdate(object sender, EventArgs e)
        {
            this.comboBox1.ForeColor = Color.Black;
            this.label5.Text = string.Empty;
        }

        private void ComboBox1_MouseLeave(object sender, EventArgs e)
        {
            if (this.comboBox1.Text.Length == 0)
            {
                this.label5.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                this.comboBox1.Text = "Example: computer.fabrikam.com";
                this.comboBox1.ForeColor = Color.Gray;
            }
        }

       
        private void ComboBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.comboBox2.Text == "Example: computer.fabrikam.com")
            {
                this.comboBox2.Text = string.Empty;
            }
        }

        private void ComboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.comboBox2.Text == "Example: computer.fabrikam.com")
            {
                this.comboBox2.Text = string.Empty;
            }
        }

        private void ComboBox2_TextUpdate(object sender, EventArgs e)
        {
            this.comboBox2.ForeColor = Color.Black;
            this.label2.Text = string.Empty;
        }

        private void ComboBox2_MouseLeave(object sender, EventArgs e)
        {
            if (this.comboBox2.Text.Length == 0)
            {
                this.label2.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                this.comboBox2.Text = "Example: computer.fabrikam.com";
                this.comboBox2.ForeColor = Color.Gray;
            }
        }

        private void comboBox4_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.comboBox4.Text == "Example: computer.fabrikam.com")
            {
                this.comboBox4.Text = string.Empty;
            }
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.comboBox4.Text == "Example: computer.fabrikam.com")
            {
                this.comboBox4.Text = string.Empty;
            }
        }

        private void comboBox4_TextUpdate(object sender, EventArgs e)
        {
            this.comboBox4.ForeColor = Color.Black;
            this.label41.Text = string.Empty;
        }

        private void comboBox4_MouseLeave(object sender, EventArgs e)
        {
            if (this.comboBox4.Text.Length == 0)
            {
                this.label41.Text = "The computer name field is blank. Enter a remote computer name or IP address.";
                this.comboBox4.Text = "Example: computer.fabrikam.com";
                this.comboBox4.ForeColor = Color.Gray;
            }
        }

        #endregion

        #region Radiobuttons

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.pictureBox1.Image = Properties.Resources.compmgmnt;
                this.button1.Text = "OK";
            }
            else if (this.radioButton1.Checked == false)
            {
                this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }            
        }
        
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked == true)
            {
                this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.pictureBox1.Image = Properties.Resources.eventvwr;
                this.button1.Text = "OK";
            }
            else if (this.radioButton2.Checked == false)
            {
                this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked == true)
            {
                this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.pictureBox1.Image = Properties.Resources.lusrmgr;
                this.button1.Text = "OK";
            }
            else if (this.radioButton3.Checked == false)
            {
                this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }
        
        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton4.Checked == true)
            {
                this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.pictureBox1.Image = Properties.Resources.msinfo32;
                this.button1.Text = "OK";
            }
            else if (this.radioButton4.Checked == false)
            {
                this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }
        
        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton5.Checked == true)
            {
                this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.pictureBox1.Image = Properties.Resources.services;
                this.button1.Text = "OK";
            }
            else if (this.radioButton5.Checked == false)
            {
                this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }
        
        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton6.Checked == true)
            {
                this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.pictureBox1.Image = Properties.Resources.gpedit;
                this.button1.Text = "OK";
            }
            else if (this.radioButton6.Checked == false)
            {
                this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }
        
        private void RadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton7.Checked == true)
            {
                this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.pictureBox1.Image = Properties.Resources.shrpubw;
                this.button1.Text = "OK";
            }
            else if (this.radioButton7.Checked == false)
            {
                this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }
        
        private void RadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton8.Checked == true)
            {
                this.pictureBox2.Image = Properties.Resources.shutdown;
                this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.button3.Enabled = true;
                this.button3.Text = "Restart";
            }
            else if (this.radioButton8.Checked == false)
            {
                this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }
        
        private void RadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton9.Checked == true)
            {
                this.pictureBox2.Image = Properties.Resources.msra;
                this.radioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.button3.Enabled = true;
                this.button3.Text = "Connect";
            }
            else if (this.radioButton9.Checked == false)
            {
                this.radioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }
        
        private void RadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton10.Checked == true)
            {
                this.pictureBox2.Image = Properties.Resources.mstsc;
                this.radioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.button3.Enabled = true;
                this.button3.Text = "Connect";
                this.checkBox1.Visible = true;
                this.checkBox2.Visible = true;
                this.label8.Visible = true;
            }
            else if (this.radioButton10.Checked == false)
            {
                this.radioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.checkBox1.Visible = false;
                this.checkBox2.Visible = false;
                this.label8.Visible = false;
            }
        }
        
             private void RadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton11.Checked == true)
            {
                this.pictureBox2.Image = Properties.Resources.uvnc;
                this.radioButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                this.button3.Text = "Connect";
            }
            else if (this.radioButton11.Checked == false)
            {
                this.radioButton11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }
        }

        #endregion

        #region Linklabels

             private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
             {              
                string vncviewerPath = Properties.Settings.Default.vncviewerPath;
                string vncviewer = Properties.Settings.Default.vncviewer;
                 
                 if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                 {
                     string s = System.IO.Path.GetDirectoryName(this.openFileDialog1.FileName);
                     Properties.Settings.Default.vncviewerPath = s;
                     Properties.Settings.Default.Save();
                     if (File.Exists(s + "\\" + vncviewer))
                     {
                         this.button3.Enabled = true;
                         this.linkLabel1.Text = "Edit path to vncviewer.exe";
                     }
                 }
             }

             private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
             {
                 try
                 {

                     System.Diagnostics.Process.Start("mailto:wayne.lloyd@gmx.com?subject=" + this.AssemblyProduct + " feedback");
                 }
             
         catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
}

        #endregion

        #region Functions

        private void Cbo1PingCommands()
    {
         Ping objPing = new Ping();
         try
         {
             PingReply objPingReply = objPing.Send(this.comboBox1.Text);
             if (objPingReply.Status == IPStatus.Success)
             {
                 if (this.radioButton1.Checked == true)
                 {
                     System.Diagnostics.Process.Start("compmgmt.msc", "/computer=" + this.comboBox1.Text);
                 }
                 else if (this.radioButton2.Checked == true)
                 {
                     System.Diagnostics.Process.Start("eventvwr.msc", "/computer:" + this.comboBox1.Text);
                 }
                 else if (this.radioButton3.Checked == true)
                 {
                     System.Diagnostics.Process.Start("lusrmgr.msc", "/computer:" + this.comboBox1.Text);
                 }
                 else if (this.radioButton4.Checked == true)
                 {
                     System.Diagnostics.Process.Start("msinfo32.exe", "/computer " + this.comboBox1.Text);
                 }
                 else if (this.radioButton5.Checked == true)
                 {
                     System.Diagnostics.Process.Start("services.msc", "/computer:" + this.comboBox1.Text);
                 }
                 else if (this.radioButton6.Checked == true)
                 {
                     System.Diagnostics.Process.Start("gpedit.msc", "/gpcomputer: " + this.comboBox1.Text);
                 }
                 else if (this.radioButton7.Checked == true)
                 {
                     System.Diagnostics.Process.Start("shrpubw.exe", "/s " + this.comboBox1.Text);
                 }
                 
                 string s = this.comboBox1.Text;
                 if (!Properties.Settings.Default.ComboItems.Contains(s))
                 {
                     Properties.Settings.Default.ComboItems.Add(s);
                     this.comboBox1.AutoCompleteCustomSource.Add(s);
                     Properties.Settings.Default.Save();
                 }
             }
             else
             {
                 //// Initializes the variables to pass to the MessageBox.Show method.
                 string message = "Destination host unreachable";
                 string caption = string.Empty;
                 MessageBoxButtons buttons = MessageBoxButtons.OK;
                 DialogResult result;
                 //// Displays the MessageBox.
                 result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
             }
         }
         catch (Exception ex)
         {
             MessageBox.Show(ex.InnerException.Message);
         }
}

        private void Cbo2PingCommands()
        {
            Ping objPing = new Ping();
            try
            {
                PingReply objPingReply = objPing.Send(this.comboBox2.Text);

                if (objPingReply.Status == IPStatus.Success)
                {
                    if (this.radioButton11.Checked == true)
                    {
                            string vncviewerPath = Properties.Settings.Default.vncviewerPath;
                            string vncviewer = Properties.Settings.Default.vncviewer;
                            Process p = new Process();
                            ProcessStartInfo pi = new ProcessStartInfo();
                            pi.WorkingDirectory = vncviewerPath + "\\";
                            pi.FileName = vncviewer + " ";
                            pi.Arguments = this.comboBox2.Text;
                            p.StartInfo = pi;
                            p.Start();
                    }
                    else if (this.radioButton8.Checked == true)
                    {
                        System.Diagnostics.Process.Start("cmd.exe", "/C shutdown.exe -r -m " + this.comboBox2.Text + " -t " + this.textBox1.Text + " -c \"Remote restart initiated");
                    }
                    else if (this.radioButton9.Checked == true)
                    {
                        System.Diagnostics.Process.Start("msra.exe", "/offerRA " + this.comboBox2.Text);
                    }
                    else if (this.radioButton10.Checked == true && this.checkBox1.Checked == false && this.checkBox2.Checked == false)
                    {
                        System.Diagnostics.Process.Start("mstsc.exe", "/v: " + this.comboBox2.Text);
                    }
                    else if (this.radioButton10.Checked == true && this.checkBox1.Checked == true && this.checkBox2.Checked == false)
                    {
                        System.Diagnostics.Process.Start("mstsc.exe", "/v: " + this.comboBox2.Text + " /public");
                    }
                    else if (this.radioButton10.Checked == true && this.checkBox1.Checked == false && this.checkBox2.Checked == true)
                    {
                        System.Diagnostics.Process.Start("mstsc.exe", "/v: " + this.comboBox2.Text + " /multimon");
                    }
                    else if (this.radioButton10.Checked == true && this.checkBox1.Checked == true && this.checkBox2.Checked == true)
                    {
                        System.Diagnostics.Process.Start("mstsc.exe", "/v: " + this.comboBox2.Text + " /public /multimon");
                    }
                    
                    string s = this.comboBox2.Text;
                    if (!Properties.Settings.Default.ComboItems.Contains(s))
                    {
                        Properties.Settings.Default.ComboItems.Add(s);
                        this.comboBox2.AutoCompleteCustomSource.Add(s);
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    //// Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Destination host unreachable";
                    string caption = string.Empty;
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    //// Displays the MessageBox.
                    result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        #endregion

        #region Buttons

        private void Button1_Click(object sender, EventArgs e)
        {
            // Checks the value of the text.
            if (this.comboBox1.Text == "Example: computer.fabrikam.com")
            {
                ////  Initializes the variables to pass to the MessageBox.Show method.
                string message = "Please specify a computer name or IP address";
                string caption = "No Computer Name or IP Specified";
                MessageBoxButtons buttons = MessageBoxButtons.OK; 
                DialogResult result;
                //// Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else if (this.comboBox1.Text.Length == 0)
            {
                ////  Initializes the variables to pass to the MessageBox.Show method.
                string message = "Please specify a computer name or IP address";
                string caption = "No Computer Name or IP Specified";
                MessageBoxButtons buttons = MessageBoxButtons.OK; 
                DialogResult result;
                //// Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
                else
                {
                    this.Cbo1PingCommands();
                }
        }
    
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // Checks the value of the text.
            if (this.comboBox2.Text == "Example: computer.fabrikam.com")
            {
                //// Initializes the variables to pass to the MessageBox.Show method.
                string message = "Please specify a computer name or IP address";
                string caption = "No Computer Name or IP Specified";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                //// Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else if (this.comboBox2.Text.Length == 0)
            {
                //// Initializes the variables to pass to the MessageBox.Show method.
                string message = "Please specify a computer name or IP address";
                string caption = "No Computer Name or IP Specified";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                //// Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else
            {
                this.Cbo2PingCommands();
            }
        }

        private void BtnGenerate_Click_1(object sender, EventArgs e)
        {
            this.txtOutput.Text = string.Empty;

            int numberOfPasswords = int.Parse(this.txtNumPass.Text);
            int passwordLength = int.Parse(this.txtLength.Text);
            ////generate each password
            for (int i = 0; i < numberOfPasswords; i++)  
            {
                ////generate each character value
                for (int g = 0; g < passwordLength; g++)
                {
                    this.txtOutput.Text += this.GetCharacter();
                }
                ////seperate the passwords to multiple lines
                this.txtOutput.Text += "\r\n";  
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ComboItems.Clear();
            this.comboBox1.AutoCompleteCustomSource.Clear();
            this.comboBox2.AutoCompleteCustomSource.Clear();
            Properties.Settings.Default.Save();
            //// Initializes the variables to pass to the MessageBox.Show method.
            string message = "The autocomplete history has been cleared successfully!";
            string caption = string.Empty;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            //// Displays the MessageBox.
            result = MessageBox.Show(this, message, caption, buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        #endregion

        #region Textbox

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string currentText = string.Empty;
            //// output parameter - don't really need.
            float result; 
            bool isNumeric = float.TryParse(this.textBox1.Text, out result);

            if (isNumeric)
            {
                currentText = this.textBox1.Text;
            }
            else
            {
                this.textBox1.Text = currentText;
            }
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            string currentText = string.Empty;
            //// output parameter - don't really need.
            float result;
            bool isNumeric = float.TryParse(this.txtLength.Text, out result);

            if (isNumeric)
            {
                currentText = this.txtLength.Text;
            }
            else
            {
                this.txtLength.Text = currentText;
            }
        }

        private void txtNumPass_TextChanged(object sender, EventArgs e)
        {
            string currentText = string.Empty;
            //// output parameter - don't really need.
            float result;
            bool isNumeric = float.TryParse(this.txtNumPass.Text, out result);

            if (isNumeric)
            {
                currentText = this.txtNumPass.Text;
            }
            else
            {
                this.txtNumPass.Text = currentText;
            }
        }

        #endregion
        
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != string.Empty)
                    {
                        return titleAttribute.Title;
                    }
                }
                
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox9.Checked == true)
            {
                this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                //this.pictureBox8.Image = Properties.Resources.usr;
                //this.button8.Text = "OK";
                this.button8.Enabled = true;
            }
            else if (this.checkBox9.Checked == false)
            {
                this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }       
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox10.Checked == true)
            {
                this.checkBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                //this.pictureBox8.Image = Properties.Resources.usr;
                //this.button8.Text = "OK";
                this.button8.Enabled = true;
            }
            else if (this.checkBox10.Checked == false)
            {
                this.checkBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }       
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox11.Checked == true)
            {
                this.checkBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                //this.pictureBox8.Image = Properties.Resources.usr;
                //this.button8.Text = "OK";
                this.button8.Enabled = true;
            }
            else if (this.checkBox11.Checked == false)
            {
                this.checkBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            }     
        }

      

      

        

       
    
        }
    }

