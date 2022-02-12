using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DeepAI; // Add this line to the top of your file
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NNUpscaler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sButton1_Click(object sender, EventArgs e)
        {
            DeepAI_API api = new DeepAI_API(apiKey: "f324a1e7-c056-4613-9e27-9cfb0ccad096");

            StandardApiResponse resp = api.callStandardApi("torch-srgan", new
            {
                image = File.OpenRead(label2.Text),
            });
            textBox1.Text=api.objectAsJsonString(resp);
        }
        
        private void sButton2_Click(object sender, EventArgs e)
        {
            string pathfull = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                pathfull = filepath;
            }
            string extractedfilename = null;

            // using the method
            extractedfilename = Path.GetFileName(pathfull);
            selectedfile.Text= extractedfilename;
            label2.Text = pathfull;
        }
    }
}
