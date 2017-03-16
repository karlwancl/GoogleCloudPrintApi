namespace GoogleCloudPrintApi.Models.Application
{
	public class SubmitFileLink : BaseSubmitFile 
	{
		public SubmitFileLink(string link)
		{
			Link = link;
		}

		public string Link { get; private set; }
	}
}