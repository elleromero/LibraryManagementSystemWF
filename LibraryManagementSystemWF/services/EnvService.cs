﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.services
{
    internal class EnvService
    {
        // NOTE:This class stores important constant variables that will be used in the entire program.
        // You can customize the values of each variable as much as you like.
        //DESKTOP-SL438A7\SQLEXPRESS
        private const string
            DB_NAME = "LMS",
            CONN_BASE = "Data Source = DESKTOP-65FQSMS\\SQLEXPRESS;Integrated Security=true;",
            CONN_STR = $"{CONN_BASE}Initial Catalog={DB_NAME}",
            VERSION = "v4.0 - stable branch";
        private const int BORROW_TIME_DAYS = 7;
                           
        public static int GetBorrowTimeDays()
        {
            return BORROW_TIME_DAYS;
        }

        public static string GetDBName()
        {
            return DB_NAME;
        }

        public static string GetConnBase()
        {
            return CONN_BASE;
        }

        public static string GetConnStr()
        {
            return CONN_STR;
        }

        public static string GetVersion()
        {
            return VERSION;
        }
    }
}
