﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MVC09.Models.Common
{
    // Part 77 Custom Action Filters
    public class TrackExecutionTime : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
                "-> " + filterContext.ActionDescriptor.ActionName + " -> OnActionExecuting \t-" +
                DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
               "-> " + filterContext.ActionDescriptor.ActionName + " -> OnActionExecuted \t-" +
               DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() +
               "-> " + filterContext.RouteData.Values["action"].ToString() + " -> OnResultExecuting \t-" +
               DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() +
               "-> " + filterContext.RouteData.Values["action"].ToString() + " -> OnResultExecuted \t-" +
               DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
            LogExecutionTime("-------------------------");
        }
        private void LogExecutionTime(string data)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Data/Data.txt"), data);
        }
        public void OnException(ExceptionContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() +
               "-> " + filterContext.RouteData.Values["action"].ToString() + " ->" + filterContext.Exception.Message+ "\t-" +
               DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
            LogExecutionTime("-------------------------");
        }
    }
}