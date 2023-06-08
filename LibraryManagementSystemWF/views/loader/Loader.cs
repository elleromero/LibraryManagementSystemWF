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

        public Loader()
        {
            this.loading = new();
        }

        public void StartLoading()
        {
            this.loading.Show();
        }

        public void StopLoading()
        {
            this.loading.Close();
        }
    }
}
