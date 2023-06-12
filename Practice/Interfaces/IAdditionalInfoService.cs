namespace Practice.Interfaces
{
    public interface IAdditionalInfoService<TValue,TInfo>
    {
        public TInfo AppendAdditionalInfo(TValue value);
    }
}
