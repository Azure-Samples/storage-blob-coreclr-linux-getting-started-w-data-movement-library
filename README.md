---
services: storage 
platforms: dotnetcore, linux, dotnet
author: seguler
---

# Azure Storage Data Movement Library on CoreCLR for Linux

Azure Storage Data Movement Library on CoreCLR targetting Linux platforms - Demonstrates how to copy
and download large directory of files to/from Azure Storage Blob service.

Note: If you don't have a Microsoft Azure subscription you can
get a FREE trial account [here](http://go.microsoft.com/fwlink/?LinkId=330212)

## Running this sample

This sample can only be run using an Azure Storage Account. When the sample is run, the user will be
be prompted to enter an Azure Storage account name and a service/account SAS key that has read and write access to the blob service.

### Pre-requisite
You need to install the .NET Core 1.1 in your linux environment. Please visit https://www.microsoft.com/net/core for installation instructions. If you have a different version than .NET Core 1.1, be sure to update project.json file for the .NET Core dependency version.

### To run the sample you need to supplement two arguments in the Linux commandline
1. First argument is the option to backup or restore data. Simply provide 'backup' or 'restore' keyword
2. Local directory to be backed up or restored to. 

### Sample usage:
* Clone and create a dotnet project.
```azurecli
	git clone https://github.com/Azure-Samples/storage-blob-coreclr-linux-getting-started-w-data-movement-library/
	cd Backup2Azure
```
* Build and run the sample
```azurecli
	dotnet restore
	dotnet build
	dotnet run  <first argument: backup/restore> <second argument: /home/sampledirectory>
	dotnet run backup /home/sampledirectory
	dotnet run restore /home/sampledirectory
```

## More information
- [What is a Storage Account](http://azure.microsoft.com/en-us/documentation/articles/storage-whatis-account/)
- [Introduction to Storage](https://azure.microsoft.com/en-us/documentation/articles/storage-introduction/)
- [Blob Storage Concepts] (https://msdn.microsoft.com/library/dd179376.aspx)
- [Get Started with Blobs in .NET](https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/)
- [Azure Data Movement Library](https://www.nuget.org/packages/Microsoft.Azure.Storage.DataMovement)
- [Azure Data Movement Library Samples on Github] (https://github.com/Azure/azure-storage-net-data-movement/tree/dev/samples)
