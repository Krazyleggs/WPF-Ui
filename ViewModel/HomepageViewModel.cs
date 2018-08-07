using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uiprogramming.ViewModel
{
    class HomepageViewModel : ViewModelBase
    {
        #region Commands

        // Start timer command
        public RelayCommand StarttimerCommand { get; private set; }

        #endregion

        #region Default Constructor
        public HomepageViewModel ()
        {
            StarttimerCommand = new RelayCommand(() =>
                {
                    DataAccess db = new DataAccess();
                    db.RecordStartTime(0, DateTime.Now, "Swaggins");
                }
            );
        }
        #endregion
    }
}
