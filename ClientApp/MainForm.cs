
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private tblcustomer cus_ { get; set; }
        private APIService api_sv { get; set; }
        public MainForm(tblcustomer cus)
        {
            cus_ = cus;
            InitializeComponent();
            lbinf.Text = "Hello " + cus_.name_ + " - Phone: "+ cus_.phonenumber+" - Ngày sinh: "+ cus_.dateofbirth.ToString("dd-MM-yyyy") + " - Địa chỉ: "+cus_.address_;

            api_sv = new APIService();
            loadAlltick();
            //MessageBox.Show("Hello, " + cus_.name_);
        }


        private void btnput_Click(object sender, EventArgs e)
        {
            decimal lotNum = txtlotnum.Value;
            if (lotNum < 0 || lotNum > 9)
            {
                MessageBox.Show("Số đặt phải là số từ 0 đến 9");
                return;
            }
            if (cbsession.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phiên sổ xố");
                return;
            }
            int session = int.Parse(cbsession.SelectedItem.ToString());
            if (session <= DateTime.Now.Hour || session >= (DateTime.Now.Hour) + 2)
            {
                MessageBox.Show("Bạn chỉ đặt được phiên kế tiếp: " + (DateTime.Now.Hour + 1));
                return;
            }

            tblticket tick = new tblticket() { lot_num = (int)lotNum, session_ = session, datelot = DateTime.Now, cusid = cus_.cusid };
            API_Result rs = api_sv.CreateTicket(tick);
            int ticketid = JsonConvert.DeserializeObject<int>(rs.stringResult);
            switch (ticketid)
            {
                case 0:
                    MessageBox.Show("Xảy ra lỗi trong quá trình đặt số.");
                    break;
                case -1:
                    MessageBox.Show("Số này đã được đăng ký.");
                    break;
                default:
                    MessageBox.Show("Đặt số thành công.");
                    tick.tickid = ticketid;
                    clearData_GridViewTicket();
                    loadAlltick();
                    break;
            }

        }
        public void loadAlltick()
        {
            clearData_GridViewTicket();
            int countColumn = dataGridViewTick.Columns.Count;
            List<tblticket> listTick = JsonConvert.DeserializeObject<List<tblticket>>(api_sv.Get_all_ticket_by_cus(cus_.cusid).stringResult);
            try
            {
                int countRow = listTick.Count;
                dataGridViewTick.RowCount = countRow;
                for (int i = 0; i < countRow; i++)
                {
                    var row = new String[] { (i + 1).ToString(), listTick[i].session_.ToString(), listTick[i].datelot.ToString("dd-MM-yyyy"), listTick[i].lot_num.ToString(), listTick[i].ismatch == -1 ? "Chờ sổ" : (listTick[i].ismatch == 1 ? "Đã trúng" : "Không trúng"), listTick[i].lastedit.ToString("dd-MM-yyyy HH:mm:ss") };

                    for (int j = 0; j < countColumn; j++)
                    {
                        try
                        {
                            dataGridViewTick[j, i].Value = row[j];
                        }
                        catch
                        {
                            break;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void clearData_GridViewTicket()
        {
            try
            {
                dataGridViewTick.DataSource = null;
                dataGridViewTick.Rows.Clear();
                dataGridViewTick.Refresh();
            }
            catch
            {
            }
        }

        private void timer_reloaddata_Tick(object sender, EventArgs e)
        {
            loadAlltick();
        }
    }
}
