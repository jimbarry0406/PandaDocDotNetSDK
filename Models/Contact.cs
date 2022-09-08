using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDocDotNetSDK.Models
{

    public class Contact
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Contact(
            [JsonProperty("email")] string? email = null,
            [JsonProperty("first_name")] string? firstName = null,
            [JsonProperty("last_name")] string? lastName = null,
            [JsonProperty("company")] string? company = null,
            [JsonProperty("job_title")] string? jobTitle = null,
            [JsonProperty("street_address")] string? streetAddress = null,
            [JsonProperty("city")] string? city = null,
            [JsonProperty("state")] string? state = null,
            [JsonProperty("postal_code")] string? postalCode = null,
            [JsonProperty("county")] string? country = null,
            [JsonProperty("phone")] string? phone = null,
            [JsonProperty("type")] string? type = null
        ) : base()
        {
            CopyFrom(
                email,
                firstName,
                lastName,
                company,
                jobTitle,
                streetAddress,
                city,
                state,
                postalCode,
                country,
                phone,
                type
            );
        }

        public Contact(Contact contact) : base()
        {
            CopyFrom(contact);
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("company")]
        public string? Company { get; set; }

        [JsonProperty("job_title")]
        public string? JobTitle { get; set; }

        [JsonProperty("title")]
        public string? Title { get { return JobTitle; } set { JobTitle = value; } } // alias for JobTitle

        [JsonProperty("street_address")]
        public string? StreetAdress { get; set; }

        [JsonProperty("address")]
        public string? Address { get { return StreetAdress; } set { StreetAdress = value; } } // alias for StreetAdress

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("postal_code")]
        public string? PostalCode { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        //
        // Read-Only Attributes
        //

        // contact_id string
        [JsonProperty("contact_id")]
        public string? ContactId { get; }

        //
        // Methods
        //

        public void CopyFrom(
            string? email = null, 
            string? firstName = null, 
            string? lastName = null, 
            string? company = null, 
            string? jobTitle = null, 
            string? streetAddress = null, 
            string? city = null, 
            string? state = null, 
            string? postalCode = null, 
            string? country = null, 
            string? phone = null, 
            string? type = null
        )
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            JobTitle = jobTitle;
            StreetAdress = streetAddress;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Type = type;
        }

        public void CopyFrom(Contact contact)
        {
            CopyFrom(
                contact.Email,
                contact.FirstName,
                contact.LastName,
                contact.Company,
                contact.JobTitle,
                contact.StreetAdress,
                contact.City,
                contact.State,
                contact.PostalCode,
                contact.Country,
                contact.Phone,
                contact.Type
            );
        }

    } // class Contact

} // namespace
