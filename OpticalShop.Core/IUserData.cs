using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Core
{
    /// <summary>
    /// Hold Current Data Source Id which using to connect Online Decide database
    /// </summary>
    public interface IUserData
    {
        string DataSourceId { get; set; }

        string DataSourceServer { get; set; }

        string DataSourceDatabase { get; set; }

        string DataSourceUsername { get; set; }
    }
}
