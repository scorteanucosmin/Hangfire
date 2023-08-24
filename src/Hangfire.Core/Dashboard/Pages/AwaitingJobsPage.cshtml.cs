#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Common;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Dashboard.Resources;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.States;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
    using Hangfire.Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class AwaitingJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");













            
            #line 13 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
  
    Layout = new LayoutPage(Strings.AwaitingJobsPage_Title);

    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    List<string> jobIds = null;
    Pager pager = null;
    JobList <AwaitingJobDto> jobs = null;
    int jobCount = 0;

    if (Storage.HasFeature(JobStorageFeatures.Monitoring.AwaitingJobs))
    {
        var monitor = Storage.GetMonitoringApi() as JobStorageMonitor;
        if (monitor == null) 
        {
            throw new NotSupportedException("MonitoringApi should inherit the `JobStorageMonitor` class");
        }

        pager = new Pager(from, perPage, DashboardOptions.DefaultRecordsPerPage, monitor.AwaitingCount());
        jobs = monitor.AwaitingJobs(pager.FromRecord, pager.RecordsPerPage);
        jobCount = jobs.Count;
    }
    else
    {
        using (var connection = Storage.GetReadOnlyConnection())
        {
            var storageConnection = connection as JobStorageConnection;

            if (storageConnection != null)
            {
                pager = new Pager(from, perPage, DashboardOptions.DefaultRecordsPerPage, storageConnection.GetSetCount("awaiting"));
                jobIds = storageConnection.GetRangeFromSet("awaiting", pager.FromRecord, pager.FromRecord + pager.RecordsPerPage - 1);
                jobCount = jobIds.Count;
            }
        }
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");


            
            #line 56 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
   Write(Html.JobsSidebar());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <h1 class=\"page-header\">");


            
            #line 59 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                           Write(Strings.AwaitingJobsPage_Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n\r\n");


            
            #line 61 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
         if (jobIds == null && jobs == null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-warning\">\r\n                <h4>");


            
            #line 64 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
               Write(Strings.AwaitingJobsPage_ContinuationsWarning_Title);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                <p>");


            
            #line 65 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
              Write(Strings.AwaitingJobsPage_ContinuationsWarning_Text);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n            </div>\r\n");


            
            #line 67 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
        }
        else if (jobCount > 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"js-jobs-list\">\r\n                <div class=\"btn-toolbar b" +
"tn-toolbar-top\">\r\n");


            
            #line 72 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                     if (!IsReadOnly)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button class=\"js-jobs-list-command btn btn-sm btn-primar" +
"y\"\r\n                                data-url=\"");


            
            #line 75 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                     Write(Url.To("/jobs/awaiting/enqueue"));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                data-loading-text=\"");


            
            #line 76 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                              Write(Strings.Common_Enqueueing);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span class=\"glyphicon glyphicon-repeat\"></span>\r" +
"\n                            ");


            
            #line 78 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                       Write(Strings.Common_EnqueueButton_Text);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </button>\r\n");


            
            #line 80 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                    }

            
            #line default
            #line hidden

            
            #line 81 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                     if (!IsReadOnly)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button class=\"js-jobs-list-command btn btn-sm btn-defaul" +
"t\"\r\n                                data-url=\"");


            
            #line 84 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                     Write(Url.To("/jobs/awaiting/delete"));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                data-loading-text=\"");


            
            #line 85 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                              Write(Strings.Common_Deleting);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                data-confirm=\"");


            
            #line 86 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                         Write(Strings.Common_DeleteConfirm);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span class=\"glyphicon glyphicon-remove\"></span>\r" +
"\n                            ");


            
            #line 88 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                       Write(Strings.Common_DeleteSelected);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </button>\r\n");


            
            #line 90 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");


            
            #line 91 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
               Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"table-responsive\">\r\n     " +
"               <table class=\"table table-hover\">\r\n                        <thead" +
">\r\n                            <tr>\r\n");


            
            #line 98 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                 if (!IsReadOnly)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <th class=\"min-width\">\r\n                     " +
"                   <input type=\"checkbox\" class=\"js-jobs-list-select-all\"/>\r\n   " +
"                                 </th>\r\n");


            
            #line 103 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                                <th class=\"min-width\">");


            
            #line 104 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                 Write(Strings.Common_Id);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                <th>");


            
            #line 105 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                               Write(Strings.Common_Job);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                <th class=\"min-width\">");


            
            #line 106 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                 Write(Strings.AwaitingJobsPage_Table_Options);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                <th class=\"min-width\">");


            
            #line 107 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                 Write(Strings.AwaitingJobsPage_Table_Parent);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                <th class=\"align-right\">");


            
            #line 108 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                   Write(Strings.AwaitingJobsPage_Table_Since);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            </tr>\r\n                        </thead>\r\n     " +
