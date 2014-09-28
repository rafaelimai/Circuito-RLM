using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ProjetoIDEIntl
{
    public partial class MainGUI : Form
    {
        private OpenFileDialog ofd;
        public MainGUI()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if(ofd.CheckPathExists){
                ProgramData.getInstance().loadTranslation(ofd.OpenFile());
            } else{
                MessageBox.Show("Invalid path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Programar aqui para sair.Como é que dava System.exit em C#?
            this.Close();
        }

        private void MainGUI_Load(object sender, EventArgs e)
        {

            
        }

        private void aboutIntlIDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aboutProgram = "Intl IDE v1.0\n"+
                "A simple way to handle internationalization in computer programs.\n"+
                "Developed first by Rafael Y.Imai in September/2014 \n"+
                "This program is avaliable under the Creative Commons license.";
            MessageBox.Show(aboutProgram, "About Intl IDE", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void openTranslationFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C:/";
            ofd.ShowDialog(this);
            //Mudar depois para deixar portátil?
            //Programar o listener da janela de seleção de arquivo para voltar para cá quando o usuário clicar ok.
           
        }

        private void updateSupportedlanguagesdatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void intlIDEWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/rafaelimai/Circuito-RLM");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

            
    }
}
