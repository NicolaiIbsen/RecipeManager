using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;

namespace RecipeManager.Service
{
    public class ApiAccess
    {
        private readonly Uri uri;
        

        public ApiAccess()
        {
            uri = new Uri("https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exlimit=max&explaintext&exintro&titles=");
            
        }
        public string GetSummary(string page)
        {
            
            try
            {
                WebClient wc = new WebClient();
                ApiAccess access = new ApiAccess();
                string respone = wc.DownloadString(access.uri + page);
                JObject obj = JObject.Parse(respone);
                JObject enterJson = (JObject)obj["query"]["pages"];

                JToken invtoken = enterJson.First.First["missing"];
                if( invtoken != null )
                {
                    throw new Exception("Site doesn't exist on wikipedia");
                }
                JToken valToken = enterJson.First.First["extract"];
                return valToken.ToString();
            }
            catch( Exception )
            {
                throw;
            }
        }
        

        public static (bool, string) IsValidUri(Uri uri)
        {
            Convert.ToString(uri);
            if( String.IsNullOrWhiteSpace(Convert.ToString(uri))  )
            {
                return (false, "Url'en er tom");
            }
            return (true, String.Empty);
        }
    }
}
