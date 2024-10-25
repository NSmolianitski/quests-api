namespace QuestsApi.Domain.Common;

public abstract class BaseEntity
{
    public bool IsDeleted { get; private set; } = false;
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void Delete() => IsDeleted = true;
    public void SetCreatedAt(DateTime value) => CreatedAt = value;
    public void SetUpdatedAt(DateTime value) => UpdatedAt = value;

    protected BaseEntity() {}
}