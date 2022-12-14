using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClientAPI.Interfaces;
using Newtonsoft.Json.Linq;

namespace ClientAPI.ServiceApi
{
    public class ApiService : IApiService
    {

        private string _url = "https://time.frakiec89.ru";

        public bool ValidateConnection()
        {
            try
            {
               string res =   GetHello(_url, "test");
                if (res == "Привет test я  апи  для  подготовки  к  олимпиаде ") 
                return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetHello(string url, string name)
        {

            if (string.IsNullOrWhiteSpace(name))
                return "пустое имя";
            return Get($"{url}/api/Auth/Hello?name={name}");
        }

        public string Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            try
            {
                WebResponse response = request.GetResponse();
                string result = "";
                using (StreamReader sr = new(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
                return result;
            }
            catch (WebException ex)
            {
                string resultEx = GetExceptionContent(ex);
                throw new Exception(resultEx);
            }
        }

        public string GetOnHider(string url, string tokken)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{_url + url}");
            request.Method = "GET";
            request.Headers.Add($"tokken:{tokken}");
            try
            {
                WebResponse response = request.GetResponse();
                string result = "";
                using (StreamReader sr = new(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
                return result;
            }
            catch (WebException ex)
            {
                string resultEx = GetExceptionContent(ex);
                throw new Exception(resultEx);
            }

        }


        public string Post(string url, string jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url+  url);
            request.Method = "POST";
           
            request.ContentType = "application/json";
            byte[] contentBytes = Encoding.UTF8.GetBytes(jsonContent);
            request.ContentLength = contentBytes.Length;
            using (Stream s = request.GetRequestStream())
            {
                s.Write(contentBytes, 0, contentBytes.Length);
            }
            string result = "";
            try
            {
                WebResponse response = request.GetResponse();
          
                using (StreamReader sr = new(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
                return result;
            }
            catch (WebException ex)
            {
                string resultEx = GetExceptionContent(ex);
                throw new Exception(resultEx);
            }

        }


        public string PostOnHider(string url, string tokken)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url + url);
            request.Method = "POST";

            request.ContentType = "application/json";
            request.Headers.Add($"tokken:{tokken}");
            using (Stream s = request.GetRequestStream())
            {
            }
            string result = "";
            WebResponse response = request.GetResponse();
            try
            {
                using (StreamReader sr = new(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = sr.ReadToEnd();
                }
                return result;
            }
            catch (WebException ex)
            {
                string resultEx = GetExceptionContent(ex);
                throw new Exception(resultEx);
            }
        }


        private static string GetExceptionContent(WebException ex)
        {
            WebResponse response = ex.Response;
            string resultEx = "";
            if (response != null)


                using (StreamReader sr = new(response.GetResponseStream(), Encoding.UTF8))
                {
                    resultEx = sr.ReadToEnd();
                }

            return resultEx;
        }

        
    }
}
