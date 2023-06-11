using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.views.loader
{
    internal class Loader
    {
        private Loading loading;
        private Form form;

        public Loader(Form form)
        {
            this.loading = new();
            this.form = form;
        }

        public void StartLoading()
        {
            this.form.Enabled = false;
            this.loading.Show();
        }

        public void StopLoading()
        {
            this.form.Enabled = true;
            this.loading.Close();
        }
    }
}
