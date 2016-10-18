---
services: storage
platforms: dotnetcore
author: seguler
---

# Azure Storage Data Movement Library on CoreCLR

Azure Storage Data Movement Library on CoreCLR targetting Linux platforms - Demonstrates how to copy
and download large directory of files to/from Azure Storage Blob service.

Note: If you don't have a Microsoft Azure subscription you can
get a FREE trial account [here](http://go.microsoft.com/fwlink/?LinkId=330212)

## Running this sample

This sample can only be run using an Azure Storage Account. When the sample is run, the user will be
be prompted to enter an Azure Storage account name and a service/account SAS key that has read and write access to the blob service.

To run the sample you need to supplement two arguments in the Linux commandline
1. First argument is the option to backup or restore data. Simply provide 'backup' or 'restore' keyword
2. Local directory to be backed up or restored to. Full path is needed

Sample usage:
	dotnet run  <first argument: backup/restore> <second argument: /home/sampledirectory>
	dotnet run backup /home/sampledirectory
	dotnet run restore /home/sampledirectory

## More information
- [What is a Storage Account](http://azure.microsoft.com/en-us/documentation/articles/storage-whatis-account/)
- [Introduction to Storage](https://azure.microsoft.com/en-us/documentation/articles/storage-introduction/)
- [Blob Storage Concepts] (https://msdn.microsoft.com/library/dd179376.aspx)
- [Get Started with Blobs in .NET](https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/)
- [Azure Data Movement Library](https://www.nuget.org/packages/Microsoft.Azure.Storage.DataMovement)