using AngouriMath;
using AngouriMath.Extensions;
using ProjektTales.ViewModels;
using ProjektTales.Model;

namespace ProjektTales;

public partial class EquationUsePage : ContentPage
{
    public EquationUsePage(EquationUseViewModel equationUseViewModel)
	{
		InitializeComponent();
        BindingContext = equationUseViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    
    Entity selectedExpr;
    Entity createdExpr;

    private void Calculate_Clicked(object sender, EventArgs e)
    {
        result.Text = createdExpr.ToString() + "  |  " + selectedExpr.ToString();
    }
    
    private void Input_Changed(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;
        string variable = entry.Placeholder;

        float.TryParse(entry.Text, out float value);

        result.Text = $"{variable} - nazwa zmienna,  dane zmienneh  {value}";

        createdExpr = selectedExpr.Substitute(variable, value); // sie zapomianaj zmeinne inne ustawione JESTSMY TAK BLISKO
    }

    private void Page_Loaded(object sender, EventArgs e)
    {
        ContentPage page = (ContentPage)sender;
        EquationUseViewModel useViewModel = (EquationUseViewModel)page.BindingContext;
        EquationStats es = useViewModel.EquationStats;
        selectedExpr = es.MathExpression;
    }
}