using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class CreatedBy : Contact
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public CreatedBy(
            [JsonProperty("email")] string? email = null,
            [JsonProperty("membership_id")] string? membershipId = null,
            [JsonProperty("avatar")] string? avatar = null
        ) : base(email: email)
        {
            CopyFrom(membershipId: membershipId, avatar: avatar, bFromConstructor: true);
        }

        public CreatedBy(CreatedBy CreatedBy) : base(CreatedBy)
        {
            CopyFrom(CreatedBy, bFromConstructor: true);
        }

        //
        // Read-Write Attributes
        //

        [JsonProperty("membership_id")]
        public string? MembershipId { get; set; }

        [JsonProperty("avatar")]
        public string? Avatar { get; set; }

        //
        // Methods
        //

        public void CopyFrom(
            string? email = null, 
            string? membershipId = null, 
            string? avatar = null, 
            bool bFromConstructor = false, 
            bool bSkipBase = false
        )
        {
            if (!bFromConstructor && !bSkipBase)
            {
                base.CopyFrom(email: email);
            }

            MembershipId = membershipId;
            Avatar = avatar;
        }

        public void CopyFrom(CreatedBy CreatedBy, bool bFromConstructor = false, bool bSkipBase = false)
        {
            if (!bFromConstructor && !bSkipBase)
            {
                base.CopyFrom(CreatedBy);
            }

            CopyFrom(email: CreatedBy.Email, membershipId: CreatedBy.MembershipId, avatar: CreatedBy.Avatar, bFromConstructor: bFromConstructor, bSkipBase: true);
        }

    } // class

} // namespace
