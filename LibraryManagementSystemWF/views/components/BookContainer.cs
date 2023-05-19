﻿using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.views.Dashboard.Librarian;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.views.components
{
    public partial class BookContainer : UserControl
    {
        private Book book = new();
        private bool isPreview;

        public BookContainer(Book book, bool isPreview = false)
        {
            InitializeComponent();

            this.isPreview = isPreview;
            this.book = book;
            new ToolTip().SetToolTip(titleLbl, book.Title);
            titleLbl.Text = book.Title;
            authorLbl.Text = book.Author;

            if (File.Exists(book.Cover)) pictureBox1.Image = Image.FromFile(book.Cover);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!isPreview) topPanel.Visible = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (!isPreview)
            {
                topPanel.Visible = true;
                topPanel.BringToFront();
            }
        }

        private void titleLbl_Click(object sender, EventArgs e)
        {
            new BookInformation(this.book).Show();
        }

        private void titleLbl_MouseEnter(object sender, EventArgs e)
        {
            titleLbl.ForeColor = Color.Gray;
        }

        private void titleLbl_MouseLeave(object sender, EventArgs e)
        {
            titleLbl.ForeColor = Color.Black;
        }
    }
}
