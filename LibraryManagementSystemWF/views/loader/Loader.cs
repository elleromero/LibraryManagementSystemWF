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
        private Button triggerBtn;

        public Loader(Button triggerBtn)
        {
            this.loading = new();
            this.triggerBtn = triggerBtn;
        }

        public void StartLoading()
        {
            this.triggerBtn.Enabled = false;
            this.loading.Show();
        }

        public void StopLoading()
        {
            this.triggerBtn.Enabled = true;
            this.loading.Close();
        }
    }
}
