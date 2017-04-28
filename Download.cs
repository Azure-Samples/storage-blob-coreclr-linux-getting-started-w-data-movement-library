//----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Linq;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.DataMovement;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Backup2Azure
{
    public class Download
    {
        public async Task doDownload(string containerName, DirectoryInfo localDir, string storageConnectionString)
        {
            try
            {
                // Connect to Azure Storage to download a container
                CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = account.CreateCloudBlobClient();

                // Get the container and root directory reference
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
                CloudBlobDirectory rootDir = blobContainer.GetDirectoryReference("");

                // Log
                Console.WriteLine("Directory to be downloaded is {0} and {1}", rootDir.Container.Name, rootDir.StorageUri);

				// Parallel Operations
				TransferManager.Configurations.ParallelOperations = 32;
				
                // Setup the transfer context and track the upoload progress
                DirectoryTransferContext context = new DirectoryTransferContext();
                context.FileFailed += Program.FileFailedCallback;
				
                context.ProgressHandler = new Progress<TransferStatus>((progress) =>
                {
                    Console.WriteLine("{0} MB downloaded", progress.BytesTransferred / (1024 * 1024));
                });

                // Download recursively
                DownloadDirectoryOptions options = new DownloadDirectoryOptions()
                {
                    Recursive = true
                };

                // Start the counter
                Stopwatch s = Stopwatch.StartNew();

                // Initiate the download from DMLib
                TransferStatus transferStatus = await TransferManager.DownloadDirectoryAsync(rootDir, localDir.ToString(), options, context);

                s.Stop();

                if (transferStatus.NumberOfFilesFailed > 0)
                {
                    Console.WriteLine("{0} files failed to transfer", transferStatus.NumberOfFilesFailed);
                }

                // Log the result
                Console.WriteLine("Download has been completed in {0} seconds", s.Elapsed.TotalSeconds);

            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                ex = (ex.InnerException != null) ? ex.InnerException.GetBaseException() : ex;
                Console.WriteLine(ex.Message);
            }

        }	
    }
}
