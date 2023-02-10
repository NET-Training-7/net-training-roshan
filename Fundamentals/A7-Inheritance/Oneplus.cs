class Oneplus : Android, IAndroid
{
    public Oneplus(string brand, int price, int storage) : base(brand, price, storage)
    {
    }

    public string GetAndroidVersion()
    {
        return "Tiramisu, 13.0";
    }

    public string GetLastSecurityPatch()
    {
        return "January";
    }
}