using Newtonsoft.Json;
using System;
using System.Security.Policy;

namespace PandaDocDotNetSDK.Models
{

    public class Receipient : Contact
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public Receipient(
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
        ) : base (
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
            )
        {
        }

        public Receipient(Receipient recipient) : base(recipient)
        {
        }

        //
        // Read-Only Attributes
        //

        // recipient_type string
        [JsonProperty("recipient_type")]
        public string? RecipientType { get; }

        // shared_link string
        [JsonProperty("shared_link")]
        public string? SharedLink { get; }

        // has_completed bool
        [JsonProperty("has_completed")]
        public bool HasCompleted { get; }

        // is_done bool
        [JsonProperty("is_done")]
        public bool IsDone { get; }

        // roles array[string]
        [JsonProperty("roles")]
        public string[]? Roles { get; }

    } // class Receipient

    public class DocumentRecipient : Receipient
    {

        //
        // Constructors
        //

        public DocumentRecipient() : base()
        {
        }

        public DocumentRecipient(
            string? email, 
            string? role, 
            string? signingOrder = null
        ) : base(email: email)
        {
            CopyFrom(role: role, signingOrder: signingOrder, bFromConstructor: true);
        }

        public DocumentRecipient(DocumentRecipient recipient) : base(recipient)
        {
            CopyFrom(recipient, bFromConstructor: true);
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("role")]
        public string? Role { get; set; }

        [JsonProperty("signing_order")]
        public string? SigningOrder { get; set; }

        //
        // Methods
        //

        public void CopyFrom(
            string? email = null, 
            string? role = null, 
            string? signingOrder = null, 
            bool bFromConstructor = false, 
            bool bSkipBase = false)
        {
            if (!bFromConstructor && !bSkipBase)
            {
                base.CopyFrom(email: email);
            }

            Role = role;
            SigningOrder = signingOrder;
        }

        public void CopyFrom(DocumentRecipient recipient, bool bFromConstructor = false, bool bSkipBase = false)
        {
            if (!bFromConstructor && !bSkipBase)
            {
                base.CopyFrom(recipient);
            }

            CopyFrom(email: recipient.Email, role: recipient.Role, signingOrder: recipient.SigningOrder, bFromConstructor: bFromConstructor, bSkipBase: true);
        }

    } // class DocumentRecipient


    /*
     * 
     * futue use ???
     * 
     
        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("date_created")]
        public DateTime DateCreated { get; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

    *
    */

} // namespace PandaDocDotNetSDK.Models
