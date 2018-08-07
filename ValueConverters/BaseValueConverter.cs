using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Uiprogramming
{
    /// <summary>
    /// A base value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T">The type of this value converter</typeparam>

    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members
        // A single static instance of this value coverter
        private static T mConverter = null;
        #endregion

        #region Markup Extension Methods
        /// <summary>
        /// Provides a static instance of ther value converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }
        #endregion

        #region Value Converter Methods

        // The method to convert one type to another
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        // The method to convert a value back to it's source type
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);


        #endregion
    }
}
