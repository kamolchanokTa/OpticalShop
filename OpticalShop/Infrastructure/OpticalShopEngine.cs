using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpticalShop.Core;

namespace OpticalShop.Infrastructure
{

    /// <summary>
    /// OpticalShopEngine represent single point of access Application, User data and any information
    /// </summary>
    public class OpticalShopEngine : IEngine
    {
        private OpticalShopEngine()
        {

        }

        /// <summary>
        /// Init SPC Engine
        /// </summary>
        /// <returns></returns>
        public static OpticalShopEngine Init()
        {
            return new OpticalShopEngine();
        }

       

        #region IEngine Members


        #endregion
    }
}