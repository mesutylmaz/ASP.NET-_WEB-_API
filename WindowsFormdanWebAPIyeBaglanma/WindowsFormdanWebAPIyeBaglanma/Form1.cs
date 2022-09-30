using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormdanWebAPIyeBaglanma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44337/");
            HttpResponseMessage responseMessage = await client.GetAsync("api/sehir/");
            string result = await responseMessage.Content.ReadAsStringAsync();
            label1.Text = result;
        }
    }
}
