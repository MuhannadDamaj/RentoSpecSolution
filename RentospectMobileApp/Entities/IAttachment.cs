namespace RentospectMobileApp.Entities
{
    public interface IAttachment
    {
        string Description { get; set; }
        string StringData { get; set; }
        byte[] ByteData { get; set; }
        /// <summary>
        /// field name of this attachment in related object
        /// </summary>
        string RelatedField { get; set; }

    }
}
