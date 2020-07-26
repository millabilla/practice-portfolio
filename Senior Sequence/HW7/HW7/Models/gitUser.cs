using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW7.Models {
    public class gitUser {

        gitUser(JToken token) {
            gitName = token.Value<string>(/*here is where the items go that you want to grab from your string*/);
        }
        string gitName { get; set; }
        string gitUserName { get; set; }
        string gitEmail { get; set; }
        string gitLocation { get; set; }



    }
}