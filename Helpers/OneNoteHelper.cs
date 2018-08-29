using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fotooo.Views;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace Fotooo.Helpers
{
    class OneNoteHelper
    {
        internal async Task getNameAndAvatarAsync()
        {
            // Get user's photo
            Stream photoStream = await GetCurrentUserPhotoStreamAsync();
            //Stream photoStream = null;

            Settings settings = Settings.currentSettings;
            Debug.WriteLine("after new Settings()");
            settings.setLogsOutput("inside GetNotesAsync");

            if (photoStream == null)
            {
                Debug.WriteLine("NULL photoStream");
                settings.setLogsOutput("NULL");               
            }
            else
            {
                Debug.WriteLine("NOT NULL photoStream");
                settings.setLogsOutput("avatar");
            }

            try
            {

                HttpClient client = new HttpClient();
                var token = await AuthenticationHelper.GetTokenForUserAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                /*
                 HttpResponseMessage response = await client.PostAsync(new Uri("https://graph.microsoft.com/v1.0/me/microsoft.graph.SendMail"), emailBody);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("We could not get the notes: " + response.StatusCode.ToString());
                }
                */

            }

            catch (Exception e)
            {
                throw new Exception("We could not get the notes: " + e.Message);
            }
        }


        public async Task<Stream> GetCurrentUserPhotoStreamAsync()
        {
            Stream currentUserPhotoStream = null;

            try
            {
                HttpClient client = new HttpClient();
                var token = await AuthenticationHelper.GetTokenForUserAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                // Endpoint for the current user's photo
                Uri photoEndpoint = new Uri("https://graph.microsoft.com/beta/me/photo/$value");

                HttpResponseMessage response = await client.GetAsync(photoEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    currentUserPhotoStream = await response.Content.ReadAsStreamAsync();
                }
                else
                {
                    return null;
                }

            }

            catch (Exception e)
            {
                return null;

            }

            return currentUserPhotoStream;

        }


        public async Task<string> GetNotebooksAsync()
        {
            JObject jResult = null;
            string responseContent = null;

            try
            {
                HttpClient client = new HttpClient();
                var token = await AuthenticationHelper.GetTokenForUserAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                // Endpoint for the notebooks
                Uri notebooksEndpoint = new Uri("https://graph.microsoft.com/beta/me/onenote/notebooks");

                HttpResponseMessage response = await client.GetAsync(notebooksEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                    //jResult = JObject.Parse(responseContent);
                }
                else
                {
                    return responseContent;
                }

            }

            catch (Exception e)
            {
                return null;

            }

            return responseContent;

        }


        public async Task<string> GetPagesAsync()
        {
            string responseContent = null;

            try
            {
                HttpClient client = new HttpClient();
                var token = await AuthenticationHelper.GetTokenForUserAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                // Endpoint for the Pages (Notes)
                Uri pagesEndpoint = new Uri("https://graph.microsoft.com/beta/me/onenote/pages");

                HttpResponseMessage response = await client.GetAsync(pagesEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                    //jResult = JObject.Parse(responseContent);
                }
                else
                {
                    return responseContent;
                }

            }

            catch (Exception e)
            {
                return null;

            }

            return responseContent;

        }

        public async Task<string> GetNotesContentAsync(string id)
        {
            string responseContent = null;

            try
            {
                HttpClient client = new HttpClient();
                var token = await AuthenticationHelper.GetTokenForUserAsync();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                // Endpoint for the Pages (Notes)
                string endPoint;
                endPoint = "https://graph.microsoft.com/beta/users/me/onenote/pages/" + id + "/content?preAuthenticated=true";
                //endPoint = "https://onenote.com/api/v1/users/me/onenote/pages/" + id + "/content?preAuthenticated=true";
                Uri pagesEndpoint = new Uri(endPoint);

                HttpResponseMessage response = await client.GetAsync(pagesEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                    //jResult = JObject.Parse(responseContent);
                }
                else
                {
                    return responseContent;
                }

            }

            catch (Exception e)
            {
                return null;

            }

            return responseContent;

        }

    }
}
