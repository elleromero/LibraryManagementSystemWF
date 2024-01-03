using LibraryManagementSystemWF.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystemWF.utils
{
    internal class ReceiptMaker 
    {
        private string headerTitle, headerName, headerCourse, footerText;
        private Dictionary<string, double> items;
        

        public ReceiptMaker()
        {
            

            this.headerTitle = "                       Library Management System"; ;
            this.headerName = "Name: " ;
            this.headerCourse = "Course: ";
            this.footerText = "             DO NOT THROW AWAY THIS RECEIPT";
            this.items = new();
        }

        

        public void AddItem(string itemName, double amount)
        {
            this.items.Add(itemName, amount);
        }

        public void RemoveItem(string itemName)
        {
            this.items.Remove(itemName);
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public double GetTotal()
        {
            double total = 0;

            foreach (KeyValuePair<string, double> item in this.items)
            {
                total += item.Value;
            }

            return total;
        }

        public double GetChange(double cash)
        {
            double change = 0;

            if (cash >= this.GetTotal())
            {
                change = cash - this.GetTotal();
            }

            return change;
        }

        public string GetReceipt()
        {
            string receipt = string.Empty;

            // render header
            receipt += $"{this.headerTitle}" +
                $"\n{this.InsertLineBreak()}" +
                $"\n{this.headerName}" +
                $"\n{this.headerCourse}" +
                $"\n{this.InsertLineBreak()}" +
                $"\nBook (Copy ID){this.InsertWhitespace(35)}Amount (PHP)" +
                $"{this.GetItems()}" +
                $"\n{this.InsertLineBreak()}\n" +
                $"\n{this.footerText}";

            return receipt;
        }

        

        public string GetItems()
        {
            string itemsTxt = string.Empty;

            foreach (KeyValuePair<string, double> item in this.items)
            {
                itemsTxt += $"\n{item.Key} {this.InsertWhitespace(20)} - P{item.Value}";
            }

            return itemsTxt;
        }

        private string InsertLineBreak()
        {
            string lineBreak = string.Empty;

            for (int i = 0; i < 37; i++)
            {
                lineBreak += "=";
            }

            return lineBreak;
        }

        private string InsertWhitespace(int size)
        {
            string ws = string.Empty;

            for (int i = 0; i < size; i++)
            {
                ws += " ";
            }

            return ws;
        }
    }
}
