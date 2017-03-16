using System.IO;

namespace GoogleCloudPrintApi.Models.Application 
{
	public class SubmitFileStream : ISubmitFile
	{
		public SubmitFileStream(string contentType, string fileName, Stream file)
		{
			ContentType = contentType;
			FileName = fileName;
			File = file;
		}

		public string ContentType { get; private set; }

		public string FileName { get; private set; }

		public Stream File { get; private set; }
	}
}