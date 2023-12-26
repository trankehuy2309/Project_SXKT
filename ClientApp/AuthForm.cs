
using ClientApp.Services;
using Lib_Models;
using Lib_Models.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class AuthForm : Form
    {
        private APIService api_sv { get; set; }
        private RegisForm regis {get;set;}
        private MainForm mainF { get; set; }
        public AuthForm()
        {
            InitializeComponent();
            api_sv = new APIService();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            String messAlert = "Đã có lỗi xảy ra trong quá trình xử lý, vui lòng thử lại.";
            try
            {
                String txtPhone = txtphoneAuth.Text;
                if (String.IsNullOrEmpty(txtPhone)) {
                    messAlert = "Vui lòng nhập số điện thoại.";
                    MessageBox.Show(messAlert);
                    return;
                }
                API_Result rs = api_sv.Auth(txtPhone);
                tblcustomer cus = JsonConvert.DeserializeObject<tblcustomer>(rs.stringResult);
                if (cus.cusid >0)
                {
                    messAlert = "Chào mừng " + cus.name_ + " quay trở lại phần mềm sổ xố kiến thiết.";
                    MessageBox.Show(messAlert);
                    mainF = new MainForm(cus);
                    this.Visible = false;
                    mainF.Visible = true;
                }
                else {
                    messAlert = "Chào mừng thành viên mới, chúng ta sẽ đăng ký thông tin trước.";
                    MessageBox.Show(messAlert);
                    regis = new RegisForm();
                    this.Visible = false;
                    regis.Visible = true;
                }
               
                return;
               
            }
            catch {
                MessageBox.Show(messAlert);
            }
         

        }

        private void btnRegis_Click(object sender, EventArgs e)
        {
            regis = new RegisForm();
            this.Visible=false;
            regis.Visible = true;
            
        }
    }
}
