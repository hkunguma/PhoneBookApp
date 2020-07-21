using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

using PhoneBook.Domain.Interfaces;
using PhoneBook.Domain.Entities;

namespace PhoneBook.DAL.API.Client
{
    public class PhoneBookApiClient : IPhoneBookApiClient
    {
        private readonly string _baseAddress;

        public PhoneBookApiClient(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        #region //phonebook

        public async Task<List<Domain.Entities.PhoneBook>> GetPhoneBooks()
        {

            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    //string json = JsonConvert.SerializeObject(phoneBook);
                    //HttpContent data = Content(json); //new StringContent(json, Encoding.UTF8, "application/json");

                    string requestUri = $"api/PhoneBook/GetPhoneBooks"; //?id={}";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<List<Domain.Entities.PhoneBook>>(result);

                        return response;

                    }
                }
            }
            catch(HttpRequestException ex)
            {
                return new List<Domain.Entities.PhoneBook>();
            }
            catch (Exception ex)
            {
                return new List<Domain.Entities.PhoneBook>();
            }
        }
        public async Task<Domain.Entities.PhoneBook> GetPhoneBookById(int id)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string requestUri = $"api/PhoneBook/GetPhoneBookById?id={id}";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<Domain.Entities.PhoneBook>(result);

                        return response;

                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new Domain.Entities.PhoneBook();
            }
            catch (Exception ex)
            {
                return new Domain.Entities.PhoneBook();
            }
        }
        public async Task CreatePhoneBook(Domain.Entities.PhoneBook phoneBook)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string json = JsonConvert.SerializeObject(phoneBook);
                    HttpContent data = Content(json); //new StringContent(json, Encoding.UTF8, "application/json");

                    httpResponse = await client.PostAsync("/api/PhoneBook/CreatePhoneBook", data);

                   // if (httpResponse == null)
                       // return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject(result);

                        //return response;

                    }
                }
            }
            catch (HttpRequestException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
        
        #endregion //phonebook

        #region //entry

        public async Task<List<Entry>> GetEntries(int phoneBookId, string nameSearchTerm = null)
        {            
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string requestUri = $"api/PhoneBook/GetEntries?phoneBookId={phoneBookId}&nameSearchTerm={nameSearchTerm}";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<List<Entry>>(result);

                        return response;

                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new List<Entry>();
            }
            catch (Exception ex)
            {
                return new List<Entry>();
            }
        }
        public async Task<Entry> GetEntryById(int id)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string requestUri = $"api/PhoneBook/GetEntryById?id={id}";

                    httpResponse = await client.GetAsync(requestUri);

                    if (httpResponse == null)
                        return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject<Entry>(result);

                        return response;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return new Entry();
            }
            catch (Exception ex)
            {
                return new Entry();
            }
        }
        public async Task CreateEntry(Entry entry)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            try
            {
                using (HttpClient client = Client())
                {
                    string json = JsonConvert.SerializeObject(entry);
                    HttpContent data = Content(json); //new StringContent(json, Encoding.UTF8, "application/json");

                    httpResponse = await client.PostAsync("/api/PhoneBook/CreateEntry", data);

                    // if (httpResponse == null)
                    // return null;

                    using (HttpContent content = httpResponse.Content)
                    {
                        string result = await content.ReadAsStringAsync();

                        //if(((int)httpResponse.statusCode)!=200)

                        var response = JsonConvert.DeserializeObject(result);

                        //return response;

                    }
                }
            }
            catch (HttpRequestException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        #endregion //entry

        private HttpContent Content(string json)
        {
            HttpContent data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

        private HttpClient Client()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

    }
}
