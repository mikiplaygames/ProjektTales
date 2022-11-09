namespace ProjektTales;

public partial class ObliczeniaMatematyczne : ContentPage
{
	public ObliczeniaMatematyczne()
	{
		InitializeComponent();
	}

    private void Calculate_Clicked(object sender, EventArgs e)
    {
		double calculatedResult;
        double _an;
		
        double.TryParse(a1.Text, out double _a1);
        double.TryParse(r.Text, out double _r);
        double.TryParse(n.Text, out double _n);

        _an = _a1 + (_n - 1) * _r;

        calculatedResult = (_a1 + _an) / 2 * _n;

        result.Text = calculatedResult.ToString();
    }

    private void Reset_Result(object sender, EventArgs e)
    {
        result.Text = "";
    }
}