"                   <tbody>\r\n");


            
            #line 112 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                             for (var i = 0; i < jobCount; i++)
                            {
                                var jobId = jobIds != null ? jobIds[i] : jobs[i].Key;

                                Job job = null;
                                bool inAwaitingState = true;
                                IDictionary<string, string> stateData = null;
                                string parentStateName = null;
                                DateTime? awaitingSince = null;

                                if (jobs != null)
                                {
                                    if (jobs[i].Value != null)
                                    {
                                        job = jobs[i].Value.Job;
                                        inAwaitingState = jobs[i].Value.InAwaitingState;
                                        stateData = jobs[i].Value.StateData;
                                        parentStateName = jobs[i].Value.ParentStateName;
                                        awaitingSince = jobs[i].Value.AwaitingAt;
                                    }
                                }
                                else
                                {
                                    using (var connection = Storage.GetReadOnlyConnection())
                                    {
                                        var jobData = connection.GetJobData(jobId);
                                        var state = connection.GetStateData(jobId);
                                        inAwaitingState = AwaitingState.StateName.Equals(state?.Name);

                                        if (state != null && inAwaitingState)
                                        {
                                            var parentState = connection.GetStateData(state.Data["ParentId"]);
                                            parentStateName = parentState.Name;
                                        }

                                        job = jobData.Job;
                                        stateData = state?.Data;
                                        awaitingSince = jobData.CreatedAt;
                                    }
                                }


            
            #line default
            #line hidden
WriteLiteral("                                <tr class=\"js-jobs-list-row ");


            
            #line 153 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                        Write(job == null || !inAwaitingState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 153 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                                                                                    Write(job != null && inAwaitingState ? "hover" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n");


            
            #line 154 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                     if (!IsReadOnly)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <td>\r\n");


            
            #line 157 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                             if (job == null || inAwaitingState)
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <input type=\"checkbox\" class=\"js-" +
"jobs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 159 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                                                                                     Write(jobId);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n");


            
            #line 160 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </td>\r\n");


            
            #line 162 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                    <td class=\"min-width\">\r\n                     " +
"                   ");


            
            #line 164 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                   Write(Html.JobIdLink(jobId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 165 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                         if (job != null && !inAwaitingState)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <span title=\"");


            
            #line 167 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                    Write(Strings.Common_JobStateChanged_Text);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 168 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\r\n");


            
            #line 170 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                     if (job == null)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <td colspan=\"2\"><em>");


            
            #line 172 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                       Write(Strings.Common_JobExpired);

            
            #line default
            #line hidden
WriteLiteral("</em></td>\r\n");


            
            #line 173 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                    }
                                    else
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <td class=\"word-break\">\r\n                " +
"                            ");


            
            #line 177 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                       Write(Html.JobNameLink(jobId, job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n");



WriteLiteral("                                        <td class=\"min-width\">\r\n");


            
            #line 180 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                             if (stateData != null && stateData.ContainsKey("Options") && !String.IsNullOrWhiteSpace(stateData["Options"]))
                                            {
                                                var optionsDescription = stateData["Options"];
                                                if (Enum.TryParse(optionsDescription, out JobContinuationOptions options))
                                                {
                                                    optionsDescription = options.ToString("G");
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                                <code>");


            
            #line 187 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                 Write(optionsDescription);

            
            #line default
            #line hidden
WriteLiteral("</code>\r\n");


            
            #line 188 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                            }
                                            else
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <em>");


            
            #line 191 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                               Write(Strings.Common_NotAvailable);

            
            #line default
            #line hidden
WriteLiteral("</em>\r\n");


            
            #line 192 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </td>\r\n");



WriteLiteral("                                        <td class=\"min-width\">\r\n");


            
            #line 195 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                             if (parentStateName != null)
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <a href=\"");


            
            #line 197 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                    Write(Url.JobDetails(stateData["ParentId"]));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"text-decoration-none\">\r\n                                                " +
"    ");


            
            #line 198 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                               Write(Html.StateLabel(parentStateName, parentStateName, hover: true));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </a>\r\n");


            
            #line 200 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                            }
                                            else
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <em>");


            
            #line 203 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                               Write(Strings.Common_NotAvailable);

            
            #line default
            #line hidden
WriteLiteral("</em>\r\n");


            
            #line 204 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </td>\r\n");



WriteLiteral("                                        <td class=\"min-width align-right\">\r\n");


            
            #line 207 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                             if (awaitingSince.HasValue)
                                            {
                                                
            
            #line default
            #line hidden
            
            #line 209 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                           Write(Html.RelativeTime(awaitingSince.Value));

            
            #line default
            #line hidden
            
            #line 209 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                                                                       
                                            }
                                            else
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <em>");


            
            #line 213 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                               Write(Strings.Common_NotAvailable);

            
            #line default
            #line hidden
WriteLiteral("</em>\r\n");


            
            #line 214 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                            }

            
            #line default
            #line hidden
WriteLiteral("                                        </td>\r\n");


            
            #line 216 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");


            
            #line 218 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </tbody>\r\n                    </table>\r\n                <" +
"/div>\r\n                ");


            
            #line 222 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
           Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 224 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-info\">\r\n                ");


            
            #line 228 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
           Write(Strings.AwaitingJobsPage_NoJobs);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 230 "..\..\Dashboard\Pages\AwaitingJobsPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591
