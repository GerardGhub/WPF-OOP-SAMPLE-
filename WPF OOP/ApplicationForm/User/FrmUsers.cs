﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPF_OOP.Interfaces;
using WPF_OOP.Notifications;
using WPF_OOP.Repository;
using WPF_OOP.StoredProcedures;

namespace WPF_OOP.ApplicationForm.User
{
    public partial class FrmUsers : Form
    {


        //TblCustomersRepository TblCustomerRepo = new TblCustomersRepository();
        UserFileRepository UserFileRepository = new UserFileRepository();
        PopupNotifierClass GlobalStatePopup = new PopupNotifierClass();
        IStoredProcedures g_objStoredProcCollection = null;
        readonly myclasses xClass = new myclasses();
        public FrmUsers()
        {
            InitializeComponent();
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            this.ConnetionString();
            this.UserFileRepository.GetUsers (this.DgvUsers);
            this.LblTotalRecords.Text = this.DgvUsers.RowCount.ToString();
        }

        private void ConnetionString()
        {
            this.g_objStoredProcCollection = this.xClass.g_objStoredProc.GetCollections();
        }


    }
}
