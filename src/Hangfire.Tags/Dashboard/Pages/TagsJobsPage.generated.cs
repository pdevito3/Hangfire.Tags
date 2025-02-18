﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Tags.Dashboard.Pages
{
    using System;
    
    #line 2 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using System.Text.RegularExpressions;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using Hangfire.Dashboard.Resources;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using Hangfire.Storage.Monitoring;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using Hangfire.Tags;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using Hangfire.Tags.Dashboard;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using Hangfire.Tags.Dashboard.Monitoring;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
    using Hangfire.Tags.Storage;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class TagsJobsPage : TagsRazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");














            
            #line 14 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
  
    Layout = new LayoutPage("Tags");

    int.TryParse(Query("from"), out var from);
    int.TryParse(Query("count"), out var perPage);

    var tags = new string[0];
    string state = null;

    var match = Regex.Match(RequestPath, "^/tags/search(/(?<tags>[^/]+))(/(?<state>[^/]+))?");
    if (match.Success)
    {
        tags = match.Groups["tags"].Value.Split(',');
        state = match.Groups["state"].Value;
    }
    Pager pager;

    var tagsListStyle = Options.TagsListStyle;

    var relatedTags = new List<string>();

    JobList<MatchingJobDto> matchingJobs;
    IDictionary<string, int> matchingStates = null;
    using (var tagStorage = new TagsStorage(Storage))
    {
        var monitor = tagStorage.GetMonitoringApi();

        if (tagsListStyle == TagsListStyle.Dropdown && tags.Length == 1)
        {
            relatedTags = monitor.SearchRelatedTags(tags.First()).ToList();
        }

        pager = new Pager(from, perPage, monitor.GetJobCount(tags, state));
        if (pager.TotalPageCount == 0)
        {
            matchingJobs = new JobList<MatchingJobDto>(Enumerable.Empty<KeyValuePair<string, MatchingJobDto>>());
        }
        else
        {
            matchingJobs = monitor.GetMatchingJobs(tags, pager.FromRecord, pager.RecordsPerPage, state);
            matchingStates = monitor.GetJobStateCount(tags);
        }
    }



            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 60 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
 if (tagsListStyle == TagsListStyle.Dropdown && tags.Length == 1 && relatedTags.Any())
{

            
            #line default
            #line hidden
WriteLiteral("    <script>\r\n        function go(tag) {\r\n            var baseUrl = \"");


            
            #line 64 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                      Write(Url.To("/tags/search/" + tags.First() + ","));

            
            #line default
            #line hidden
WriteLiteral("\";\r\n            window.location = baseUrl + tag;\r\n        }\r\n    </script>\r\n");


            
            #line 68 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");


            
            #line 71 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
   Write(Html.JobsSidebar());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n");


            
            #line 74 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
         if (tags.Length == 1)
        {

            
            #line default
            #line hidden
WriteLiteral("            <h1 class=\"page-header\">Tag ");


            
            #line 76 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                   Write(tags[0]);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n");


            
            #line 77 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
        }
        else if (tags.Length > 1)
        {

            
            #line default
            #line hidden
WriteLiteral("            <h1 class=\"page-header\">Tags ");


            
            #line 80 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                    Write(string.Join(", ", tags));

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n");


            
            #line 81 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <h1 class=\"page-header\">Tags</h1>\r\n");


            
            #line 85 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        \r\n");


            
            #line 87 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
         if (tagsListStyle == TagsListStyle.Dropdown && tags.Length == 1 && relatedTags.Any())
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"col-md-12 related-tags\">\r\n                <datalist id=\"h" +
"angfireTagsList\">\r\n");


            
            #line 91 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                     foreach (var t in relatedTags)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <option value=\"");


            
            #line 93 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                  Write(t);

            
            #line default
            #line hidden
WriteLiteral("\"></option>\r\n");


            
            #line 94 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral(@"                </datalist>
                <div class=""col-md-10"">
                    <input class=""form-control"" id=""selectedTag"" list=""hangfireTagsList"" autocomplete=""off"" placeholder=""Select a related tag"" />
                </div>
                <div class=""col-md-2"">
                    <button id=""btn_go"" class=""btn"" onclick=""go(document.getElementById('selectedTag').value)"">Go</button>
                </div>
            </div>
");


            
            #line 103 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 105 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
          
            // Show a page with a list of matching jobs

            if (pager.TotalPageCount == 0)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div class=\"alert alert-info\">\r\n                    There are no " +
"jobs found for the selected tag(s).\r\n                </div>\r\n");


            
            #line 113 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
            }
            else
            {
                if (!(matchingStates is null) && matchingStates.Any())
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div class=\"js-state-list\">\r\n                        <div cla" +
"ss=\"btn-toolbar btn-toolbar-top\">\r\n");


            
            #line 120 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                             foreach (var matchingState in matchingStates)
                            {
                                var css = state == matchingState.Key ? "btn-primary" : "";

            
            #line default
            #line hidden
WriteLiteral("                                <a role=\"button\" href=\"");


            
            #line 123 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                  Write(Url.To("/tags/search/" + string.Join(",", tags) + "/" + matchingState.Key));

            
            #line default
            #line hidden
WriteLiteral("\" class=\"js-state-list-command btn btn-sm ");


            
            #line 123 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                                                                                                                                       Write(css);

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 123 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                                                                                                                                             Write(matchingState.Key);

            
            #line default
            #line hidden
WriteLiteral(" <span class=\"badge\">");


            
            #line 123 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                                                                                                                                                                                    Write(matchingState.Value);

            
            #line default
            #line hidden
WriteLiteral("</span></a>\r\n");


            
            #line 124 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </div>\r\n                    </div>\r\n");


            
            #line 127 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                }


            
            #line default
            #line hidden
WriteLiteral("                <div class=\"js-jobs-list\">\r\n                    <div class=\"btn-t" +
"oolbar btn-toolbar-top\">\r\n                        <button class=\"js-jobs-list-co" +
"mmand btn btn-sm btn-primary\"\r\n                                data-url=\"");


            
            #line 132 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                     Write(Url.To("/jobs/enqueued/requeue"));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                data-loading-text=\"");


            
            #line 133 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                              Write(Strings.Common_Enqueueing);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                disabled=\"disabled\">\r\n                        " +
"    <span class=\"glyphicon glyphicon-repeat\"></span>\r\n                          " +
"  ");


            
            #line 136 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                       Write(Strings.Common_RequeueJobs);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </button>\r\n\r\n                        ");


            
            #line 139 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                   Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral(@"
                    </div>

                    <div class=""table-responsive"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th class=""min-width"">
                                        <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                                    </th>
                                    <th class=""min-width"">");


            
            #line 149 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                     Write(Strings.Common_Id);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th>");


            
            #line 150 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                   Write(Strings.Common_Job);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th class=\"min-width\">");


            
            #line 151 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                     Write(Strings.Common_State);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th class=\"min-width\">");


            
            #line 152 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                     Write(Strings.RecurringJobsPage_Table_LastExecution);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                    <th class=\"min-width align-right\">");


            
            #line 153 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                                 Write(Strings.SucceededJobsPage_Table_TotalDuration);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                </tr>\r\n                            </thead" +
