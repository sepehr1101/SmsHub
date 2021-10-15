using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmsHub.SimpleTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
            var input= Console.ReadLine();
            Console.WriteLine(input);
            var client = new HttpClient();
            Rahyab.HttpService.IHttpService httpService = new Rahyab.HttpService.HttpService(client,null);
            //var token= await httpService.GetToken(new Core.Dtos.UsernamePassword() { Username= "qeraat@TPWW",Password= "3aQQ82Lxp12" });
            var token = @"eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyIjoie1wiVXNlcklkXCI6MTk2LFwiTmFtZVwiOlwi2KLYqCDZiCDZgdin2LbZhNin2Kgg2KfYs9iq2KfZhiDYqtmH2LHYp9mGXCIsXCJGYW1pbHlcIjpcIjEwMDAxNTIyXCIsXCJVc2VyTmFtZVwiOlwicWVyYWF0QFRQV1dcIixcIlBhc3N3b3JkXCI6XCJPUG1YbjM5QXpHUG1uY0taWHNRVk5LVTg3ZnBGY2xxZzdRQWw0NkhwRlJrPVwiLFwiUHJpb3JpdHlcIjoxLFwiSXNBZG1pblwiOmZhbHNlLFwiSXNBY3RpdmVcIjp0cnVlLFwiUGFyZW50SWRcIjowLFwiU2VuZFZpZXdRdWVyeVwiOm51bGwsXCJSZWNpZXZlVmlld1F1ZXJ5XCI6bnVsbCxcIkRlY3J5cHRQYXNzd29yZFwiOm51bGwsXCJNeVByb3BlcnR5XCI6bnVsbCxcIklzUHJlUGFpZFwiOmZhbHNlLFwiVmFsaWRhdGlvblJlc3VsdFwiOm51bGx9IiwiUHJpb3JpdHkiOiIxIiwiVXNlcm5hbWUiOiJxZXJhYXRAVFBXVyIsIklzUHJlUGFpZCI6IkZhbHNlIiwianRpIjoiZjA4ZTRkZmQtMTc2OS00MjliLWJkMGQtMTRhZGE2OGU2ZDljIiwiaWF0IjoiMDkvMTAvMjAyMSAxNjozNzo0NiIsImV4cCI6MTY0Njg0NzQ2NiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDoxNjkxMS8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjE2OTExLyJ9.DgV-1WTs5M6-ZEcWJArBPsSKIq1WGkwWLpK2I_bAAMs";
            var sendOutput = await httpService.Send(new Rahyab.Dtos.Input.SendInput()
            {
                Company = "TPWW",
                Number = "10001522",
                Username = "qeraat@TPWW",
                Password = "3aQQ82Lxp12",
                ListLikeToLikeMessage = new List<Rahyab.Dtos.Input.ListLikeToLikeMessage>()
                {
                    new Rahyab.Dtos.Input.ListLikeToLikeMessage()
                    {
                        DestNumber="09135742556",
                        Message="پیامک به جهت تست ازنسخه جدید سامانه قرائت کنتور1",
                        MessageId=string.Empty
                    },
                    new Rahyab.Dtos.Input.ListLikeToLikeMessage()
                    {
                        DestNumber="09135742556",
                        Message="پیامک به جهت تست ازنسخه جدید سامانه قرائت کنتور2",
                        MessageId=string.Empty
                    }
                    //new Rahyab.Dtos.Input.ListLikeToLikeMessage()
                    //{
                    //    DestNumber="09122458085",
                    //    Message="پیامک به جهت تست ازنسخه جدید سامانه قرائت کنتور",
                    //    MessageId=string.Empty
                    //}
                }
            }, token);
            int stop = 2;
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
