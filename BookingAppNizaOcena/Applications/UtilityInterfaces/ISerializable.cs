namespace BookingAppNizaOcena.Applications.UtilityInterfaces
{
    public interface ISerializable
    {
        void FromCSV(string[] values);
        string[] ToCSV();
    }
}
