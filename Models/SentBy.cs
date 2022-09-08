using Newtonsoft.Json;

namespace PandaDocDotNetSDK.Models
{

    public class SentBy : Contact
    {

        //
        // Constructors
        //

        [JsonConstructor]
        public SentBy(
            [JsonProperty("email")] string? email = null,
            [JsonProperty("membership_id")] string? membershipId = null,
            [JsonProperty("avatar")] string? avatar = null
        ) : base(email: email)
        {
            CopyFrom(membershipId: membershipId, avatar: avatar, bFromConstructor: true);
        }

        public SentBy(SentBy sentBy) : base(sentBy)
        {
            CopyFrom(sentBy, bFromConstructor: true);
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

        public void CopyFrom(string? email = null, string? membershipId = null, string? avatar = null, bool bFromConstructor = false, bool bSkipBase = false)
        {
            if (!bFromConstructor && !bSkipBase)
            {
                base.CopyFrom(email: email);
            }

            MembershipId = membershipId;
            Avatar = avatar;
        }

        public void CopyFrom(SentBy sentBy, bool bFromConstructor = false, bool bSkipBase = false)
        {
            if (!bFromConstructor && !bSkipBase)
            {
                base.CopyFrom(sentBy);
            }

            CopyFrom(email: sentBy.Email, membershipId: sentBy.MembershipId, avatar: sentBy.Avatar, bFromConstructor: bFromConstructor, bSkipBase: true);
        }

    } // class

} // namespace
