namespace GoogleCloudPrintApi.Models.Application
{
	public class SubmitFileLink : ISubmitFile 
	{
		public SubmitFileLink(string link)
		{
			Link = link;
		}

		public string Link { get; private set; }
	}
}