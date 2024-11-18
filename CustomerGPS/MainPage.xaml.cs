namespace CustomerGPS;

public partial class MainPage : ContentPage
{
    private GeolocationRequest request;
    
    public MainPage()
    {
        InitializeComponent();
        Title = "Location Application";
        request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));
    }

    private async void UpdateLocation_OnClicked(object sender, EventArgs e)
    {
        Location location = await Geolocation.Default.GetLocationAsync(request);

        lblLat.Text = $"Lat: {location.Latitude}";
        lblLon.Text = $"Lon: {location.Longitude}";

        var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
        var placemark = placemarks?.FirstOrDefault();

        lblAddress1.Text = $"{placemark.SubThoroughfare} {placemark.Thoroughfare}";
        lblAddress2.Text = $"{placemark.Locality} {placemark.AdminArea} {placemark.PostalCode}";
    }
}