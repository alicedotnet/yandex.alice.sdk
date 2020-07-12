using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    public class DialogsImageFileUploadRequest
    {
        public Stream Content { get; }
        public string FileName { get; }

        public DialogsImageFileUploadRequest(string fileName, byte[] content)
            : this(fileName, new MemoryStream(content))
        {
        }

        public DialogsImageFileUploadRequest(string fileName, Stream content)
        {
            Content = content;
            FileName = fileName;
        }
    }
}
