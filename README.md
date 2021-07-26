# ContactBook.API.Core

ContactBook.API.Core is a REST API application in Asp.Net Core Web api.
Its provides APIs for contact book application which has the following functionalities

- Add Contact
- Edit Contact
- Delete Contact
- List Contact

**Folder Structure**
  
  ![image](https://user-images.githubusercontent.com/87966614/126982147-9f71dd17-9b24-4948-b1e5-c86c47cb399d.png)


**Getting Started**

 - Clone https://github.com/searchanshuman/ContactBook.API.Core.git using git commands or using Visual Studio
 - Open the Solution in Visual Studio (Preferably in 2019)
 - Create DB and Tables in Sql Server
    create database ContactDB

    use ContactDB

    CREATE TABLE [dbo].[Contacts](
      [Id] [int] IDENTITY(1,1) NOT NULL,
      [FirstName] [nvarchar] (100) NOT NULL,
      [LastName] [nvarchar] (100) NOT NULL,
      [Email] [nvarchar] (100) NULL,
      [Phone] [nvarchar] (20) NULL,
      [Status] [bit] NOT NULL,

      CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED
      (
        [Id] Asc
      )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
 - Update ConnectionString in appSettings.json
 - Build the solution
 - Run the solution from Visual Studio
 - To host in IIS/Azure Cloud use publish options
