using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelCallApi
{
    public partial class ParallelCallApi : Form
    {

        static readonly HttpClient client = new HttpClient();

        static async Task postApi(string url, StringContent content)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response;

                response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(response);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task getApi(string url, string posturl, string guid)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response;

                response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic jsonObject = new JObject();
                jsonObject.Result = responseBody;
                jsonObject.Guid = guid;
                StringContent content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

                //string jsonObject = "{'Result':'" + responseBody + "','Guid':'" + guid + "'}";
                //StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                await postApi(posturl, content);
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public ParallelCallApi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getApi(getUrlTextBox.Text, postUrlTextBox.Text + "Divide", guidTextBox.Text);
            getApi(textBox1.Text, postUrlTextBox.Text + "Sub", guidTextBox.Text);
            getApi(textBox2.Text, postUrlTextBox.Text + "Sum", guidTextBox.Text);
            getApi(textBox3.Text, postUrlTextBox.Text + "Multiply", guidTextBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Factory.StartNew(() => getApi(getUrlTextBox.Text, postUrlTextBox.Text + "Divide", guidTextBox.Text)));
            taskList.Add(Task.Factory.StartNew(() => getApi(textBox1.Text, postUrlTextBox.Text + "Sub", guidTextBox.Text)));
            taskList.Add(Task.Factory.StartNew(() => getApi(textBox2.Text, postUrlTextBox.Text + "Sum", guidTextBox.Text)));
            taskList.Add(Task.Factory.StartNew(() => getApi(textBox3.Text, postUrlTextBox.Text + "Multiply", guidTextBox.Text)));
            Task.WaitAll(taskList.ToArray());
        }
    }
}
