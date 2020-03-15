using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW7.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HW7.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }
        public ActionResult GitInfo() {
            /**************************
             * setting up variables
             * ***********************/
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GitKey"];
            string uri = "https://api.github.com/user";
            string username = "millabilla";


            /*****************************
             * returning string to parse
             * **************************/
            string result = SendRequest(uri, apiKey, username);
            JObject returnObject = JObject.Parse(result);
            List<string> output = new List<string>();

            /*********************************
             * Obtaining user information
             * ******************************/
            string gitName = (string)returnObject["name"];
            string gitEmail = (string)returnObject["email"];
            string gitUserName = (string)returnObject["login"];
            string gitLocation = (string)returnObject["location"];
            string gitCompany = (string)returnObject["company"];
            string gitImage = (string)returnObject["avatar_url"];

            /*************************************
             * Add this information to JSON object
             * ***********************************/

            output.Add(gitName);
            output.Add(gitUserName);
            output.Add(gitEmail);
            output.Add(gitLocation);
            output.Add(gitCompany);

            var jsonObj = new {
                photo = gitImage,
                name = gitName,
                username = gitUserName,
                email = gitEmail,
                loc = gitLocation,
                comp = gitCompany
            };

            return Json(jsonObj, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GitRepos() {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GitKey"];
            string uri = "https://api.github.com/user/repos";
            string username = "millabilla";

            string result = SendRequest(uri, apiKey, username);
            JArray returnObject = JArray.Parse(result);
            var repoList = new List<object>();

            for (int i = 0; i < returnObject.Count(); i++) {
                var tempObject = new {
                    repo = (string)returnObject[i]["name"],
                    owner = (string)returnObject[i]["owner"]["login"],
                    avatar = (string)returnObject[i]["owner"]["avatar_url"],
                    editedAt = (string)returnObject[i]["updated_at"],
                    commits = (string)returnObject[i]["commits_url"]
                };

                repoList.Add(tempObject);
            }

            return Json(repoList, JsonRequestBehavior.AllowGet);

        }


        private string SendRequest(string uri, string credentials, string username) {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;
            request.Accept = "application/json";

            //implementing try/catch block at Jeff's suggestion
            string jsonString = null;
            WebResponse response = null;


            try {
                response = request.GetResponse();
            }

            catch (WebException web_e) {
                response = web_e.Response;
            }

            catch (Exception e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }

            using (response) {
                System.IO.Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
          

        }
    }

