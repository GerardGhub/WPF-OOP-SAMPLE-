﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPF_OOP.Application.Main_Menu;
using WPF_OOP.Interfaces;
using WPF_OOP.Notifications;
using WPF_OOP.Repository;
using WPF_OOP.StoredProcedures;

namespace WPF_OOP
{
    public partial class FrmLoginForm : Form
    {


        DataSet dSet = new DataSet();
        readonly PopupNotifierClass GlobalStatePopup = new PopupNotifierClass();
        readonly myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;
        readonly myglobal pointer_module = new myglobal();
        UserFileRepository UserFileRepository = new UserFileRepository();

        public FrmLoginForm()
        {
            InitializeComponent();
        }

        private void FrmLoginForm_Load(object sender, EventArgs e)
        {
            this.ConnectionInit();
            this.UseEffectMenuLoad();
        }

        private void ConnectionInit()
        {
            this.objStorProc = xClass.g_objStoredProc.GetCollections();
        }

        private void UseEffectMenuLoad()
        {
            this.TxtUserName.Focus();
        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxIsValid();
        }

        private void TextBoxIsValid()
        {

            bool result = (this.TxtUserName.Text == String.Empty || this.TxtPassword.Text == String.Empty)  ?  this.BtnLogin.Enabled = false : this.BtnLogin.Enabled = true;
 
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxIsValid();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.LoginProcedure();
        }

        private void LoginProcedure() 
        {

            //User Stored Procedure Validate name & Password

            this.UserFileRepository.LoginValidation(this.TxtUserName.Text.Trim(), this.TxtPassword.Text.Trim()); 
 
  


            if (this.UserFileRepository.dSet.Tables[0].Rows.Count > 0)
            {
                userinfo.set_user_parameters(this.UserFileRepository.dSet);
                myglobal.user_password = this.TxtPassword.Text;

                //string winpath = Environment.GetEnvironmentVariable("windir");
                //string path = System.IO.Path.GetDirectoryName(
                //System.Windows.Forms.Application.ExecutablePath);




                this.Hide();
                MDIParentMenu MainMenu = new MDIParentMenu();
                MainMenu.ShowDialog();
                this.Close();

                //end of form validation
            }
            else
            {


                NotAllowToUsedTheSystem();

            }
        }


        public void NotAllowToUsedTheSystem()
        {

            MetroFramework.MetroMessageBox
            .Show(this, "Sorry! You are not allowed to use this system invalid credentials! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
           xClass.ClearTxt(this.TxtUserName, this.TxtPassword);
            this.UseEffectMenuLoad();


        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoginProcedure();
            }
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoginProcedure();
            }
        }
    }
}
