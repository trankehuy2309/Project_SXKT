
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class RegisForm : Form
    {
        private APIService api_sv { get; set; }
        public RegisForm()
        {
            InitializeComponent();
            api_sv = new APIService();
        }
        private MainForm mainF { get; set; }
        private void btnRegis_Click(object sender, EventArgs e)
        {
            try
            {
                String name = txtName.Text;
                String phone = txtphonenum.Text;
                String address = txtAddress.Text;
                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(address))
                {
                    MessageBox.Show("Vui lòng không để trống các trường thông tin.");
                    return;
                }
                Regex validatePhoneNumberRegex = new Regex("^\\+?[0-9][0-9]{7,14}$");
                if (!validatePhoneNumberRegex.IsMatch(phone)) {
                    MessageBox.Show("Vui lòng nhập lại số điện thoại.");
                    return;
                }
                
                DateTime dateofbirth = txtdateofbirth.Value;
                tblcustomer cus = new tblcustomer() { name_ = name, phonenumber = phone, address_ = address, dateofbirth = dateofbirth };
                API_Result rs = api_sv.Regis(cus);
                int cusid = JsonConvert.DeserializeObject<int>(rs.stringResult);
                switch (cusid)
                {
                    case 0:
                        MessageBox.Show("Xảy ra lỗi trong quá trình đăng ký.");
                        break;
                    case -1:
                        MessageBox.Show("Số điện thoại này đã được đăng ký.");
                        break;
                    default:
                        MessageBox.Show("Đăng ký thành công.");
                        cus.cusid = cusid;
                        mainF = new MainForm(cus);
                        this.Visible = false;
                        mainF.Visible = true;
                        break;
                }


            }
            catch
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình xử lý.");
            }


        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
