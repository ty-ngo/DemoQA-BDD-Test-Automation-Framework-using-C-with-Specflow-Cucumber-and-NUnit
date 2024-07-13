using Newtonsoft.Json;

namespace DemoQA.Services.Model.DataObject
{
    public class StudentDto
    {
        
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("subjects")]
        public List<string> Subjects { get; set; }

        [JsonProperty("hobbies")]
        public List<string> Hobbies { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("currentAddress")]
        public string CurrentAddress { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}