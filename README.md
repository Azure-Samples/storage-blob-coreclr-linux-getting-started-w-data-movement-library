---
services: storage 
platforms: dotnetcore, linux, dotnet
author: seguler
---

# Azure Storage Data Movement Library on CoreCLR for Linux

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fseguler%2Fstorage-blob-coreclr-linux-getting-started-w-data-movement-library%2Fmaster%2Fazuredeploy.json" target="_blank">
    <img src="http://azuredeploy.net/deploybutton.png"/>
</a>

Azure Storage Data Movement Library on CoreCLR targetting Linux platforms - Demonstrates how to copy
and download large directory of files to/from Azure Storage Blob service.

Note: If you don't have a Microsoft Azure subscription you can
get a FREE trial account [here](http://go.microsoft.com/fwlink/?LinkId=330212)

## Running this sample with one-click deploy

1. Click on the 'Deploy to Azure' link above, which will create a new VM with name 'StorageSampleVM-DMlib-CoreCLR' and a storage account in your azure subscription using an Azure Resource Manager template.
2. Once deployment is completed, login to the Linux VM using SSH.
3. The sample application will be located under /home/< your-user>/storage-blob-coreclr-linux-getting-started-w-data-movement-library/. Sample data will be located under /mnt/testdata
4. To run the sample app, issue the following commands:
```azurecli
cd /home/<your-user>/storage-blob-coreclr-linux-getting-started-w-data-movement-library/
dotnet run backup /mnt/testdata
dotnet run restore /mnt/restoreddata
```

## Running this sample manually

This sample can only be run using an Azure Storage Account. When the sample is run, the user will be
be prompted to enter an Azure Storage account name and a service/account SAS key that has read and write access to the blob service.

### Pre-requisite
You need to install the .NET Core 1.1 in your linux environment. Please visit https://www.microsoft.com/net/core for installation instructions. If you have a different version than .NET Core 1.1, be sure to update project.json file for the .NET Core dependency version.

### To run the sample you need to supplement two arguments in the Linux commandline
1. First argument is the option to backup or restore data. Simply provide 'backup' or 'restore' keyword
2. Local directory to be backed up or restored to. 

### Sample usage:
* Clone this repository.
```azurecli
git clone https://github.com/Azure-Samples/storage-blob-coreclr-linux-getting-started-w-data-movement-library/
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
- [Blob Storage Concepts](https://msdn.microsoft.com/library/dd179376.aspx)
- [Get Started with Blobs in .NET](https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/)
- [Azure Data Movement Library](https://www.nuget.org/packages/Microsoft.Azure.Storage.DataMovement)
- [Azure Data Movement Library Samples on Github](https://github.com/Azure/azure-storage-net-data-movement/tree/dev/samples)
