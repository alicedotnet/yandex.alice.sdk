using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsFileUploadRequest
    {
        public Stream Content { get; }
        public string FileName { get; }

        public DialogsFileUploadRequest(string fileName, byte[] content)
            : this(fileName, new MemoryStream(content))
        {
        }

        public DialogsFileUploadRequest(string fileName, Stream content)
        {
            Content = content;
            FileName = fileName;
        }
    }
}
