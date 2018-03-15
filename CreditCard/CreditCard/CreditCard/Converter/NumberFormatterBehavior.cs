using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace CreditCard.Converter
{
    public class NumberFormatterBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += onTextChanged;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= onTextChanged;

            base.OnDetachingFrom(bindable);
        }

        void onTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;

            entry.Text = formatPhoneNumber(entry.Text);
        }

        private string formatPhoneNumber(string input)
        {
           
                var digitsRegex = new Regex(@"[^\d]");
                var digits = digitsRegex.Replace(input, "");
            #region 12 characters --- 1234-5678-9123
            if (digits.Length <= 4) //0-3
                return digits;
            if (digits.Length <= 8)//4-7
                return $"{digits.Substring(0, 4)}-{digits.Substring(4)}";
            if (digits.Length <= 12)//7-11
                return $"{digits.Substring(0, 4)}-{digits.Substring(4, 4)}-{digits.Substring(8)}";
            return $"{digits.Substring(0, 4)}-{digits.Substring(4, 4)}-{digits.Substring(8)}";
            #endregion




        }
    }
}
