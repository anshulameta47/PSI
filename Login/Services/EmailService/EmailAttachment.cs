
namespace Com.Sapient.Services.EmailService
{
	public class EmailAttachment
	{
		public byte[] Content { get; set; }
		public string Type { get; set; }
		public string Filename { get; set; }
		public string Disposition { get; set; }
		public string ContentId { get; set; }

		public EmailAttachment(byte[] content, string type, string filename, string disposition, string contentId)
		{
			Content = content;
			Type = type;
			Filename = filename;
			Disposition = disposition;
			ContentId = contentId;
		}
	}

}