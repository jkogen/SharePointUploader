using Microsoft.SharePoint.Client;
using System.Security;

public class SharePointUploader
{
	/// <summary>
	/// Uploads documentStream to sharepoint
	/// </summary>
	/// <param name="siteURL">Example: 'https://mysharepointsite.com/sites/test384'</param>
	/// <param name="documentListName">Example: 'Dokumente'. Can be visible in websitesettings>website-contents.</param>
	/// <param name="documentListURL">Example for subdirectory: 'Freigegebene%20Dokumente/Testo/'. Please note the last slash.</param>
	/// <param name="documentName">Filename which will be uploaded. Can be variable</param>
	/// <param name="documentStream">Content-stream which will be uploaded</param>
	/// <param name="username">Optional: Username-Credentials</param>
	/// <param name="password">Optional: Password-Credentials</param>
	public void UploadDocument(string siteURL, string documentListName, string documentListURL, string documentName, byte[] documentStream, string username = "", string password = "")
	{
		//Context to the site
		using (ClientContext clientContext = new ClientContext(siteURL))
		{
			//Credentials
			if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
				clientContext.Credentials = createSharePointCredentials(username, password);

			//Get Document List
			List documentsList = clientContext.Web.Lists.GetByTitle(documentListName);

			var fileCreationInformation = new FileCreationInformation();
			//Assign to content byte[] i.e. documentStream

			fileCreationInformation.Content = documentStream;
			//Allow owerwrite of document

			fileCreationInformation.Overwrite = true;
			//Upload URL

			fileCreationInformation.Url = siteURL + documentListURL + documentName;
			Microsoft.SharePoint.Client.File uploadFile = documentsList.RootFolder.Files.Add(
				fileCreationInformation);

			uploadFile.ListItemAllFields.Update();
			clientContext.ExecuteQuery();
		}
	}

	/// <summary>
	/// Creates sharepoint-credentials based on username and password
	/// </summary>
	/// <param name="username"></param>
	/// <param name="password"></param>
	/// <returns></returns>
	private SharePointOnlineCredentials createSharePointCredentials(string username, string password)
	{
		SecureString securePass = new SecureString();

		foreach (char ch in password.ToCharArray())
			securePass.AppendChar(ch);

		return new SharePointOnlineCredentials(username, securePass);
	}
}