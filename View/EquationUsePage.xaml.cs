using ProjektTales.ViewModels;

namespace ProjektTales;

public partial class EquationUsePage : ContentPage
{
	public EquationUsePage(EquationListViewModel equationListViewModel)
	{
		InitializeComponent();
        BindingContext = equationListViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private void Calculate_Clicked(object sender, EventArgs e)
    {
        if (Sn.Text == null || Sn.Text == "")
        {
            CalculateSn();
        }
        else if (n.Text == null || n.Text == "")
        {
            CalculateN();
        }
    }

    private void CalculateN()
    {
        //double calculatedResult;

        double.TryParse(a1.Text, out double _a1);
        double.TryParse(r.Text, out double _r);
        int.TryParse(Sn.Text, out int _Sn);
    }

    private void CalculateSn()
    {
        double calculatedResult;
        double _an;

        double.TryParse(a1.Text, out double _a1);
        double.TryParse(r.Text, out double _r);
        int.TryParse(n.Text, out int _n);

        _an = _a1 + (_n - 1) * _r;

        calculatedResult = (_a1 + _an) / 2 * _n;

        result.Text = calculatedResult.ToString();
    }

    private void Reset_Result(object sender, EventArgs e)
    {
        result.Text = "";
    }
}