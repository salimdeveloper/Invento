using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Components
{
    public static class HtmlExtensions
    {
        #region Bootstrap Submit Button Helpers

        /// <summary>
        /// Bootstrap Submit Button helpers
        /// </summary>
        /// <param name="htmlHelper">The helper</param>
        /// <param name="buttonText">The text for the button</param>
        /// <param name="htmlAttributes">An Object that contains The HTML attributes to set for the element.</param>
        /// <returns>An HTML input type='submit' with the appropriate properties set.</returns>
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string buttonText, object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, null, false, null);
        }

        /// <summary>
        /// Bootstrap Submit Button Helper
        /// </summary>
        /// <param name="htmlHelper">The helper</param>
        /// <param name="buttonText">The text for the button</param>
        /// <param name="id">The id for the button</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input type='submit' with the appropriate properties set.</returns>
        ///
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper,
           string buttonText, string id,
           object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, id, false, null, htmlAttributes);
        }

        /// <summary>
        /// Bootstrap Submit Button Helper
        /// </summary>
        /// <param name="htmlHelper">The helper</param>
        /// <param name="buttonText">The text for the button</param>
        /// <param name="id">The id for the button</param>
        /// <param name="isDisabled">Set to true if you want the button disabled</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input type='submit' with the appropriate properties set.</returns>

        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper,
    string buttonText, string id, bool isDisabled,
    object htmlAttributes = null)
        {
            return SubmitButton(htmlHelper, buttonText, id, isDisabled, null, htmlAttributes);
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper,
     string buttonText, string id, bool isDisabled, string btnClass,
     object htmlAttributes = null)
        {
            string html = string.Empty;
            string disable = string.Empty;

            if (string.IsNullOrEmpty(id))
                id = buttonText;
            if (string.IsNullOrEmpty(btnClass))
                btnClass = "btn-primary";

            //Ensure ID is a valid identifier
            id = id.Replace(" ", "").Replace("-", "_");

            html = "<input type='Submit' class='btn {3}{1}' title='{0}' value='{0}' id='{2}' {4} />";

            if (isDisabled)
                disable = " disabled";

            html = string.Format(html, buttonText, disable, id, btnClass, GetHtmlAttributes(htmlAttributes));
            html = html.Replace("'", "\"");

            return new MvcHtmlString(html);
        }
        #endregion

        #region GetHtmlAttributes Method
        private static object GetHtmlAttributes(object htmlAttributes)
        {
            string ret = string.Empty;

            if (htmlAttributes!=null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var item in attributes)
                {
                    ret += " " + item.Key + "=" + "'" + item.Value + "'";
                }
            }
            return ret;
        }
        #endregion
    }
}