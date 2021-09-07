using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;
using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Dom;
using System.Net.Http;
using AngleSharp.Html.Dom;

namespace Test
{
    public class IntegrationTestWeb: IClassFixture<WebApplicationFactory<Web.Startup>>
    {
        private readonly HttpClient _client;

        public IntegrationTestWeb(WebApplicationFactory<Web.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task VisitRootPage_ShouldRenderTwoMateriaCardsAndTheFirstOneHasCertainCardSubtitle()
        {
            // Arrange
            var response = await _client.GetAsync("/");
            /// Create a new context for evaluating webpages with the given config
            var context = BrowsingContext.New(Configuration.Default);

            // Act
            var pageContent = await response.Content.ReadAsStringAsync();
            var parsedDocument = context.GetService<IHtmlParser>().ParseDocument(pageContent);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(actual: parsedDocument.QuerySelectorAll(".card").Length, expected: 2);
            Assert.Contains(actualString: parsedDocument.QuerySelectorAll(".card-subtitle")[0].TextContent
                            , expectedSubstring: "Horas Semanales: 4");
        }

        [Fact]
        public async Task SubmitNewMateriaWithErrors_ShouldDisplayValidationMessages()
        {
            var getResponse = await _client.GetAsync("/Materia/Create");
            var context = BrowsingContext.New(Configuration.Default);

            var pageContent = await getResponse.Content.ReadAsStringAsync();
            var parsedDocument = context.GetService<IHtmlParser>().ParseDocument(pageContent);

            var submit = form.GetSubmission();
            HttpRequestMessage submission = new HttpRequestMessage(
                                new HttpMethod("post"),
                                new Uri(submit.Target.Path, UriKind.Relative))
            {
                Content = new StreamContent(submit.Body)
            };

            foreach (var header in submit.Headers)
            {
                submission.Headers.TryAddWithoutValidation(header.Key, header.Value);
                submission.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            var response = await _client.SendAsync(
                submission
            );

            var submitPageContent = await response.Content.ReadAsStringAsync();

            Assert.Contains(actualString: submitPageContent, expectedSubstring: "Materia_Descripcion-error");
        }
    }
}
