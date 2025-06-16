using UCertify.Modules.Applications.Domain.Common;

namespace UCertify.Modules.Applications.Domain.Application;

public class ApplicationDocument : Entity
{
    public string FileName { get; private set; }
    public string DocumentType { get; private set; }
    public DateTime UploadedAt { get; private set; }
    public long SizeInBytes { get; private set; }
    
    public ApplicationDocument(
        string fileName,
        string documentType,
        long sizeInBytes) : base(Guid.NewGuid())
    {
        FileName = fileName;
        DocumentType = documentType;
        SizeInBytes = sizeInBytes;
        UploadedAt = DateTime.UtcNow;
    }
    
    private ApplicationDocument() { }
}
