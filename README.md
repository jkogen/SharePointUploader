# SharePointUploader
Uploads files on SharePoint (Client-sided, CSOM)

Use it like below
```cs
//Initialising creds
string username = "mymail.provider.de";
string password = "123";

//Getting the bytes
byte[] bytes = System.IO.File.ReadAllBytes("C:/YourFile2.txt");

//Initialising sharepoint-uploader
SharePointUploader MySharePointUploader = new SharePointUploader();

//Upload to an sub-directory "Testo"
MySharePointUploader.UploadDocument("https://mysharepointsite.com/sites/test384", "Dokumente", "Freigegebene%20Dokumente/Testo/", "YourFile4t.txt", bytes, username, password);

//Upload to another list-object with default credentials
MySharePointUploader.UploadDocument("https://mysharepointsite.com/sites/test384", "Websiteobjekte", "SiteAssets/", "YourFile4t.xlsx", bytes);
```
