using sa47.team8ad.SSIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
namespace sa47.team8ad.SSIS.Utility
{
    public class utitlityApiRequest
    {
        private const string baseUrl = "http://localhost/team8ssis-api/";
        public utitlityApiRequest()
        {
            //AuthorizeApiToken(new LoginViewModel {UserName= "zap", Password="P@ssw0rd1" });
        }
        public async Task<bool> AuthorizeApiToken(LoginViewModel model)
        {
            try
            {
                string requestUrl = baseUrl + "token";
                // var tokenServiceUrl = request.Url.GetLeftPart(UriPartial.Authority) + request;
                using (var client = new HttpClient())
                {
                    var requestParams = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", model.UserName),
                        new KeyValuePair<string, string>("password", model.Password)
                    };
                    var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                    var tokenServiceResponse = client.PostAsync(requestUrl, requestParamsFormUrlEncoded).Result;
                    if (tokenServiceResponse.IsSuccessStatusCode)
                    {
                        string resultContent = tokenServiceResponse.Content.ReadAsStringAsync().Result;

                        Token token = JsonConvert.DeserializeObject<Token>(resultContent);
                        AuthenticationProperties options = new AuthenticationProperties();
                        options.AllowRefresh = true;
                        options.IsPersistent = true;
                        options.ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse(token.expires_in));
                        System.Web.HttpContext.Current.Session["sessionString"] = token.access_token;
                    }
                    return tokenServiceResponse.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string requestPost(object model,string apiurl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string resultContent = null;
                    string Token = (string)HttpContext.Current.Session["sessionString"];
                    if (!string.IsNullOrEmpty(Token))
                    {
                        client.BaseAddress = new Uri(baseUrl);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        client.DefaultRequestHeaders.Accept.Clear();

                        HttpResponseMessage response = client.PostAsync(apiurl,
                                                        new StringContent(
                                                            JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                                                        ).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            resultContent = response.Content.ReadAsStringAsync().Result;
                            return resultContent;
                        }
                        else
                        {
                            throw new HttpException(500,response.ReasonPhrase);
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string  requestGet(string param,string apiurl)
        {
            try
            {
                string Token = (string)HttpContext.Current.Session["sessionString"];
                if (!string.IsNullOrEmpty(Token))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string resultContent = null;

                        if (!string.IsNullOrEmpty(Token))
                        {
                            string fullapiurl = baseUrl + apiurl;
                            if (!string.IsNullOrEmpty(param))
                            {
                                fullapiurl += "?" + param;
                            }
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                            client.DefaultRequestHeaders.Accept.Clear();
                            HttpResponseMessage response = client.GetAsync(fullapiurl).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                resultContent = response.Content.ReadAsStringAsync().Result;
                            }
                            else
                            {
                                throw new HttpException(500, "Session has expired.");
                            }
                        }
                        return resultContent;
                    }
                }
                else
                {
                    throw new HttpException(0, "Session has expired.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}