using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace EpsumThings
{
    /**
     *
     * @author Epsum Labs Private Limited
     * 
     * @Licence MIT
     */
    public class Things
    {
        private static string BaseUrl = "http://things.epsumlabs.com/api";


        /**
         * This function is used to Display EpsumThings Profile
         *
         * @param user object of the Account class
         * @return the json string of the response
         */
        public static IDictionary<string, object> UserProfile(Accounts user)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", user.Get_UserName() + ";" + user.Get_AccessToken());
            string json = client.DownloadString(BaseUrl + "/world/user/profile?app_id=" + user.Get_AppId());
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }


        /**
         * This function is used to update user profile 
         *
         * @param user object of the Account class
         * @param fields stores the fields which are to be updated
         * example:-phone,social
         * @param parameter Dictionary of the user profile to update example:-
         * {"phone": "8328857891"}
         * 
         * 
         * @return json string of the response
         */
        public static IDictionary<string, object> UpdateProfile(Accounts user, string fields, Dictionary<string, string> parameters)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(parameters);
            string data = JsonConvert.DeserializeObject(jsonString).ToString();
            Uri url = new Uri(BaseUrl + "/world/user/updateprofile?app_id=" + user.Get_AppId() + "&fields=" + fields);
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", user.Get_UserName() + ";" + user.Get_AccessToken());
            string json = client.UploadString(url, data);
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }


        /**
         * This is used to configure thing
         *
         * @param user object of the Account class
         * @param configure Dictionary of the configure user example:- {"homes":"test"}
         * 
         * @return json string of the response
         */
        public static IDictionary<string, object> configureThings(Accounts user, Dictionary<string, string> configure)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(configure);
            string data = JsonConvert.DeserializeObject(jsonString).ToString();
            Uri url = new Uri(BaseUrl + "/world/thing/config?app_id=" + user.Get_AppId());
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", user.Get_UserName() + ";" + user.Get_AccessToken());
            string json = client.UploadString(url, data);
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }


        /**
         * This is used to Update Password
         *
         * @param user object of the Account class
         * @param newpassword store the New Password
         * 
         * @return json string of the response
         */
        public static IDictionary<string, object> UpdatePassword(Accounts user, string newpassword)
        {
            Uri url = new Uri(BaseUrl + "/world/updatepassword?app_id=" + user.Get_AppId());
            WebClient client = new WebClient();
            string data = "{\"password\":\"" + newpassword + "\"}";
            client.Headers.Add("Authorization", user.Get_UserName() + ";" + user.Get_AccessToken());
            string json = client.UploadString(url, data);
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }


        /**
         * This is used to send the OTP to the user 
         *
         * @param email stores the user email
         * 
         * @return json string of the response
         */
        public static IDictionary<string, object> ForgotPasswordStep1(string email)
        {
            string data = "{\"email\":\"" + email + "\"}";
            Uri url = new Uri(BaseUrl + "/world/forgot1");
            WebClient client = new WebClient();
            string json = client.UploadString(url, data);
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }


        /**
         * This is used to set new password
         *
         * @param email stores the user email
         * @param token stores the token
         * @param newpassword stores the new password
         * 
         * @return json string of the request
         */
        public static IDictionary<string, object> ForgotPasswordStep2(string email, string token, string newpassword)
        {
            string data = "{\"email\":\"" + email + "\",\"token\":\"" + token + "\",\"newpassword\":\"" + newpassword + "\"}";
            Uri url = new Uri(BaseUrl + "/world/forgot2");
            WebClient client = new WebClient();
            string json = client.UploadString(url, data);
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }


        /**
         * This is used to get the activity log of the user
         *
         * @param user object of the Account Class
         * 
         * @return json string of the response
         */
        public static IDictionary<string, object> activity(Accounts user)
        {
            Uri url = new Uri(BaseUrl + "/world/activity?app_id=" + user.Get_AppId());
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", user.Get_UserName() + ";" + user.Get_AccessToken());
            string json = client.DownloadString(url);
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }


        /**
         * This is used to control Thing
         *
         * @param user object of the Account Class
         * @param thingid stores the thing id
         * @param control stores the HashMap of the thing configuration
         * 
         * @return json string of the response
         */
        public static IDictionary<string, object> ControlThing(Accounts user, string thingid, Dictionary<string, string> control)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(control);
            string data = JsonConvert.DeserializeObject(jsonString).ToString();
            Uri url = new Uri(BaseUrl + "/world/thing/rw/" + thingid + "?app_id=" + user.Get_AppId());
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", user.Get_UserName() + ";" + user.Get_AccessToken());
            string json = client.UploadString(url, data);
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }


        /**
         * This is used to thing Details
         *
         * @param user object of the Account Class
         * @param thingid stores the thing id
         * 
         * @return HashMap of the request
         */
        public static IDictionary<string, object> ThingDetails(Accounts user, string thingid)
        {
            Uri url = new Uri(BaseUrl + "/world/thing/rw/" + thingid + "?app_id=" + user.Get_AppId());
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", user.Get_UserName() + ";" + user.Get_AccessToken());
            string json = client.DownloadString(url);
            IDictionary<string, object> response = new JavaScriptSerializer().DeserializeObject(json) as IDictionary<string, object>;
            return response;
        }
    }
}