">\r\n                            <tbody>\r\n");


            
            #line 157 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                 foreach (var job in matchingJobs)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <tr class=\"js-jobs-list-row\">\r\n              " +
"                          <td>\r\n                                            <inp" +
"ut type=\"checkbox\" class=\"js-jobs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 161 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                                                                                 Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n                                        </td>\r\n                            " +
"            <td class=\"min-width\">\r\n                                            " +
"");


            
            #line 164 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                       Write(Html.JobIdLink(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        </td>\r\n\r\n");


            
            #line 167 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                         if (job.Value == null)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <td colspan=\"3\">\r\n                   " +
"                             <em>");


            
            #line 170 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                               Write(Strings.Common_JobExpired);

            
            #line default
            #line hidden
WriteLiteral("</em>\r\n                                            </td>\r\n");


            
            #line 172 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <td class=\"word-break\">\r\n            " +
"                                    ");


            
            #line 176 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                           Write(Html.JobNameLink(job.Key, job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n");



WriteLiteral("                                            <td class=\"min-width\">\r\n             " +
"                                   ");


            
            #line 179 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                           Write(job.Value.State);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n");



WriteLiteral("                                            <td class=\"min-width\">\r\n");


            
            #line 182 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                 if (job.Value.ResultAt.HasValue)
                                                {
                                                    
            
            #line default
            #line hidden
            
            #line 184 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                               Write(Html.RelativeTime(job.Value.ResultAt.Value));

            
            #line default
            #line hidden
            
            #line 184 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                                                                
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                            </td>\r\n");



WriteLiteral("                                            <td class=\"min-width align-right\">\r\n");


            
            #line 188 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                  
                                                    var fromDate = job.Value.EnqueueAt ?? job.Value.CreatedAt;
                                                

            
            #line default
            #line hidden

            
            #line 191 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                 if (fromDate.HasValue && job.Value.ResultAt.HasValue)
                                                {
                                                    
            
            #line default
            #line hidden
            
            #line 193 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                               Write(Html.Raw((job.Value.ResultAt.Value - fromDate.Value).ToString(@"hh\:mm\:ss\.fff")));

            
            #line default
            #line hidden
            
            #line 193 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                                                                                                                       
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                            </td>\r\n");


            
            #line 196 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </tr>\r\n");


            
            #line 198 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </tbody>\r\n                        </table>\r\n         " +
"           </div>\r\n                    ");


            
            #line 202 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
               Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");


            
            #line 204 "..\..\Dashboard\Pages\TagsJobsPage.cshtml"
            }
        

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");


        }
    }
}
#pragma warning restore 1591
