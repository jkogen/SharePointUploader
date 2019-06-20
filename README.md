# SharePointUploader
Uploads files on SharePoint (Client-sided, CSOM)

Use it like below

string username = "jkogen";
string password = "mypass";

//Getting the bytes of your source-file
byte[] bytes = System.IO.File.ReadAllBytes("C:/YourFile2.txt");

//Upload to an sub-directory "Testo"
UploadDocument("https://mysharepointsite.com/sites/test384", "Dokumente", "Freigegebene%20Dokumente/Testo/", "YourFile4t.txt", bytes, username, password);

//Upload to another list-object "Websiteobjekte" with default-credentials
UploadDocument("https://mysharepointsite.com/sites/test384", "Websiteobjekte", "SiteAssets/", "YourFile4t.xlsx", bytes);
