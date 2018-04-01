using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SysAdminCompanion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        #region Form Events

        private void Form1_Load(object sender, EventArgs e)
        {
           if (comboBox1.Text.Length == 0)
            {
                label5.Text = "The computer name field is blank. Enter a computer name or IP address.";
                comboBox1.Text = "Example:192.168.0.2";
                comboBox1.ForeColor = Color.Gray;
            }
           if (comboBox1.Text == "Example:192.168.0.2")
            {
                label5.Text = "The computer name field is blank. Enter a computer name or IP address.";
                comboBox1.Text = "Example:192.168.0.2";
                comboBox1.ForeColor = Color.Gray;
            }
            
            button1.Text = "OK";
            radioButton1.Checked = true;
            pictureBox1.Image = Properties.Resources.compmgmnt;
            radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
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
                    if (titleAttribute.Title != "")
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
                    return "";
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
                    return "";
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
                    return "";
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
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion  

        #region Tab Events

        private void tabControl1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                this.Text = String.Format("Remote Control");
                this.AcceptButton = button3;
                radioButton8.Checked = true;
                radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                button3.Text = "Restart";
               // label2.Text = "The computer name field is blank. Enter a computer name or IP address.";
                comboBox2.Text = comboBox1.Text;
                // comboBox2.ForeColor = Color.Gray;
                if (comboBox2.Text == "Example:192.168.0.2")
                {
                    label2.Text = "The computer name field is blank. Enter a computer name or IP address.";
                    comboBox2.ForeColor = Color.Gray;
                }
            
            }
            else if (tabControl1.SelectedTab == tabPage1)
           {
               this.Text = String.Format(AssemblyTitle);
               this.AcceptButton = button1;
                radioButton8.Checked = false;
            radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                this.Text = String.Format("Password Generator");
                this.AcceptButton = btnGenerate;
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                this.Text = String.Format("About {0}", AssemblyTitle);
                this.label9.Text = AssemblyProduct;
                this.label10.Text = String.Format("Version {0}", AssemblyVersion);
                this.label11.Text = AssemblyCopyright;
                this.linkLabel2.Text = AssemblyCompany;
                label14.Text = System.Environment.MachineName.ToString();
                label16.Text = System.Environment.OSVersion.ToString();
                label18.Text = System.Environment.OSVersion.ServicePack.ToString();
                TimeSpan ts = TimeSpan.FromMilliseconds(Environment.TickCount);
                label20.Text = (ts.Days + " days " + ts.Hours + " hrs and " + ts.Minutes + " mins"); 
            }
        }

        #endregion   

        #region Combobox Events

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.ForeColor = Color.Black;
        } 

        private void comboBox1_MouseUp(object sender, MouseEventArgs e)
        {
            comboBox1.Text = "";
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox2.ForeColor = Color.Black;
        }

        private void comboBox2_MouseUp(object sender, MouseEventArgs e)
        {
            comboBox2.Text = "";
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        #endregion

        #region Radiobutton Events

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                pictureBox1.Image = Properties.Resources.compmgmnt;
                button1.Text = "OK";
            }
            else if (radioButton1.Checked == false)
            {
                radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                pictureBox1.Image = Properties.Resources.eventvwr;
                button1.Text = "OK";
            }
            else if (radioButton2.Checked == false)
            {
                radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                pictureBox1.Image = Properties.Resources.lusrmgr;
                button1.Text = "OK";
            }
            else if (radioButton3.Checked == false)
            {
                radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                pictureBox1.Image = Properties.Resources.msinfo32;
                button1.Text = "OK";
            }
            else if (radioButton4.Checked == false)
            {
                radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                pictureBox1.Image = Properties.Resources.services;
                button1.Text = "OK";
            }
            else if (radioButton5.Checked == false)
            {
                radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                pictureBox1.Image = Properties.Resources.gpedit;
                button1.Text = "OK";
            }
            else if (radioButton6.Checked == false)
            {
                radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                pictureBox1.Image = Properties.Resources.shrpubw;
                button1.Text = "OK";
            }
            else if (radioButton7.Checked == false)
            {
                radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                pictureBox2.Image = Properties.Resources.shutdown;
                radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                button3.Text = "Restart";
            }
            else if (radioButton8.Checked == false)
            {
                radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
            {
                pictureBox2.Image = Properties.Resources.msra;
                radioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                button3.Text = "Connect";
            }
            else if (radioButton9.Checked == false)
            {
                radioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
            }
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                pictureBox2.Image = Properties.Resources.mstsc;
                radioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                button3.Text = "Connect";
                checkBox1.Visible=true;
                checkBox2.Visible=true;
                label8.Visible=true;
            }
            else if (radioButton10.Checked == false)
            {
                radioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
                checkBox1.Visible=false;
                checkBox2.Visible=false;
                label8.Visible=false;
            }
        }

        #endregion 

        #region Button Events


        private void button1_Click(object sender, EventArgs e)
        {

            // Checks the value of the text.

            if (comboBox1.Text.Length == 0)
            {

                // Initializes the variables to pass to the MessageBox.Show method.

                string message = "You did not specify a computer name or IP address";
                string caption = "No Computer Name or IP Specified";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else if (comboBox1.Text == "Example:192.168.0.2")
            {

                // Initializes the variables to pass to the MessageBox.Show method.

                string message = "You did not specify a computer name or IP address";
                string caption = "No Computer Name or IP Specified";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else if (radioButton1.Checked == true)
            {
                System.Diagnostics.Process.Start("compmgmt.msc", "/computer=" + comboBox1.Text);
            }
            else if (radioButton2.Checked == true)
            {
                System.Diagnostics.Process.Start("eventvwr.msc", "/computer:" + comboBox1.Text);
            }
            else if (radioButton3.Checked == true)
            {
                System.Diagnostics.Process.Start("lusrmgr.msc", "/computer:" + comboBox1.Text);
            }
            else if (radioButton4.Checked == true)
            {
                System.Diagnostics.Process.Start("msinfo32.exe", "/computer " + comboBox1.Text);
            }
            else if (radioButton5.Checked == true)
            {
                System.Diagnostics.Process.Start("services.msc", "/computer:" + comboBox1.Text);
            }
            else if (radioButton6.Checked == true)
            {
                System.Diagnostics.Process.Start("gpedit.msc", "/gpcomputer: " + comboBox1.Text);
            }
            else if (radioButton7.Checked == true)
            {
                System.Diagnostics.Process.Start("shrpubw.exe", "/s " + comboBox1.Text);
            }
        }
           

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Checks the value of the text.

            if (comboBox2.Text.Length == 0)
            {

                // Initializes the variables to pass to the MessageBox.Show method.

                string message = "You did not specify a computer name or IP address";
                string caption = "No Computer Name or IP Specified";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else if (comboBox2.Text == "Example:192.168.0.2")
            {

                // Initializes the variables to pass to the MessageBox.Show method.

                string message = "You did not specify a computer name or IP address";
                string caption = "No Computer Name or IP Specified";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
            else if (radioButton8.Checked == true)
            {
                System.Diagnostics.Process.Start("cmd.exe", "/C shutdown.exe -r -m " + comboBox2.Text + " -t " + textBox1.Text + " -c \"Remote restart initiated");
            }
            else if (radioButton9.Checked == true)
            {
                System.Diagnostics.Process.Start("msra.exe", "/offerRA " + comboBox2.Text);
            }
            else if (radioButton10.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false)
            {
                System.Diagnostics.Process.Start("mstsc.exe", "/v: " + comboBox2.Text);
            }
            else if (radioButton10.Checked == true && checkBox1.Checked == true && checkBox2.Checked == false)
            {
                System.Diagnostics.Process.Start("mstsc.exe", "/v: " + comboBox2.Text + " /public");
            }
            else if (radioButton10.Checked == true && checkBox1.Checked == false && checkBox2.Checked == true)
            {
                		System.Diagnostics.Process.Start("mstsc.exe", "/v: " + comboBox2.Text + " /multimon");
            }
            else if (radioButton10.Checked == true && checkBox1.Checked == true && checkBox2.Checked == true)
            {
                System.Diagnostics.Process.Start("mstsc.exe", "/v: " + comboBox2.Text + " /public /multimon");
            }
        }

        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            txtOutput.Text = "";

            int NumberOfPasswords = int.Parse(txtNumPass.Text);
            int PasswordLength = int.Parse(txtLength.Text);

            for (int i = 0; i < NumberOfPasswords; i++)  //generate each password
            {
                for (int g = 0; g < PasswordLength; g++) //generate each character value
                {
                    txtOutput.Text += GetCharacter();

                }
                txtOutput.Text += "\r\n";  //seperate the passwords to multiple lines
            }
        }

        #endregion

        #region Textbox Events


        private string currentText = "";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float result; // output parameter - don't really need.
            bool isNumeric = float.TryParse(textBox1.Text, out result);

            if (isNumeric)
            {
                currentText = textBox1.Text;
            }
            else
            {
                textBox1.Text = currentText;
            }

        }

        #endregion

        private string GetCharacter()
        {

            string[] Lower = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] Upper = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] Number = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] Symbol = new string[] { "!", "@", "#", "$", "%", "&", "*", "?" };

            //Generate a random number
            //http://codebetter.com/blogs/brendan.tompkins/archive/2005/03/09/59496.aspx
            //shows a neat method to randomize the seed, on the default time, fast computers create a password characters on the same seed
            Random rand = new System.Random(Guid.NewGuid().GetHashCode());
            int rplace = rand.Next(0, 4);
            int rplace2 = 0;
            while (!IsChecked(rplace))
            {
                rplace = rand.Next(0, 4);
            }
            switch (rplace)
            {
                case 0:
                    rplace2 = rand.Next(0, 26);
                    return Lower[rplace2];
                case 1:
                    rplace2 = rand.Next(0, 26);
                    return Upper[rplace2];
                case 2:
                    rplace2 = rand.Next(0, 10);
                    return Number[rplace2];
                case 3:
                    rplace2 = rand.Next(0, 8);
                    return Symbol[rplace2];
                default:
                    return "";
            }
        }

        //Routine to see if a random value matches with a check box
        private bool IsChecked(int r)
        {
            switch (r)
            {
                case 0:
                    return cbLower.Checked;
                case 1:
                    return cbUpper.Checked;
                case 2:
                    return cdNumbers.Checked;
                case 3:
                    return cbSymbols.Checked;
                default:
                    return true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:wayne.lloyd@gmx.com?subject=" + AssemblyProduct + " feedback");
        }

        }       

    }
