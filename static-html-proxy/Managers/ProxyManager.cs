using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace static_html_proxy
{

    public abstract class ProxyManagerProvider
    {
        private Dictionary<string, string> _dictionaries;
        private HttpClient _client;

        public ProxyManagerProvider()
        {
            this._dictionaries = new Dictionary<string, string>();
            this._client = new HttpClient();

            this.SetDictionary(this._dictionaries);
        }

        protected abstract void SetDictionary(Dictionary<string, string> dictionary);


        private string GetUrl(string key)
        {
            return this._dictionaries[key];
        }

        public async Task<string> GetContent(string key)
        {
            var _url = this.GetUrl(key);

            var _response = await this._client.GetAsync(_url);

            if (_response.IsSuccessStatusCode == true)
            {
                return await _response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }
    }

    public class ProxyManager : ProxyManagerProvider
    {

        protected override void SetDictionary(Dictionary<string, string> dictionary)
        {
            dictionary.Add("txstudio-style", "https://raw.githubusercontent.com/txstudio/blogspot-image/master/style.css");
            dictionary.Add("txstudio-js", "https://raw.githubusercontent.com/txstudio/blogspot-image/master/main.js");
        }

    }
}
