using Film.BLL.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeKit;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.BLL.Jobs
{
    [DisallowConcurrentExecution]
    public class EmailJob : IJob
    {
        private readonly IServiceProvider _provider;
        public EmailJob(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                using (var scope = _provider.CreateScope())
                {
                    var filmService = scope.ServiceProvider.GetService<IFilmService>();
                    var titleData = await filmService.GetHighestRatedFilmAsync(1);

                    if (titleData == null)
                        return;

                    var _emailConfig = scope.ServiceProvider.GetService<EmailConfiguration>();

                    var message = new Message(new string[] { "toemail@gmail.com" }, "Test email", "This is the content from our email.");
                    var emailMessage = new MimeMessage();
                    emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
                    emailMessage.To.AddRange(message.To);
                    emailMessage.Subject = message.Subject;

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = $"<img style='width:{titleData.Posters.Posters[0].Width / 3}px; height: {titleData.Posters.Posters[0].Height / 3}px;' src='{titleData.Posters.Posters[0].Link}' alt='Poster' />"
                        + $"<h1>{titleData.Title}</h1><h2>Rating IMDb {titleData.IMDbRating}</h2>{titleData.Wikipedia.PlotShort.Html}";

                    emailMessage.Body = bodyBuilder.ToMessageBody();

                    using (var client = new SmtpClient())
                    {
                        try
                        {
                            await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                            client.AuthenticationMechanisms.Remove("XOAUTH2");
                            await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                            await client.SendAsync(emailMessage);
                        }
                        catch (Exception ex)
                        {
                            return;
                        }
                        finally
                        {
                            await client.DisconnectAsync(true);
                            client.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
