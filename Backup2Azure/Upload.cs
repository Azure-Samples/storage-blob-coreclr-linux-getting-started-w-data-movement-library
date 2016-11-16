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
    public class Upload
    {
        public async Task doCopy(DirectoryInfo source, string storageConnectionString)
        {
            try
            {
                // Connect to Azure Storage to create a container for this backup
                CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = account.CreateCloudBlobClient();

                // Unique container name with timestamp
                string container = source.Name + DateTime.Now.ToString("MMddyyyy-HHmmss");
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(container);

                await blobContainer.CreateIfNotExistsAsync();
                Console.WriteLine("Container {0} has been created.", container);

                // Get root directory reference for the container
                CloudBlobDirectory destBlob = blobContainer.GetDirectoryReference("");

                // Setup the transfer context and track the upload progress
                TransferContext context = new TransferContext();
                context.FileFailed += Program.FileFailedCallback;

                context.ProgressHandler = new Progress<TransferStatus>((progress) =>
                {
                    Console.WriteLine("{0} MB uploaded", progress.BytesTransferred / (1024 * 1024));
                });

                // Upload recursively
                UploadDirectoryOptions options = new UploadDirectoryOptions()
                {
                    Recursive = true
                };

                // Start the counter
                Stopwatch s = Stopwatch.StartNew();

                // Initiate the Upload from DMLib
                TransferStatus transferStatus = await TransferManager.UploadDirectoryAsync(source.FullName, destBlob, options, context);

                s.Stop();

                if(transferStatus.NumberOfFilesFailed > 0)
                {
                    Console.WriteLine("{0} files failed to transfer", transferStatus.NumberOfFilesFailed);
                }
                
                // Log the result
                Console.WriteLine("Upload has been completed in {0} seconds.", s.Elapsed.TotalSeconds);
            }
            catch (StorageException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}

