namespace Yandex.Alice.Sdk.Models.DialogsApi
{
    using System.IO;
    using JetBrains.Annotations;

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
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
