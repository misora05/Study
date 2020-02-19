using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace study_01
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {

        public MainPage()
        {
            InitializeComponent();

            btnSample01.Clicked += (sender, e) => {
                DisplayAlert("通知", "Tab1_" + sender.ToString() + "Clicked", "OK") ;
            };

            btnSample02.Clicked += delegate(object sender,EventArgs e) {
                DisplayAlert("通知2", "Tab1_btnSample02 Clicked", "OK!");
            };

            btnAuth.Clicked += BtnAuth_Clicked;
            
            btnClear.Clicked += (sender, e) =>
            {
                this.ClearTextBox();
            };

            Search1.SearchButtonPressed += (sender, e) =>
            {
                lblResult.Text = Search1.Text;
            };

            Search1.TextChanged += (sender, e) => {
                lblResult.Text = string.Empty;
            };

        }

        private void ClearTextBox() {
            txtAccount.Text = "";
            txtPassword.Text = "";
        }

        private async void BtnAuth_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAccount.Text))
            {
                await DisplayAlert("エラー", "アカウントを入力してください。", "OK");
            }
            else if (String.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("エラー", "パスワードを入力してください。", "OK");
            }
            else {
                if ((bool)await DisplayAlert("確認", "よろしいですか？", "はい", "いいえ")) {
                    await DisplayAlert("よっしゃ", "Okay!", "OK");
                }
                else {
                    this.ClearTextBox();
                }
            }
        }
    }
}
