using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC05.CustomHtmlHelper
{
    public static class CustomHtmlHelper
    {
        // Part 48 - Custom html helpers in MVC
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }

        public static string Image2(this HtmlHelper helper, string src, string alt)
        {
            // Part 49 – HTML encoding in MVC
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            return tb.ToString(TagRenderMode.SelfClosing);
        }
    }


}