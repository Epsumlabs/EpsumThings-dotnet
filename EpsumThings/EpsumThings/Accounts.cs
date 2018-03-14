using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace EpsumThings
{
    /**
     *
     * @author Epsum Labs Private Limited
     * 
     * @License MIT
     */
    public class Accounts
    {
        private string UserName;
        private string SecretKey;
        private string AccessToken;
        private string AppId;
        public Accounts(string username, string secretkey, string appid)
        {
            this.UserName = username;
            this.SecretKey = secretkey;
            this.AppId = appid;
            Login();
        }
        public void Set_AccessToken(string token)
        {
            this.AccessToken = token;
        }
        public string Get_AccessToken()
        {
            return this.AccessToken;
        }
        public string Get_AppId()
        {
            return this.AppId;
        }
        public string Get_UserName()
        {
            return this.UserName;
        }
        public string Get_SecretKey()
        {
            return this.SecretKey;
        }

        /**
         * This is used to login to the system and generate access token
         *
         * 
         * @return access token of the user
         */
        public string Login()
        {
            WebClient client = new WebClient();
            client.Headers.Add("user", this.Get_UserName());
            client.Headers.Add("secret", this.Get_SecretKey());
            var jsondata = client.DownloadString("http://things.epsumlabs.com/api/world/user/login?app_id=" + Get_AppId());
            var data = JsonConvert.DeserializeObject<LoginData>(jsondata);
            Set_AccessToken(data.access_token);
            return data.access_token;
        }
    }
    public class LoginData
    {
        public string status { get; set; }
        public string message { get; set; }
        public string access_token { get; set; }
        public string abc { get; set; }
    }
}
