using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMedioDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _htppClientFactory;

        public _UILayoutSocialMediaPartialComponent(IHttpClientFactory htppClientFactory)
        {
            _htppClientFactory = htppClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _htppClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7029/api/SocialMedia");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
